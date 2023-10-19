using System;

namespace Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Jack.Part
{
    class gauntletr
    {
        public string Seek { get; private set; }
        public string Length { get; private set; }
        public string SeekLength { get; private set; }

        private struct ReallyData
        {
            public long seek;
            public int length;
            public int seeklength;
        }

        public gauntletr(String PartName, int imagecheck)
        {
            if (PartName.Contains("col"))
            {
                colData(imagecheck);
            }
            /*
            else if (PartName.Contains("nml"))
            {
                nmlData(imagecheck);
            }
            else if (PartName.Contains("gls"))
            {
                glsData(imagecheck);
            }
            else if (PartName.Contains("spc"))
            {
                spcData(imagecheck);
            }
            else if (PartName.Contains("ilm"))
            {
                ilmData(imagecheck);
            }
            else if (PartName.Contains("ao"))
            {
                aoData(imagecheck);
            }
            else if (PartName.Contains("cav"))
            {
                cavData(imagecheck);
            }
            */
            else
            {
                throw new Exception("BUG!" + "\n" + "In Texture Part.");
            }
        }
        //Jack Cooper col layer use BC7U Compression
        private void colData(int ImageResolution)
        {
            int i = 1;
            ReallyData[] ReallyDatas = new ReallyData[3];
            ReallyDatas[0].seek = 261099520;
            ReallyDatas[0].length = 131072;
            ReallyDatas[0].seeklength = 128;
            while (i <= 2)
            {
                ReallyDatas[i].seek = ReallyDatas[i - 1].seek + ReallyDatas[i - 1].length;
                ReallyDatas[i].length = ReallyDatas[i - 1].length * 4;
                ReallyDatas[i].seeklength = 128;
                i++;
            }
            Seek = Convert.ToString(ReallyDatas[ImageResolution].seek);
            Length = Convert.ToString(ReallyDatas[ImageResolution].length);
            SeekLength = Convert.ToString(ReallyDatas[ImageResolution].seeklength);
        }
        /*
         private void nmlData(int ImageResolution)
         {
             int i = 1;
             ReallyData[] ReallyDatas = new ReallyData[3];
             ReallyDatas[0].seek = 241831936;
             ReallyDatas[0].length = 262144;
             ReallyDatas[0].seeklength = 128;
             while (i <= 1)
             {
                 ReallyDatas[i].seek = ReallyDatas[i - 1].seek + ReallyDatas[i - 1].length;
                 ReallyDatas[i].length = ReallyDatas[i - 1].length * 4;
                 ReallyDatas[i].seeklength = 128;
                 i++;
             }
             Seek = Convert.ToString(ReallyDatas[ImageResolution].seek);
             Length = Convert.ToString(ReallyDatas[ImageResolution].length);
             SeekLength = Convert.ToString(ReallyDatas[ImageResolution].seeklength);
         }

         private void glsData(int ImageResolution)
         {
             int i = 1;
             ReallyData[] ReallyDatas = new ReallyData[3];
             ReallyDatas[0].seek = 247336960;
             ReallyDatas[0].length = 131072;
             ReallyDatas[0].seeklength = 128;
             while (i <= 1)
             {
                 ReallyDatas[i].seek = ReallyDatas[i - 1].seek + ReallyDatas[i - 1].length;
                 ReallyDatas[i].length = ReallyDatas[i - 1].length * 4;
                 ReallyDatas[i].seeklength = 128;
                 i++;
             }
             Seek = Convert.ToString(ReallyDatas[ImageResolution].seek);
             Length = Convert.ToString(ReallyDatas[ImageResolution].length);
             SeekLength = Convert.ToString(ReallyDatas[ImageResolution].seeklength);
         }

         private void spcData(int ImageResolution)
         {
             int i = 1;
             ReallyData[] ReallyDatas = new ReallyData[3];
             ReallyDatas[0].seek = 250089472;
             ReallyDatas[0].length = 131072;
             ReallyDatas[0].seeklength = 128;
             while (i <= 1)
             {
                 ReallyDatas[i].seek = ReallyDatas[i - 1].seek + ReallyDatas[i - 1].length;
                 ReallyDatas[i].length = ReallyDatas[i - 1].length * 4;
                 ReallyDatas[i].seeklength = 128;
                 i++;
             }
             Seek = Convert.ToString(ReallyDatas[ImageResolution].seek);
             Length = Convert.ToString(ReallyDatas[ImageResolution].length);
             SeekLength = Convert.ToString(ReallyDatas[ImageResolution].seeklength);
         }

         private void ilmData(int ImageResolution)
         {
             int i = 1;
             ReallyData[] ReallyDatas = new ReallyData[3];
             ReallyDatas[0].seek = 252841984;
             ReallyDatas[0].length = 131072;
             ReallyDatas[0].seeklength = 128;
             while (i <= 1)
             {
                 ReallyDatas[i].seek = ReallyDatas[i - 1].seek + ReallyDatas[i - 1].length;
                 ReallyDatas[i].length = ReallyDatas[i - 1].length * 4;
                 ReallyDatas[i].seeklength = 128;
                 i++;
             }
             Seek = Convert.ToString(ReallyDatas[ImageResolution].seek);
             Length = Convert.ToString(ReallyDatas[ImageResolution].length);
             SeekLength = Convert.ToString(ReallyDatas[ImageResolution].seeklength);
         }

         private void aoData(int ImageResolution)
         {
             int i = 1;
             ReallyData[] ReallyDatas = new ReallyData[3];
             ReallyDatas[0].seek = 255594496;
             ReallyDatas[0].length = 131072;
             ReallyDatas[0].seeklength = 128;
             while (i <= 1)
             {
                 ReallyDatas[i].seek = ReallyDatas[i - 1].seek + ReallyDatas[i - 1].length;
                 ReallyDatas[i].length = ReallyDatas[i - 1].length * 4;
                 ReallyDatas[i].seeklength = 128;
                 i++;
             }
             Seek = Convert.ToString(ReallyDatas[ImageResolution].seek);
             Length = Convert.ToString(ReallyDatas[ImageResolution].length);
             SeekLength = Convert.ToString(ReallyDatas[ImageResolution].seeklength);
         }

         private void cavData(int ImageResolution)
         {
             int i = 1;
             ReallyData[] ReallyDatas = new ReallyData[3];
             ReallyDatas[0].seek = 258347008;
             ReallyDatas[0].length = 131072;
             ReallyDatas[0].seeklength = 128;
             while (i <= 1)
             {
                 ReallyDatas[i].seek = ReallyDatas[i - 1].seek + ReallyDatas[i - 1].length;
                 ReallyDatas[i].length = ReallyDatas[i - 1].length * 4;
                 ReallyDatas[i].seeklength = 128;
                 i++;
             }
             Seek = Convert.ToString(ReallyDatas[ImageResolution].seek);
             Length = Convert.ToString(ReallyDatas[ImageResolution].length);
             SeekLength = Convert.ToString(ReallyDatas[ImageResolution].seeklength);
         }
          */
    }
}
