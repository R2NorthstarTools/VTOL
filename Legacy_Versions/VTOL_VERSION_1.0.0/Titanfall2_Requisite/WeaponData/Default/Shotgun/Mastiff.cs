using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Shotgun
{
    class Mastiff
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Mastiff_col;
        public ReallyData[] Mastiff_nml;
        public ReallyData[] Mastiff_gls;
        public ReallyData[] Mastiff_spc;
        public ReallyData[] Mastiff_ilm;
        public ReallyData[] Mastiff_ao;
        public ReallyData[] Mastiff_cav;
        public Mastiff()
        {
            int i = 1;

            Mastiff_col = new ReallyData[3];
            Mastiff_nml = new ReallyData[3];
            Mastiff_gls = new ReallyData[3];
            Mastiff_spc = new ReallyData[3];
            Mastiff_ilm = new ReallyData[3];
            Mastiff_ao = new ReallyData[3];
            Mastiff_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            Mastiff_col[0].name = "col";
            Mastiff_col[0].seek = 8923582464;
            Mastiff_col[0].length = 131072;
            Mastiff_col[0].seeklength = 128;
            while (i <= 2)
            {
                Mastiff_col[i].name = "col";
                Mastiff_col[i].seek = Mastiff_col[i - 1].seek + Mastiff_col[i - 1].length;
                Mastiff_col[i].length = Mastiff_col[i - 1].length * 4;
                Mastiff_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mastiff_nml[0].name = "nml";
            Mastiff_nml[0].seek = 8926400512;
            Mastiff_nml[0].length = 262144;
            Mastiff_nml[0].seeklength = 128;
            while (i <= 2)
            {
                Mastiff_nml[i].name = "nml";
                Mastiff_nml[i].seek = Mastiff_nml[i - 1].seek + Mastiff_nml[i - 1].length;
                Mastiff_nml[i].length = Mastiff_nml[i - 1].length * 4;
                Mastiff_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mastiff_gls[0].name = "gls";
            Mastiff_gls[0].seek = 8931905536;
            Mastiff_gls[0].length = 131072;
            Mastiff_gls[0].seeklength = 128;
            while (i <= 2)
            {
                Mastiff_gls[i].name = "gls";
                Mastiff_gls[i].seek = Mastiff_gls[i - 1].seek + Mastiff_gls[i - 1].length;
                Mastiff_gls[i].length = Mastiff_gls[i - 1].length * 4;
                Mastiff_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mastiff_spc[0].name = "spc";
            Mastiff_spc[0].seek = 8934658048;
            Mastiff_spc[0].length = 131072;
            Mastiff_spc[0].seeklength = 128;
            while (i <= 2)
            {
                Mastiff_spc[i].name = "spc";
                Mastiff_spc[i].seek = Mastiff_spc[i - 1].seek + Mastiff_spc[i - 1].length;
                Mastiff_spc[i].length = Mastiff_spc[i - 1].length * 4;
                Mastiff_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mastiff_ilm[0].name = "ilm";
            Mastiff_ilm[0].seek = 8937410560;
            Mastiff_ilm[0].length = 131072;
            Mastiff_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                Mastiff_ilm[i].name = "ilm";
                Mastiff_ilm[i].seek = Mastiff_ilm[i - 1].seek + Mastiff_ilm[i - 1].length;
                Mastiff_ilm[i].length = Mastiff_ilm[i - 1].length * 4;
                Mastiff_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mastiff_ao[0].name = "ao";
            Mastiff_ao[0].seek = 8940163072;
            Mastiff_ao[0].length = 131072;
            Mastiff_ao[0].seeklength = 128;
            while (i <= 2)
            {
                Mastiff_ao[i].name = "ao";
                Mastiff_ao[i].seek = Mastiff_ao[i - 1].seek + Mastiff_ao[i - 1].length;
                Mastiff_ao[i].length = Mastiff_ao[i - 1].length * 4;
                Mastiff_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Mastiff_cav[0].name = "cav";
            Mastiff_cav[0].seek = 8942915584;
            Mastiff_cav[0].length = 131072;
            Mastiff_cav[0].seeklength = 128;
            while (i <= 2)
            {
                Mastiff_cav[i].name = "cav";
                Mastiff_cav[i].seek = Mastiff_cav[i - 1].seek + Mastiff_cav[i - 1].length;
                Mastiff_cav[i].length = Mastiff_cav[i - 1].length * 4;
                Mastiff_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
