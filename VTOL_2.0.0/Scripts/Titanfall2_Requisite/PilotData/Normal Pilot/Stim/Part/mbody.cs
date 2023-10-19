using System;

namespace Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Stim.Part
{
    class mbody
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

        public mbody(String PartName, int imagecheck)
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
            else
            {
                throw new Exception("BUG!" + "\n" + "In Texture Part.");
            }
        }

        private void colData(int ImageResolution)
        {
            int i = 1;
            ReallyData[] ReallyDatas = new ReallyData[4];
            ReallyDatas[0].seek = 1583550464;
            ReallyDatas[0].length = 65536;
            ReallyDatas[0].seeklength = 128;
            while (i <= 3)
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
            ReallyData[] ReallyDatas = new ReallyData[4];
            ReallyDatas[0].seek = 1589121024;
            ReallyDatas[0].length = 131072;
            ReallyDatas[0].seeklength = 128;
            while (i <= 3)
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
            ReallyData[] ReallyDatas = new ReallyData[4];
            ReallyDatas[0].seek = 1600262144;
            ReallyDatas[0].length = 65536;
            ReallyDatas[0].seeklength = 128;
            while (i <= 3)
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
            ReallyData[] ReallyDatas = new ReallyData[4];
            ReallyDatas[0].seek = 1605832704;
            ReallyDatas[0].length = 65536;
            ReallyDatas[0].seeklength = 128;
            while (i <= 3)
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
            ReallyData[] ReallyDatas = new ReallyData[4];
            ReallyDatas[0].seek = 1611403264;
            ReallyDatas[0].length = 65536;
            ReallyDatas[0].seeklength = 128;
            while (i <= 3)
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
            ReallyData[] ReallyDatas = new ReallyData[4];
            ReallyDatas[0].seek = 1616973824;
            ReallyDatas[0].length = 65536;
            ReallyDatas[0].seeklength = 128;
            while (i <= 3)
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
            ReallyData[] ReallyDatas = new ReallyData[4];
            ReallyDatas[0].seek = 1622544384;
            ReallyDatas[0].length = 65536;
            ReallyDatas[0].seeklength = 128;
            while (i <= 3)
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
