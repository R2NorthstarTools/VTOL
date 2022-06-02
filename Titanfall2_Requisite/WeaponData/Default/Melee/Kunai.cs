using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Melee
{
    class Kunai
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Kunai_col;
        public ReallyData[] Kunai_nml;
        public ReallyData[] Kunai_gls;
        public ReallyData[] Kunai_spc;
        public ReallyData[] Kunai_ao;
        public Kunai()
        {
            int i = 1;

            Kunai_col = new ReallyData[3];
            Kunai_nml = new ReallyData[3];
            Kunai_gls = new ReallyData[3];
            Kunai_spc = new ReallyData[3];
            Kunai_ao = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512
            //苦无没有ilm和cav贴图

            Kunai_col[0].name = "col";
            Kunai_col[0].seek = 9936244736;
            Kunai_col[0].length = 131072;
            Kunai_col[0].seeklength = 128;
            while (i <= 2)
            {
                Kunai_col[i].name = "col";
                Kunai_col[i].seek = Kunai_col[i - 1].seek + Kunai_col[i - 1].length;
                Kunai_col[i].length = Kunai_col[i - 1].length * 4;
                Kunai_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Kunai_nml[0].name = "nml";
            Kunai_nml[0].seek = 9939062784;
            Kunai_nml[0].length = 262144;
            Kunai_nml[0].seeklength = 128;
            while (i <= 2)
            {
                Kunai_nml[i].name = "nml";
                Kunai_nml[i].seek = Kunai_nml[i - 1].seek + Kunai_nml[i - 1].length;
                Kunai_nml[i].length = Kunai_nml[i - 1].length * 4;
                Kunai_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Kunai_gls[0].name = "gls";
            Kunai_gls[0].seek = 9944567808;
            Kunai_gls[0].length = 131072;
            Kunai_gls[0].seeklength = 128;
            while (i <= 2)
            {
                Kunai_gls[i].name = "gls";
                Kunai_gls[i].seek = Kunai_gls[i - 1].seek + Kunai_gls[i - 1].length;
                Kunai_gls[i].length = Kunai_gls[i - 1].length * 4;
                Kunai_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Kunai_spc[0].name = "spc";
            Kunai_spc[0].seek = 9947320320;
            Kunai_spc[0].length = 131072;
            Kunai_spc[0].seeklength = 128;
            while (i <= 2)
            {
                Kunai_spc[i].name = "spc";
                Kunai_spc[i].seek = Kunai_spc[i - 1].seek + Kunai_spc[i - 1].length;
                Kunai_spc[i].length = Kunai_spc[i - 1].length * 4;
                Kunai_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Kunai_ao[0].name = "ao";
            Kunai_ao[0].seek = 9950072832;
            Kunai_ao[0].length = 131072;
            Kunai_ao[0].seeklength = 128;
            while (i <= 2)
            {
                Kunai_ao[i].name = "ao";
                Kunai_ao[i].seek = Kunai_ao[i - 1].seek + Kunai_ao[i - 1].length;
                Kunai_ao[i].length = Kunai_ao[i - 1].length * 4;
                Kunai_ao[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
