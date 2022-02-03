using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Grenadier
{
    class ColdWar
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] ColdWar_col;
        public ReallyData[] ColdWar_nml;
        public ReallyData[] ColdWar_gls;
        public ReallyData[] ColdWar_spc;
        public ReallyData[] ColdWar_ilm;
        public ReallyData[] ColdWar_ao;
        public ReallyData[] ColdWar_cav;
        public ColdWar()
        {
            int i = 1;

            ColdWar_col = new ReallyData[3];
            ColdWar_nml = new ReallyData[3];
            ColdWar_gls = new ReallyData[3];
            ColdWar_spc = new ReallyData[3];
            ColdWar_ilm = new ReallyData[3];
            ColdWar_ao = new ReallyData[3];
            ColdWar_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            ColdWar_col[0].name = "col";
            ColdWar_col[0].seek = 9865400320;
            ColdWar_col[0].length = 131072;
            ColdWar_col[0].seeklength = 128;
            while (i <= 2)
            {
                ColdWar_col[i].name = "col";
                ColdWar_col[i].seek = ColdWar_col[i - 1].seek + ColdWar_col[i - 1].length;
                ColdWar_col[i].length = ColdWar_col[i - 1].length * 4;
                ColdWar_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            ColdWar_nml[0].name = "nml";
            ColdWar_nml[0].seek = 9868218368;
            ColdWar_nml[0].length = 262144;
            ColdWar_nml[0].seeklength = 128;
            while (i <= 2)
            {
                ColdWar_nml[i].name = "nml";
                ColdWar_nml[i].seek = ColdWar_nml[i - 1].seek + ColdWar_nml[i - 1].length;
                ColdWar_nml[i].length = ColdWar_nml[i - 1].length * 4;
                ColdWar_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            ColdWar_gls[0].name = "gls";
            ColdWar_gls[0].seek = 9873723392;
            ColdWar_gls[0].length = 131072;
            ColdWar_gls[0].seeklength = 128;
            while (i <= 2)
            {
                ColdWar_gls[i].name = "gls";
                ColdWar_gls[i].seek = ColdWar_gls[i - 1].seek + ColdWar_gls[i - 1].length;
                ColdWar_gls[i].length = ColdWar_gls[i - 1].length * 4;
                ColdWar_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            ColdWar_spc[0].name = "spc";
            ColdWar_spc[0].seek = 9876475904;
            ColdWar_spc[0].length = 131072;
            ColdWar_spc[0].seeklength = 128;
            while (i <= 2)
            {
                ColdWar_spc[i].name = "spc";
                ColdWar_spc[i].seek = ColdWar_spc[i - 1].seek + ColdWar_spc[i - 1].length;
                ColdWar_spc[i].length = ColdWar_spc[i - 1].length * 4;
                ColdWar_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            ColdWar_ilm[0].name = "ilm";
            ColdWar_ilm[0].seek = 9879228416;
            ColdWar_ilm[0].length = 131072;
            ColdWar_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                ColdWar_ilm[i].name = "ilm";
                ColdWar_ilm[i].seek = ColdWar_ilm[i - 1].seek + ColdWar_ilm[i - 1].length;
                ColdWar_ilm[i].length = ColdWar_ilm[i - 1].length * 4;
                ColdWar_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            ColdWar_ao[0].name = "ao";
            ColdWar_ao[0].seek = 9881980928;
            ColdWar_ao[0].length = 131072;
            ColdWar_ao[0].seeklength = 128;
            while (i <= 2)
            {
                ColdWar_ao[i].name = "ao";
                ColdWar_ao[i].seek = ColdWar_ao[i - 1].seek + ColdWar_ao[i - 1].length;
                ColdWar_ao[i].length = ColdWar_ao[i - 1].length * 4;
                ColdWar_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            ColdWar_cav[0].name = "cav";
            ColdWar_cav[0].seek = 9884733440;
            ColdWar_cav[0].length = 131072;
            ColdWar_cav[0].seeklength = 128;
            while (i <= 2)
            {
                ColdWar_cav[i].name = "cav";
                ColdWar_cav[i].seek = ColdWar_cav[i - 1].seek + ColdWar_cav[i - 1].length;
                ColdWar_cav[i].length = ColdWar_cav[i - 1].length * 4;
                ColdWar_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
