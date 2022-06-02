using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Attachment
{
    class ThreatScope
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] ThreatScope_col;
        public ReallyData[] ThreatScope_nml;
        public ReallyData[] ThreatScope_gls;
        public ReallyData[] ThreatScope_spc;
        public ReallyData[] ThreatScope_ilm;
        public ReallyData[] ThreatScope_ao;
        public ReallyData[] ThreatScope_cav;
        public ThreatScope()
        {
            int i = 1;

            ThreatScope_col = new ReallyData[2];
            ThreatScope_nml = new ReallyData[2];
            ThreatScope_gls = new ReallyData[2];
            ThreatScope_spc = new ReallyData[2];
            ThreatScope_ilm = new ReallyData[2];
            ThreatScope_ao = new ReallyData[2];
            ThreatScope_cav = new ReallyData[2];
            //1为1024x1024,0为512x512

            ThreatScope_col[0].name = "col";
            ThreatScope_col[0].seek = 9371389952;
            ThreatScope_col[0].length = 131072;
            ThreatScope_col[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScope_col[i].name = "col";
                ThreatScope_col[i].seek = ThreatScope_col[i - 1].seek + ThreatScope_col[i - 1].length;
                ThreatScope_col[i].length = ThreatScope_col[i - 1].length * 4;
                ThreatScope_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScope_nml[0].name = "nml";
            ThreatScope_nml[0].seek = 9372110848;
            ThreatScope_nml[0].length = 262144;
            ThreatScope_nml[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScope_nml[i].name = "nml";
                ThreatScope_nml[i].seek = ThreatScope_nml[i - 1].seek + ThreatScope_nml[i - 1].length;
                ThreatScope_nml[i].length = ThreatScope_nml[i - 1].length * 4;
                ThreatScope_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScope_gls[0].name = "gls";
            ThreatScope_gls[0].seek = 9373421568;
            ThreatScope_gls[0].length = 131072;
            ThreatScope_gls[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScope_gls[i].name = "gls";
                ThreatScope_gls[i].seek = ThreatScope_gls[i - 1].seek + ThreatScope_gls[i - 1].length;
                ThreatScope_gls[i].length = ThreatScope_gls[i - 1].length * 4;
                ThreatScope_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScope_spc[0].name = "spc";
            ThreatScope_spc[0].seek = 9374076928;
            ThreatScope_spc[0].length = 131072;
            ThreatScope_spc[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScope_spc[i].name = "spc";
                ThreatScope_spc[i].seek = ThreatScope_spc[i - 1].seek + ThreatScope_spc[i - 1].length;
                ThreatScope_spc[i].length = ThreatScope_spc[i - 1].length * 4;
                ThreatScope_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScope_ilm[0].name = "ilm";
            ThreatScope_ilm[0].seek = 9374732288;
            ThreatScope_ilm[0].length = 131072;
            ThreatScope_ilm[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScope_ilm[i].name = "ilm";
                ThreatScope_ilm[i].seek = ThreatScope_ilm[i - 1].seek + ThreatScope_ilm[i - 1].length;
                ThreatScope_ilm[i].length = ThreatScope_ilm[i - 1].length * 4;
                ThreatScope_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScope_ao[0].name = "ao";
            ThreatScope_ao[0].seek = 9375387648;
            ThreatScope_ao[0].length = 131072;
            ThreatScope_ao[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScope_ao[i].name = "ao";
                ThreatScope_ao[i].seek = ThreatScope_ao[i - 1].seek + ThreatScope_ao[i - 1].length;
                ThreatScope_ao[i].length = ThreatScope_ao[i - 1].length * 4;
                ThreatScope_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScope_cav[0].name = "cav";
            ThreatScope_cav[0].seek = 9376043008;
            ThreatScope_cav[0].length = 131072;
            ThreatScope_cav[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScope_cav[i].name = "cav";
                ThreatScope_cav[i].seek = ThreatScope_cav[i - 1].seek + ThreatScope_cav[i - 1].length;
                ThreatScope_cav[i].length = ThreatScope_cav[i - 1].length * 4;
                ThreatScope_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
