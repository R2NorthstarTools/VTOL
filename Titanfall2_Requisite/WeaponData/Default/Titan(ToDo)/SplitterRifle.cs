using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Titan
{
    class SplitterRifle
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] SplitterRifle_col;
        public ReallyData[] SplitterRifle_nml;
        public ReallyData[] SplitterRifle_gls;
        public ReallyData[] SplitterRifle_spc;
        public ReallyData[] SplitterRifle_ilm;
        public ReallyData[] SplitterRifle_ao;
        public ReallyData[] SplitterRifle_cav;
        public SplitterRifle()
        {
            int i = 1;

            SplitterRifle_col = new ReallyData[3];
            SplitterRifle_nml = new ReallyData[3];
            SplitterRifle_gls = new ReallyData[3];
            SplitterRifle_spc = new ReallyData[3];
            SplitterRifle_ilm = new ReallyData[3];
            SplitterRifle_ao = new ReallyData[3];
            SplitterRifle_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            SplitterRifle_col[0].name = "col";
            SplitterRifle_col[0].seek = 9510850560;
            SplitterRifle_col[0].length = 131072;
            SplitterRifle_col[0].seeklength = 128;
            while (i <= 2)
            {
                SplitterRifle_col[i].name = "col";
                SplitterRifle_col[i].seek = SplitterRifle_col[i - 1].seek + SplitterRifle_col[i - 1].length;
                SplitterRifle_col[i].length = SplitterRifle_col[i - 1].length * 4;
                SplitterRifle_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            SplitterRifle_nml[0].name = "nml";
            SplitterRifle_nml[0].seek = 9513668608;
            SplitterRifle_nml[0].length = 262144;
            SplitterRifle_nml[0].seeklength = 128;
            while (i <= 2)
            {
                SplitterRifle_nml[i].name = "nml";
                SplitterRifle_nml[i].seek = SplitterRifle_nml[i - 1].seek + SplitterRifle_nml[i - 1].length;
                SplitterRifle_nml[i].length = SplitterRifle_nml[i - 1].length * 4;
                SplitterRifle_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            SplitterRifle_gls[0].name = "gls";
            SplitterRifle_gls[0].seek = 9519173632;
            SplitterRifle_gls[0].length = 131072;
            SplitterRifle_gls[0].seeklength = 128;
            while (i <= 2)
            {
                SplitterRifle_gls[i].name = "gls";
                SplitterRifle_gls[i].seek = SplitterRifle_gls[i - 1].seek + SplitterRifle_gls[i - 1].length;
                SplitterRifle_gls[i].length = SplitterRifle_gls[i - 1].length * 4;
                SplitterRifle_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            SplitterRifle_spc[0].name = "spc";
            SplitterRifle_spc[0].seek = 9521926144;
            SplitterRifle_spc[0].length = 131072;
            SplitterRifle_spc[0].seeklength = 128;
            while (i <= 2)
            {
                SplitterRifle_spc[i].name = "spc";
                SplitterRifle_spc[i].seek = SplitterRifle_spc[i - 1].seek + SplitterRifle_spc[i - 1].length;
                SplitterRifle_spc[i].length = SplitterRifle_spc[i - 1].length * 4;
                SplitterRifle_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            SplitterRifle_ilm[0].name = "ilm";
            SplitterRifle_ilm[0].seek = 9524678656;
            SplitterRifle_ilm[0].length = 131072;
            SplitterRifle_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                SplitterRifle_ilm[i].name = "ilm";
                SplitterRifle_ilm[i].seek = SplitterRifle_ilm[i - 1].seek + SplitterRifle_ilm[i - 1].length;
                SplitterRifle_ilm[i].length = SplitterRifle_ilm[i - 1].length * 4;
                SplitterRifle_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            SplitterRifle_ao[0].name = "ao";
            SplitterRifle_ao[0].seek = 9527431168;
            SplitterRifle_ao[0].length = 131072;
            SplitterRifle_ao[0].seeklength = 128;
            while (i <= 2)
            {
                SplitterRifle_ao[i].name = "ao";
                SplitterRifle_ao[i].seek = SplitterRifle_ao[i - 1].seek + SplitterRifle_ao[i - 1].length;
                SplitterRifle_ao[i].length = SplitterRifle_ao[i - 1].length * 4;
                SplitterRifle_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            SplitterRifle_cav[0].name = "cav";
            SplitterRifle_cav[0].seek = 9530183680;
            SplitterRifle_cav[0].length = 131072;
            SplitterRifle_cav[0].seeklength = 128;
            while (i <= 2)
            {
                SplitterRifle_cav[i].name = "cav";
                SplitterRifle_cav[i].seek = SplitterRifle_cav[i - 1].seek + SplitterRifle_cav[i - 1].length;
                SplitterRifle_cav[i].length = SplitterRifle_cav[i - 1].length * 4;
                SplitterRifle_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
