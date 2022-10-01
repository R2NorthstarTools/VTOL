using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Pistol
{
    class Mozambique
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Mozambique_col;
        public ReallyData[] Mozambique_nml;
        public ReallyData[] Mozambique_gls;
        public ReallyData[] Mozambique_spc;
        //public ReallyData[] Mozambique_ilm;
        public ReallyData[] Mozambique_ao;
        public ReallyData[] Mozambique_cav;
        public Mozambique()
        {
            int i = 1;

            Mozambique_col = new ReallyData[3];
            Mozambique_nml = new ReallyData[3];
            Mozambique_gls = new ReallyData[3];
            Mozambique_spc = new ReallyData[3];
            Mozambique_ao = new ReallyData[3];
            Mozambique_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            Mozambique_col[0].name = "col";
            Mozambique_col[0].seek = 9858781184;
            Mozambique_col[0].length = 131072;
            Mozambique_col[0].seeklength = 128;
            while (i <= 1)
            {
                Mozambique_col[i].name = "col";
                Mozambique_col[i].seek = Mozambique_col[i - 1].seek + Mozambique_col[i - 1].length;
                Mozambique_col[i].length = Mozambique_col[i - 1].length * 4;
                Mozambique_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mozambique_nml[0].name = "nml";
            Mozambique_nml[0].seek = 9859502080;
            Mozambique_nml[0].length = 262144;
            Mozambique_nml[0].seeklength = 128;
            while (i <= 1)
            {
                Mozambique_nml[i].name = "nml";
                Mozambique_nml[i].seek = Mozambique_nml[i - 1].seek + Mozambique_nml[i - 1].length;
                Mozambique_nml[i].length = Mozambique_nml[i - 1].length * 4;
                Mozambique_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mozambique_gls[0].name = "gls";
            Mozambique_gls[0].seek = 9860812800;
            Mozambique_gls[0].length = 131072;
            Mozambique_gls[0].seeklength = 128;
            while (i <= 1)
            {
                Mozambique_gls[i].name = "gls";
                Mozambique_gls[i].seek = Mozambique_gls[i - 1].seek + Mozambique_gls[i - 1].length;
                Mozambique_gls[i].length = Mozambique_gls[i - 1].length * 4;
                Mozambique_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mozambique_spc[0].name = "spc";
            Mozambique_spc[0].seek = 9861468160;
            Mozambique_spc[0].length = 131072;
            Mozambique_spc[0].seeklength = 128;
            while (i <= 1)
            {
                Mozambique_spc[i].name = "spc";
                Mozambique_spc[i].seek = Mozambique_spc[i - 1].seek + Mozambique_spc[i - 1].length;
                Mozambique_spc[i].length = Mozambique_spc[i - 1].length * 4;
                Mozambique_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mozambique_ao[0].name = "ao";
            Mozambique_ao[0].seek = 9862123520;
            Mozambique_ao[0].length = 131072;
            Mozambique_ao[0].seeklength = 128;
            while (i <= 1)
            {
                Mozambique_ao[i].name = "ao";
                Mozambique_ao[i].seek = Mozambique_ao[i - 1].seek + Mozambique_ao[i - 1].length;
                Mozambique_ao[i].length = Mozambique_ao[i - 1].length * 4;
                Mozambique_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mozambique_cav[0].name = "cav";
            Mozambique_cav[0].seek = 9862778880;
            Mozambique_cav[0].length = 131072;
            Mozambique_cav[0].seeklength = 128;
            while (i <= 1)
            {
                Mozambique_cav[i].name = "cav";
                Mozambique_cav[i].seek = Mozambique_cav[i - 1].seek + Mozambique_cav[i - 1].length;
                Mozambique_cav[i].length = Mozambique_cav[i - 1].length * 4;
                Mozambique_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
