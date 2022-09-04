using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class Legion
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Legion_col;
        public ReallyData[] Legion_nml;
        public ReallyData[] Legion_gls;
        public ReallyData[] Legion_spc;
        public ReallyData[] Legion_ilm;
        public ReallyData[] Legion_ao;
        public ReallyData[] Legion_cav;
        public Legion()
        {
            int i = 1;

            Legion_col = new ReallyData[4];
            Legion_nml = new ReallyData[4];
            Legion_gls = new ReallyData[4];
            Legion_spc = new ReallyData[4];
            Legion_ilm = new ReallyData[4];
            Legion_ao = new ReallyData[4];
            Legion_cav = new ReallyData[4];
            //3为4096x40962为2048x2048,1为1024x1024,0为512x512

            Legion_col[0].name = "col";
            Legion_col[0].seek = 4833873920;
            Legion_col[0].length = 131072;
            Legion_col[0].seeklength = 128;
            while (i <= 3)
            {
                Legion_col[i].name = "col";
                Legion_col[i].seek = Legion_col[i - 1].seek + Legion_col[i - 1].length;
                Legion_col[i].length = Legion_col[i - 1].length * 4;
                Legion_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Legion_nml[0].name = "nml";
            Legion_nml[0].seek = 4845080576;
            Legion_nml[0].length = 262144;
            Legion_nml[0].seeklength = 128;
            while (i <= 3)
            {
                Legion_nml[i].name = "nml";
                Legion_nml[i].seek = Legion_nml[i - 1].seek + Legion_nml[i - 1].length;
                Legion_nml[i].length = Legion_nml[i - 1].length * 4;
                Legion_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Legion_gls[0].name = "gls";
            Legion_gls[0].seek = 4867362816;
            Legion_gls[0].length = 131072;
            Legion_gls[0].seeklength = 128;
            while (i <= 3)
            {
                Legion_gls[i].name = "gls";
                Legion_gls[i].seek = Legion_gls[i - 1].seek + Legion_gls[i - 1].length;
                Legion_gls[i].length = Legion_gls[i - 1].length * 4;
                Legion_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Legion_spc[0].name = "spc";
            Legion_spc[0].seek = 4878503936;
            Legion_spc[0].length = 131072;
            Legion_spc[0].seeklength = 128;
            while (i <= 3)
            {
                Legion_spc[i].name = "spc";
                Legion_spc[i].seek = Legion_spc[i - 1].seek + Legion_spc[i - 1].length;
                Legion_spc[i].length = Legion_spc[i - 1].length * 4;
                Legion_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Legion_ilm[0].name = "ilm";
            Legion_ilm[0].seek = 4889645056;
            Legion_ilm[0].length = 131072;
            Legion_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                Legion_ilm[i].name = "ilm";
                Legion_ilm[i].seek = Legion_ilm[i - 1].seek + Legion_ilm[i - 1].length;
                Legion_ilm[i].length = Legion_ilm[i - 1].length * 4;
                Legion_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Legion_ao[0].name = "ao";
            Legion_ao[0].seek = 4900786176;
            Legion_ao[0].length = 131072;
            Legion_ao[0].seeklength = 128;
            while (i <= 3)
            {
                Legion_ao[i].name = "ao";
                Legion_ao[i].seek = Legion_ao[i - 1].seek + Legion_ao[i - 1].length;
                Legion_ao[i].length = Legion_ao[i - 1].length * 4;
                Legion_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Legion_cav[0].name = "cav";
            Legion_cav[0].seek = 4911927296;
            Legion_cav[0].length = 131072;
            Legion_cav[0].seeklength = 128;
            while (i <= 3)
            {
                Legion_cav[i].name = "cav";
                Legion_cav[i].seek = Legion_cav[i - 1].seek + Legion_cav[i - 1].length;
                Legion_cav[i].length = Legion_cav[i - 1].length * 4;
                Legion_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}