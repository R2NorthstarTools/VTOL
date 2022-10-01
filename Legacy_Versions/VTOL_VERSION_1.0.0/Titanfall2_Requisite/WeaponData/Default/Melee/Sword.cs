using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Melee
{
    class Sword
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Sword_col;
        public ReallyData[] Sword_nml;
        public ReallyData[] Sword_gls;
        public ReallyData[] Sword_spc;
        public ReallyData[] Sword_ao;
        public Sword()
        {
            int i = 1;

            Sword_col = new ReallyData[3];
            Sword_nml = new ReallyData[3];
            Sword_gls = new ReallyData[3];
            Sword_spc = new ReallyData[3];
            Sword_ao = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512
            //铁驭剑没有ilm和cav贴图

            Sword_col[0].name = "col";
            Sword_col[0].seek = 8808697856;
            Sword_col[0].length = 131072;
            Sword_col[0].seeklength = 128;
            while (i <= 1)
            {
                Sword_col[i].name = "col";
                Sword_col[i].seek = Sword_col[i - 1].seek + Sword_col[i - 1].length;
                Sword_col[i].length = Sword_col[i - 1].length * 4;
                Sword_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Sword_nml[0].name = "nml";
            Sword_nml[0].seek = 8809418752;
            Sword_nml[0].length = 262144;
            Sword_nml[0].seeklength = 128;
            while (i <= 1)
            {
                Sword_nml[i].name = "nml";
                Sword_nml[i].seek = Sword_nml[i - 1].seek + Sword_nml[i - 1].length;
                Sword_nml[i].length = Sword_nml[i - 1].length * 4;
                Sword_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Sword_gls[0].name = "gls";
            Sword_gls[0].seek = 8810729472;
            Sword_gls[0].length = 131072;
            Sword_gls[0].seeklength = 128;
            while (i <= 1)
            {
                Sword_gls[i].name = "gls";
                Sword_gls[i].seek = Sword_gls[i - 1].seek + Sword_gls[i - 1].length;
                Sword_gls[i].length = Sword_gls[i - 1].length * 4;
                Sword_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Sword_spc[0].name = "spc";
            Sword_spc[0].seek = 8811384832;
            Sword_spc[0].length = 131072;
            Sword_spc[0].seeklength = 128;
            while (i <= 1)
            {
                Sword_spc[i].name = "spc";
                Sword_spc[i].seek = Sword_spc[i - 1].seek + Sword_spc[i - 1].length;
                Sword_spc[i].length = Sword_spc[i - 1].length * 4;
                Sword_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Sword_ao[0].name = "ao";
            Sword_ao[0].seek = 8812040192;
            Sword_ao[0].length = 131072;
            Sword_ao[0].seeklength = 128;
            while (i <= 1)
            {
                Sword_ao[i].name = "ao";
                Sword_ao[i].seek = Sword_ao[i - 1].seek + Sword_ao[i - 1].length;
                Sword_ao[i].length = Sword_ao[i - 1].length * 4;
                Sword_ao[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
