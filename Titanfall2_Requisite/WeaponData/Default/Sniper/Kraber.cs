using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Sniper
{
    class Kraber
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Kraber_col;
        public ReallyData[] Kraber_nml;
        public ReallyData[] Kraber_gls;
        public ReallyData[] Kraber_spc;
        public ReallyData[] Kraber_ilm;
        public ReallyData[] Kraber_ao;
        public ReallyData[] Kraber_cav;
        public Kraber()
        {
            int i = 1;

            Kraber_col = new ReallyData[3];
            Kraber_nml = new ReallyData[3];
            Kraber_gls = new ReallyData[3];
            Kraber_spc = new ReallyData[3];
            Kraber_ilm = new ReallyData[3];
            Kraber_ao = new ReallyData[3];
            Kraber_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            Kraber_col[0].name = "col";
            Kraber_col[0].seek = 9742520320;
            Kraber_col[0].length = 131072;
            Kraber_col[0].seeklength = 128;
            while (i <= 2)
            {
                Kraber_col[i].name = "col";
                Kraber_col[i].seek = Kraber_col[i - 1].seek + Kraber_col[i - 1].length;
                Kraber_col[i].length = Kraber_col[i - 1].length * 4;
                Kraber_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Kraber_nml[0].name = "nml";
            Kraber_nml[0].seek = 9745338368;
            Kraber_nml[0].length = 262144;
            Kraber_nml[0].seeklength = 128;
            while (i <= 2)
            {
                Kraber_nml[i].name = "nml";
                Kraber_nml[i].seek = Kraber_nml[i - 1].seek + Kraber_nml[i - 1].length;
                Kraber_nml[i].length = Kraber_nml[i - 1].length * 4;
                Kraber_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Kraber_gls[0].name = "gls";
            Kraber_gls[0].seek = 9750843392;
            Kraber_gls[0].length = 131072;
            Kraber_gls[0].seeklength = 128;
            while (i <= 2)
            {
                Kraber_gls[i].name = "gls";
                Kraber_gls[i].seek = Kraber_gls[i - 1].seek + Kraber_gls[i - 1].length;
                Kraber_gls[i].length = Kraber_gls[i - 1].length * 4;
                Kraber_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Kraber_spc[0].name = "spc";
            Kraber_spc[0].seek = 9753595904;
            Kraber_spc[0].length = 131072;
            Kraber_spc[0].seeklength = 128;
            while (i <= 2)
            {
                Kraber_spc[i].name = "spc";
                Kraber_spc[i].seek = Kraber_spc[i - 1].seek + Kraber_spc[i - 1].length;
                Kraber_spc[i].length = Kraber_spc[i - 1].length * 4;
                Kraber_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Kraber_ilm[0].name = "ilm";
            Kraber_ilm[0].seek = 9756348416;
            Kraber_ilm[0].length = 131072;
            Kraber_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                Kraber_ilm[i].name = "ilm";
                Kraber_ilm[i].seek = Kraber_ilm[i - 1].seek + Kraber_ilm[i - 1].length;
                Kraber_ilm[i].length = Kraber_ilm[i - 1].length * 4;
                Kraber_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Kraber_ao[0].name = "ao";
            Kraber_ao[0].seek = 9759100928;
            Kraber_ao[0].length = 131072;
            Kraber_ao[0].seeklength = 128;
            while (i <= 2)
            {
                Kraber_ao[i].name = "ao";
                Kraber_ao[i].seek = Kraber_ao[i - 1].seek + Kraber_ao[i - 1].length;
                Kraber_ao[i].length = Kraber_ao[i - 1].length * 4;
                Kraber_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Kraber_cav[0].name = "cav";
            Kraber_cav[0].seek = 9761853440;
            Kraber_cav[0].length = 131072;
            Kraber_cav[0].seeklength = 128;
            while (i <= 2)
            {
                Kraber_cav[i].name = "cav";
                Kraber_cav[i].seek = Kraber_cav[i - 1].seek + Kraber_cav[i - 1].length;
                Kraber_cav[i].length = Kraber_cav[i - 1].length * 4;
                Kraber_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
