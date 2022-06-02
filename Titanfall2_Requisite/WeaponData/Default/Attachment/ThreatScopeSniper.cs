using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Attachment
{
    class ThreatScopeSniper
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] ThreatScopeSniper_col;
        public ReallyData[] ThreatScopeSniper_nml;
        public ReallyData[] ThreatScopeSniper_gls;
        public ReallyData[] ThreatScopeSniper_spc;
        //public ReallyData[] ThreatScopeSniper_ilm;
        public ReallyData[] ThreatScopeSniper_ao;
        public ReallyData[] ThreatScopeSniper_cav;
        public ThreatScopeSniper()
        {
            int i = 1;

            ThreatScopeSniper_col = new ReallyData[2];
            ThreatScopeSniper_nml = new ReallyData[2];
            ThreatScopeSniper_gls = new ReallyData[2];
            ThreatScopeSniper_spc = new ReallyData[2];
            ThreatScopeSniper_ao = new ReallyData[2];
            ThreatScopeSniper_cav = new ReallyData[2];
            //1为1024x1024,0为512x512

            ThreatScopeSniper_col[0].name = "col";
            ThreatScopeSniper_col[0].seek = 9390985216;
            ThreatScopeSniper_col[0].length = 131072;
            ThreatScopeSniper_col[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScopeSniper_col[i].name = "col";
                ThreatScopeSniper_col[i].seek = ThreatScopeSniper_col[i - 1].seek + ThreatScopeSniper_col[i - 1].length;
                ThreatScopeSniper_col[i].length = ThreatScopeSniper_col[i - 1].length * 4;
                ThreatScopeSniper_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScopeSniper_nml[0].name = "nml";
            ThreatScopeSniper_nml[0].seek = 9391706112;
            ThreatScopeSniper_nml[0].length = 262144;
            ThreatScopeSniper_nml[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScopeSniper_nml[i].name = "nml";
                ThreatScopeSniper_nml[i].seek = ThreatScopeSniper_nml[i - 1].seek + ThreatScopeSniper_nml[i - 1].length;
                ThreatScopeSniper_nml[i].length = ThreatScopeSniper_nml[i - 1].length * 4;
                ThreatScopeSniper_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScopeSniper_gls[0].name = "gls";
            ThreatScopeSniper_gls[0].seek = 9393016832;
            ThreatScopeSniper_gls[0].length = 131072;
            ThreatScopeSniper_gls[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScopeSniper_gls[i].name = "gls";
                ThreatScopeSniper_gls[i].seek = ThreatScopeSniper_gls[i - 1].seek + ThreatScopeSniper_gls[i - 1].length;
                ThreatScopeSniper_gls[i].length = ThreatScopeSniper_gls[i - 1].length * 4;
                ThreatScopeSniper_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScopeSniper_spc[0].name = "spc";
            ThreatScopeSniper_spc[0].seek = 9393672192;
            ThreatScopeSniper_spc[0].length = 131072;
            ThreatScopeSniper_spc[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScopeSniper_spc[i].name = "spc";
                ThreatScopeSniper_spc[i].seek = ThreatScopeSniper_spc[i - 1].seek + ThreatScopeSniper_spc[i - 1].length;
                ThreatScopeSniper_spc[i].length = ThreatScopeSniper_spc[i - 1].length * 4;
                ThreatScopeSniper_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScopeSniper_ao[0].name = "ao";
            ThreatScopeSniper_ao[0].seek = 9394327552;
            ThreatScopeSniper_ao[0].length = 131072;
            ThreatScopeSniper_ao[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScopeSniper_ao[i].name = "ao";
                ThreatScopeSniper_ao[i].seek = ThreatScopeSniper_ao[i - 1].seek + ThreatScopeSniper_ao[i - 1].length;
                ThreatScopeSniper_ao[i].length = ThreatScopeSniper_ao[i - 1].length * 4;
                ThreatScopeSniper_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThreatScopeSniper_cav[0].name = "cav";
            ThreatScopeSniper_cav[0].seek = 9394982912;
            ThreatScopeSniper_cav[0].length = 131072;
            ThreatScopeSniper_cav[0].seeklength = 128;
            while (i <= 1)
            {
                ThreatScopeSniper_cav[i].name = "cav";
                ThreatScopeSniper_cav[i].seek = ThreatScopeSniper_cav[i - 1].seek + ThreatScopeSniper_cav[i - 1].length;
                ThreatScopeSniper_cav[i].length = ThreatScopeSniper_cav[i - 1].length * 4;
                ThreatScopeSniper_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
