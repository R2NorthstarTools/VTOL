using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Attachment
{
    class SniperScope
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] SniperScope_col;
        public ReallyData[] SniperScope_nml;
        public ReallyData[] SniperScope_gls;
        public ReallyData[] SniperScope_spc;
        //public ReallyData[] SniperScope_ilm;
        public ReallyData[] SniperScope_ao;
        public ReallyData[] SniperScope_cav;
        public SniperScope()
        {
            int i = 1;

            SniperScope_col = new ReallyData[2];
            SniperScope_nml = new ReallyData[2];
            SniperScope_gls = new ReallyData[2];
            SniperScope_spc = new ReallyData[2];
            SniperScope_ao = new ReallyData[2];
            SniperScope_cav = new ReallyData[2];
            //1为1024x1024,0为512x512

            SniperScope_col[0].name = "col";
            SniperScope_col[0].seek = 9376698368;
            SniperScope_col[0].length = 131072;
            SniperScope_col[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScope_col[i].name = "col";
                SniperScope_col[i].seek = SniperScope_col[i - 1].seek + SniperScope_col[i - 1].length;
                SniperScope_col[i].length = SniperScope_col[i - 1].length * 4;
                SniperScope_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            SniperScope_nml[0].name = "nml";
            SniperScope_nml[0].seek = 9377419264;
            SniperScope_nml[0].length = 262144;
            SniperScope_nml[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScope_nml[i].name = "nml";
                SniperScope_nml[i].seek = SniperScope_nml[i - 1].seek + SniperScope_nml[i - 1].length;
                SniperScope_nml[i].length = SniperScope_nml[i - 1].length * 4;
                SniperScope_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            SniperScope_gls[0].name = "gls";
            SniperScope_gls[0].seek = 9378729984;
            SniperScope_gls[0].length = 131072;
            SniperScope_gls[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScope_gls[i].name = "gls";
                SniperScope_gls[i].seek = SniperScope_gls[i - 1].seek + SniperScope_gls[i - 1].length;
                SniperScope_gls[i].length = SniperScope_gls[i - 1].length * 4;
                SniperScope_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            SniperScope_spc[0].name = "spc";
            SniperScope_spc[0].seek = 9379385344;
            SniperScope_spc[0].length = 131072;
            SniperScope_spc[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScope_spc[i].name = "spc";
                SniperScope_spc[i].seek = SniperScope_spc[i - 1].seek + SniperScope_spc[i - 1].length;
                SniperScope_spc[i].length = SniperScope_spc[i - 1].length * 4;
                SniperScope_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            SniperScope_ao[0].name = "ao";
            SniperScope_ao[0].seek = 9380040704;
            SniperScope_ao[0].length = 131072;
            SniperScope_ao[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScope_ao[i].name = "ao";
                SniperScope_ao[i].seek = SniperScope_ao[i - 1].seek + SniperScope_ao[i - 1].length;
                SniperScope_ao[i].length = SniperScope_ao[i - 1].length * 4;
                SniperScope_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            SniperScope_cav[0].name = "cav";
            SniperScope_cav[0].seek = 9380696064;
            SniperScope_cav[0].length = 131072;
            SniperScope_cav[0].seeklength = 128;
            while (i <= 1)
            {
                SniperScope_cav[i].name = "cav";
                SniperScope_cav[i].seek = SniperScope_cav[i - 1].seek + SniperScope_cav[i - 1].length;
                SniperScope_cav[i].length = SniperScope_cav[i - 1].length * 4;
                SniperScope_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
