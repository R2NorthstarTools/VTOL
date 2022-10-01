using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.LightMachineGun
{
    class Spitfire
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Spitfire_col;
        public ReallyData[] Spitfire_nml;
        public ReallyData[] Spitfire_gls;
        public ReallyData[] Spitfire_spc;
        public ReallyData[] Spitfire_ilm;
        public ReallyData[] Spitfire_ao;
        public ReallyData[] Spitfire_cav;
        public Spitfire()
        {
            int i = 1;

            Spitfire_col = new ReallyData[3];
            Spitfire_nml = new ReallyData[3];
            Spitfire_gls = new ReallyData[3];
            Spitfire_spc = new ReallyData[3];
            Spitfire_ilm = new ReallyData[3];
            Spitfire_ao = new ReallyData[3];
            Spitfire_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            Spitfire_col[0].name = "col";
            Spitfire_col[0].seek = 9986445312;
            Spitfire_col[0].length = 131072;
            Spitfire_col[0].seeklength = 128;
            while (i <= 2)
            {
                Spitfire_col[i].name = "col";
                Spitfire_col[i].seek = Spitfire_col[i - 1].seek + Spitfire_col[i - 1].length;
                Spitfire_col[i].length = Spitfire_col[i - 1].length * 4;
                Spitfire_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Spitfire_nml[0].name = "nml";
            Spitfire_nml[0].seek = 9989263360;
            Spitfire_nml[0].length = 262144;
            Spitfire_nml[0].seeklength = 128;
            while (i <= 2)
            {
                Spitfire_nml[i].name = "nml";
                Spitfire_nml[i].seek = Spitfire_nml[i - 1].seek + Spitfire_nml[i - 1].length;
                Spitfire_nml[i].length = Spitfire_nml[i - 1].length * 4;
                Spitfire_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Spitfire_gls[0].name = "gls";
            Spitfire_gls[0].seek = 9994768384;
            Spitfire_gls[0].length = 131072;
            Spitfire_gls[0].seeklength = 128;
            while (i <= 2)
            {
                Spitfire_gls[i].name = "gls";
                Spitfire_gls[i].seek = Spitfire_gls[i - 1].seek + Spitfire_gls[i - 1].length;
                Spitfire_gls[i].length = Spitfire_gls[i - 1].length * 4;
                Spitfire_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Spitfire_spc[0].name = "spc";
            Spitfire_spc[0].seek = 9997520896;
            Spitfire_spc[0].length = 131072;
            Spitfire_spc[0].seeklength = 128;
            while (i <= 2)
            {
                Spitfire_spc[i].name = "spc";
                Spitfire_spc[i].seek = Spitfire_spc[i - 1].seek + Spitfire_spc[i - 1].length;
                Spitfire_spc[i].length = Spitfire_spc[i - 1].length * 4;
                Spitfire_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Spitfire_ilm[0].name = "ilm";
            Spitfire_ilm[0].seek = 10000273408;
            Spitfire_ilm[0].length = 131072;
            Spitfire_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                Spitfire_ilm[i].name = "ilm";
                Spitfire_ilm[i].seek = Spitfire_ilm[i - 1].seek + Spitfire_ilm[i - 1].length;
                Spitfire_ilm[i].length = Spitfire_ilm[i - 1].length * 4;
                Spitfire_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Spitfire_ao[0].name = "ao";
            Spitfire_ao[0].seek = 10003025920;
            Spitfire_ao[0].length = 131072;
            Spitfire_ao[0].seeklength = 128;
            while (i <= 2)
            {
                Spitfire_ao[i].name = "ao";
                Spitfire_ao[i].seek = Spitfire_ao[i - 1].seek + Spitfire_ao[i - 1].length;
                Spitfire_ao[i].length = Spitfire_ao[i - 1].length * 4;
                Spitfire_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Spitfire_cav[0].name = "cav";
            Spitfire_cav[0].seek = 10005778432;
            Spitfire_cav[0].length = 131072;
            Spitfire_cav[0].seeklength = 128;
            while (i <= 2)
            {
                Spitfire_cav[i].name = "cav";
                Spitfire_cav[i].seek = Spitfire_cav[i - 1].seek + Spitfire_cav[i - 1].length;
                Spitfire_cav[i].length = Spitfire_cav[i - 1].length * 4;
                Spitfire_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
