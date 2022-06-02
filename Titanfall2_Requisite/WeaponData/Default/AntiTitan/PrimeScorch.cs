using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class PrimeScorch
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] PrimeScorch_col;
        public ReallyData[] PrimeScorch_nml;
        public ReallyData[] PrimeScorch_gls;
        public ReallyData[] PrimeScorch_spc;
        public ReallyData[] PrimeScorch_ilm;
        public ReallyData[] PrimeScorch_ao;
        public ReallyData[] PrimeScorch_cav;
        public PrimeScorch()
        {
            int i = 1;

            PrimeScorch_col = new ReallyData[4];
            PrimeScorch_nml = new ReallyData[4];
            PrimeScorch_gls = new ReallyData[4];
            PrimeScorch_spc = new ReallyData[4];
            PrimeScorch_ilm = new ReallyData[4];
            PrimeScorch_ao = new ReallyData[4];
            PrimeScorch_cav = new ReallyData[4];
            //3为4096x4096,2为2048x2048,1为1024x1024,0为512x512
            PrimeScorch_col[0].name = "col";
            PrimeScorch_col[0].seek = 602476544;
            PrimeScorch_col[0].length = 131072;
            PrimeScorch_col[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeScorch_col[i].name = "col";
                PrimeScorch_col[i].seek = PrimeScorch_col[i - 1].seek + PrimeScorch_col[i - 1].length;
                PrimeScorch_col[i].length = PrimeScorch_col[i - 1].length * 4;
                PrimeScorch_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeScorch_nml[0].name = "nml";
            PrimeScorch_nml[0].seek = 613683200;
            PrimeScorch_nml[0].length = 262144;
            PrimeScorch_nml[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeScorch_nml[i].name = "nml";
                PrimeScorch_nml[i].seek = PrimeScorch_nml[i - 1].seek + PrimeScorch_nml[i - 1].length;
                PrimeScorch_nml[i].length = PrimeScorch_nml[i - 1].length * 4;
                PrimeScorch_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeScorch_gls[0].name = "gls";
            PrimeScorch_gls[0].seek = 635965440;
            PrimeScorch_gls[0].length = 131072;
            PrimeScorch_gls[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeScorch_gls[i].name = "gls";
                PrimeScorch_gls[i].seek = PrimeScorch_gls[i - 1].seek + PrimeScorch_gls[i - 1].length;
                PrimeScorch_gls[i].length = PrimeScorch_gls[i - 1].length * 4;
                PrimeScorch_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeScorch_spc[0].name = "spc";
            PrimeScorch_spc[0].seek = 647106560;
            PrimeScorch_spc[0].length = 131072;
            PrimeScorch_spc[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeScorch_spc[i].name = "spc";
                PrimeScorch_spc[i].seek = PrimeScorch_spc[i - 1].seek + PrimeScorch_spc[i - 1].length;
                PrimeScorch_spc[i].length = PrimeScorch_spc[i - 1].length * 4;
                PrimeScorch_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeScorch_ilm[0].name = "ilm";
            PrimeScorch_ilm[0].seek = 658247680;
            PrimeScorch_ilm[0].length = 131072;
            PrimeScorch_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeScorch_ilm[i].name = "ilm";
                PrimeScorch_ilm[i].seek = PrimeScorch_ilm[i - 1].seek + PrimeScorch_ilm[i - 1].length;
                PrimeScorch_ilm[i].length = PrimeScorch_ilm[i - 1].length * 4;
                PrimeScorch_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeScorch_ao[0].name = "ao";
            PrimeScorch_ao[0].seek = 669388800;
            PrimeScorch_ao[0].length = 131072;
            PrimeScorch_ao[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeScorch_ao[i].name = "ao";
                PrimeScorch_ao[i].seek = PrimeScorch_ao[i - 1].seek + PrimeScorch_ao[i - 1].length;
                PrimeScorch_ao[i].length = PrimeScorch_ao[i - 1].length * 4;
                PrimeScorch_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeScorch_cav[0].name = "cav";
            PrimeScorch_cav[0].seek = 680529920;
            PrimeScorch_cav[0].length = 131072;
            PrimeScorch_cav[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeScorch_cav[i].name = "cav";
                PrimeScorch_cav[i].seek = PrimeScorch_cav[i - 1].seek + PrimeScorch_cav[i - 1].length;
                PrimeScorch_cav[i].length = PrimeScorch_cav[i - 1].length * 4;
                PrimeScorch_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}