using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Grenadier
{
    class Softball
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Softball_col;
        public ReallyData[] Softball_nml;
        public ReallyData[] Softball_gls;
        public ReallyData[] Softball_spc;
        //public ReallyData[] Softball_ilm;
        public ReallyData[] Softball_ao;
        public ReallyData[] Softball_cav;
        public Softball()
        {
            int i = 1;

            Softball_col = new ReallyData[3];
            Softball_nml = new ReallyData[3];
            Softball_gls = new ReallyData[3];
            Softball_spc = new ReallyData[3];
            Softball_ao = new ReallyData[3];
            Softball_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            Softball_col[0].name = "col";
            Softball_col[0].seek = 9061076992;
            Softball_col[0].length = 131072;
            Softball_col[0].seeklength = 128;
            while (i <= 2)
            {
                Softball_col[i].name = "col";
                Softball_col[i].seek = Softball_col[i - 1].seek + Softball_col[i - 1].length;
                Softball_col[i].length = Softball_col[i - 1].length * 4;
                Softball_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Softball_nml[0].name = "nml";
            Softball_nml[0].seek = 9063895040;
            Softball_nml[0].length = 262144;
            Softball_nml[0].seeklength = 128;
            while (i <= 2)
            {
                Softball_nml[i].name = "nml";
                Softball_nml[i].seek = Softball_nml[i - 1].seek + Softball_nml[i - 1].length;
                Softball_nml[i].length = Softball_nml[i - 1].length * 4;
                Softball_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Softball_gls[0].name = "gls";
            Softball_gls[0].seek = 9069400064;
            Softball_gls[0].length = 131072;
            Softball_gls[0].seeklength = 128;
            while (i <= 2)
            {
                Softball_gls[i].name = "gls";
                Softball_gls[i].seek = Softball_gls[i - 1].seek + Softball_gls[i - 1].length;
                Softball_gls[i].length = Softball_gls[i - 1].length * 4;
                Softball_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Softball_spc[0].name = "spc";
            Softball_spc[0].seek = 9072152576;
            Softball_spc[0].length = 131072;
            Softball_spc[0].seeklength = 128;
            while (i <= 2)
            {
                Softball_spc[i].name = "spc";
                Softball_spc[i].seek = Softball_spc[i - 1].seek + Softball_spc[i - 1].length;
                Softball_spc[i].length = Softball_spc[i - 1].length * 4;
                Softball_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Softball_ao[0].name = "ao";
            Softball_ao[0].seek = 9074905088;
            Softball_ao[0].length = 131072;
            Softball_ao[0].seeklength = 128;
            while (i <= 2)
            {
                Softball_ao[i].name = "ao";
                Softball_ao[i].seek = Softball_ao[i - 1].seek + Softball_ao[i - 1].length;
                Softball_ao[i].length = Softball_ao[i - 1].length * 4;
                Softball_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Softball_cav[0].name = "cav";
            Softball_cav[0].seek = 9077657600;
            Softball_cav[0].length = 131072;
            Softball_cav[0].seeklength = 128;
            while (i <= 2)
            {
                Softball_cav[i].name = "cav";
                Softball_cav[i].seek = Softball_cav[i - 1].seek + Softball_cav[i - 1].length;
                Softball_cav[i].length = Softball_cav[i - 1].length * 4;
                Softball_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
