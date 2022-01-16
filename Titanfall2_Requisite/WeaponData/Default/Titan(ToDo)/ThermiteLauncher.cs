using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Titan
{
    class ThermiteLauncher
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] ThermiteLauncher_col;
        public ReallyData[] ThermiteLauncher_nml;
        public ReallyData[] ThermiteLauncher_gls;
        public ReallyData[] ThermiteLauncher_spc;
        public ReallyData[] ThermiteLauncher_ilm;
        public ReallyData[] ThermiteLauncher_ao;
        public ReallyData[] ThermiteLauncher_cav;
        public ThermiteLauncher()
        {
            int i = 1;

            ThermiteLauncher_col = new ReallyData[3];
            ThermiteLauncher_nml = new ReallyData[3];
            ThermiteLauncher_gls = new ReallyData[3];
            ThermiteLauncher_spc = new ReallyData[3];
            ThermiteLauncher_ilm = new ReallyData[3];
            ThermiteLauncher_ao = new ReallyData[3];
            ThermiteLauncher_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            ThermiteLauncher_col[0].name = "col";
            ThermiteLauncher_col[0].seek = 9510850560;
            ThermiteLauncher_col[0].length = 131072;
            ThermiteLauncher_col[0].seeklength = 128;
            while (i <= 2)
            {
                ThermiteLauncher_col[i].name = "col";
                ThermiteLauncher_col[i].seek = ThermiteLauncher_col[i - 1].seek + ThermiteLauncher_col[i - 1].length;
                ThermiteLauncher_col[i].length = ThermiteLauncher_col[i - 1].length * 4;
                ThermiteLauncher_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThermiteLauncher_nml[0].name = "nml";
            ThermiteLauncher_nml[0].seek = 9513668608;
            ThermiteLauncher_nml[0].length = 262144;
            ThermiteLauncher_nml[0].seeklength = 128;
            while (i <= 2)
            {
                ThermiteLauncher_nml[i].name = "nml";
                ThermiteLauncher_nml[i].seek = ThermiteLauncher_nml[i - 1].seek + ThermiteLauncher_nml[i - 1].length;
                ThermiteLauncher_nml[i].length = ThermiteLauncher_nml[i - 1].length * 4;
                ThermiteLauncher_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThermiteLauncher_gls[0].name = "gls";
            ThermiteLauncher_gls[0].seek = 9519173632;
            ThermiteLauncher_gls[0].length = 131072;
            ThermiteLauncher_gls[0].seeklength = 128;
            while (i <= 2)
            {
                ThermiteLauncher_gls[i].name = "gls";
                ThermiteLauncher_gls[i].seek = ThermiteLauncher_gls[i - 1].seek + ThermiteLauncher_gls[i - 1].length;
                ThermiteLauncher_gls[i].length = ThermiteLauncher_gls[i - 1].length * 4;
                ThermiteLauncher_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThermiteLauncher_spc[0].name = "spc";
            ThermiteLauncher_spc[0].seek = 9521926144;
            ThermiteLauncher_spc[0].length = 131072;
            ThermiteLauncher_spc[0].seeklength = 128;
            while (i <= 2)
            {
                ThermiteLauncher_spc[i].name = "spc";
                ThermiteLauncher_spc[i].seek = ThermiteLauncher_spc[i - 1].seek + ThermiteLauncher_spc[i - 1].length;
                ThermiteLauncher_spc[i].length = ThermiteLauncher_spc[i - 1].length * 4;
                ThermiteLauncher_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThermiteLauncher_ilm[0].name = "ilm";
            ThermiteLauncher_ilm[0].seek = 9524678656;
            ThermiteLauncher_ilm[0].length = 131072;
            ThermiteLauncher_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                ThermiteLauncher_ilm[i].name = "ilm";
                ThermiteLauncher_ilm[i].seek = ThermiteLauncher_ilm[i - 1].seek + ThermiteLauncher_ilm[i - 1].length;
                ThermiteLauncher_ilm[i].length = ThermiteLauncher_ilm[i - 1].length * 4;
                ThermiteLauncher_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThermiteLauncher_ao[0].name = "ao";
            ThermiteLauncher_ao[0].seek = 9527431168;
            ThermiteLauncher_ao[0].length = 131072;
            ThermiteLauncher_ao[0].seeklength = 128;
            while (i <= 2)
            {
                ThermiteLauncher_ao[i].name = "ao";
                ThermiteLauncher_ao[i].seek = ThermiteLauncher_ao[i - 1].seek + ThermiteLauncher_ao[i - 1].length;
                ThermiteLauncher_ao[i].length = ThermiteLauncher_ao[i - 1].length * 4;
                ThermiteLauncher_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            ThermiteLauncher_cav[0].name = "cav";
            ThermiteLauncher_cav[0].seek = 9530183680;
            ThermiteLauncher_cav[0].length = 131072;
            ThermiteLauncher_cav[0].seeklength = 128;
            while (i <= 2)
            {
                ThermiteLauncher_cav[i].name = "cav";
                ThermiteLauncher_cav[i].seek = ThermiteLauncher_cav[i - 1].seek + ThermiteLauncher_cav[i - 1].length;
                ThermiteLauncher_cav[i].length = ThermiteLauncher_cav[i - 1].length * 4;
                ThermiteLauncher_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
