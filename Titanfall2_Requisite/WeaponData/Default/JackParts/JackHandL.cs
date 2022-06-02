using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.JackParts
{
    class JackHandL
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] JackHandL_col;
        public ReallyData[] JackHandL_nml;
        public ReallyData[] JackHandL_gls;
        public ReallyData[] JackHandL_spc;
        public ReallyData[] JackHandL_ilm;
        public ReallyData[] JackHandL_ao;
        public ReallyData[] JackHandL_cav;
        public JackHandL()
        {
            int i = 1;

            JackHandL_col = new ReallyData[3];
            JackHandL_nml = new ReallyData[3];
            JackHandL_gls = new ReallyData[3];
            JackHandL_spc = new ReallyData[3];
            JackHandL_ilm = new ReallyData[3];
            JackHandL_ao = new ReallyData[3];
            JackHandL_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            JackHandL_col[0].name = "col";
            JackHandL_col[0].seek = 236261376;
            JackHandL_col[0].length = 262144;
            JackHandL_col[0].seeklength = 148;
            while (i <= 2)
            {
                JackHandL_col[i].name = "col";
                JackHandL_col[i].seek = JackHandL_col[i - 1].seek + JackHandL_col[i - 1].length;
                JackHandL_col[i].length = JackHandL_col[i - 1].length * 4;
                JackHandL_col[i].seeklength = 148;
                i++;
            }
            i = 1;

            JackHandL_nml[0].name = "nml";
            JackHandL_nml[0].seek = 241831936;
            JackHandL_nml[0].length = 262144;
            JackHandL_nml[0].seeklength = 128;
            while (i <= 2)
            {
                JackHandL_nml[i].name = "nml";
                JackHandL_nml[i].seek = JackHandL_nml[i - 1].seek + JackHandL_nml[i - 1].length;
                JackHandL_nml[i].length = JackHandL_nml[i - 1].length * 4;
                JackHandL_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            JackHandL_gls[0].name = "gls";
            JackHandL_gls[0].seek = 247336960;
            JackHandL_gls[0].length = 131072;
            JackHandL_gls[0].seeklength = 128;
            while (i <= 2)
            {
                JackHandL_gls[i].name = "gls";
                JackHandL_gls[i].seek = JackHandL_gls[i - 1].seek + JackHandL_gls[i - 1].length;
                JackHandL_gls[i].length = JackHandL_gls[i - 1].length * 4;
                JackHandL_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            JackHandL_spc[0].name = "spc";
            JackHandL_spc[0].seek = 250089472;
            JackHandL_spc[0].length = 131072;
            JackHandL_spc[0].seeklength = 128;
            while (i <= 2)
            {
                JackHandL_spc[i].name = "spc";
                JackHandL_spc[i].seek = JackHandL_spc[i - 1].seek + JackHandL_spc[i - 1].length;
                JackHandL_spc[i].length = JackHandL_spc[i - 1].length * 4;
                JackHandL_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            JackHandL_ilm[0].name = "ilm";
            JackHandL_ilm[0].seek = 252841984;
            JackHandL_ilm[0].length = 131072;
            JackHandL_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                JackHandL_ilm[i].name = "ilm";
                JackHandL_ilm[i].seek = JackHandL_ilm[i - 1].seek + JackHandL_ilm[i - 1].length;
                JackHandL_ilm[i].length = JackHandL_ilm[i - 1].length * 4;
                JackHandL_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            JackHandL_ao[0].name = "ao";
            JackHandL_ao[0].seek = 255594496;
            JackHandL_ao[0].length = 131072;
            JackHandL_ao[0].seeklength = 128;
            while (i <= 2)
            {
                JackHandL_ao[i].name = "ao";
                JackHandL_ao[i].seek = JackHandL_ao[i - 1].seek + JackHandL_ao[i - 1].length;
                JackHandL_ao[i].length = JackHandL_ao[i - 1].length * 4;
                JackHandL_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            JackHandL_cav[0].name = "cav";
            JackHandL_cav[0].seek = 258347008;
            JackHandL_cav[0].length = 131072;
            JackHandL_cav[0].seeklength = 128;
            while (i <= 2)
            {
                JackHandL_cav[i].name = "cav";
                JackHandL_cav[i].seek = JackHandL_cav[i - 1].seek + JackHandL_cav[i - 1].length;
                JackHandL_cav[i].length = JackHandL_cav[i - 1].length * 4;
                JackHandL_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
