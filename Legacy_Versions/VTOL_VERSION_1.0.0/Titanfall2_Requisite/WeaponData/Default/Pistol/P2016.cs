using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Pistol
{
    class P2016
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] P2016_col;
        public ReallyData[] P2016_nml;
        public ReallyData[] P2016_gls;
        public ReallyData[] P2016_spc;
        public ReallyData[] P2016_ilm;
        public ReallyData[] P2016_ao;
        public ReallyData[] P2016_cav;
        public P2016()
        {
            int i = 1;

            P2016_col = new ReallyData[3];
            P2016_nml = new ReallyData[3];
            P2016_gls = new ReallyData[3];
            P2016_spc = new ReallyData[3];
            P2016_ilm = new ReallyData[3];
            P2016_ao = new ReallyData[3];
            P2016_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            P2016_col[0].name = "col";
            P2016_col[0].seek = 9805959168;
            P2016_col[0].length = 131072;
            P2016_col[0].seeklength = 128;
            while (i <= 1)
            {
                P2016_col[i].name = "col";
                P2016_col[i].seek = P2016_col[i - 1].seek + P2016_col[i - 1].length;
                P2016_col[i].length = P2016_col[i - 1].length * 4;
                P2016_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            P2016_nml[0].name = "nml";
            P2016_nml[0].seek = 9806680064;
            P2016_nml[0].length = 262144;
            P2016_nml[0].seeklength = 128;
            while (i <= 1)
            {
                P2016_nml[i].name = "nml";
                P2016_nml[i].seek = P2016_nml[i - 1].seek + P2016_nml[i - 1].length;
                P2016_nml[i].length = P2016_nml[i - 1].length * 4;
                P2016_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            P2016_gls[0].name = "gls";
            P2016_gls[0].seek = 9807990784;
            P2016_gls[0].length = 131072;
            P2016_gls[0].seeklength = 128;
            while (i <= 1)
            {
                P2016_gls[i].name = "gls";
                P2016_gls[i].seek = P2016_gls[i - 1].seek + P2016_gls[i - 1].length;
                P2016_gls[i].length = P2016_gls[i - 1].length * 4;
                P2016_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            P2016_spc[0].name = "spc";
            P2016_spc[0].seek = 9808646144;
            P2016_spc[0].length = 131072;
            P2016_spc[0].seeklength = 128;
            while (i <= 1)
            {
                P2016_spc[i].name = "spc";
                P2016_spc[i].seek = P2016_spc[i - 1].seek + P2016_spc[i - 1].length;
                P2016_spc[i].length = P2016_spc[i - 1].length * 4;
                P2016_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            P2016_ilm[0].name = "ilm";
            P2016_ilm[0].seek = 9809301504;
            P2016_ilm[0].length = 131072;
            P2016_ilm[0].seeklength = 128;
            while (i <= 1)
            {
                P2016_ilm[i].name = "ilm";
                P2016_ilm[i].seek = P2016_ilm[i - 1].seek + P2016_ilm[i - 1].length;
                P2016_ilm[i].length = P2016_ilm[i - 1].length * 4;
                P2016_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            P2016_ao[0].name = "ao";
            P2016_ao[0].seek = 9809956864;
            P2016_ao[0].length = 131072;
            P2016_ao[0].seeklength = 128;
            while (i <= 1)
            {
                P2016_ao[i].name = "ao";
                P2016_ao[i].seek = P2016_ao[i - 1].seek + P2016_ao[i - 1].length;
                P2016_ao[i].length = P2016_ao[i - 1].length * 4;
                P2016_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            P2016_cav[0].name = "cav";
            P2016_cav[0].seek = 9810612224;
            P2016_cav[0].length = 131072;
            P2016_cav[0].seeklength = 128;
            while (i <= 1)
            {
                P2016_cav[i].name = "cav";
                P2016_cav[i].seek = P2016_cav[i - 1].seek + P2016_cav[i - 1].length;
                P2016_cav[i].length = P2016_cav[i - 1].length * 4;
                P2016_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
