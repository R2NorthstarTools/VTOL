using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Shotgun
{
    class EVA8
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] EVA8_col;
        public ReallyData[] EVA8_nml;
        public ReallyData[] EVA8_gls;
        public ReallyData[] EVA8_spc;
        public ReallyData[] EVA8_ilm;
        public ReallyData[] EVA8_ao;
        public ReallyData[] EVA8_cav;
        public EVA8()
        {
            int i = 1;

            EVA8_col = new ReallyData[3];
            EVA8_nml = new ReallyData[3];
            EVA8_gls = new ReallyData[3];
            EVA8_spc = new ReallyData[3];
            EVA8_ilm = new ReallyData[3];
            EVA8_ao = new ReallyData[3];
            EVA8_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            EVA8_col[0].name = "col";
            EVA8_col[0].seek = 9647886336;
            EVA8_col[0].length = 131072;
            EVA8_col[0].seeklength = 128;
            while (i <= 2)
            {
                EVA8_col[i].name = "col";
                EVA8_col[i].seek = EVA8_col[i - 1].seek + EVA8_col[i - 1].length;
                EVA8_col[i].length = EVA8_col[i - 1].length * 4;
                EVA8_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            EVA8_nml[0].name = "nml";
            EVA8_nml[0].seek = 9650704384;
            EVA8_nml[0].length = 262144;
            EVA8_nml[0].seeklength = 128;
            while (i <= 2)
            {
                EVA8_nml[i].name = "nml";
                EVA8_nml[i].seek = EVA8_nml[i - 1].seek + EVA8_nml[i - 1].length;
                EVA8_nml[i].length = EVA8_nml[i - 1].length * 4;
                EVA8_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            EVA8_gls[0].name = "gls";
            EVA8_gls[0].seek = 9656209408;
            EVA8_gls[0].length = 131072;
            EVA8_gls[0].seeklength = 128;
            while (i <= 2)
            {
                EVA8_gls[i].name = "gls";
                EVA8_gls[i].seek = EVA8_gls[i - 1].seek + EVA8_gls[i - 1].length;
                EVA8_gls[i].length = EVA8_gls[i - 1].length * 4;
                EVA8_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            EVA8_spc[0].name = "spc";
            EVA8_spc[0].seek = 9658961920;
            EVA8_spc[0].length = 131072;
            EVA8_spc[0].seeklength = 128;
            while (i <= 2)
            {
                EVA8_spc[i].name = "spc";
                EVA8_spc[i].seek = EVA8_spc[i - 1].seek + EVA8_spc[i - 1].length;
                EVA8_spc[i].length = EVA8_spc[i - 1].length * 4;
                EVA8_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            EVA8_ilm[0].name = "ilm";
            EVA8_ilm[0].seek = 9661714432;
            EVA8_ilm[0].length = 131072;
            EVA8_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                EVA8_ilm[i].name = "ilm";
                EVA8_ilm[i].seek = EVA8_ilm[i - 1].seek + EVA8_ilm[i - 1].length;
                EVA8_ilm[i].length = EVA8_ilm[i - 1].length * 4;
                EVA8_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            EVA8_ao[0].name = "ao";
            EVA8_ao[0].seek = 9664466944;
            EVA8_ao[0].length = 131072;
            EVA8_ao[0].seeklength = 128;
            while (i <= 2)
            {
                EVA8_ao[i].name = "ao";
                EVA8_ao[i].seek = EVA8_ao[i - 1].seek + EVA8_ao[i - 1].length;
                EVA8_ao[i].length = EVA8_ao[i - 1].length * 4;
                EVA8_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            EVA8_cav[0].name = "cav";
            EVA8_cav[0].seek = 9667219456;
            EVA8_cav[0].length = 131072;
            EVA8_cav[0].seeklength = 128;
            while (i <= 2)
            {
                EVA8_cav[i].name = "cav";
                EVA8_cav[i].seek = EVA8_cav[i - 1].seek + EVA8_cav[i - 1].length;
                EVA8_cav[i].length = EVA8_cav[i - 1].length * 4;
                EVA8_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
