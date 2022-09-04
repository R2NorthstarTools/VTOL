using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class ChargeRifle
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] ChargeRifle_col;
        public ReallyData[] ChargeRifle_nml;
        public ReallyData[] ChargeRifle_gls;
        public ReallyData[] ChargeRifle_spc;
        public ReallyData[] ChargeRifle_ilm;
        public ReallyData[] ChargeRifle_ao;
        public ReallyData[] ChargeRifle_cav;
        public ChargeRifle()
        {
            int i = 1;

            ChargeRifle_col = new ReallyData[3];
            ChargeRifle_nml = new ReallyData[3];
            ChargeRifle_gls = new ReallyData[3];
            ChargeRifle_spc = new ReallyData[3];
            ChargeRifle_ilm = new ReallyData[3];
            ChargeRifle_ao = new ReallyData[3];
            ChargeRifle_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            ChargeRifle_col[0].name = "col";
            ChargeRifle_col[0].seek = 9543946240;
            ChargeRifle_col[0].length = 131072;
            ChargeRifle_col[0].seeklength = 128;
            while (i <= 2)
            {
                ChargeRifle_col[i].name = "col";
                ChargeRifle_col[i].seek = ChargeRifle_col[i - 1].seek + ChargeRifle_col[i - 1].length;
                ChargeRifle_col[i].length = ChargeRifle_col[i - 1].length * 4;
                ChargeRifle_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            ChargeRifle_nml[0].name = "nml";
            ChargeRifle_nml[0].seek = 9546764288;
            ChargeRifle_nml[0].length = 262144;
            ChargeRifle_nml[0].seeklength = 128;
            while (i <= 2)
            {
                ChargeRifle_nml[i].name = "nml";
                ChargeRifle_nml[i].seek = ChargeRifle_nml[i - 1].seek + ChargeRifle_nml[i - 1].length;
                ChargeRifle_nml[i].length = ChargeRifle_nml[i - 1].length * 4;
                ChargeRifle_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            ChargeRifle_gls[0].name = "gls";
            ChargeRifle_gls[0].seek = 9552269312;
            ChargeRifle_gls[0].length = 131072;
            ChargeRifle_gls[0].seeklength = 128;
            while (i <= 2)
            {
                ChargeRifle_gls[i].name = "gls";
                ChargeRifle_gls[i].seek = ChargeRifle_gls[i - 1].seek + ChargeRifle_gls[i - 1].length;
                ChargeRifle_gls[i].length = ChargeRifle_gls[i - 1].length * 4;
                ChargeRifle_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            ChargeRifle_spc[0].name = "spc";
            ChargeRifle_spc[0].seek = 9555021824;
            ChargeRifle_spc[0].length = 131072;
            ChargeRifle_spc[0].seeklength = 128;
            while (i <= 2)
            {
                ChargeRifle_spc[i].name = "spc";
                ChargeRifle_spc[i].seek = ChargeRifle_spc[i - 1].seek + ChargeRifle_spc[i - 1].length;
                ChargeRifle_spc[i].length = ChargeRifle_spc[i - 1].length * 4;
                ChargeRifle_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            ChargeRifle_ilm[0].name = "ilm";
            ChargeRifle_ilm[0].seek = 9557774336;
            ChargeRifle_ilm[0].length = 131072;
            ChargeRifle_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                ChargeRifle_ilm[i].name = "ilm";
                ChargeRifle_ilm[i].seek = ChargeRifle_ilm[i - 1].seek + ChargeRifle_ilm[i - 1].length;
                ChargeRifle_ilm[i].length = ChargeRifle_ilm[i - 1].length * 4;
                ChargeRifle_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            ChargeRifle_ao[0].name = "ao";
            ChargeRifle_ao[0].seek = 9560526848;
            ChargeRifle_ao[0].length = 131072;
            ChargeRifle_ao[0].seeklength = 128;
            while (i <= 2)
            {
                ChargeRifle_ao[i].name = "ao";
                ChargeRifle_ao[i].seek = ChargeRifle_ao[i - 1].seek + ChargeRifle_ao[i - 1].length;
                ChargeRifle_ao[i].length = ChargeRifle_ao[i - 1].length * 4;
                ChargeRifle_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            ChargeRifle_cav[0].name = "cav";
            ChargeRifle_cav[0].seek = 9563279360;
            ChargeRifle_cav[0].length = 131072;
            ChargeRifle_cav[0].seeklength = 128;
            while (i <= 2)
            {
                ChargeRifle_cav[i].name = "cav";
                ChargeRifle_cav[i].seek = ChargeRifle_cav[i - 1].seek + ChargeRifle_cav[i - 1].length;
                ChargeRifle_cav[i].length = ChargeRifle_cav[i - 1].length * 4;
                ChargeRifle_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
