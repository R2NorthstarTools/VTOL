using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class Thunderbolt
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Thunderbolt_col;
        public ReallyData[] Thunderbolt_nml;
        public ReallyData[] Thunderbolt_gls;
        public ReallyData[] Thunderbolt_spc;
        public ReallyData[] Thunderbolt_ilm;
        public ReallyData[] Thunderbolt_ao;
        public ReallyData[] Thunderbolt_cav;
        public Thunderbolt()
        {
            int i = 1;

            Thunderbolt_col = new ReallyData[3];
            Thunderbolt_nml = new ReallyData[3];
            Thunderbolt_gls = new ReallyData[3];
            Thunderbolt_spc = new ReallyData[3];
            Thunderbolt_ilm = new ReallyData[3];
            Thunderbolt_ao = new ReallyData[3];
            Thunderbolt_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            Thunderbolt_col[0].name = "col";
            Thunderbolt_col[0].seek = 9258405888;
            Thunderbolt_col[0].length = 131072;
            Thunderbolt_col[0].seeklength = 128;
            while (i <= 2)
            {
                Thunderbolt_col[i].name = "col";
                Thunderbolt_col[i].seek = Thunderbolt_col[i - 1].seek + Thunderbolt_col[i - 1].length;
                Thunderbolt_col[i].length = Thunderbolt_col[i - 1].length * 4;
                Thunderbolt_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Thunderbolt_nml[0].name = "nml";
            Thunderbolt_nml[0].seek = 9261223936;
            Thunderbolt_nml[0].length = 262144;
            Thunderbolt_nml[0].seeklength = 128;
            while (i <= 2)
            {
                Thunderbolt_nml[i].name = "nml";
                Thunderbolt_nml[i].seek = Thunderbolt_nml[i - 1].seek + Thunderbolt_nml[i - 1].length;
                Thunderbolt_nml[i].length = Thunderbolt_nml[i - 1].length * 4;
                Thunderbolt_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Thunderbolt_gls[0].name = "gls";
            Thunderbolt_gls[0].seek = 9266728960;
            Thunderbolt_gls[0].length = 131072;
            Thunderbolt_gls[0].seeklength = 128;
            while (i <= 2)
            {
                Thunderbolt_gls[i].name = "gls";
                Thunderbolt_gls[i].seek = Thunderbolt_gls[i - 1].seek + Thunderbolt_gls[i - 1].length;
                Thunderbolt_gls[i].length = Thunderbolt_gls[i - 1].length * 4;
                Thunderbolt_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Thunderbolt_spc[0].name = "spc";
            Thunderbolt_spc[0].seek = 9269481472;
            Thunderbolt_spc[0].length = 131072;
            Thunderbolt_spc[0].seeklength = 128;
            while (i <= 2)
            {
                Thunderbolt_spc[i].name = "spc";
                Thunderbolt_spc[i].seek = Thunderbolt_spc[i - 1].seek + Thunderbolt_spc[i - 1].length;
                Thunderbolt_spc[i].length = Thunderbolt_spc[i - 1].length * 4;
                Thunderbolt_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Thunderbolt_ilm[0].name = "ilm";
            Thunderbolt_ilm[0].seek = 9272233984;
            Thunderbolt_ilm[0].length = 131072;
            Thunderbolt_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                Thunderbolt_ilm[i].name = "ilm";
                Thunderbolt_ilm[i].seek = Thunderbolt_ilm[i - 1].seek + Thunderbolt_ilm[i - 1].length;
                Thunderbolt_ilm[i].length = Thunderbolt_ilm[i - 1].length * 4;
                Thunderbolt_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Thunderbolt_ao[0].name = "ao";
            Thunderbolt_ao[0].seek = 9274986496;
            Thunderbolt_ao[0].length = 131072;
            Thunderbolt_ao[0].seeklength = 128;
            while (i <= 2)
            {
                Thunderbolt_ao[i].name = "ao";
                Thunderbolt_ao[i].seek = Thunderbolt_ao[i - 1].seek + Thunderbolt_ao[i - 1].length;
                Thunderbolt_ao[i].length = Thunderbolt_ao[i - 1].length * 4;
                Thunderbolt_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Thunderbolt_cav[0].name = "cav";
            Thunderbolt_cav[0].seek = 9277739008;
            Thunderbolt_cav[0].length = 131072;
            Thunderbolt_cav[0].seeklength = 128;
            while (i <= 2)
            {
                Thunderbolt_cav[i].name = "cav";
                Thunderbolt_cav[i].seek = Thunderbolt_cav[i - 1].seek + Thunderbolt_cav[i - 1].length;
                Thunderbolt_cav[i].length = Thunderbolt_cav[i - 1].length * 4;
                Thunderbolt_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
