using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class PrimeRonin
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] PrimeRonin_col;
        public ReallyData[] PrimeRonin_nml;
        public ReallyData[] PrimeRonin_gls;
        public ReallyData[] PrimeRonin_spc;
        public ReallyData[] PrimeRonin_ilm;
        public ReallyData[] PrimeRonin_ao;
        public ReallyData[] PrimeRonin_cav;
        public PrimeRonin()
        {
            int i = 1;

            PrimeRonin_col = new ReallyData[4];
            PrimeRonin_nml = new ReallyData[4];
            PrimeRonin_gls = new ReallyData[4];
            PrimeRonin_spc = new ReallyData[4];
            PrimeRonin_ilm = new ReallyData[4];
            PrimeRonin_ao = new ReallyData[4];
            PrimeRonin_cav = new ReallyData[4];
            //3为4096x4096,2为2048x2048,1为1024x1024,0为512x512
            PrimeRonin_col[0].name = "col";
            PrimeRonin_col[0].seek = 16584704;
            PrimeRonin_col[0].length = 131072;
            PrimeRonin_col[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeRonin_col[i].name = "col";
                PrimeRonin_col[i].seek = PrimeRonin_col[i - 1].seek + PrimeRonin_col[i - 1].length;
                PrimeRonin_col[i].length = PrimeRonin_col[i - 1].length * 4;
                PrimeRonin_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeRonin_nml[0].name = "nml";
            PrimeRonin_nml[0].seek = 1220218880;
            PrimeRonin_nml[0].length = 262144;
            PrimeRonin_nml[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeRonin_nml[i].name = "nml";
                PrimeRonin_nml[i].seek = PrimeRonin_nml[i - 1].seek + PrimeRonin_nml[i - 1].length;
                PrimeRonin_nml[i].length = PrimeRonin_nml[i - 1].length * 4;
                PrimeRonin_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeRonin_gls[0].name = "gls";
            PrimeRonin_gls[0].seek = 1242501120;
            PrimeRonin_gls[0].length = 131072;
            PrimeRonin_gls[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeRonin_gls[i].name = "gls";
                PrimeRonin_gls[i].seek = PrimeRonin_gls[i - 1].seek + PrimeRonin_gls[i - 1].length;
                PrimeRonin_gls[i].length = PrimeRonin_gls[i - 1].length * 4;
                PrimeRonin_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeRonin_spc[0].name = "spc";
            PrimeRonin_spc[0].seek = 1253642240;
            PrimeRonin_spc[0].length = 131072;
            PrimeRonin_spc[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeRonin_spc[i].name = "spc";
                PrimeRonin_spc[i].seek = PrimeRonin_spc[i - 1].seek + PrimeRonin_spc[i - 1].length;
                PrimeRonin_spc[i].length = PrimeRonin_spc[i - 1].length * 4;
                PrimeRonin_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeRonin_ilm[0].name = "ilm";
            PrimeRonin_ilm[0].seek = 213192704;
            PrimeRonin_ilm[0].length = 131072;
            PrimeRonin_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeRonin_ilm[i].name = "ilm";
                PrimeRonin_ilm[i].seek = PrimeRonin_ilm[i - 1].seek + PrimeRonin_ilm[i - 1].length;
                PrimeRonin_ilm[i].length = PrimeRonin_ilm[i - 1].length * 4;
                PrimeRonin_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeRonin_ao[0].name = "ao";
            PrimeRonin_ao[0].seek = 1275924480;
            PrimeRonin_ao[0].length = 131072;
            PrimeRonin_ao[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeRonin_ao[i].name = "ao";
                PrimeRonin_ao[i].seek = PrimeRonin_ao[i - 1].seek + PrimeRonin_ao[i - 1].length;
                PrimeRonin_ao[i].length = PrimeRonin_ao[i - 1].length * 4;
                PrimeRonin_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeRonin_cav[0].name = "cav";
            PrimeRonin_cav[0].seek = 1287065600;
            PrimeRonin_cav[0].length = 131072;
            PrimeRonin_cav[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeRonin_cav[i].name = "cav";
                PrimeRonin_cav[i].seek = PrimeRonin_cav[i - 1].seek + PrimeRonin_cav[i - 1].length;
                PrimeRonin_cav[i].length = PrimeRonin_cav[i - 1].length * 4;
                PrimeRonin_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}