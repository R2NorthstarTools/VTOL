using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTOL.Advocate.DDS
{
	internal class Header
	{

		// public variables for getting information about the header
		public string Magic { get { return magic.ToString(); } }
		public int Size { get { return (int)size; } }

		public uint Flags { get; set; }
		public int Width { get { return (int)width; } }
		public int Height { get { return (int)height; } }
		public int PitchOrLinearSize { get { return (int)pitchOrLinearSize; } set { pitchOrLinearSize = (uint)value; } }
		public int MipMapCount { get { return (int)mipMapCount; } set { mipMapCount = (uint)value; } }

		public string FourCC { get { return new string(pixel_FourCC); } }
		public bool isDX10 { get; private set; }
		public DXGI_FORMAT DXGIFormat { get { return dxgiFormat; } }

		// dds file structure
		char[] magic = new char[4];
		// header
		uint size;
		uint flags;
		uint height;
		uint width;
		uint pitchOrLinearSize;
		uint depth;
		uint mipMapCount;
		char[] reserved = new char[44];
		// header -> pixel format
		uint pixel_Size;
		uint pixel_Flags;
		char[] pixel_FourCC = new char[4];
		uint pixel_RGBBitCount;
		uint pixel_rBitMask;
		uint pixel_gBitMask;
		uint pixel_bBitMask;
		uint pixel_aBitMask;
		// header again
		uint caps;
		uint caps2;
		uint caps3;
		uint caps4;
		uint reserved1;
		// dx10 header
		DXGI_FORMAT dxgiFormat;
		DX10ResourceDimension resourceDimension;
		uint miscFlags;
		uint arraySize;
		DX10AlphaMode alphaMode;

		public Header(BinaryReader reader)
		{
			// read magic
			magic = reader.ReadChars(4);
			if (new string(magic) != "DDS ")
			{
				throw new Exception("File is not a valid DDS file!");
			}
			// read header
			size = reader.ReadUInt32();
			flags = reader.ReadUInt32();
			height = reader.ReadUInt32();
			width = reader.ReadUInt32();
			pitchOrLinearSize = reader.ReadUInt32();
			depth = reader.ReadUInt32();
			mipMapCount = reader.ReadUInt32();
			reserved = reader.ReadChars(44);
			pixel_Size = reader.ReadUInt32();
			pixel_Flags = reader.ReadUInt32();
			pixel_FourCC = reader.ReadChars(4);
			pixel_RGBBitCount = reader.ReadUInt32();
			pixel_rBitMask = reader.ReadUInt32();
			pixel_gBitMask = reader.ReadUInt32();
			pixel_bBitMask = reader.ReadUInt32();
			pixel_aBitMask = reader.ReadUInt32();
			caps = reader.ReadUInt32();
			caps2 = reader.ReadUInt32();
			caps3 = reader.ReadUInt32();
			caps4 = reader.ReadUInt32();
			reserved1 = reader.ReadUInt32();
			// read extra header if needed
			isDX10 = new string(pixel_FourCC) == "DX10";
			if (isDX10)
			{
				//Logging.Logger.Debug("DDS file is using DX10");
				dxgiFormat = (DXGI_FORMAT)reader.ReadUInt32();
				resourceDimension = (DX10ResourceDimension)reader.ReadUInt32();
				miscFlags = reader.ReadUInt32();
				arraySize = reader.ReadUInt32();
				alphaMode = (DX10AlphaMode)reader.ReadUInt32();
			}
		}

		public void Convert()
		{
			string str_fourCC = new(pixel_FourCC);

			switch (str_fourCC)
			{
				case "DXT1":
					ToDX10(DXGI_FORMAT.DXGI_FORMAT_BC1_UNORM_SRGB);
					break;
				case "ATI2":
					//Logging.Logger.Debug($"DDS file is using ATI2, changing to BC5U");
					pixel_FourCC = new char[4] { 'B', 'C', '5', 'U' };
					goto case "BC5U";
				case "BC5U":
					if ((flags & 0x000A0000) != 0x000A0000)
						flags |= 0x000A0000;
					break;
				case "BC4U":
					//ToDX10(DXGI_FORMAT.DXGI_FORMAT_BC4_UNORM);
					if ((flags & 0x000A0000) != 0x000A0000)
						flags |= 0x000A0000;
					if ((caps & 0x00400000) != 0x00400000)
						caps |= 0x00400000;
					if ((caps & 0x00000008) != 0x00000008)
						caps |= 0x00000008;
					break;
				case "DX10":
					// some DXGI formats arent in their SRGB variants, but we need them to be
					dxgiFormat = dxgiFormat switch
					{
						DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM => DXGI_FORMAT.DXGI_FORMAT_BC7_UNORM_SRGB,
						_ => dxgiFormat
					};
					break;

				default:
					//Logging.Logger.Debug($"DDS file is using {str_fourCC}, which is unsupported.");
					throw new NotImplementedException("DDS fourCC not supported: " + str_fourCC);
			}
		}

		public void ToDX10(DXGI_FORMAT format)
		{
			dxgiFormat = format;
			arraySize = 1;
			resourceDimension = DX10ResourceDimension.Texture2D;
			alphaMode = DX10AlphaMode.Unknown;
			miscFlags = 0;
			pixel_FourCC = new char[4] { 'D', 'X', '1', '0' };
			isDX10 = true;
		}


		public void Save(BinaryWriter writer)
		{
			// write magic
			writer.Write(magic);
			// write header
			writer.Write(size);
			writer.Write(flags);
			writer.Write(height);
			writer.Write(width);
			writer.Write(pitchOrLinearSize);
			writer.Write(depth);
			writer.Write(mipMapCount);
			writer.Write(reserved);
			writer.Write(pixel_Size);
			writer.Write(pixel_Flags);
			writer.Write(pixel_FourCC);
			writer.Write(pixel_RGBBitCount);
			writer.Write(pixel_rBitMask);
			writer.Write(pixel_gBitMask);
			writer.Write(pixel_bBitMask);
			writer.Write(pixel_aBitMask);
			writer.Write(caps);
			writer.Write(caps2);
			writer.Write(caps3);
			writer.Write(caps4);
			writer.Write(reserved1);
			// write dx10 header if needed
			if (isDX10)
			{
				writer.Write((uint)dxgiFormat);
				writer.Write((uint)resourceDimension);
				writer.Write(miscFlags);
				writer.Write(arraySize);
				writer.Write((uint)alphaMode);
			}
		}
	}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public enum DXGI_FORMAT : uint
	{
		DXGI_FORMAT_UNKNOWN,
		DXGI_FORMAT_R32G32B32A32_TYPELESS,
		DXGI_FORMAT_R32G32B32A32_FLOAT,
		DXGI_FORMAT_R32G32B32A32_UINT,
		DXGI_FORMAT_R32G32B32A32_SINT,
		DXGI_FORMAT_R32G32B32_TYPELESS,
		DXGI_FORMAT_R32G32B32_FLOAT,
		DXGI_FORMAT_R32G32B32_UINT,
		DXGI_FORMAT_R32G32B32_SINT,
		DXGI_FORMAT_R16G16B16A16_TYPELESS,
		DXGI_FORMAT_R16G16B16A16_FLOAT,
		DXGI_FORMAT_R16G16B16A16_UNORM,
		DXGI_FORMAT_R16G16B16A16_UINT,
		DXGI_FORMAT_R16G16B16A16_SNORM,
		DXGI_FORMAT_R16G16B16A16_SINT,
		DXGI_FORMAT_R32G32_TYPELESS,
		DXGI_FORMAT_R32G32_FLOAT,
		DXGI_FORMAT_R32G32_UINT,
		DXGI_FORMAT_R32G32_SINT,
		DXGI_FORMAT_R32G8X24_TYPELESS,
		DXGI_FORMAT_D32_FLOAT_S8X24_UINT,
		DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS,
		DXGI_FORMAT_X32_TYPELESS_G8X24_UINT,
		DXGI_FORMAT_R10G10B10A2_TYPELESS,
		DXGI_FORMAT_R10G10B10A2_UNORM,
		DXGI_FORMAT_R10G10B10A2_UINT,
		DXGI_FORMAT_R11G11B10_FLOAT,
		DXGI_FORMAT_R8G8B8A8_TYPELESS,
		DXGI_FORMAT_R8G8B8A8_UNORM,
		DXGI_FORMAT_R8G8B8A8_UNORM_SRGB,
		DXGI_FORMAT_R8G8B8A8_UINT,
		DXGI_FORMAT_R8G8B8A8_SNORM,
		DXGI_FORMAT_R8G8B8A8_SINT,
		DXGI_FORMAT_R16G16_TYPELESS,
		DXGI_FORMAT_R16G16_FLOAT,
		DXGI_FORMAT_R16G16_UNORM,
		DXGI_FORMAT_R16G16_UINT,
		DXGI_FORMAT_R16G16_SNORM,
		DXGI_FORMAT_R16G16_SINT,
		DXGI_FORMAT_R32_TYPELESS,
		DXGI_FORMAT_D32_FLOAT,
		DXGI_FORMAT_R32_FLOAT,
		DXGI_FORMAT_R32_UINT,
		DXGI_FORMAT_R32_SINT,
		DXGI_FORMAT_R24G8_TYPELESS,
		DXGI_FORMAT_D24_UNORM_S8_UINT,
		DXGI_FORMAT_R24_UNORM_X8_TYPELESS,
		DXGI_FORMAT_X24_TYPELESS_G8_UINT,
		DXGI_FORMAT_R8G8_TYPELESS,
		DXGI_FORMAT_R8G8_UNORM,
		DXGI_FORMAT_R8G8_UINT,
		DXGI_FORMAT_R8G8_SNORM,
		DXGI_FORMAT_R8G8_SINT,
		DXGI_FORMAT_R16_TYPELESS,
		DXGI_FORMAT_R16_FLOAT,
		DXGI_FORMAT_D16_UNORM,
		DXGI_FORMAT_R16_UNORM,
		DXGI_FORMAT_R16_UINT,
		DXGI_FORMAT_R16_SNORM,
		DXGI_FORMAT_R16_SINT,
		DXGI_FORMAT_R8_TYPELESS,
		DXGI_FORMAT_R8_UNORM,
		DXGI_FORMAT_R8_UINT,
		DXGI_FORMAT_R8_SNORM,
		DXGI_FORMAT_R8_SINT,
		DXGI_FORMAT_A8_UNORM,
		DXGI_FORMAT_R1_UNORM,
		DXGI_FORMAT_R9G9B9E5_SHAREDEXP,
		DXGI_FORMAT_R8G8_B8G8_UNORM,
		DXGI_FORMAT_G8R8_G8B8_UNORM,
		DXGI_FORMAT_BC1_TYPELESS,
		DXGI_FORMAT_BC1_UNORM,
		DXGI_FORMAT_BC1_UNORM_SRGB,
		DXGI_FORMAT_BC2_TYPELESS,
		DXGI_FORMAT_BC2_UNORM,
		DXGI_FORMAT_BC2_UNORM_SRGB,
		DXGI_FORMAT_BC3_TYPELESS,
		DXGI_FORMAT_BC3_UNORM,
		DXGI_FORMAT_BC3_UNORM_SRGB,
		DXGI_FORMAT_BC4_TYPELESS,
		DXGI_FORMAT_BC4_UNORM,
		DXGI_FORMAT_BC4_SNORM,
		DXGI_FORMAT_BC5_TYPELESS,
		DXGI_FORMAT_BC5_UNORM,
		DXGI_FORMAT_BC5_SNORM,
		DXGI_FORMAT_B5G6R5_UNORM,
		DXGI_FORMAT_B5G5R5A1_UNORM,
		DXGI_FORMAT_B8G8R8A8_UNORM,
		DXGI_FORMAT_B8G8R8X8_UNORM,
		DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM,
		DXGI_FORMAT_B8G8R8A8_TYPELESS,
		DXGI_FORMAT_B8G8R8A8_UNORM_SRGB,
		DXGI_FORMAT_B8G8R8X8_TYPELESS,
		DXGI_FORMAT_B8G8R8X8_UNORM_SRGB,
		DXGI_FORMAT_BC6H_TYPELESS,
		DXGI_FORMAT_BC6H_UF16,
		DXGI_FORMAT_BC6H_SF16,
		DXGI_FORMAT_BC7_TYPELESS,
		DXGI_FORMAT_BC7_UNORM,
		DXGI_FORMAT_BC7_UNORM_SRGB,
		DXGI_FORMAT_AYUV,
		DXGI_FORMAT_Y410,
		DXGI_FORMAT_Y416,
		DXGI_FORMAT_NV12,
		DXGI_FORMAT_P010,
		DXGI_FORMAT_P016,
		DXGI_FORMAT_420_OPAQUE,
		DXGI_FORMAT_YUY2,
		DXGI_FORMAT_Y210,
		DXGI_FORMAT_Y216,
		DXGI_FORMAT_NV11,
		DXGI_FORMAT_AI44,
		DXGI_FORMAT_IA44,
		DXGI_FORMAT_P8,
		DXGI_FORMAT_A8P8,
		DXGI_FORMAT_B4G4R4A4_UNORM,
		DXGI_FORMAT_P208,
		DXGI_FORMAT_V208,
		DXGI_FORMAT_V408,
		DXGI_FORMAT_FORCE_UINT,
	};

	public enum DX10ResourceDimension : uint
	{
		Unknown = 0,
		Buffer = 1,
		Texture1D = 2,
		Texture2D = 3,
		Texture3D = 4,
	};

	public enum DX10AlphaMode : uint
	{
		Unknown = 0,
		Straight = 1,
		PreMultiplied = 2,
		Opaque = 3,
		Custom = 4,
	};
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

