using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class Monarch
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Monarch_col;
        //public ReallyData[] Monarch_nml;
        public ReallyData[] Monarch_gls;
        public ReallyData[] Monarch_spc;
        //public ReallyData[] Monarch_ilm;
        public ReallyData[] Monarch_ao;
        //public ReallyData[] Monarch_cav;
        public Monarch()
        {
            int i = 1;

            Monarch_col = new ReallyData[4];
            //Monarch_nml = new ReallyData[4];
            Monarch_gls = new ReallyData[4];
            Monarch_spc = new ReallyData[4];
            //Monarch_ilm = new ReallyData[4];
            Monarch_ao = new ReallyData[4];
            //Monarch_cav = new ReallyData[4];
            //3为4096x4096,2为2048x2048,1为1024x1024,0为512x512
            //Cant find find HeX code for normal, ilm and cav map because it blank images
            Monarch_col[0].name = "col";
            Monarch_col[0].seek = 166662144;
            Monarch_col[0].length = 131072;
            Monarch_col[0].seeklength = 128;
            while (i <= 3)
            {
                Monarch_col[i].name = "col";
                Monarch_col[i].seek = Monarch_col[i - 1].seek + Monarch_col[i - 1].length;
                Monarch_col[i].length = Monarch_col[i - 1].length * 4;
                Monarch_col[i].seeklength = 128;
                i++;
            }
            i = 1;
/* 
            Monarch_nml[0].name = "nml";
            Monarch_nml[0].seek = 7186092032;
            Monarch_nml[0].length = 262144;
            Monarch_nml[0].seeklength = 128;
            while (i <= 3)
            {
                Monarch_nml[i].name = "nml";
                Monarch_nml[i].seek = Monarch_nml[i - 1].seek + Monarch_nml[i - 1].length;
                Monarch_nml[i].length = Monarch_nml[i - 1].length * 4;
                Monarch_nml[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
            Monarch_gls[0].name = "gls";
            Monarch_gls[0].seek = 177803264;
            Monarch_gls[0].length = 131072;
            Monarch_gls[0].seeklength = 128;
            while (i <= 3)
            {
                Monarch_gls[i].name = "gls";
                Monarch_gls[i].seek = Monarch_gls[i - 1].seek + Monarch_gls[i - 1].length;
                Monarch_gls[i].length = Monarch_gls[i - 1].length * 4;
                Monarch_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Monarch_spc[0].name = "spc";
            Monarch_spc[0].seek = 188944384;
            Monarch_spc[0].length = 131072;
            Monarch_spc[0].seeklength = 128;
            while (i <= 3)
            {
                Monarch_spc[i].name = "spc";
                Monarch_spc[i].seek = Monarch_spc[i - 1].seek + Monarch_spc[i - 1].length;
                Monarch_spc[i].length = Monarch_spc[i - 1].length * 4;
                Monarch_spc[i].seeklength = 128;
                i++;
            }
            i = 1;
/*
            Monarch_ilm[0].name = "ilm";
            Monarch_ilm[0].seek = 7230656512;
            Monarch_ilm[0].length = 131072;
            Monarch_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                Monarch_ilm[i].name = "ilm";
                Monarch_ilm[i].seek = Monarch_ilm[i - 1].seek + Monarch_ilm[i - 1].length;
                Monarch_ilm[i].length = Monarch_ilm[i - 1].length * 4;
                Monarch_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
            Monarch_ao[0].name = "ao";
            Monarch_ao[0].seek = 7241797632;
            Monarch_ao[0].length = 131072;
            Monarch_ao[0].seeklength = 128;
            while (i <= 3)
            {
                Monarch_ao[i].name = "ao";
                Monarch_ao[i].seek = Monarch_ao[i - 1].seek + Monarch_ao[i - 1].length;
                Monarch_ao[i].length = Monarch_ao[i - 1].length * 4;
                Monarch_ao[i].seeklength = 128;
                i++;
            }
            i = 1;
/*
            Monarch_cav[0].name = "cav";
            Monarch_cav[0].seek = 7252938752;
            Monarch_cav[0].length = 131072;
            Monarch_cav[0].seeklength = 128;
            while (i <= 3)
            {
                Monarch_cav[i].name = "cav";
                Monarch_cav[i].seek = Monarch_cav[i - 1].seek + Monarch_cav[i - 1].length;
                Monarch_cav[i].length = Monarch_cav[i - 1].length * 4;
                Monarch_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
        }
    }
}