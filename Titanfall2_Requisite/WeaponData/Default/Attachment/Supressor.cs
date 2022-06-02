using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Attachment
{
    class Supressor
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Supressor_col;
        public ReallyData[] Supressor_nml;
        public ReallyData[] Supressor_gls;
        public ReallyData[] Supressor_spc;
        //public ReallyData[] Supressor_ilm;
        public ReallyData[] Supressor_ao;
        //public ReallyData[] Supressor_cav;
        public Supressor()
        {
            int i = 1;

            Supressor_col = new ReallyData[2];
            Supressor_nml = new ReallyData[2];
            Supressor_gls = new ReallyData[2];
            Supressor_spc = new ReallyData[2];
            Supressor_ao = new ReallyData[2];
            //Supressor_cav = new ReallyData[2];
            //1为1024x1024,0为512x512

            Supressor_col[0].name = "col";
            Supressor_col[0].seek = 8800768000;
            Supressor_col[0].length = 131072;
            Supressor_col[0].seeklength = 128;
            while (i <= 1)
            {
                Supressor_col[i].name = "col";
                Supressor_col[i].seek = Supressor_col[i - 1].seek + Supressor_col[i - 1].length;
                Supressor_col[i].length = Supressor_col[i - 1].length * 4;
                Supressor_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Supressor_nml[0].name = "nml";
            Supressor_nml[0].seek = 8801488896;
            Supressor_nml[0].length = 262144;
            Supressor_nml[0].seeklength = 128;
            while (i <= 1)
            {
                Supressor_nml[i].name = "nml";
                Supressor_nml[i].seek = Supressor_nml[i - 1].seek + Supressor_nml[i - 1].length;
                Supressor_nml[i].length = Supressor_nml[i - 1].length * 4;
                Supressor_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Supressor_gls[0].name = "gls";
            Supressor_gls[0].seek = 8802799616;
            Supressor_gls[0].length = 131072;
            Supressor_gls[0].seeklength = 128;
            while (i <= 1)
            {
                Supressor_gls[i].name = "gls";
                Supressor_gls[i].seek = Supressor_gls[i - 1].seek + Supressor_gls[i - 1].length;
                Supressor_gls[i].length = Supressor_gls[i - 1].length * 4;
                Supressor_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Supressor_spc[0].name = "spc";
            Supressor_spc[0].seek = 8803454976;
            Supressor_spc[0].length = 131072;
            Supressor_spc[0].seeklength = 128;
            while (i <= 1)
            {
                Supressor_spc[i].name = "spc";
                Supressor_spc[i].seek = Supressor_spc[i - 1].seek + Supressor_spc[i - 1].length;
                Supressor_spc[i].length = Supressor_spc[i - 1].length * 4;
                Supressor_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Supressor_ao[0].name = "ao";
            Supressor_ao[0].seek = 8804110336;
            Supressor_ao[0].length = 131072;
            Supressor_ao[0].seeklength = 128;
            while (i <= 1)
            {
                Supressor_ao[i].name = "ao";
                Supressor_ao[i].seek = Supressor_ao[i - 1].seek + Supressor_ao[i - 1].length;
                Supressor_ao[i].length = Supressor_ao[i - 1].length * 4;
                Supressor_ao[i].seeklength = 128;
                i++;
            }
            i = 1;
/*
            Supressor_cav[0].name = "cav";
            Supressor_cav[0].seek = 8789102592;
            Supressor_cav[0].length = 131072;
            Supressor_cav[0].seeklength = 128;
            while (i <= 1)
            {
                Supressor_cav[i].name = "cav";
                Supressor_cav[i].seek = Supressor_cav[i - 1].seek + Supressor_cav[i - 1].length;
                Supressor_cav[i].length = Supressor_cav[i - 1].length * 4;
                Supressor_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
        }
    }
}
