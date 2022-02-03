using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.SubmachineGun
{
    class R97
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] R97_col;
        public ReallyData[] R97_nml;
        public ReallyData[] R97_gls;
        public ReallyData[] R97_spc;
        public ReallyData[] R97_ilm;
        public ReallyData[] R97_ao;
        public ReallyData[] R97_cav;
        public R97()
        {
            int i = 1;

            R97_col = new ReallyData[3];
            R97_nml = new ReallyData[3];
            R97_gls = new ReallyData[3];
            R97_spc = new ReallyData[3];
            R97_ilm = new ReallyData[3];
            R97_ao = new ReallyData[3];
            R97_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            R97_col[0].name = "col";
            R97_col[0].seek = 9898496000;
            R97_col[0].length = 131072;
            R97_col[0].seeklength = 128;
            while (i <= 2)
            {
                R97_col[i].name = "col";
                R97_col[i].seek = R97_col[i - 1].seek + R97_col[i - 1].length;
                R97_col[i].length = R97_col[i - 1].length * 4;
                R97_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            R97_nml[0].name = "nml";
            R97_nml[0].seek = 9901314048;
            R97_nml[0].length = 262144;
            R97_nml[0].seeklength = 128;
            while (i <= 2)
            {
                R97_nml[i].name = "nml";
                R97_nml[i].seek = R97_nml[i - 1].seek + R97_nml[i - 1].length;
                R97_nml[i].length = R97_nml[i - 1].length * 4;
                R97_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            R97_gls[0].name = "gls";
            R97_gls[0].seek = 9906819072;
            R97_gls[0].length = 131072;
            R97_gls[0].seeklength = 128;
            while (i <= 2)
            {
                R97_gls[i].name = "gls";
                R97_gls[i].seek = R97_gls[i - 1].seek + R97_gls[i - 1].length;
                R97_gls[i].length = R97_gls[i - 1].length * 4;
                R97_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            R97_spc[0].name = "spc";
            R97_spc[0].seek = 9909571584;
            R97_spc[0].length = 131072;
            R97_spc[0].seeklength = 128;
            while (i <= 2)
            {
                R97_spc[i].name = "spc";
                R97_spc[i].seek = R97_spc[i - 1].seek + R97_spc[i - 1].length;
                R97_spc[i].length = R97_spc[i - 1].length * 4;
                R97_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            R97_ilm[0].name = "ilm";
            R97_ilm[0].seek = 9912324096;
            R97_ilm[0].length = 131072;
            R97_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                R97_ilm[i].name = "ilm";
                R97_ilm[i].seek = R97_ilm[i - 1].seek + R97_ilm[i - 1].length;
                R97_ilm[i].length = R97_ilm[i - 1].length * 4;
                R97_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            R97_ao[0].name = "ao";
            R97_ao[0].seek = 9915076608;
            R97_ao[0].length = 131072;
            R97_ao[0].seeklength = 128;
            while (i <= 2)
            {
                R97_ao[i].name = "ao";
                R97_ao[i].seek = R97_ao[i - 1].seek + R97_ao[i - 1].length;
                R97_ao[i].length = R97_ao[i - 1].length * 4;
                R97_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            R97_cav[0].name = "cav";
            R97_cav[0].seek = 9917829120;
            R97_cav[0].length = 131072;
            R97_cav[0].seeklength = 128;
            while (i <= 2)
            {
                R97_cav[i].name = "cav";
                R97_cav[i].seek = R97_cav[i - 1].seek + R97_cav[i - 1].length;
                R97_cav[i].length = R97_cav[i - 1].length * 4;
                R97_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
