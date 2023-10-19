using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace VTOL.Advocate.DDS
{
    internal class Manager
    {
        /* the purpose of this class is:
		 * 1. to store the raw dds images for a texture
		 * 2. to delegate mipmap generation
		 * 3. to act as the way that other classes interact with DDS files
		 * 4. to save dds images to files
		 * 
		 */

        // holds the different images used to create the single image with mipmaps
        // the key is the number of pixels in the mip level (width * height)
        private SortedList<int, byte[]> mipmaps = new();

        public int MipMapCount { get { return mipmaps.Count; } }

        private Header lastHeader;

        public void LoadImage(BinaryReader reader)
        {
            // load the header
            Header hdr = new(reader);
            // override lastHeader if this dds is higher resolution (should make my life easier)
            if (lastHeader == null || hdr.Width * hdr.Height > lastHeader.Width * lastHeader.Height)
            {
                lastHeader = hdr;
            }

            // if the fourCC does not match up, skip this image
            if (lastHeader.FourCC != hdr.FourCC)
            {
                //Logging.Logger.Debug($"fourCC ({hdr.FourCC}) for added image does not match existing images ({lastHeader.FourCC})");
                return;
            }
            // if the DXGI format does not match up, also skip this image
            if (lastHeader.isDX10 == hdr.isDX10 && lastHeader.DXGIFormat != hdr.DXGIFormat)
            {
                //Logging.Logger.Debug($"{lastHeader.isDX10} != {hdr.isDX10} or {lastHeader.DXGIFormat} == {hdr.DXGIFormat}");
                //Logging.Logger.Debug($"DXGI format for added image ({hdr.DXGIFormat}) does not match existing images ({lastHeader.DXGIFormat})");
                return;
            }

            // read the image data into mipmaps dictionary
            for (int i = 0; i < hdr.MipMapCount || i == 0; i++)
            {
                int width = hdr.Width / (int)Math.Pow(2, i);
                int height = hdr.Height / (int)Math.Pow(2, i);
                int numPixels = width * height;
                // if we already have a mip for this resolution, dont do anything
                if (mipmaps.ContainsKey(numPixels))
                {
                    continue;
                }

                // sometimes dds files dont have this set (WHICH IS ANNOYING)
                // to "fix" this, just assume its all one mip level
                if (hdr.PitchOrLinearSize == 0)
                {
                    //Logging.Logger.Debug($"DDS file did not have pitchOrLinearSize set, assuming the DDS file has no mipmaps");
                    mipmaps[numPixels] = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
                    break;
                }
                else
                {
                    int actualSize = Math.Max(hdr.PitchOrLinearSize / (int)Math.Pow(4, i), 16);
                    mipmaps[numPixels] = reader.ReadBytes(actualSize);
                    //Logging.Logger.Debug($"Found mip level:\n Width: {width} Height: {height}");
                }
            }
        }

        public void SaveImage(BinaryWriter writer)
        {
            // edit the header to work
            lastHeader.PitchOrLinearSize = mipmaps.Values.Last().Length;
            lastHeader.MipMapCount = mipmaps.Count;
            // make sure that the mipmap flag is set if we have more than 1 mip level
            if (lastHeader.MipMapCount > 0)
            {
                lastHeader.Flags |= 0x20000;
            }

            // write the header
            lastHeader.Save(writer);
            // write the image data (bigger mips first so iterate backwards)
            for (int i = mipmaps.Count - 1; i >= 0; --i)
            {
                writer.Write(mipmaps.Values[i]);
            }
        }

        public void SaveImage_NoMipMaps(BinaryWriter writer)
        {
            // edit the header to work
            lastHeader.PitchOrLinearSize = mipmaps.Values.Last().Length;
            lastHeader.MipMapCount = 1;
            // make sure that the mipmap flag is set if we have more than 1 mip level
            if (lastHeader.MipMapCount > 0)
            {
                lastHeader.Flags |= 0x20000;
            }

            // write the header
            lastHeader.Save(writer);
            // write the image data (only the biggest mip)
            writer.Write(mipmaps.Values.Last());
        }

        public bool HasMissingMips()
        {
            // if there are 0 missing mips, return true
            return GetMissingMips().Count != 0;
        }

        public List<int> GetMissingMips()
        {
            List<int> ret = new();
            // if the highest resolution key is a square number then the image is a square, if not, assume its 2:1/1:2
            // floating point precision will eventually make this break, but that shouldnt be the case with numbers as small as 268435456 (16384^2)
            // i doubt we will get larger images than that, thats 16k resolution. If we do end up having this be a problem, i swear to god
            bool isSquare = Math.Sqrt(mipmaps.Last().Key) % 1 == 0;

            int curKey = mipmaps.Last().Key;
            // square images will have their final mipmap be 1x1, non square will get down to 1x2 and then have a 1x1 as well (for some reason)
            // we check the 1x1 for non-square images separately
            while (curKey != (isSquare ? 1 : 2))
            {
                // the total area of the next mipmap is 1/4 of the area of the current mipmap
                curKey /= 4;

                // if we dont have a mipmap entry for this key, we are missing a mip
                if (!mipmaps.ContainsKey(curKey))
                    ret.Add(curKey);
            }

            // check for non-square images having a 1x1 mip
            if (!isSquare && !mipmaps.ContainsKey(1))
                ret.Add(1);

            return ret;
        }

        public void GenerateMissingMips(string texconvPath)
        {
            // find which mips we need to generate
            List<int> missing = GetMissingMips();

            // no missing mips, just return
            if (missing.Count == 0)
                return;

            // create a temp file and make a DDS with no mipmaps there
            string temp = Guid.NewGuid().ToString() + ".dds";
            //string temp2 = $"{Converter.tempFolderPath}\\TexConv\\Before";
            //string temp3 = $"{Converter.tempFolderPath}\\TexConv\\After";
            //	Directory.CreateDirectory(temp2);
            //	Directory.CreateDirectory(temp3);
            //	BinaryWriter writer = new(new FileStream($"{temp2}\\{temp}", FileMode.Create));
            //		SaveImage_NoMipMaps(writer);
            //	writer.Close();

            // use texconv

            string format;
            if (lastHeader.isDX10)
            {
                format = Enum.GetName(typeof(DXGI_FORMAT), lastHeader.DXGIFormat).Replace("DXGI_FORMAT_", "") + " -dx10";
            }
            else
            {
                format = lastHeader.FourCC;

                // fix some format aliases that texcov does not support
                format = format switch
                {
                    "BC4U" => "BC4_UNORM",
                    "ATI2" => "BC5_UNORM",
                    _ => format
                };
            }

            // convert the dds into a dds with mipmaps using texconv
            StringBuilder sb = new();
            Process proc = new();
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.OutputDataReceived += (sender, args) => sb.AppendLine(args.Data);
            proc.ErrorDataReceived += (sender, args) => sb.AppendLine(args.Data);
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = texconvPath;
            //	proc.StartInfo.Arguments = $"-f {format} -nologo -m 0 -bc d -o {temp3} -y {temp2}\\{temp}";
            proc.Start();
            proc.WaitForExit();

            //Logging.Logger.Debug(sb.ToString());

            //	BinaryReader reader = new(new FileStream($"{temp3}\\{temp}", FileMode.Open));
            //	LoadImage(reader);
            //	reader.Close();
        }

        public void Convert()
        {
            lastHeader.Convert();
        }
    }
}
