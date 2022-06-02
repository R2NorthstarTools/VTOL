using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class Scorch
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Scorch_col;
        public ReallyData[] Scorch_nml;
        public ReallyData[] Scorch_gls;
        public ReallyData[] Scorch_spc;
        public ReallyData[] Scorch_ilm;
        public ReallyData[] Scorch_ao;
        public ReallyData[] Scorch_cav;
        public Scorch()
        {
            int i = 1;

            Scorch_col = new ReallyData[4];
            Scorch_nml = new ReallyData[4];
            Scorch_gls = new ReallyData[4];
            Scorch_spc = new ReallyData[4];
            Scorch_ilm = new ReallyData[4];
            Scorch_ao = new ReallyData[4];
            Scorch_cav = new ReallyData[4];
            //3为4096x4096,2为2048x2048,1为1024x1024,0为512x512
            Scorch_col[0].name = "col";
            Scorch_col[0].seek = 5279125504;
            Scorch_col[0].length = 131072;
            Scorch_col[0].seeklength = 128;
            while (i <= 3)
            {
                Scorch_col[i].name = "col";
                Scorch_col[i].seek = Scorch_col[i - 1].seek + Scorch_col[i - 1].length;
                Scorch_col[i].length = Scorch_col[i - 1].length * 4;
                Scorch_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Scorch_nml[0].name = "nml";
            Scorch_nml[0].seek = 5290332160;
            Scorch_nml[0].length = 262144;
            Scorch_nml[0].seeklength = 128;
            while (i <= 3)
            {
                Scorch_nml[i].name = "nml";
                Scorch_nml[i].seek = Scorch_nml[i - 1].seek + Scorch_nml[i - 1].length;
                Scorch_nml[i].length = Scorch_nml[i - 1].length * 4;
                Scorch_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Scorch_gls[0].name = "gls";
            Scorch_gls[0].seek = 5312614400;
            Scorch_gls[0].length = 131072;
            Scorch_gls[0].seeklength = 128;
            while (i <= 3)
            {
                Scorch_gls[i].name = "gls";
                Scorch_gls[i].seek = Scorch_gls[i - 1].seek + Scorch_gls[i - 1].length;
                Scorch_gls[i].length = Scorch_gls[i - 1].length * 4;
                Scorch_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Scorch_spc[0].name = "spc";
            Scorch_spc[0].seek = 5323755520;
            Scorch_spc[0].length = 131072;
            Scorch_spc[0].seeklength = 128;
            while (i <= 3)
            {
                Scorch_spc[i].name = "spc";
                Scorch_spc[i].seek = Scorch_spc[i - 1].seek + Scorch_spc[i - 1].length;
                Scorch_spc[i].length = Scorch_spc[i - 1].length * 4;
                Scorch_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Scorch_ilm[0].name = "ilm";
            Scorch_ilm[0].seek = 5334896640;
            Scorch_ilm[0].length = 131072;
            Scorch_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                Scorch_ilm[i].name = "ilm";
                Scorch_ilm[i].seek = Scorch_ilm[i - 1].seek + Scorch_ilm[i - 1].length;
                Scorch_ilm[i].length = Scorch_ilm[i - 1].length * 4;
                Scorch_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Scorch_ao[0].name = "ao";
            Scorch_ao[0].seek = 5346037760;
            Scorch_ao[0].length = 131072;
            Scorch_ao[0].seeklength = 128;
            while (i <= 3)
            {
                Scorch_ao[i].name = "ao";
                Scorch_ao[i].seek = Scorch_ao[i - 1].seek + Scorch_ao[i - 1].length;
                Scorch_ao[i].length = Scorch_ao[i - 1].length * 4;
                Scorch_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Scorch_cav[0].name = "cav";
            Scorch_cav[0].seek = 5357178880;
            Scorch_cav[0].length = 131072;
            Scorch_cav[0].seeklength = 128;
            while (i <= 3)
            {
                Scorch_cav[i].name = "cav";
                Scorch_cav[i].seek = Scorch_cav[i - 1].seek + Scorch_cav[i - 1].length;
                Scorch_cav[i].length = Scorch_cav[i - 1].length * 4;
                Scorch_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}