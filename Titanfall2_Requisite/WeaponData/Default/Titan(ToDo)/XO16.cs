using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Titan
{
    class XO16
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] XO16_col;
        public ReallyData[] XO16_nml;
        public ReallyData[] XO16_gls;
        public ReallyData[] XO16_spc;
        public ReallyData[] XO16_ilm;
        public ReallyData[] XO16_ao;
        public ReallyData[] XO16_cav;
        public XO16()
        {
            int i = 1;

            XO16_col = new ReallyData[3];
            XO16_nml = new ReallyData[3];
            XO16_gls = new ReallyData[3];
            XO16_spc = new ReallyData[3];
            XO16_ilm = new ReallyData[3];
            XO16_ao = new ReallyData[3];
            XO16_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            XO16_col[0].name = "col";
            XO16_col[0].seek = 9510850560;
            XO16_col[0].length = 131072;
            XO16_col[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_col[i].name = "col";
                XO16_col[i].seek = XO16_col[i - 1].seek + XO16_col[i - 1].length;
                XO16_col[i].length = XO16_col[i - 1].length * 4;
                XO16_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_nml[0].name = "nml";
            XO16_nml[0].seek = 9513668608;
            XO16_nml[0].length = 262144;
            XO16_nml[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_nml[i].name = "nml";
                XO16_nml[i].seek = XO16_nml[i - 1].seek + XO16_nml[i - 1].length;
                XO16_nml[i].length = XO16_nml[i - 1].length * 4;
                XO16_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_gls[0].name = "gls";
            XO16_gls[0].seek = 9519173632;
            XO16_gls[0].length = 131072;
            XO16_gls[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_gls[i].name = "gls";
                XO16_gls[i].seek = XO16_gls[i - 1].seek + XO16_gls[i - 1].length;
                XO16_gls[i].length = XO16_gls[i - 1].length * 4;
                XO16_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_spc[0].name = "spc";
            XO16_spc[0].seek = 9521926144;
            XO16_spc[0].length = 131072;
            XO16_spc[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_spc[i].name = "spc";
                XO16_spc[i].seek = XO16_spc[i - 1].seek + XO16_spc[i - 1].length;
                XO16_spc[i].length = XO16_spc[i - 1].length * 4;
                XO16_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_ilm[0].name = "ilm";
            XO16_ilm[0].seek = 9524678656;
            XO16_ilm[0].length = 131072;
            XO16_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_ilm[i].name = "ilm";
                XO16_ilm[i].seek = XO16_ilm[i - 1].seek + XO16_ilm[i - 1].length;
                XO16_ilm[i].length = XO16_ilm[i - 1].length * 4;
                XO16_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_ao[0].name = "ao";
            XO16_ao[0].seek = 9527431168;
            XO16_ao[0].length = 131072;
            XO16_ao[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_ao[i].name = "ao";
                XO16_ao[i].seek = XO16_ao[i - 1].seek + XO16_ao[i - 1].length;
                XO16_ao[i].length = XO16_ao[i - 1].length * 4;
                XO16_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_cav[0].name = "cav";
            XO16_cav[0].seek = 9530183680;
            XO16_cav[0].length = 131072;
            XO16_cav[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_cav[i].name = "cav";
                XO16_cav[i].seek = XO16_cav[i - 1].seek + XO16_cav[i - 1].length;
                XO16_cav[i].length = XO16_cav[i - 1].length * 4;
                XO16_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
