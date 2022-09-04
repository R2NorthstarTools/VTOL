using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class Northstar
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Northstar_col;
        public ReallyData[] Northstar_nml;
        public ReallyData[] Northstar_gls;
        public ReallyData[] Northstar_spc;
        public ReallyData[] Northstar_ilm;
        public ReallyData[] Northstar_ao;
        public ReallyData[] Northstar_cav;
        public Northstar()
        {
            int i = 1;

            Northstar_col = new ReallyData[4];
            Northstar_nml = new ReallyData[4];
            Northstar_gls = new ReallyData[4];
            Northstar_spc = new ReallyData[4];
            Northstar_ilm = new ReallyData[4];
            Northstar_ao = new ReallyData[4];
            Northstar_cav = new ReallyData[4];
            //3为4096x40962为2048x2048,1为1024x1024,0为512x512
            //col,spc,ilm,ao和cav是BC7U
            //nml = BC5U gls = BC4U

            Northstar_col[0].name = "col";
            Northstar_col[0].seek = 5763502080;
            Northstar_col[0].length = 262144;
            Northstar_col[0].seeklength = 148;
            while (i <= 3)
            {
                Northstar_col[i].name = "col";
                Northstar_col[i].seek = Northstar_col[i - 1].seek + Northstar_col[i - 1].length;
                Northstar_col[i].length = Northstar_col[i - 1].length * 4;
                Northstar_col[i].seeklength = 148;
                i++;
            }
            i = 1;

            Northstar_nml[0].name = "nml";
            Northstar_nml[0].seek = 5785849856;
            Northstar_nml[0].length = 262144;
            Northstar_nml[0].seeklength = 128;
            while (i <= 3)
            {
                Northstar_nml[i].name = "nml";
                Northstar_nml[i].seek = Northstar_nml[i - 1].seek + Northstar_nml[i - 1].length;
                Northstar_nml[i].length = Northstar_nml[i - 1].length * 4;
                Northstar_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Northstar_gls[0].name = "gls";
            Northstar_gls[0].seek = 5808132096;
            Northstar_gls[0].length = 131072;
            Northstar_gls[0].seeklength = 128;
            while (i <= 3)
            {
                Northstar_gls[i].name = "gls";
                Northstar_gls[i].seek = Northstar_gls[i - 1].seek + Northstar_gls[i - 1].length;
                Northstar_gls[i].length = Northstar_gls[i - 1].length * 4;
                Northstar_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Northstar_spc[0].name = "spc";
            Northstar_spc[0].seek = 5819338752;
            Northstar_spc[0].length = 262144;
            Northstar_spc[0].seeklength = 148;
            while (i <= 3)
            {
                Northstar_spc[i].name = "spc";
                Northstar_spc[i].seek = Northstar_spc[i - 1].seek + Northstar_spc[i - 1].length;
                Northstar_spc[i].length = Northstar_spc[i - 1].length * 4;
                Northstar_spc[i].seeklength = 148;
                i++;
            }
            i = 1;

            Northstar_ilm[0].name = "ilm";
            Northstar_ilm[0].seek = 5841686528;
            Northstar_ilm[0].length = 262144;
            Northstar_ilm[0].seeklength = 148;
            while (i <= 3)
            {
                Northstar_ilm[i].name = "ilm";
                Northstar_ilm[i].seek = Northstar_ilm[i - 1].seek + Northstar_ilm[i - 1].length;
                Northstar_ilm[i].length = Northstar_ilm[i - 1].length * 4;
                Northstar_ilm[i].seeklength = 148;
                i++;
            }
            i = 1;

            Northstar_ao[0].name = "ao";
            Northstar_ao[0].seek = 5864034304;
            Northstar_ao[0].length = 262144;
            Northstar_ao[0].seeklength = 148;
            while (i <= 3)
            {
                Northstar_ao[i].name = "ao";
                Northstar_ao[i].seek = Northstar_ao[i - 1].seek + Northstar_ao[i - 1].length;
                Northstar_ao[i].length = Northstar_ao[i - 1].length * 4;
                Northstar_ao[i].seeklength = 148;
                i++;
            }
            i = 1;

            Northstar_cav[0].name = "cav";
            Northstar_cav[0].seek = 5886382080;
            Northstar_cav[0].length = 262144;
            Northstar_cav[0].seeklength = 148;
            while (i <= 3)
            {
                Northstar_cav[i].name = "cav";
                Northstar_cav[i].seek = Northstar_cav[i - 1].seek + Northstar_cav[i - 1].length;
                Northstar_cav[i].length = Northstar_cav[i - 1].length * 4;
                Northstar_cav[i].seeklength = 148;
                i++;
            }
            i = 1;
        }
    }
}