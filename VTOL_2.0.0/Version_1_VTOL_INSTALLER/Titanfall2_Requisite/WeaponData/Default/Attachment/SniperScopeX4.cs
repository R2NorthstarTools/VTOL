using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Attachment
{
    class SniperScopeX4
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] SniperScopeX4_col;
        public ReallyData[] SniperScopeX4_nml;
        public ReallyData[] SniperScopeX4_gls;
        public ReallyData[] SniperScopeX4_spc;
        //public ReallyData[] SniperScopeX4_ilm;
        public ReallyData[] SniperScopeX4_ao;
        public ReallyData[] SniperScopeX4_cav;
        public SniperScopeX4()
        {
            int i = 1;

            SniperScopeX4_col = new ReallyData[2];
            SniperScopeX4_nml = new ReallyData[2];
            SniperScopeX4_gls = new ReallyData[2];
            SniperScopeX4_spc = new ReallyData[2];
            SniperScopeX4_ao = new ReallyData[2];
            SniperScopeX4_cav = new ReallyData[2];
            //1为1024x1024,0为512x512

            SniperScopeX4_col[0].name = "col";
            SniperScopeX4_col[0].seek = 9456586752;
            SniperScopeX4_col[0].length = 131072;
            SniperScopeX4_col[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScopeX4_col[i].name = "col";
                SniperScopeX4_col[i].seek = SniperScopeX4_col[i - 1].seek + SniperScopeX4_col[i - 1].length;
                SniperScopeX4_col[i].length = SniperScopeX4_col[i - 1].length * 4;
                SniperScopeX4_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            SniperScopeX4_nml[0].name = "nml";
            SniperScopeX4_nml[0].seek = 9457307648;
            SniperScopeX4_nml[0].length = 262144;
            SniperScopeX4_nml[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScopeX4_nml[i].name = "nml";
                SniperScopeX4_nml[i].seek = SniperScopeX4_nml[i - 1].seek + SniperScopeX4_nml[i - 1].length;
                SniperScopeX4_nml[i].length = SniperScopeX4_nml[i - 1].length * 4;
                SniperScopeX4_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            SniperScopeX4_gls[0].name = "gls";
            SniperScopeX4_gls[0].seek = 9458618368;
            SniperScopeX4_gls[0].length = 131072;
            SniperScopeX4_gls[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScopeX4_gls[i].name = "gls";
                SniperScopeX4_gls[i].seek = SniperScopeX4_gls[i - 1].seek + SniperScopeX4_gls[i - 1].length;
                SniperScopeX4_gls[i].length = SniperScopeX4_gls[i - 1].length * 4;
                SniperScopeX4_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            SniperScopeX4_spc[0].name = "spc";
            SniperScopeX4_spc[0].seek = 9459273728;
            SniperScopeX4_spc[0].length = 131072;
            SniperScopeX4_spc[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScopeX4_spc[i].name = "spc";
                SniperScopeX4_spc[i].seek = SniperScopeX4_spc[i - 1].seek + SniperScopeX4_spc[i - 1].length;
                SniperScopeX4_spc[i].length = SniperScopeX4_spc[i - 1].length * 4;
                SniperScopeX4_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            SniperScopeX4_ao[0].name = "ao";
            SniperScopeX4_ao[0].seek = 9459929088;
            SniperScopeX4_ao[0].length = 131072;
            SniperScopeX4_ao[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScopeX4_ao[i].name = "ao";
                SniperScopeX4_ao[i].seek = SniperScopeX4_ao[i - 1].seek + SniperScopeX4_ao[i - 1].length;
                SniperScopeX4_ao[i].length = SniperScopeX4_ao[i - 1].length * 4;
                SniperScopeX4_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            SniperScopeX4_cav[0].name = "cav";
            SniperScopeX4_cav[0].seek = 9460584448;
            SniperScopeX4_cav[0].length = 131072;
            SniperScopeX4_cav[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScopeX4_cav[i].name = "cav";
                SniperScopeX4_cav[i].seek = SniperScopeX4_cav[i - 1].seek + SniperScopeX4_cav[i - 1].length;
                SniperScopeX4_cav[i].length = SniperScopeX4_cav[i - 1].length * 4;
                SniperScopeX4_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
