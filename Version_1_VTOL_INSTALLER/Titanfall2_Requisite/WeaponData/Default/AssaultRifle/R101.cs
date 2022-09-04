using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AssaultRifle
{
    class R101
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] R101_col;
        public ReallyData[] R101_nml;
        public ReallyData[] R101_gls;
        public ReallyData[] R101_spc;
        public ReallyData[] R101_ilm;
        public ReallyData[] R101_ao;
        public ReallyData[] R101_cav;
        public R101()
        {
            int i = 1;

            R101_col = new ReallyData[3];
            R101_nml = new ReallyData[3];
            R101_gls = new ReallyData[3];
            R101_spc = new ReallyData[3];
            R101_ilm = new ReallyData[3];
            R101_ao = new ReallyData[3];
            R101_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            R101_col[0].name = "col";
            R101_col[0].seek = 2257784832;
            R101_col[0].length = 131072;
            R101_col[0].seeklength = 128;
            while (i <= 2)
            {
                R101_col[i].name = "col";
                R101_col[i].seek = R101_col[i - 1].seek + R101_col[i - 1].length;
                R101_col[i].length = R101_col[i - 1].length * 4;
                R101_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            R101_nml[0].name = "nml";
            R101_nml[0].seek = 2260602880;
            R101_nml[0].length = 262144;
            R101_nml[0].seeklength = 128;
            while (i <= 2)
            {
                R101_nml[i].name = "nml";
                R101_nml[i].seek = R101_nml[i - 1].seek + R101_nml[i - 1].length;
                R101_nml[i].length = R101_nml[i - 1].length * 4;
                R101_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            R101_gls[0].name = "gls";
            R101_gls[0].seek = 2266107904;
            R101_gls[0].length = 131072;
            R101_gls[0].seeklength = 128;
            while (i <= 2)
            {
                R101_gls[i].name = "gls";
                R101_gls[i].seek = R101_gls[i - 1].seek + R101_gls[i - 1].length;
                R101_gls[i].length = R101_gls[i - 1].length * 4;
                R101_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            R101_spc[0].name = "spc";
            R101_spc[0].seek = 2268860416;
            R101_spc[0].length = 131072;
            R101_spc[0].seeklength = 128;
            while (i <= 2)
            {
                R101_spc[i].name = "spc";
                R101_spc[i].seek = R101_spc[i - 1].seek + R101_spc[i - 1].length;
                R101_spc[i].length = R101_spc[i - 1].length * 4;
                R101_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            R101_ilm[0].name = "ilm";
            R101_ilm[0].seek = 2271612928;
            R101_ilm[0].length = 131072;
            R101_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                R101_ilm[i].name = "ilm";
                R101_ilm[i].seek = R101_ilm[i - 1].seek + R101_ilm[i - 1].length;
                R101_ilm[i].length = R101_ilm[i - 1].length * 4;
                R101_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            R101_ao[0].name = "ao";
            R101_ao[0].seek = 2274365440;
            R101_ao[0].length = 131072;
            R101_ao[0].seeklength = 128;
            while (i <= 2)
            {
                R101_ao[i].name = "ao";
                R101_ao[i].seek = R101_ao[i - 1].seek + R101_ao[i - 1].length;
                R101_ao[i].length = R101_ao[i - 1].length * 4;
                R101_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            R101_cav[0].name = "cav";
            R101_cav[0].seek = 2277117952;
            R101_cav[0].length = 131072;
            R101_cav[0].seeklength = 128;
            while (i <= 2)
            {
                R101_cav[i].name = "cav";
                R101_cav[i].seek = R101_cav[i - 1].seek + R101_cav[i - 1].length;
                R101_cav[i].length = R101_cav[i - 1].length * 4;
                R101_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
