using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class Ronin
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Ronin_col;
        public ReallyData[] Ronin_nml;
        public ReallyData[] Ronin_gls;
        public ReallyData[] Ronin_spc;
        public ReallyData[] Ronin_ilm;
        public ReallyData[] Ronin_ao;
        public ReallyData[] Ronin_cav;
        public Ronin()
        {
            int i = 1;

            Ronin_col = new ReallyData[4];
            Ronin_nml = new ReallyData[4];
            Ronin_gls = new ReallyData[4];
            Ronin_spc = new ReallyData[4];
            Ronin_ilm = new ReallyData[4];
            Ronin_ao = new ReallyData[4];
            Ronin_cav = new ReallyData[4];
            //3为4096x40962为2048x2048,1为1024x1024,0为512x512
            //col,spc是BC7U
            Ronin_col[0].name = "col";
            Ronin_col[0].seek = 6483873792;
            Ronin_col[0].length = 262144;
            Ronin_col[0].seeklength = 148;
            while (i <= 3)
            {
                Ronin_col[i].name = "col";
                Ronin_col[i].seek = Ronin_col[i - 1].seek + Ronin_col[i - 1].length;
                Ronin_col[i].length = Ronin_col[i - 1].length * 4;
                Ronin_col[i].seeklength = 148;
                i++;
            }
            i = 1;

            Ronin_nml[0].name = "nml";
            Ronin_nml[0].seek = 6216159232;
            Ronin_nml[0].length = 262144;
            Ronin_nml[0].seeklength = 128;
            while (i <= 3)
            {
                Ronin_nml[i].name = "nml";
                Ronin_nml[i].seek = Ronin_nml[i - 1].seek + Ronin_nml[i - 1].length;
                Ronin_nml[i].length = Ronin_nml[i - 1].length * 4;
                Ronin_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Ronin_gls[0].name = "gls";
            Ronin_gls[0].seek = 6428037120;
            Ronin_gls[0].length = 131072;
            Ronin_gls[0].seeklength = 128;
            while (i <= 3)
            {
                Ronin_gls[i].name = "gls";
                Ronin_gls[i].seek = Ronin_gls[i - 1].seek + Ronin_gls[i - 1].length;
                Ronin_gls[i].length = Ronin_gls[i - 1].length * 4;
                Ronin_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Ronin_spc[0].name = "spc";
            Ronin_spc[0].seek = 6517362688;
            Ronin_spc[0].length = 262144;
            Ronin_spc[0].seeklength = 148;
            while (i <= 3)
            {
                Ronin_spc[i].name = "spc";
                Ronin_spc[i].seek = Ronin_spc[i - 1].seek + Ronin_spc[i - 1].length;
                Ronin_spc[i].length = Ronin_spc[i - 1].length * 4;
                Ronin_spc[i].seeklength = 148;
                i++;
            }
            i = 1;

            Ronin_ilm[0].name = "ilm";
            Ronin_ilm[0].seek = 6260723712;
            Ronin_ilm[0].length = 131072;
            Ronin_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                Ronin_ilm[i].name = "ilm";
                Ronin_ilm[i].seek = Ronin_ilm[i - 1].seek + Ronin_ilm[i - 1].length;
                Ronin_ilm[i].length = Ronin_ilm[i - 1].length * 4;
                Ronin_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Ronin_ao[0].name = "ao";
            Ronin_ao[0].seek = 6271864832;
            Ronin_ao[0].length = 131072;
            Ronin_ao[0].seeklength = 128;
            while (i <= 3)
            {
                Ronin_ao[i].name = "ao";
                Ronin_ao[i].seek = Ronin_ao[i - 1].seek + Ronin_ao[i - 1].length;
                Ronin_ao[i].length = Ronin_ao[i - 1].length * 4;
                Ronin_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Ronin_cav[0].name = "cav";
            Ronin_cav[0].seek = 6283005952;
            Ronin_cav[0].length = 131072;
            Ronin_cav[0].seeklength = 128;
            while (i <= 3)
            {
                Ronin_cav[i].name = "cav";
                Ronin_cav[i].seek = Ronin_cav[i - 1].seek + Ronin_cav[i - 1].length;
                Ronin_cav[i].length = Ronin_cav[i - 1].length * 4;
                Ronin_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}