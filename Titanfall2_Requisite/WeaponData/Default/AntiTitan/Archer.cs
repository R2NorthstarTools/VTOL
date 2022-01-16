using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class Archer
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Archer_col;
        public ReallyData[] Archer_nml;
        public ReallyData[] Archer_gls;
        public ReallyData[] Archer_spc;
        public ReallyData[] Archer_ilm;
        public ReallyData[] Archer_ao;
        public ReallyData[] Archer_cav;
        public Archer()
        {
            int i = 1;

            Archer_col = new ReallyData[3];
            Archer_nml = new ReallyData[3];
            Archer_gls = new ReallyData[3];
            Archer_spc = new ReallyData[3];
            Archer_ilm = new ReallyData[3];
            Archer_ao = new ReallyData[3];
            Archer_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            Archer_col[0].name = "col";
            Archer_col[0].seek = 9310900224;
            Archer_col[0].length = 262144;
            Archer_col[0].seeklength = 148;
            while (i <= 2)
            {
                Archer_col[i].name = "col";
                Archer_col[i].seek = Archer_col[i - 1].seek + Archer_col[i - 1].length;
                Archer_col[i].length = Archer_col[i - 1].length * 4;
                Archer_col[i].seeklength = 148;
                i++;
            }
            i = 1;

            Archer_nml[0].name = "nml";
            Archer_nml[0].seek = 9316470784;
            Archer_nml[0].length = 262144;
            Archer_nml[0].seeklength = 128;
            while (i <= 2)
            {
                Archer_nml[i].name = "nml";
                Archer_nml[i].seek = Archer_nml[i - 1].seek + Archer_nml[i - 1].length;
                Archer_nml[i].length = Archer_nml[i - 1].length * 4;
                Archer_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Archer_gls[0].name = "gls";
            Archer_gls[0].seek = 9321975808;
            Archer_gls[0].length = 131072;
            Archer_gls[0].seeklength = 128;
            while (i <= 2)
            {
                Archer_gls[i].name = "gls";
                Archer_gls[i].seek = Archer_gls[i - 1].seek + Archer_gls[i - 1].length;
                Archer_gls[i].length = Archer_gls[i - 1].length * 4;
                Archer_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Archer_spc[0].name = "spc";
            Archer_spc[0].seek = 9324728320;
            Archer_spc[0].length = 131072;
            Archer_spc[0].seeklength = 128;
            while (i <= 2)
            {
                Archer_spc[i].name = "spc";
                Archer_spc[i].seek = Archer_spc[i - 1].seek + Archer_spc[i - 1].length;
                Archer_spc[i].length = Archer_spc[i - 1].length * 4;
                Archer_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Archer_ilm[0].name = "ilm";
            Archer_ilm[0].seek = 9327480832;
            Archer_ilm[0].length = 131072;
            Archer_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                Archer_ilm[i].name = "ilm";
                Archer_ilm[i].seek = Archer_ilm[i - 1].seek + Archer_ilm[i - 1].length;
                Archer_ilm[i].length = Archer_ilm[i - 1].length * 4;
                Archer_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Archer_ao[0].name = "ao";
            Archer_ao[0].seek = 9330233344;
            Archer_ao[0].length = 131072;
            Archer_ao[0].seeklength = 128;
            while (i <= 2)
            {
                Archer_ao[i].name = "ao";
                Archer_ao[i].seek = Archer_ao[i - 1].seek + Archer_ao[i - 1].length;
                Archer_ao[i].length = Archer_ao[i - 1].length * 4;
                Archer_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Archer_cav[0].name = "cav";
            Archer_cav[0].seek = 9332985856;
            Archer_cav[0].length = 131072;
            Archer_cav[0].seeklength = 128;
            while (i <= 2)
            {
                Archer_cav[i].name = "cav";
                Archer_cav[i].seek = Archer_cav[i - 1].seek + Archer_cav[i - 1].length;
                Archer_cav[i].length = Archer_cav[i - 1].length * 4;
                Archer_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
