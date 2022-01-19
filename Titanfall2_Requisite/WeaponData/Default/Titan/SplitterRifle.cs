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
        public ReallyData[] SplitterRifle_ao;
        public ReallyData[] SplitterRifle_cav;
        public SplitterRifle()
        {
            int i = 1;

            SplitterRifle_col = new ReallyData[3];
            SplitterRifle_nml = new ReallyData[3];
            SplitterRifle_gls = new ReallyData[3];
            SplitterRifle_spc = new ReallyData[3];
            SplitterRifle_ao = new ReallyData[3];
            SplitterRifle_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512
            //分裂枪没有ilm

            SplitterRifle_col[0].name = "col";
            SplitterRifle_col[0].seek = 9119141888;
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
            SplitterRifle_nml[0].seek = 9121959936;
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
            SplitterRifle_gls[0].seek = 9127464960;
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
            SplitterRifle_spc[0].seek = 9130217472;
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


            SplitterRifle_ao[0].name = "ao";
            SplitterRifle_ao[0].seek = 9132969984;
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
            SplitterRifle_cav[0].seek = 9135722496;
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
