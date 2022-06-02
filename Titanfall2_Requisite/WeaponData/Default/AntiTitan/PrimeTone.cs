using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class PrimeTone
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] PrimeTone_col;
        public ReallyData[] PrimeTone_nml;
        public ReallyData[] PrimeTone_gls;
        public ReallyData[] PrimeTone_spc;
        public ReallyData[] PrimeTone_ilm;
        public ReallyData[] PrimeTone_ao;
        public ReallyData[] PrimeTone_cav;
        public PrimeTone()
        {
            int i = 1;

            PrimeTone_col = new ReallyData[4];
            PrimeTone_nml = new ReallyData[4];
            PrimeTone_gls = new ReallyData[4];
            PrimeTone_spc = new ReallyData[4];
            PrimeTone_ilm = new ReallyData[4];
            PrimeTone_ao = new ReallyData[4];
            PrimeTone_cav = new ReallyData[4];
            //3为4096x4096,2为2048x2048,1为1024x1024,0为512x512
            //done
            PrimeTone_col[0].name = "col";
            PrimeTone_col[0].seek = 344788992;
            PrimeTone_col[0].length = 131072;
            PrimeTone_col[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeTone_col[i].name = "col";
                PrimeTone_col[i].seek = PrimeTone_col[i - 1].seek + PrimeTone_col[i - 1].length;
                PrimeTone_col[i].length = PrimeTone_col[i - 1].length * 4;
                PrimeTone_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeTone_nml[0].name = "nml";
            PrimeTone_nml[0].seek = 355995648;
            PrimeTone_nml[0].length = 262144;
            PrimeTone_nml[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeTone_nml[i].name = "nml";
                PrimeTone_nml[i].seek = PrimeTone_nml[i - 1].seek + PrimeTone_nml[i - 1].length;
                PrimeTone_nml[i].length = PrimeTone_nml[i - 1].length * 4;
                PrimeTone_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeTone_gls[0].name = "gls";
            PrimeTone_gls[0].seek = 378277888;
            PrimeTone_gls[0].length = 131072;
            PrimeTone_gls[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeTone_gls[i].name = "gls";
                PrimeTone_gls[i].seek = PrimeTone_gls[i - 1].seek + PrimeTone_gls[i - 1].length;
                PrimeTone_gls[i].length = PrimeTone_gls[i - 1].length * 4;
                PrimeTone_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeTone_spc[0].name = "spc";
            PrimeTone_spc[0].seek = 389419008;
            PrimeTone_spc[0].length = 131072;
            PrimeTone_spc[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeTone_spc[i].name = "spc";
                PrimeTone_spc[i].seek = PrimeTone_spc[i - 1].seek + PrimeTone_spc[i - 1].length;
                PrimeTone_spc[i].length = PrimeTone_spc[i - 1].length * 4;
                PrimeTone_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeTone_ilm[0].name = "ilm";
            PrimeTone_ilm[0].seek = 400560128;
            PrimeTone_ilm[0].length = 131072;
            PrimeTone_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeTone_ilm[i].name = "ilm";
                PrimeTone_ilm[i].seek = PrimeTone_ilm[i - 1].seek + PrimeTone_ilm[i - 1].length;
                PrimeTone_ilm[i].length = PrimeTone_ilm[i - 1].length * 4;
                PrimeTone_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeTone_ao[0].name = "ao";
            PrimeTone_ao[0].seek = 411701248;
            PrimeTone_ao[0].length = 131072;
            PrimeTone_ao[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeTone_ao[i].name = "ao";
                PrimeTone_ao[i].seek = PrimeTone_ao[i - 1].seek + PrimeTone_ao[i - 1].length;
                PrimeTone_ao[i].length = PrimeTone_ao[i - 1].length * 4;
                PrimeTone_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeTone_cav[0].name = "cav";
            PrimeTone_cav[0].seek = 422842368;
            PrimeTone_cav[0].length = 131072;
            PrimeTone_cav[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeTone_cav[i].name = "cav";
                PrimeTone_cav[i].seek = PrimeTone_cav[i - 1].seek + PrimeTone_cav[i - 1].length;
                PrimeTone_cav[i].length = PrimeTone_cav[i - 1].length * 4;
                PrimeTone_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}