using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class PrimeNorthstar
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] PrimeNorthstar_col;
        public ReallyData[] PrimeNorthstar_nml;
        public ReallyData[] PrimeNorthstar_gls;
        public ReallyData[] PrimeNorthstar_spc;
        public ReallyData[] PrimeNorthstar_ilm;
        public ReallyData[] PrimeNorthstar_ao;
        public ReallyData[] PrimeNorthstar_cav;
        public PrimeNorthstar()
        {
            int i = 1;

            PrimeNorthstar_col = new ReallyData[4];
            PrimeNorthstar_nml = new ReallyData[4];
            PrimeNorthstar_gls = new ReallyData[4];
            PrimeNorthstar_spc = new ReallyData[4];
            PrimeNorthstar_ilm = new ReallyData[4];
            PrimeNorthstar_ao = new ReallyData[4];
            PrimeNorthstar_cav = new ReallyData[4];
            //3为4096x4096,2为2048x2048,1为1024x1024,0为512x512
            PrimeNorthstar_col[0].name = "col";
            PrimeNorthstar_col[0].seek = 801378304;
            PrimeNorthstar_col[0].length = 131072;
            PrimeNorthstar_col[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeNorthstar_col[i].name = "col";
                PrimeNorthstar_col[i].seek = PrimeNorthstar_col[i - 1].seek + PrimeNorthstar_col[i - 1].length;
                PrimeNorthstar_col[i].length = PrimeNorthstar_col[i - 1].length * 4;
                PrimeNorthstar_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeNorthstar_nml[0].name = "nml";
            PrimeNorthstar_nml[0].seek = 812584960;
            PrimeNorthstar_nml[0].length = 262144;
            PrimeNorthstar_nml[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeNorthstar_nml[i].name = "nml";
                PrimeNorthstar_nml[i].seek = PrimeNorthstar_nml[i - 1].seek + PrimeNorthstar_nml[i - 1].length;
                PrimeNorthstar_nml[i].length = PrimeNorthstar_nml[i - 1].length * 4;
                PrimeNorthstar_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeNorthstar_gls[0].name = "gls";
            PrimeNorthstar_gls[0].seek = 834867200;
            PrimeNorthstar_gls[0].length = 131072;
            PrimeNorthstar_gls[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeNorthstar_gls[i].name = "gls";
                PrimeNorthstar_gls[i].seek = PrimeNorthstar_gls[i - 1].seek + PrimeNorthstar_gls[i - 1].length;
                PrimeNorthstar_gls[i].length = PrimeNorthstar_gls[i - 1].length * 4;
                PrimeNorthstar_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeNorthstar_spc[0].name = "spc";
            PrimeNorthstar_spc[0].seek = 846008320;
            PrimeNorthstar_spc[0].length = 131072;
            PrimeNorthstar_spc[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeNorthstar_spc[i].name = "spc";
                PrimeNorthstar_spc[i].seek = PrimeNorthstar_spc[i - 1].seek + PrimeNorthstar_spc[i - 1].length;
                PrimeNorthstar_spc[i].length = PrimeNorthstar_spc[i - 1].length * 4;
                PrimeNorthstar_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeNorthstar_ilm[0].name = "ilm";
            PrimeNorthstar_ilm[0].seek = 857149440;
            PrimeNorthstar_ilm[0].length = 131072;
            PrimeNorthstar_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeNorthstar_ilm[i].name = "ilm";
                PrimeNorthstar_ilm[i].seek = PrimeNorthstar_ilm[i - 1].seek + PrimeNorthstar_ilm[i - 1].length;
                PrimeNorthstar_ilm[i].length = PrimeNorthstar_ilm[i - 1].length * 4;
                PrimeNorthstar_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeNorthstar_ao[0].name = "ao";
            PrimeNorthstar_ao[0].seek = 868290560;
            PrimeNorthstar_ao[0].length = 131072;
            PrimeNorthstar_ao[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeNorthstar_ao[i].name = "ao";
                PrimeNorthstar_ao[i].seek = PrimeNorthstar_ao[i - 1].seek + PrimeNorthstar_ao[i - 1].length;
                PrimeNorthstar_ao[i].length = PrimeNorthstar_ao[i - 1].length * 4;
                PrimeNorthstar_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeNorthstar_cav[0].name = "cav";
            PrimeNorthstar_cav[0].seek = 879431680;
            PrimeNorthstar_cav[0].length = 131072;
            PrimeNorthstar_cav[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeNorthstar_cav[i].name = "cav";
                PrimeNorthstar_cav[i].seek = PrimeNorthstar_cav[i - 1].seek + PrimeNorthstar_cav[i - 1].length;
                PrimeNorthstar_cav[i].length = PrimeNorthstar_cav[i - 1].length * 4;
                PrimeNorthstar_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}