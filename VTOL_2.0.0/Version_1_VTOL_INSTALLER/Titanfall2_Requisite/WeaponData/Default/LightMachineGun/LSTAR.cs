using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.LightMachineGun
{
    class LSTAR
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] LSTAR_col;
        public ReallyData[] LSTAR_nml;
        public ReallyData[] LSTAR_gls;
        public ReallyData[] LSTAR_spc;
        public ReallyData[] LSTAR_ilm;
        public ReallyData[] LSTAR_ao;
        public ReallyData[] LSTAR_cav;
        public LSTAR()
        {
            int i = 1;

            LSTAR_col = new ReallyData[3];
            LSTAR_nml = new ReallyData[3];
            LSTAR_gls = new ReallyData[3];
            LSTAR_spc = new ReallyData[3];
            LSTAR_ilm = new ReallyData[3];
            LSTAR_ao = new ReallyData[3];
            LSTAR_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            LSTAR_col[0].name = "col";
            LSTAR_col[0].seek = 8889831424;
            LSTAR_col[0].length = 131072;
            LSTAR_col[0].seeklength = 128;
            while (i <= 2)
            {
                LSTAR_col[i].name = "col";
                LSTAR_col[i].seek = LSTAR_col[i - 1].seek + LSTAR_col[i - 1].length;
                LSTAR_col[i].length = LSTAR_col[i - 1].length * 4;
                LSTAR_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            LSTAR_nml[0].name = "nml";
            LSTAR_nml[0].seek = 8892649472;
            LSTAR_nml[0].length = 262144;
            LSTAR_nml[0].seeklength = 128;
            while (i <= 2)
            {
                LSTAR_nml[i].name = "nml";
                LSTAR_nml[i].seek = LSTAR_nml[i - 1].seek + LSTAR_nml[i - 1].length;
                LSTAR_nml[i].length = LSTAR_nml[i - 1].length * 4;
                LSTAR_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            LSTAR_gls[0].name = "gls";
            LSTAR_gls[0].seek = 8898154496;
            LSTAR_gls[0].length = 131072;
            LSTAR_gls[0].seeklength = 128;
            while (i <= 2)
            {
                LSTAR_gls[i].name = "gls";
                LSTAR_gls[i].seek = LSTAR_gls[i - 1].seek + LSTAR_gls[i - 1].length;
                LSTAR_gls[i].length = LSTAR_gls[i - 1].length * 4;
                LSTAR_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            LSTAR_spc[0].name = "spc";
            LSTAR_spc[0].seek = 8900907008;
            LSTAR_spc[0].length = 131072;
            LSTAR_spc[0].seeklength = 128;
            while (i <= 2)
            {
                LSTAR_spc[i].name = "spc";
                LSTAR_spc[i].seek = LSTAR_spc[i - 1].seek + LSTAR_spc[i - 1].length;
                LSTAR_spc[i].length = LSTAR_spc[i - 1].length * 4;
                LSTAR_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            LSTAR_ilm[0].name = "ilm";
            LSTAR_ilm[0].seek = 8903659520;
            LSTAR_ilm[0].length = 131072;
            LSTAR_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                LSTAR_ilm[i].name = "ilm";
                LSTAR_ilm[i].seek = LSTAR_ilm[i - 1].seek + LSTAR_ilm[i - 1].length;
                LSTAR_ilm[i].length = LSTAR_ilm[i - 1].length * 4;
                LSTAR_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            LSTAR_ao[0].name = "ao";
            LSTAR_ao[0].seek = 8906412032;
            LSTAR_ao[0].length = 131072;
            LSTAR_ao[0].seeklength = 128;
            while (i <= 2)
            {
                LSTAR_ao[i].name = "ao";
                LSTAR_ao[i].seek = LSTAR_ao[i - 1].seek + LSTAR_ao[i - 1].length;
                LSTAR_ao[i].length = LSTAR_ao[i - 1].length * 4;
                LSTAR_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            LSTAR_cav[0].name = "cav";
            LSTAR_cav[0].seek = 8909164544;
            LSTAR_cav[0].length = 131072;
            LSTAR_cav[0].seeklength = 128;
            while (i <= 2)
            {
                LSTAR_cav[i].name = "cav";
                LSTAR_cav[i].seek = LSTAR_cav[i - 1].seek + LSTAR_cav[i - 1].length;
                LSTAR_cav[i].length = LSTAR_cav[i - 1].length * 4;
                LSTAR_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
