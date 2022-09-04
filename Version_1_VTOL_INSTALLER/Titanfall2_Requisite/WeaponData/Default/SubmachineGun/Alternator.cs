using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.SubmachineGun
{
    class Alternator
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Alternator_col;
        public ReallyData[] Alternator_nml;
        public ReallyData[] Alternator_gls;
        public ReallyData[] Alternator_spc;
        //public ReallyData[] Alternator_ilm;
        public ReallyData[] Alternator_ao;
        public ReallyData[] Alternator_cav;
        public Alternator()
        {
            int i = 1;
            Alternator_col = new ReallyData[3];
            Alternator_nml = new ReallyData[3];
            Alternator_gls = new ReallyData[3];
            Alternator_spc = new ReallyData[3];
            //ReallyData[] Alternator_ilm = new ReallyData[3];
            Alternator_ao = new ReallyData[3];
            Alternator_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            Alternator_col[0].name = "col";
            Alternator_col[0].seek = 9233567744;
            Alternator_col[0].length = 131072;
            Alternator_col[0].seeklength = 128;
            while (i <= 2)
            {
                Alternator_col[i].name = "col";
                Alternator_col[i].seek = Alternator_col[i - 1].seek + Alternator_col[i - 1].length;
                Alternator_col[i].length = Alternator_col[i - 1].length * 4;
                Alternator_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Alternator_nml[0].name = "nml";
            Alternator_nml[0].seek = 9236385792;
            Alternator_nml[0].length = 262144;
            Alternator_nml[0].seeklength = 128;
            while (i <= 2)
            {
                Alternator_nml[i].name = "nml";
                Alternator_nml[i].seek = Alternator_nml[i - 1].seek + Alternator_nml[i - 1].length;
                Alternator_nml[i].length = Alternator_nml[i - 1].length * 4;
                Alternator_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Alternator_gls[0].name = "gls";
            Alternator_gls[0].seek = 9241890816;
            Alternator_gls[0].length = 131072;
            Alternator_gls[0].seeklength = 128;
            while (i <= 2)
            {
                Alternator_gls[i].name = "gls";
                Alternator_gls[i].seek = Alternator_gls[i - 1].seek + Alternator_gls[i - 1].length;
                Alternator_gls[i].length = Alternator_gls[i - 1].length * 4;
                Alternator_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Alternator_spc[0].name = "spc";
            Alternator_spc[0].seek = 9244643328;
            Alternator_spc[0].length = 131072;
            Alternator_spc[0].seeklength = 128;
            while (i <= 2)
            {
                Alternator_spc[i].name = "spc";
                Alternator_spc[i].seek = Alternator_spc[i - 1].seek + Alternator_spc[i - 1].length;
                Alternator_spc[i].length = Alternator_spc[i - 1].length * 4;
                Alternator_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Alternator_ao[0].name = "ao";
            Alternator_ao[0].seek = 9247395840;
            Alternator_ao[0].length = 131072;
            Alternator_ao[0].seeklength = 128;
            while (i <= 2)
            {
                Alternator_ao[i].name = "ao";
                Alternator_ao[i].seek = Alternator_ao[i - 1].seek + Alternator_ao[i - 1].length;
                Alternator_ao[i].length = Alternator_ao[i - 1].length * 4;
                Alternator_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Alternator_cav[0].name = "cav";
            Alternator_cav[0].seek = 9250148352;
            Alternator_cav[0].length = 131072;
            Alternator_cav[0].seeklength = 128;
            while (i <= 2)
            {
                Alternator_cav[i].name = "cav";
                Alternator_cav[i].seek = Alternator_cav[i - 1].seek + Alternator_cav[i - 1].length;
                Alternator_cav[i].length = Alternator_cav[i - 1].length * 4;
                Alternator_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
