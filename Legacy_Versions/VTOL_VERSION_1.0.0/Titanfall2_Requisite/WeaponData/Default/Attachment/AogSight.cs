using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Attachment
{
    class AogSight
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] AogSight_col;
        public ReallyData[] AogSight_nml;
        public ReallyData[] AogSight_gls;
        public ReallyData[] AogSight_spc;
        //public ReallyData[] AogSight_ilm;
        public ReallyData[] AogSight_ao;
        public ReallyData[] AogSight_cav;
        public AogSight()
        {
            int i = 1;

            AogSight_col = new ReallyData[2];
            AogSight_nml = new ReallyData[2];
            AogSight_gls = new ReallyData[2];
            AogSight_spc = new ReallyData[2];
            AogSight_ao = new ReallyData[2];
            AogSight_cav = new ReallyData[2];
            //1为1024x1024,0为512x512

            AogSight_col[0].name = "col";
            AogSight_col[0].seek = 8785104896;
            AogSight_col[0].length = 131072;
            AogSight_col[0].seeklength = 128;
            while (i <= 1)
            {
                AogSight_col[i].name = "col";
                AogSight_col[i].seek = AogSight_col[i - 1].seek + AogSight_col[i - 1].length;
                AogSight_col[i].length = AogSight_col[i - 1].length * 4;
                AogSight_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            AogSight_nml[0].name = "nml";
            AogSight_nml[0].seek = 8785825792;
            AogSight_nml[0].length = 262144;
            AogSight_nml[0].seeklength = 128;
            while (i <= 1)
            {
                AogSight_nml[i].name = "nml";
                AogSight_nml[i].seek = AogSight_nml[i - 1].seek + AogSight_nml[i - 1].length;
                AogSight_nml[i].length = AogSight_nml[i - 1].length * 4;
                AogSight_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            AogSight_gls[0].name = "gls";
            AogSight_gls[0].seek = 8787136512;
            AogSight_gls[0].length = 131072;
            AogSight_gls[0].seeklength = 128;
            while (i <= 1)
            {
                AogSight_gls[i].name = "gls";
                AogSight_gls[i].seek = AogSight_gls[i - 1].seek + AogSight_gls[i - 1].length;
                AogSight_gls[i].length = AogSight_gls[i - 1].length * 4;
                AogSight_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            AogSight_spc[0].name = "spc";
            AogSight_spc[0].seek = 8787791872;
            AogSight_spc[0].length = 131072;
            AogSight_spc[0].seeklength = 128;
            while (i <= 1)
            {
                AogSight_spc[i].name = "spc";
                AogSight_spc[i].seek = AogSight_spc[i - 1].seek + AogSight_spc[i - 1].length;
                AogSight_spc[i].length = AogSight_spc[i - 1].length * 4;
                AogSight_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            AogSight_ao[0].name = "ao";
            AogSight_ao[0].seek = 8788447232;
            AogSight_ao[0].length = 131072;
            AogSight_ao[0].seeklength = 128;
            while (i <= 1)
            {
                AogSight_ao[i].name = "ao";
                AogSight_ao[i].seek = AogSight_ao[i - 1].seek + AogSight_ao[i - 1].length;
                AogSight_ao[i].length = AogSight_ao[i - 1].length * 4;
                AogSight_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            AogSight_cav[0].name = "cav";
            AogSight_cav[0].seek = 8789102592;
            AogSight_cav[0].length = 131072;
            AogSight_cav[0].seeklength = 128;
            while (i <= 1)
            {
                AogSight_cav[i].name = "cav";
                AogSight_cav[i].seek = AogSight_cav[i - 1].seek + AogSight_cav[i - 1].length;
                AogSight_cav[i].length = AogSight_cav[i - 1].length * 4;
                AogSight_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
