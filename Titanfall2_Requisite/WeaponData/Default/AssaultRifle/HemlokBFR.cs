using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AssaultRifle
{
    class HemlokBFR
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] HemlokBFR_col;
        public ReallyData[] HemlokBFR_nml;
        public ReallyData[] HemlokBFR_gls;
        public ReallyData[] HemlokBFR_spc;
        public ReallyData[] HemlokBFR_ilm;
        public ReallyData[] HemlokBFR_ao;
        public ReallyData[] HemlokBFR_cav;
        public HemlokBFR()
        {
            int i = 1;

            HemlokBFR_col = new ReallyData[3];
            HemlokBFR_nml = new ReallyData[3];
            HemlokBFR_gls = new ReallyData[3];
            HemlokBFR_spc = new ReallyData[3];
            HemlokBFR_ilm = new ReallyData[3];
            HemlokBFR_ao = new ReallyData[3];
            HemlokBFR_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            HemlokBFR_col[0].name = "col";
            HemlokBFR_col[0].seek = 9708572672;
            HemlokBFR_col[0].length = 131072;
            HemlokBFR_col[0].seeklength = 128;
            while (i <= 2)
            {
                HemlokBFR_col[i].name = "col";
                HemlokBFR_col[i].seek = HemlokBFR_col[i - 1].seek + HemlokBFR_col[i - 1].length;
                HemlokBFR_col[i].length = HemlokBFR_col[i - 1].length * 4;
                HemlokBFR_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            HemlokBFR_nml[0].name = "nml";
            HemlokBFR_nml[0].seek = 9711390720;
            HemlokBFR_nml[0].length = 262144;
            HemlokBFR_nml[0].seeklength = 128;
            while (i <= 2)
            {
                HemlokBFR_nml[i].name = "nml";
                HemlokBFR_nml[i].seek = HemlokBFR_nml[i - 1].seek + HemlokBFR_nml[i - 1].length;
                HemlokBFR_nml[i].length = HemlokBFR_nml[i - 1].length * 4;
                HemlokBFR_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            HemlokBFR_gls[0].name = "gls";
            HemlokBFR_gls[0].seek = 9716895744;
            HemlokBFR_gls[0].length = 131072;
            HemlokBFR_gls[0].seeklength = 128;
            while (i <= 2)
            {
                HemlokBFR_gls[i].name = "gls";
                HemlokBFR_gls[i].seek = HemlokBFR_gls[i - 1].seek + HemlokBFR_gls[i - 1].length;
                HemlokBFR_gls[i].length = HemlokBFR_gls[i - 1].length * 4;
                HemlokBFR_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            HemlokBFR_spc[0].name = "spc";
            HemlokBFR_spc[0].seek = 9719648256;
            HemlokBFR_spc[0].length = 131072;
            HemlokBFR_spc[0].seeklength = 128;
            while (i <= 2)
            {
                HemlokBFR_spc[i].name = "spc";
                HemlokBFR_spc[i].seek = HemlokBFR_spc[i - 1].seek + HemlokBFR_spc[i - 1].length;
                HemlokBFR_spc[i].length = HemlokBFR_spc[i - 1].length * 4;
                HemlokBFR_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            HemlokBFR_ilm[0].name = "ilm";
            HemlokBFR_ilm[0].seek = 9722400768;
            HemlokBFR_ilm[0].length = 131072;
            HemlokBFR_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                HemlokBFR_ilm[i].name = "ilm";
                HemlokBFR_ilm[i].seek = HemlokBFR_ilm[i - 1].seek + HemlokBFR_ilm[i - 1].length;
                HemlokBFR_ilm[i].length = HemlokBFR_ilm[i - 1].length * 4;
                HemlokBFR_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            HemlokBFR_ao[0].name = "ao";
            HemlokBFR_ao[0].seek = 9725153280;
            HemlokBFR_ao[0].length = 131072;
            HemlokBFR_ao[0].seeklength = 128;
            while (i <= 2)
            {
                HemlokBFR_ao[i].name = "ao";
                HemlokBFR_ao[i].seek = HemlokBFR_ao[i - 1].seek + HemlokBFR_ao[i - 1].length;
                HemlokBFR_ao[i].length = HemlokBFR_ao[i - 1].length * 4;
                HemlokBFR_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            HemlokBFR_cav[0].name = "cav";
            HemlokBFR_cav[0].seek = 9727905792;
            HemlokBFR_cav[0].length = 131072;
            HemlokBFR_cav[0].seeklength = 128;
            while (i <= 2)
            {
                HemlokBFR_cav[i].name = "cav";
                HemlokBFR_cav[i].seek = HemlokBFR_cav[i - 1].seek + HemlokBFR_cav[i - 1].length;
                HemlokBFR_cav[i].length = HemlokBFR_cav[i - 1].length * 4;
                HemlokBFR_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
