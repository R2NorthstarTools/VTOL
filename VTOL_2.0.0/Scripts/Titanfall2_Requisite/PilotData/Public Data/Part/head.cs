﻿using System;

namespace Titanfall2_SkinTool.Titanfall2.PilotData.Public_Data.Part
{
    class head
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

        public head(String PartName, int imagecheck)
        {
            if (PartName.Contains("col"))
            {
                colData(imagecheck);
            }
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
            else if (PartName.Contains("ao"))
            {
                aoData(imagecheck);
            }
            else
            {
                throw new Exception("BUG!" + "\n" + "In Texture Part.");
            }
        }

        private void colData(int ImageResolution)
        {
            int i = 1;
            ReallyData[] ReallyDatas = new ReallyData[3];
            ReallyDatas[0].seek = 2279804928;
            ReallyDatas[0].length = 65536;
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

        private void nmlData(int ImageResolution)
        {
            int i = 1;
            ReallyData[] ReallyDatas = new ReallyData[3];
            ReallyDatas[0].seek = 2282557440;
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

        private void glsData(int ImageResolution)
        {
            int i = 1;
            ReallyData[] ReallyDatas = new ReallyData[3];
            ReallyDatas[0].seek = 2285309952;
            ReallyDatas[0].length = 65536;
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

        private void spcData(int ImageResolution)
        {
            int i = 1;
            ReallyData[] ReallyDatas = new ReallyData[3];
            ReallyDatas[0].seek = 2286686208;
            ReallyDatas[0].length = 65536;
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

        private void aoData(int ImageResolution)
        {
            int i = 1;
            ReallyData[] ReallyDatas = new ReallyData[3];
            ReallyDatas[0].seek = 2288062464;
            ReallyDatas[0].length = 65536;
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
    }
}
