using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Pistol
{
    class Wingman
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Wingman_col;
        public ReallyData[] Wingman_nml;
        public ReallyData[] Wingman_gls;
        public ReallyData[] Wingman_spc;
        public ReallyData[] Wingman_ilm;
        public ReallyData[] Wingman_ao;
        public ReallyData[] Wingman_cav;
        public Wingman()
        {
            int i = 1;

            Wingman_col = new ReallyData[3];
            Wingman_nml = new ReallyData[3];
            Wingman_gls = new ReallyData[3];
            Wingman_spc = new ReallyData[3];
            Wingman_ilm = new ReallyData[3];
            Wingman_ao = new ReallyData[3];
            Wingman_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            Wingman_col[0].name = "col";
            Wingman_col[0].seek = 10226241536;
            Wingman_col[0].length = 131072;
            Wingman_col[0].seeklength = 128;
            while (i <= 1)
            {
                Wingman_col[i].name = "col";
                Wingman_col[i].seek = Wingman_col[i - 1].seek + Wingman_col[i - 1].length;
                Wingman_col[i].length = Wingman_col[i - 1].length * 4;
                Wingman_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Wingman_nml[0].name = "nml";
            Wingman_nml[0].seek = 10226962432;
            Wingman_nml[0].length = 262144;
            Wingman_nml[0].seeklength = 128;
            while (i <= 1)
            {
                Wingman_nml[i].name = "nml";
                Wingman_nml[i].seek = Wingman_nml[i - 1].seek + Wingman_nml[i - 1].length;
                Wingman_nml[i].length = Wingman_nml[i - 1].length * 4;
                Wingman_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Wingman_gls[0].name = "gls";
            Wingman_gls[0].seek = 10228273152;
            Wingman_gls[0].length = 131072;
            Wingman_gls[0].seeklength = 128;
            while (i <= 1)
            {
                Wingman_gls[i].name = "gls";
                Wingman_gls[i].seek = Wingman_gls[i - 1].seek + Wingman_gls[i - 1].length;
                Wingman_gls[i].length = Wingman_gls[i - 1].length * 4;
                Wingman_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Wingman_spc[0].name = "spc";
            Wingman_spc[0].seek = 10228928512;
            Wingman_spc[0].length = 131072;
            Wingman_spc[0].seeklength = 128;
            while (i <= 1)
            {
                Wingman_spc[i].name = "spc";
                Wingman_spc[i].seek = Wingman_spc[i - 1].seek + Wingman_spc[i - 1].length;
                Wingman_spc[i].length = Wingman_spc[i - 1].length * 4;
                Wingman_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Wingman_ilm[0].name = "ilm";
            Wingman_ilm[0].seek = 10229583872;
            Wingman_ilm[0].length = 131072;
            Wingman_ilm[0].seeklength = 128;
            while (i <= 1)
            {
                Wingman_ilm[i].name = "ilm";
                Wingman_ilm[i].seek = Wingman_ilm[i - 1].seek + Wingman_ilm[i - 1].length;
                Wingman_ilm[i].length = Wingman_ilm[i - 1].length * 4;
                Wingman_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Wingman_ao[0].name = "ao";
            Wingman_ao[0].seek = 10230239232;
            Wingman_ao[0].length = 131072;
            Wingman_ao[0].seeklength = 128;
            while (i <= 1)
            {
                Wingman_ao[i].name = "ao";
                Wingman_ao[i].seek = Wingman_ao[i - 1].seek + Wingman_ao[i - 1].length;
                Wingman_ao[i].length = Wingman_ao[i - 1].length * 4;
                Wingman_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Wingman_cav[0].name = "cav";
            Wingman_cav[0].seek = 10230894592;
            Wingman_cav[0].length = 131072;
            Wingman_cav[0].seeklength = 128;
            while (i <= 1)
            {
                Wingman_cav[i].name = "cav";
                Wingman_cav[i].seek = Wingman_cav[i - 1].seek + Wingman_cav[i - 1].length;
                Wingman_cav[i].length = Wingman_cav[i - 1].length * 4;
                Wingman_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
