using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Titan
{
    class BroadSword
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] BroadSword_col;
        public ReallyData[] BroadSword_nml;
        public ReallyData[] BroadSword_gls;
        public ReallyData[] BroadSword_spc;
        public ReallyData[] BroadSword_ao;
        public ReallyData[] BroadSword_cav;
        public BroadSword()
        {
            int i = 1;

            BroadSword_col = new ReallyData[3];
            BroadSword_nml = new ReallyData[3];
            BroadSword_gls = new ReallyData[3];
            BroadSword_spc = new ReallyData[3];
            BroadSword_ao = new ReallyData[3];
            BroadSword_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512
            //浪人大剑没有ilm,col和spc是BC7U

            BroadSword_col[0].name = "col";
            BroadSword_col[0].seek = 9163313152;
            BroadSword_col[0].length = 131072;
            BroadSword_col[0].seeklength = 148;
            while (i <= 2)
            {
                BroadSword_col[i].name = "col";
                BroadSword_col[i].seek = BroadSword_col[i - 1].seek + BroadSword_col[i - 1].length;
                BroadSword_col[i].length = BroadSword_col[i - 1].length * 4;
                BroadSword_col[i].seeklength = 148;
                i++;
            }
            i = 1;

            BroadSword_nml[0].name = "nml";
            BroadSword_nml[0].seek = 9166065664;
            BroadSword_nml[0].length = 262144;
            BroadSword_nml[0].seeklength = 128;
            while (i <= 2)
            {
                BroadSword_nml[i].name = "nml";
                BroadSword_nml[i].seek = BroadSword_nml[i - 1].seek + BroadSword_nml[i - 1].length;
                BroadSword_nml[i].length = BroadSword_nml[i - 1].length * 4;
                BroadSword_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            BroadSword_gls[0].name = "gls";
            BroadSword_gls[0].seek = 9168818176;
            BroadSword_gls[0].length = 65536;
            BroadSword_gls[0].seeklength = 128;
            while (i <= 2)
            {
                BroadSword_gls[i].name = "gls";
                BroadSword_gls[i].seek = BroadSword_gls[i - 1].seek + BroadSword_gls[i - 1].length;
                BroadSword_gls[i].length = BroadSword_gls[i - 1].length * 4;
                BroadSword_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            BroadSword_spc[0].name = "spc";
            BroadSword_spc[0].seek = 9170194432;
            BroadSword_spc[0].length = 131072;
            BroadSword_spc[0].seeklength = 148;
            while (i <= 2)
            {
                BroadSword_spc[i].name = "spc";
                BroadSword_spc[i].seek = BroadSword_spc[i - 1].seek + BroadSword_spc[i - 1].length;
                BroadSword_spc[i].length = BroadSword_spc[i - 1].length * 4;
                BroadSword_spc[i].seeklength = 148;
                i++;
            }
            i = 1;

            BroadSword_ao[0].name = "ao";
            BroadSword_ao[0].seek = 9172946944;
            BroadSword_ao[0].length = 65536;
            BroadSword_ao[0].seeklength = 128;
            while (i <= 2)
            {
                BroadSword_ao[i].name = "ao";
                BroadSword_ao[i].seek = BroadSword_ao[i - 1].seek + BroadSword_ao[i - 1].length;
                BroadSword_ao[i].length = BroadSword_ao[i - 1].length * 4;
                BroadSword_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            BroadSword_cav[0].name = "cav";
            BroadSword_cav[0].seek = 9174323200;
            BroadSword_cav[0].length = 65536;
            BroadSword_cav[0].seeklength = 128;
            while (i <= 2)
            {
                BroadSword_cav[i].name = "cav";
                BroadSword_cav[i].seek = BroadSword_cav[i - 1].seek + BroadSword_cav[i - 1].length;
                BroadSword_cav[i].length = BroadSword_cav[i - 1].length * 4;
                BroadSword_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
