using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Pistol
{
    class WingmanElite
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] WingmanElite_col;
        public ReallyData[] WingmanElite_nml;
        public ReallyData[] WingmanElite_gls;
        public ReallyData[] WingmanElite_spc;
        public ReallyData[] WingmanElite_ilm;
        public ReallyData[] WingmanElite_ao;
        public ReallyData[] WingmanElite_cav;
        public WingmanElite()
        {
            int i = 1;
            //小帮手精英在common(03).rpak
            WingmanElite_col = new ReallyData[3];
            WingmanElite_nml = new ReallyData[3];
            WingmanElite_gls = new ReallyData[3];
            WingmanElite_spc = new ReallyData[3];
            WingmanElite_ilm = new ReallyData[3];
            WingmanElite_ao = new ReallyData[3];
            WingmanElite_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            WingmanElite_col[0].name = "col";
            WingmanElite_col[0].seek = 2285375488;
            WingmanElite_col[0].length = 131072;
            WingmanElite_col[0].seeklength = 128;
            while (i <= 1)
            {
                WingmanElite_col[i].name = "col";
                WingmanElite_col[i].seek = WingmanElite_col[i - 1].seek + WingmanElite_col[i - 1].length;
                WingmanElite_col[i].length = WingmanElite_col[i - 1].length * 4;
                WingmanElite_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            WingmanElite_nml[0].name = "nml";
            WingmanElite_nml[0].seek = 2286096384;
            WingmanElite_nml[0].length = 262144;
            WingmanElite_nml[0].seeklength = 128;
            while (i <= 1)
            {
                WingmanElite_nml[i].name = "nml";
                WingmanElite_nml[i].seek = WingmanElite_nml[i - 1].seek + WingmanElite_nml[i - 1].length;
                WingmanElite_nml[i].length = WingmanElite_nml[i - 1].length * 4;
                WingmanElite_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            WingmanElite_gls[0].name = "gls";
            WingmanElite_gls[0].seek = 2287407104;
            WingmanElite_gls[0].length = 131072;
            WingmanElite_gls[0].seeklength = 128;
            while (i <= 1)
            {
                WingmanElite_gls[i].name = "gls";
                WingmanElite_gls[i].seek = WingmanElite_gls[i - 1].seek + WingmanElite_gls[i - 1].length;
                WingmanElite_gls[i].length = WingmanElite_gls[i - 1].length * 4;
                WingmanElite_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            WingmanElite_spc[0].name = "spc";
            WingmanElite_spc[0].seek = 2288062464;
            WingmanElite_spc[0].length = 131072;
            WingmanElite_spc[0].seeklength = 128;
            while (i <= 1)
            {
                WingmanElite_spc[i].name = "spc";
                WingmanElite_spc[i].seek = WingmanElite_spc[i - 1].seek + WingmanElite_spc[i - 1].length;
                WingmanElite_spc[i].length = WingmanElite_spc[i - 1].length * 4;
                WingmanElite_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            WingmanElite_ilm[0].name = "ilm";
            WingmanElite_ilm[0].seek = 2288717824;
            WingmanElite_ilm[0].length = 131072;
            WingmanElite_ilm[0].seeklength = 128;
            while (i <= 1)
            {
                WingmanElite_ilm[i].name = "ilm";
                WingmanElite_ilm[i].seek = WingmanElite_ilm[i - 1].seek + WingmanElite_ilm[i - 1].length;
                WingmanElite_ilm[i].length = WingmanElite_ilm[i - 1].length * 4;
                WingmanElite_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            WingmanElite_ao[0].name = "ao";
            WingmanElite_ao[0].seek = 2289373184;
            WingmanElite_ao[0].length = 131072;
            WingmanElite_ao[0].seeklength = 128;
            while (i <= 1)
            {
                WingmanElite_ao[i].name = "ao";
                WingmanElite_ao[i].seek = WingmanElite_ao[i - 1].seek + WingmanElite_ao[i - 1].length;
                WingmanElite_ao[i].length = WingmanElite_ao[i - 1].length * 4;
                WingmanElite_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            WingmanElite_cav[0].name = "cav";
            WingmanElite_cav[0].seek = 2290028544;
            WingmanElite_cav[0].length = 131072;
            WingmanElite_cav[0].seeklength = 128;
            while (i <= 1)
            {
                WingmanElite_cav[i].name = "cav";
                WingmanElite_cav[i].seek = WingmanElite_cav[i - 1].seek + WingmanElite_cav[i - 1].length;
                WingmanElite_cav[i].length = WingmanElite_cav[i - 1].length * 4;
                WingmanElite_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
