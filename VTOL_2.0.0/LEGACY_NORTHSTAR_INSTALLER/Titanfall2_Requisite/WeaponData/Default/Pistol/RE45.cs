using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Pistol
{
    class RE45
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] RE45_col;
        public ReallyData[] RE45_nml;
        public ReallyData[] RE45_gls;
        public ReallyData[] RE45_spc;
        public ReallyData[] RE45_ilm;
        public ReallyData[] RE45_ao;
        public ReallyData[] RE45_cav;
        public RE45()
        {
            int i = 1;

            RE45_col = new ReallyData[3];
            RE45_nml = new ReallyData[3];
            RE45_gls = new ReallyData[3];
            RE45_spc = new ReallyData[3];
            RE45_ilm = new ReallyData[3];
            RE45_ao = new ReallyData[3];
            RE45_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            RE45_col[0].name = "col";
            RE45_col[0].seek = 9928839168;
            RE45_col[0].length = 131072;
            RE45_col[0].seeklength = 128;
            while (i <= 1)
            {
                RE45_col[i].name = "col";
                RE45_col[i].seek = RE45_col[i - 1].seek + RE45_col[i - 1].length;
                RE45_col[i].length = RE45_col[i - 1].length * 4;
                RE45_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            RE45_nml[0].name = "nml";
            RE45_nml[0].seek = 9929560064;
            RE45_nml[0].length = 262144;
            RE45_nml[0].seeklength = 128;
            while (i <= 1)
            {
                RE45_nml[i].name = "nml";
                RE45_nml[i].seek = RE45_nml[i - 1].seek + RE45_nml[i - 1].length;
                RE45_nml[i].length = RE45_nml[i - 1].length * 4;
                RE45_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            RE45_gls[0].name = "gls";
            RE45_gls[0].seek = 9930870784;
            RE45_gls[0].length = 131072;
            RE45_gls[0].seeklength = 128;
            while (i <= 1)
            {
                RE45_gls[i].name = "gls";
                RE45_gls[i].seek = RE45_gls[i - 1].seek + RE45_gls[i - 1].length;
                RE45_gls[i].length = RE45_gls[i - 1].length * 4;
                RE45_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            RE45_spc[0].name = "spc";
            RE45_spc[0].seek = 9931526144;
            RE45_spc[0].length = 131072;
            RE45_spc[0].seeklength = 128;
            while (i <= 1)
            {
                RE45_spc[i].name = "spc";
                RE45_spc[i].seek = RE45_spc[i - 1].seek + RE45_spc[i - 1].length;
                RE45_spc[i].length = RE45_spc[i - 1].length * 4;
                RE45_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            RE45_ilm[0].name = "ilm";
            RE45_ilm[0].seek = 9932181504;
            RE45_ilm[0].length = 131072;
            RE45_ilm[0].seeklength = 128;
            /*while (i <= 1)
            {
                RE45_ilm[i].name = "ilm";
                RE45_ilm[i].seek = RE45_ilm[i - 1].seek + RE45_ilm[i - 1].length;
                RE45_ilm[i].length = RE45_ilm[i - 1].length * 4;
                RE45_ilm[i].seeklength = 128;
                i++;
            }*/
            i = 1;

            RE45_ao[0].name = "ao";
            RE45_ao[0].seek = 9932312576;
            RE45_ao[0].length = 131072;
            RE45_ao[0].seeklength = 128;
            while (i <= 1)
            {
                RE45_ao[i].name = "ao";
                RE45_ao[i].seek = RE45_ao[i - 1].seek + RE45_ao[i - 1].length;
                RE45_ao[i].length = RE45_ao[i - 1].length * 4;
                RE45_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            RE45_cav[0].name = "cav";
            RE45_cav[0].seek = 9932967936;
            RE45_cav[0].length = 131072;
            RE45_cav[0].seeklength = 128;
            while (i <= 1)
            {
                RE45_cav[i].name = "cav";
                RE45_cav[i].seek = RE45_cav[i - 1].seek + RE45_cav[i - 1].length;
                RE45_cav[i].length = RE45_cav[i - 1].length * 4;
                RE45_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
