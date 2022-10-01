using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class PrimeION
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] PrimeION_col;
        public ReallyData[] PrimeION_nml;
        public ReallyData[] PrimeION_gls;
        public ReallyData[] PrimeION_spc;
        public ReallyData[] PrimeION_ilm;
        public ReallyData[] PrimeION_ao;
        public ReallyData[] PrimeION_cav;
        public PrimeION()
        {
            int i = 1;

            PrimeION_col = new ReallyData[4];
            PrimeION_nml = new ReallyData[4];
            PrimeION_gls = new ReallyData[4];
            PrimeION_spc = new ReallyData[4];
            PrimeION_ilm = new ReallyData[4];
            PrimeION_ao = new ReallyData[4];
            PrimeION_cav = new ReallyData[4];
            //3为4096x4096,2为2048x2048,1为1024x1024,0为512x512
            PrimeION_col[0].name = "col";
            PrimeION_col[0].seek = 1419055104;
            PrimeION_col[0].length = 131072;
            PrimeION_col[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeION_col[i].name = "col";
                PrimeION_col[i].seek = PrimeION_col[i - 1].seek + PrimeION_col[i - 1].length;
                PrimeION_col[i].length = PrimeION_col[i - 1].length * 4;
                PrimeION_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeION_nml[0].name = "nml";
            PrimeION_nml[0].seek = 1430261760;
            PrimeION_nml[0].length = 262144;
            PrimeION_nml[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeION_nml[i].name = "nml";
                PrimeION_nml[i].seek = PrimeION_nml[i - 1].seek + PrimeION_nml[i - 1].length;
                PrimeION_nml[i].length = PrimeION_nml[i - 1].length * 4;
                PrimeION_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeION_gls[0].name = "gls";
            PrimeION_gls[0].seek = 1452544000;
            PrimeION_gls[0].length = 131072;
            PrimeION_gls[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeION_gls[i].name = "gls";
                PrimeION_gls[i].seek = PrimeION_gls[i - 1].seek + PrimeION_gls[i - 1].length;
                PrimeION_gls[i].length = PrimeION_gls[i - 1].length * 4;
                PrimeION_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeION_spc[0].name = "spc";
            PrimeION_spc[0].seek = 1463685120;
            PrimeION_spc[0].length = 131072;
            PrimeION_spc[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeION_spc[i].name = "spc";
                PrimeION_spc[i].seek = PrimeION_spc[i - 1].seek + PrimeION_spc[i - 1].length;
                PrimeION_spc[i].length = PrimeION_spc[i - 1].length * 4;
                PrimeION_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeION_ilm[0].name = "ilm";
            PrimeION_ilm[0].seek = 1474826240;
            PrimeION_ilm[0].length = 131072;
            PrimeION_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeION_ilm[i].name = "ilm";
                PrimeION_ilm[i].seek = PrimeION_ilm[i - 1].seek + PrimeION_ilm[i - 1].length;
                PrimeION_ilm[i].length = PrimeION_ilm[i - 1].length * 4;
                PrimeION_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeION_ao[0].name = "ao";
            PrimeION_ao[0].seek = 1485967360;
            PrimeION_ao[0].length = 131072;
            PrimeION_ao[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeION_ao[i].name = "ao";
                PrimeION_ao[i].seek = PrimeION_ao[i - 1].seek + PrimeION_ao[i - 1].length;
                PrimeION_ao[i].length = PrimeION_ao[i - 1].length * 4;
                PrimeION_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeION_cav[0].name = "cav";
            PrimeION_cav[0].seek = 1497108480;
            PrimeION_cav[0].length = 131072;
            PrimeION_cav[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeION_cav[i].name = "cav";
                PrimeION_cav[i].seek = PrimeION_cav[i - 1].seek + PrimeION_cav[i - 1].length;
                PrimeION_cav[i].length = PrimeION_cav[i - 1].length * 4;
                PrimeION_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}