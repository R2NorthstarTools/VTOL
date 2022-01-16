using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AssaultRifle
{
    class R201
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] R201_col;
        public ReallyData[] R201_nml;
        public ReallyData[] R201_gls;
        public ReallyData[] R201_spc;
        public ReallyData[] R201_ilm;
        public ReallyData[] R201_ao;
        public ReallyData[] R201_cav;
        public R201()
        {
            int i = 1;

            R201_col = new ReallyData[3];
            R201_nml = new ReallyData[3];
            R201_gls = new ReallyData[3];
            R201_spc = new ReallyData[3];
            R201_ilm = new ReallyData[3];
            R201_ao = new ReallyData[3];
            R201_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            R201_col[0].name = "col";
            R201_col[0].seek = 9009893376;
            R201_col[0].length = 131072;
            R201_col[0].seeklength = 128;
            while (i <= 2)
            {
                R201_col[i].name = "col";
                R201_col[i].seek = R201_col[i - 1].seek + R201_col[i - 1].length;
                R201_col[i].length = R201_col[i - 1].length * 4;
                R201_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            R201_nml[0].name = "nml";
            R201_nml[0].seek = 9012711424;
            R201_nml[0].length = 262144;
            R201_nml[0].seeklength = 128;
            while (i <= 2)
            {
                R201_nml[i].name = "nml";
                R201_nml[i].seek = R201_nml[i - 1].seek + R201_nml[i - 1].length;
                R201_nml[i].length = R201_nml[i - 1].length * 4;
                R201_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            R201_gls[0].name = "gls";
            R201_gls[0].seek = 9018216448;
            R201_gls[0].length = 131072;
            R201_gls[0].seeklength = 128;
            while (i <= 2)
            {
                R201_gls[i].name = "gls";
                R201_gls[i].seek = R201_gls[i - 1].seek + R201_gls[i - 1].length;
                R201_gls[i].length = R201_gls[i - 1].length * 4;
                R201_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            R201_spc[0].name = "spc";
            R201_spc[0].seek = 9020968960;
            R201_spc[0].length = 131072;
            R201_spc[0].seeklength = 128;
            while (i <= 2)
            {
                R201_spc[i].name = "spc";
                R201_spc[i].seek = R201_spc[i - 1].seek + R201_spc[i - 1].length;
                R201_spc[i].length = R201_spc[i - 1].length * 4;
                R201_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            R201_ilm[0].name = "ilm";
            R201_ilm[0].seek = 9023721472;
            R201_ilm[0].length = 131072;
            R201_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                R201_ilm[i].name = "ilm";
                R201_ilm[i].seek = R201_ilm[i - 1].seek + R201_ilm[i - 1].length;
                R201_ilm[i].length = R201_ilm[i - 1].length * 4;
                R201_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            R201_ao[0].name = "ao";
            R201_ao[0].seek = 9026473984;
            R201_ao[0].length = 131072;
            R201_ao[0].seeklength = 128;
            while (i <= 2)
            {
                R201_ao[i].name = "ao";
                R201_ao[i].seek = R201_ao[i - 1].seek + R201_ao[i - 1].length;
                R201_ao[i].length = R201_ao[i - 1].length * 4;
                R201_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            R201_cav[0].name = "cav";
            R201_cav[0].seek = 9029226496;
            R201_cav[0].length = 131072;
            R201_cav[0].seeklength = 128;
            while (i <= 2)
            {
                R201_cav[i].name = "cav";
                R201_cav[i].seek = R201_cav[i - 1].seek + R201_cav[i - 1].length;
                R201_cav[i].length = R201_cav[i - 1].length * 4;
                R201_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
