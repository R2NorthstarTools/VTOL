using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class Tone
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Tone_col;
        public ReallyData[] Tone_nml;
        public ReallyData[] Tone_gls;
        public ReallyData[] Tone_spc;
        public ReallyData[] Tone_ilm;
        public ReallyData[] Tone_ao;
        public ReallyData[] Tone_cav;
        public Tone()
        {
            int i = 1;

            Tone_col = new ReallyData[4];
            Tone_nml = new ReallyData[4];
            Tone_gls = new ReallyData[4];
            Tone_spc = new ReallyData[4];
            Tone_ilm = new ReallyData[4];
            Tone_ao = new ReallyData[4];
            Tone_cav = new ReallyData[4];
            //3为4096x4096,2为2048x2048,1为1024x1024,0为512x512
            Tone_col[0].name = "col";
            Tone_col[0].seek = 7174885376;
            Tone_col[0].length = 131072;
            Tone_col[0].seeklength = 128;
            while (i <= 3)
            {
                Tone_col[i].name = "col";
                Tone_col[i].seek = Tone_col[i - 1].seek + Tone_col[i - 1].length;
                Tone_col[i].length = Tone_col[i - 1].length * 4;
                Tone_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Tone_nml[0].name = "nml";
            Tone_nml[0].seek = 7186092032;
            Tone_nml[0].length = 262144;
            Tone_nml[0].seeklength = 128;
            while (i <= 3)
            {
                Tone_nml[i].name = "nml";
                Tone_nml[i].seek = Tone_nml[i - 1].seek + Tone_nml[i - 1].length;
                Tone_nml[i].length = Tone_nml[i - 1].length * 4;
                Tone_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Tone_gls[0].name = "gls";
            Tone_gls[0].seek = 7208374272;
            Tone_gls[0].length = 131072;
            Tone_gls[0].seeklength = 128;
            while (i <= 3)
            {
                Tone_gls[i].name = "gls";
                Tone_gls[i].seek = Tone_gls[i - 1].seek + Tone_gls[i - 1].length;
                Tone_gls[i].length = Tone_gls[i - 1].length * 4;
                Tone_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Tone_spc[0].name = "spc";
            Tone_spc[0].seek = 7219515392;
            Tone_spc[0].length = 131072;
            Tone_spc[0].seeklength = 128;
            while (i <= 3)
            {
                Tone_spc[i].name = "spc";
                Tone_spc[i].seek = Tone_spc[i - 1].seek + Tone_spc[i - 1].length;
                Tone_spc[i].length = Tone_spc[i - 1].length * 4;
                Tone_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Tone_ilm[0].name = "ilm";
            Tone_ilm[0].seek = 7230656512;
            Tone_ilm[0].length = 131072;
            Tone_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                Tone_ilm[i].name = "ilm";
                Tone_ilm[i].seek = Tone_ilm[i - 1].seek + Tone_ilm[i - 1].length;
                Tone_ilm[i].length = Tone_ilm[i - 1].length * 4;
                Tone_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Tone_ao[0].name = "ao";
            Tone_ao[0].seek = 7241797632;
            Tone_ao[0].length = 131072;
            Tone_ao[0].seeklength = 128;
            while (i <= 3)
            {
                Tone_ao[i].name = "ao";
                Tone_ao[i].seek = Tone_ao[i - 1].seek + Tone_ao[i - 1].length;
                Tone_ao[i].length = Tone_ao[i - 1].length * 4;
                Tone_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Tone_cav[0].name = "cav";
            Tone_cav[0].seek = 7252938752;
            Tone_cav[0].length = 131072;
            Tone_cav[0].seeklength = 128;
            while (i <= 3)
            {
                Tone_cav[i].name = "cav";
                Tone_cav[i].seek = Tone_cav[i - 1].seek + Tone_cav[i - 1].length;
                Tone_cav[i].length = Tone_cav[i - 1].length * 4;
                Tone_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}