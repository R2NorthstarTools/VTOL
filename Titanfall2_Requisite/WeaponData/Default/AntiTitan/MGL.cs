using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class MGL
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] MGL_col;
        public ReallyData[] MGL_nml;
        public ReallyData[] MGL_gls;
        public ReallyData[] MGL_spc;
        //public ReallyData[] MGL_ilm;
        public ReallyData[] MGL_ao;
        public ReallyData[] MGL_cav;
        public MGL()
        {
            int i = 1;

            MGL_col = new ReallyData[3];
            MGL_nml = new ReallyData[3];
            MGL_gls = new ReallyData[3];
            MGL_spc = new ReallyData[3];
            MGL_ao = new ReallyData[3];
            MGL_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            MGL_col[0].name = "col";
            MGL_col[0].seek = 8956678144;
            MGL_col[0].length = 131072;
            MGL_col[0].seeklength = 128;
            while (i <= 2)
            {
                MGL_col[i].name = "col";
                MGL_col[i].seek = MGL_col[i - 1].seek + MGL_col[i - 1].length;
                MGL_col[i].length = MGL_col[i - 1].length * 4;
                MGL_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            MGL_nml[0].name = "nml";
            MGL_nml[0].seek = 8959496192;
            MGL_nml[0].length = 262144;
            MGL_nml[0].seeklength = 128;
            while (i <= 2)
            {
                MGL_nml[i].name = "nml";
                MGL_nml[i].seek = MGL_nml[i - 1].seek + MGL_nml[i - 1].length;
                MGL_nml[i].length = MGL_nml[i - 1].length * 4;
                MGL_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            MGL_gls[0].name = "gls";
            MGL_gls[0].seek = 8965001216;
            MGL_gls[0].length = 131072;
            MGL_gls[0].seeklength = 128;
            while (i <= 2)
            {
                MGL_gls[i].name = "gls";
                MGL_gls[i].seek = MGL_gls[i - 1].seek + MGL_gls[i - 1].length;
                MGL_gls[i].length = MGL_gls[i - 1].length * 4;
                MGL_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            MGL_spc[0].name = "spc";
            MGL_spc[0].seek = 8967753728;
            MGL_spc[0].length = 131072;
            MGL_spc[0].seeklength = 128;
            while (i <= 2)
            {
                MGL_spc[i].name = "spc";
                MGL_spc[i].seek = MGL_spc[i - 1].seek + MGL_spc[i - 1].length;
                MGL_spc[i].length = MGL_spc[i - 1].length * 4;
                MGL_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            MGL_ao[0].name = "ao";
            MGL_ao[0].seek = 8970506240;
            MGL_ao[0].length = 131072;
            MGL_ao[0].seeklength = 128;
            while (i <= 2)
            {
                MGL_ao[i].name = "ao";
                MGL_ao[i].seek = MGL_ao[i - 1].seek + MGL_ao[i - 1].length;
                MGL_ao[i].length = MGL_ao[i - 1].length * 4;
                MGL_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            MGL_cav[0].name = "cav";
            MGL_cav[0].seek = 8973258752;
            MGL_cav[0].length = 131072;
            MGL_cav[0].seeklength = 128;
            while (i <= 2)
            {
                MGL_cav[i].name = "cav";
                MGL_cav[i].seek = MGL_cav[i - 1].seek + MGL_cav[i - 1].length;
                MGL_cav[i].length = MGL_cav[i - 1].length * 4;
                MGL_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
