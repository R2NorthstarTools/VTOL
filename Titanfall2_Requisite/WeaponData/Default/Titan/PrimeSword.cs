using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Titan
{
    class PrimeSword
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] PrimeSword_col;
        public ReallyData[] PrimeSword_nml;
        public ReallyData[] PrimeSword_gls;
        public ReallyData[] PrimeSword_spc;
        public PrimeSword()
        {
            int i = 1;

            PrimeSword_col = new ReallyData[3];
            PrimeSword_nml = new ReallyData[3];
            PrimeSword_gls = new ReallyData[3];
            PrimeSword_spc = new ReallyData[3];
            //2为2048x1024,1为1024x512,0为512x256
            //浪人大剑没有ilm,col和spc是BC7U

            PrimeSword_col[0].name = "col";
            PrimeSword_col[0].seek = 610144256;
            PrimeSword_col[0].length = 65536;
            PrimeSword_col[0].seeklength = 128;
            while (i <= 2)
            {
                PrimeSword_col[i].name = "col";
                PrimeSword_col[i].seek = PrimeSword_col[i - 1].seek + PrimeSword_col[i - 1].length;
                PrimeSword_col[i].length = PrimeSword_col[i - 1].length * 4;
                PrimeSword_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeSword_nml[0].name = "nml";
            PrimeSword_nml[0].seek = 611520512;
            PrimeSword_nml[0].length = 131072;
            PrimeSword_nml[0].seeklength = 128;
            while (i <= 2)
            {
                PrimeSword_nml[i].name = "nml";
                PrimeSword_nml[i].seek = PrimeSword_nml[i - 1].seek + PrimeSword_nml[i - 1].length;
                PrimeSword_nml[i].length = PrimeSword_nml[i - 1].length * 4;
                PrimeSword_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeSword_gls[0].name = "gls";
            PrimeSword_gls[0].seek = 614273024;
            PrimeSword_gls[0].length = 65536;
            PrimeSword_gls[0].seeklength = 128;
            while (i <= 2)
            {
                PrimeSword_gls[i].name = "gls";
                PrimeSword_gls[i].seek = PrimeSword_gls[i - 1].seek + PrimeSword_gls[i - 1].length;
                PrimeSword_gls[i].length = PrimeSword_gls[i - 1].length * 4;
                PrimeSword_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeSword_spc[0].name = "spc";
            PrimeSword_spc[0].seek = 615649280;
            PrimeSword_spc[0].length = 65536;
            PrimeSword_spc[0].seeklength = 128;
            while (i <= 2)
            {
                PrimeSword_spc[i].name = "spc";
                PrimeSword_spc[i].seek = PrimeSword_spc[i - 1].seek + PrimeSword_spc[i - 1].length;
                PrimeSword_spc[i].length = PrimeSword_spc[i - 1].length * 4;
                PrimeSword_spc[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
