using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Pistol
{
    class SmartPistol
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] SmartPistol_col;
        public ReallyData[] SmartPistol_nml;
        public ReallyData[] SmartPistol_gls;
        public ReallyData[] SmartPistol_spc;
        public ReallyData[] SmartPistol_ilm;
        public ReallyData[] SmartPistol_ao;
        public ReallyData[] SmartPistol_cav;
        public SmartPistol()
        {
            int i = 1;

            SmartPistol_col = new ReallyData[3];
            SmartPistol_nml = new ReallyData[3];
            SmartPistol_gls = new ReallyData[3];
            SmartPistol_spc = new ReallyData[3];
            SmartPistol_ilm = new ReallyData[3];
            SmartPistol_ao = new ReallyData[3];
            SmartPistol_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            SmartPistol_col[0].name = "col";
            SmartPistol_col[0].seek = 9980481536;
            SmartPistol_col[0].length = 131072;
            SmartPistol_col[0].seeklength = 128;
            while (i <= 1)
            {
                SmartPistol_col[i].name = "col";
                SmartPistol_col[i].seek = SmartPistol_col[i - 1].seek + SmartPistol_col[i - 1].length;
                SmartPistol_col[i].length = SmartPistol_col[i - 1].length * 4;
                SmartPistol_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            SmartPistol_nml[0].name = "nml";
            SmartPistol_nml[0].seek = 9981202432;
            SmartPistol_nml[0].length = 262144;
            SmartPistol_nml[0].seeklength = 128;
            while (i <= 1)
            {
                SmartPistol_nml[i].name = "nml";
                SmartPistol_nml[i].seek = SmartPistol_nml[i - 1].seek + SmartPistol_nml[i - 1].length;
                SmartPistol_nml[i].length = SmartPistol_nml[i - 1].length * 4;
                SmartPistol_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            SmartPistol_gls[0].name = "gls";
            SmartPistol_gls[0].seek = 9982513152;
            SmartPistol_gls[0].length = 131072;
            SmartPistol_gls[0].seeklength = 128;
            while (i <= 1)
            {
                SmartPistol_gls[i].name = "gls";
                SmartPistol_gls[i].seek = SmartPistol_gls[i - 1].seek + SmartPistol_gls[i - 1].length;
                SmartPistol_gls[i].length = SmartPistol_gls[i - 1].length * 4;
                SmartPistol_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            SmartPistol_spc[0].name = "spc";
            SmartPistol_spc[0].seek = 9983168512;
            SmartPistol_spc[0].length = 131072;
            SmartPistol_spc[0].seeklength = 128;
            while (i <= 1)
            {
                SmartPistol_spc[i].name = "spc";
                SmartPistol_spc[i].seek = SmartPistol_spc[i - 1].seek + SmartPistol_spc[i - 1].length;
                SmartPistol_spc[i].length = SmartPistol_spc[i - 1].length * 4;
                SmartPistol_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            SmartPistol_ilm[0].name = "ilm";
            SmartPistol_ilm[0].seek = 9983823872;
            SmartPistol_ilm[0].length = 131072;
            SmartPistol_ilm[0].seeklength = 128;
            while (i <= 1)
            {
                SmartPistol_ilm[i].name = "ilm";
                SmartPistol_ilm[i].seek = SmartPistol_ilm[i - 1].seek + SmartPistol_ilm[i - 1].length;
                SmartPistol_ilm[i].length = SmartPistol_ilm[i - 1].length * 4;
                SmartPistol_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            SmartPistol_ao[0].name = "ao";
            SmartPistol_ao[0].seek = 9984479232;
            SmartPistol_ao[0].length = 131072;
            SmartPistol_ao[0].seeklength = 128;
            while (i <= 1)
            {
                SmartPistol_ao[i].name = "ao";
                SmartPistol_ao[i].seek = SmartPistol_ao[i - 1].seek + SmartPistol_ao[i - 1].length;
                SmartPistol_ao[i].length = SmartPistol_ao[i - 1].length * 4;
                SmartPistol_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            SmartPistol_cav[0].name = "cav";
            SmartPistol_cav[0].seek = 9985134592;
            SmartPistol_cav[0].length = 131072;
            SmartPistol_cav[0].seeklength = 128;
            while (i <= 1)
            {
                SmartPistol_cav[i].name = "cav";
                SmartPistol_cav[i].seek = SmartPistol_cav[i - 1].seek + SmartPistol_cav[i - 1].length;
                SmartPistol_cav[i].length = SmartPistol_cav[i - 1].length * 4;
                SmartPistol_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
