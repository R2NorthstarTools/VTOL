using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Titan
{
    class PredatorCannon
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] PredatorCannon_col;
        public ReallyData[] PredatorCannon_nml;
        public ReallyData[] PredatorCannon_gls;
        public ReallyData[] PredatorCannon_spc;
        public ReallyData[] PredatorCannon_ao;
        public PredatorCannon()
        {
            int i = 1;

            PredatorCannon_col = new ReallyData[3];
            PredatorCannon_nml = new ReallyData[3];
            PredatorCannon_gls = new ReallyData[3];
            PredatorCannon_spc = new ReallyData[3];
            PredatorCannon_ao = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512
            //猎杀者机炮没有ilm和cav

            PredatorCannon_col[0].name = "col";
            PredatorCannon_col[0].seek = 8985055232;
            PredatorCannon_col[0].length = 131072;
            PredatorCannon_col[0].seeklength = 128;
            while (i <= 2)
            {
                PredatorCannon_col[i].name = "col";
                PredatorCannon_col[i].seek = PredatorCannon_col[i - 1].seek + PredatorCannon_col[i - 1].length;
                PredatorCannon_col[i].length = PredatorCannon_col[i - 1].length * 4;
                PredatorCannon_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            PredatorCannon_nml[0].name = "nml";
            PredatorCannon_nml[0].seek = 8987873280;
            PredatorCannon_nml[0].length = 262144;
            PredatorCannon_nml[0].seeklength = 128;
            while (i <= 2)
            {
                PredatorCannon_nml[i].name = "nml";
                PredatorCannon_nml[i].seek = PredatorCannon_nml[i - 1].seek + PredatorCannon_nml[i - 1].length;
                PredatorCannon_nml[i].length = PredatorCannon_nml[i - 1].length * 4;
                PredatorCannon_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            PredatorCannon_gls[0].name = "gls";
            PredatorCannon_gls[0].seek = 8993378304;
            PredatorCannon_gls[0].length = 131072;
            PredatorCannon_gls[0].seeklength = 128;
            while (i <= 2)
            {
                PredatorCannon_gls[i].name = "gls";
                PredatorCannon_gls[i].seek = PredatorCannon_gls[i - 1].seek + PredatorCannon_gls[i - 1].length;
                PredatorCannon_gls[i].length = PredatorCannon_gls[i - 1].length * 4;
                PredatorCannon_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            PredatorCannon_spc[0].name = "spc";
            PredatorCannon_spc[0].seek = 8996130816;
            PredatorCannon_spc[0].length = 131072;
            PredatorCannon_spc[0].seeklength = 128;
            while (i <= 2)
            {
                PredatorCannon_spc[i].name = "spc";
                PredatorCannon_spc[i].seek = PredatorCannon_spc[i - 1].seek + PredatorCannon_spc[i - 1].length;
                PredatorCannon_spc[i].length = PredatorCannon_spc[i - 1].length * 4;
                PredatorCannon_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            PredatorCannon_ao[0].name = "ao";
            PredatorCannon_ao[0].seek = 8998883328;
            PredatorCannon_ao[0].length = 131072;
            PredatorCannon_ao[0].seeklength = 128;
            while (i <= 2)
            {
                PredatorCannon_ao[i].name = "ao";
                PredatorCannon_ao[i].seek = PredatorCannon_ao[i - 1].seek + PredatorCannon_ao[i - 1].length;
                PredatorCannon_ao[i].length = PredatorCannon_ao[i - 1].length * 4;
                PredatorCannon_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

        }
    }
}
