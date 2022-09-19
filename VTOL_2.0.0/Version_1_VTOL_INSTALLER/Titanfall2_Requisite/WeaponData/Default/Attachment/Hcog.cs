using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Attachment
{
    class Hcog
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Hcog_col;
        public ReallyData[] Hcog_nml;
        public ReallyData[] Hcog_gls;
        public ReallyData[] Hcog_spc;
        public ReallyData[] Hcog_ilm;
        public ReallyData[] Hcog_ao;
        public ReallyData[] Hcog_cav;
        public Hcog()
        {
            int i = 1;

            Hcog_col = new ReallyData[2];
            Hcog_nml = new ReallyData[2];
            Hcog_gls = new ReallyData[2];
            Hcog_spc = new ReallyData[2];
            Hcog_ilm = new ReallyData[2];
            Hcog_ao = new ReallyData[2];
            Hcog_cav = new ReallyData[2];
            //1为1024x1024,0为512x512

            Hcog_col[0].name = "col";
            Hcog_col[0].seek = 9381351424;
            Hcog_col[0].length = 131072;
            Hcog_col[0].seeklength = 128;
            while (i <= 1)
            {
                Hcog_col[i].name = "col";
                Hcog_col[i].seek = Hcog_col[i - 1].seek + Hcog_col[i - 1].length;
                Hcog_col[i].length = Hcog_col[i - 1].length * 4;
                Hcog_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Hcog_nml[0].name = "nml";
            Hcog_nml[0].seek = 9382072320;
            Hcog_nml[0].length = 262144;
            Hcog_nml[0].seeklength = 128;
            while (i <= 1)
            {
                Hcog_nml[i].name = "nml";
                Hcog_nml[i].seek = Hcog_nml[i - 1].seek + Hcog_nml[i - 1].length;
                Hcog_nml[i].length = Hcog_nml[i - 1].length * 4;
                Hcog_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Hcog_gls[0].name = "gls";
            Hcog_gls[0].seek = 9383383040;
            Hcog_gls[0].length = 131072;
            Hcog_gls[0].seeklength = 128;
            while (i <= 1)
            {
                Hcog_gls[i].name = "gls";
                Hcog_gls[i].seek = Hcog_gls[i - 1].seek + Hcog_gls[i - 1].length;
                Hcog_gls[i].length = Hcog_gls[i - 1].length * 4;
                Hcog_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Hcog_spc[0].name = "spc";
            Hcog_spc[0].seek = 9384038400;
            Hcog_spc[0].length = 131072;
            Hcog_spc[0].seeklength = 128;
            while (i <= 1)
            {
                Hcog_spc[i].name = "spc";
                Hcog_spc[i].seek = Hcog_spc[i - 1].seek + Hcog_spc[i - 1].length;
                Hcog_spc[i].length = Hcog_spc[i - 1].length * 4;
                Hcog_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Hcog_ilm[0].name = "ilm";
            Hcog_ilm[0].seek = 9384693760;
            Hcog_ilm[0].length = 131072;
            Hcog_ilm[0].seeklength = 128;
            while (i <= 1)
            {
                Hcog_ilm[i].name = "ilm";
                Hcog_ilm[i].seek = Hcog_ilm[i - 1].seek + Hcog_ilm[i - 1].length;
                Hcog_ilm[i].length = Hcog_ilm[i - 1].length * 4;
                Hcog_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Hcog_ao[0].name = "ao";
            Hcog_ao[0].seek = 9385349120;
            Hcog_ao[0].length = 131072;
            Hcog_ao[0].seeklength = 128;
            while (i <= 1)
            {
                Hcog_ao[i].name = "ao";
                Hcog_ao[i].seek = Hcog_ao[i - 1].seek + Hcog_ao[i - 1].length;
                Hcog_ao[i].length = Hcog_ao[i - 1].length * 4;
                Hcog_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Hcog_cav[0].name = "cav";
            Hcog_cav[0].seek = 9386004480;
            Hcog_cav[0].length = 131072;
            Hcog_cav[0].seeklength = 128;
            while (i <= 1)
            {
                Hcog_cav[i].name = "cav";
                Hcog_cav[i].seek = Hcog_cav[i - 1].seek + Hcog_cav[i - 1].length;
                Hcog_cav[i].length = Hcog_cav[i - 1].length * 4;
                Hcog_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
