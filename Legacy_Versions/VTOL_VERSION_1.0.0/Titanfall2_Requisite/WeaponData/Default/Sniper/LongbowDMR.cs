using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Sniper
{
    class LongbowDMR
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] LongbowDMR_col;
        public ReallyData[] LongbowDMR_nml;
        public ReallyData[] LongbowDMR_gls;
        public ReallyData[] LongbowDMR_spc;
        //public ReallyData[] LongbowDMR_ilm;
        public ReallyData[] LongbowDMR_ao;
        public ReallyData[] LongbowDMR_cav;
        public LongbowDMR()
        {
            int i = 1;

            LongbowDMR_col = new ReallyData[3];
            LongbowDMR_nml = new ReallyData[3];
            LongbowDMR_gls = new ReallyData[3];
            LongbowDMR_spc = new ReallyData[3];
            LongbowDMR_ao = new ReallyData[3];
            LongbowDMR_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            LongbowDMR_col[0].name = "col";
            LongbowDMR_col[0].seek = 9775616000;
            LongbowDMR_col[0].length = 131072;
            LongbowDMR_col[0].seeklength = 128;
            while (i <= 2)
            {
                LongbowDMR_col[i].name = "col";
                LongbowDMR_col[i].seek = LongbowDMR_col[i - 1].seek + LongbowDMR_col[i - 1].length;
                LongbowDMR_col[i].length = LongbowDMR_col[i - 1].length * 4;
                LongbowDMR_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            LongbowDMR_nml[0].name = "nml";
            LongbowDMR_nml[0].seek = 9778434048;
            LongbowDMR_nml[0].length = 262144;
            LongbowDMR_nml[0].seeklength = 128;
            while (i <= 2)
            {
                LongbowDMR_nml[i].name = "nml";
                LongbowDMR_nml[i].seek = LongbowDMR_nml[i - 1].seek + LongbowDMR_nml[i - 1].length;
                LongbowDMR_nml[i].length = LongbowDMR_nml[i - 1].length * 4;
                LongbowDMR_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            LongbowDMR_gls[0].name = "gls";
            LongbowDMR_gls[0].seek = 9783939072;
            LongbowDMR_gls[0].length = 131072;
            LongbowDMR_gls[0].seeklength = 128;
            while (i <= 2)
            {
                LongbowDMR_gls[i].name = "gls";
                LongbowDMR_gls[i].seek = LongbowDMR_gls[i - 1].seek + LongbowDMR_gls[i - 1].length;
                LongbowDMR_gls[i].length = LongbowDMR_gls[i - 1].length * 4;
                LongbowDMR_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            LongbowDMR_spc[0].name = "spc";
            LongbowDMR_spc[0].seek = 9786691584;
            LongbowDMR_spc[0].length = 131072;
            LongbowDMR_spc[0].seeklength = 128;
            while (i <= 2)
            {
                LongbowDMR_spc[i].name = "spc";
                LongbowDMR_spc[i].seek = LongbowDMR_spc[i - 1].seek + LongbowDMR_spc[i - 1].length;
                LongbowDMR_spc[i].length = LongbowDMR_spc[i - 1].length * 4;
                LongbowDMR_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            LongbowDMR_ao[0].name = "ao";
            LongbowDMR_ao[0].seek = 9789444096;
            LongbowDMR_ao[0].length = 131072;
            LongbowDMR_ao[0].seeklength = 128;
            while (i <= 2)
            {
                LongbowDMR_ao[i].name = "ao";
                LongbowDMR_ao[i].seek = LongbowDMR_ao[i - 1].seek + LongbowDMR_ao[i - 1].length;
                LongbowDMR_ao[i].length = LongbowDMR_ao[i - 1].length * 4;
                LongbowDMR_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            LongbowDMR_cav[0].name = "cav";
            LongbowDMR_cav[0].seek = 9792196608;
            LongbowDMR_cav[0].length = 131072;
            LongbowDMR_cav[0].seeklength = 128;
            while (i <= 2)
            {
                LongbowDMR_cav[i].name = "cav";
                LongbowDMR_cav[i].seek = LongbowDMR_cav[i - 1].seek + LongbowDMR_cav[i - 1].length;
                LongbowDMR_cav[i].length = LongbowDMR_cav[i - 1].length * 4;
                LongbowDMR_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
