using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class PrimeLegion
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] PrimeLegion_col;
        public ReallyData[] PrimeLegion_nml;
        public ReallyData[] PrimeLegion_gls;
        public ReallyData[] PrimeLegion_spc;
        public ReallyData[] PrimeLegion_ilm;
        public ReallyData[] PrimeLegion_ao;
        public ReallyData[] PrimeLegion_cav;
        public PrimeLegion()
        {
            int i = 1;

            PrimeLegion_col = new ReallyData[4];
            PrimeLegion_nml = new ReallyData[4];
            PrimeLegion_gls = new ReallyData[4];
            PrimeLegion_spc = new ReallyData[4];
            PrimeLegion_ilm = new ReallyData[4];
            PrimeLegion_ao = new ReallyData[4];
            PrimeLegion_cav = new ReallyData[4];
            //3为4096x4096,2为2048x2048,1为1024x1024,0为512x512
            PrimeLegion_col[0].name = "col";
            PrimeLegion_col[0].seek = 307040256;
            PrimeLegion_col[0].length = 131072;
            PrimeLegion_col[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeLegion_col[i].name = "col";
                PrimeLegion_col[i].seek = PrimeLegion_col[i - 1].seek + PrimeLegion_col[i - 1].length;
                PrimeLegion_col[i].length = PrimeLegion_col[i - 1].length * 4;
                PrimeLegion_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeLegion_nml[0].name = "nml";
            PrimeLegion_nml[0].seek = 318246912;
            PrimeLegion_nml[0].length = 262144;
            PrimeLegion_nml[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeLegion_nml[i].name = "nml";
                PrimeLegion_nml[i].seek = PrimeLegion_nml[i - 1].seek + PrimeLegion_nml[i - 1].length;
                PrimeLegion_nml[i].length = PrimeLegion_nml[i - 1].length * 4;
                PrimeLegion_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeLegion_gls[0].name = "gls";
            PrimeLegion_gls[0].seek = 340529152;
            PrimeLegion_gls[0].length = 131072;
            PrimeLegion_gls[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeLegion_gls[i].name = "gls";
                PrimeLegion_gls[i].seek = PrimeLegion_gls[i - 1].seek + PrimeLegion_gls[i - 1].length;
                PrimeLegion_gls[i].length = PrimeLegion_gls[i - 1].length * 4;
                PrimeLegion_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeLegion_spc[0].name = "spc";
            PrimeLegion_spc[0].seek = 351670272;
            PrimeLegion_spc[0].length = 131072;
            PrimeLegion_spc[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeLegion_spc[i].name = "spc";
                PrimeLegion_spc[i].seek = PrimeLegion_spc[i - 1].seek + PrimeLegion_spc[i - 1].length;
                PrimeLegion_spc[i].length = PrimeLegion_spc[i - 1].length * 4;
                PrimeLegion_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeLegion_ilm[0].name = "ilm";
            PrimeLegion_ilm[0].seek = 362811392;
            PrimeLegion_ilm[0].length = 131072;
            PrimeLegion_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeLegion_ilm[i].name = "ilm";
                PrimeLegion_ilm[i].seek = PrimeLegion_ilm[i - 1].seek + PrimeLegion_ilm[i - 1].length;
                PrimeLegion_ilm[i].length = PrimeLegion_ilm[i - 1].length * 4;
                PrimeLegion_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeLegion_ao[0].name = "ao";
            PrimeLegion_ao[0].seek = 373952512;
            PrimeLegion_ao[0].length = 131072;
            PrimeLegion_ao[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeLegion_ao[i].name = "ao";
                PrimeLegion_ao[i].seek = PrimeLegion_ao[i - 1].seek + PrimeLegion_ao[i - 1].length;
                PrimeLegion_ao[i].length = PrimeLegion_ao[i - 1].length * 4;
                PrimeLegion_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            PrimeLegion_cav[0].name = "cav";
            PrimeLegion_cav[0].seek = 385093632;
            PrimeLegion_cav[0].length = 131072;
            PrimeLegion_cav[0].seeklength = 128;
            while (i <= 3)
            {
                PrimeLegion_cav[i].name = "cav";
                PrimeLegion_cav[i].seek = PrimeLegion_cav[i - 1].seek + PrimeLegion_cav[i - 1].length;
                PrimeLegion_cav[i].length = PrimeLegion_cav[i - 1].length * 4;
                PrimeLegion_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}