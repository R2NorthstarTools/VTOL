using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Grenadier
{
    class EPG
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] EPG_col;
        public ReallyData[] EPG_nml;
        public ReallyData[] EPG_gls;
        public ReallyData[] EPG_spc;
        public ReallyData[] EPG_ilm;
        public ReallyData[] EPG_ao;
        public ReallyData[] EPG_cav;
        public EPG()
        {
            int i = 1;

            EPG_col = new ReallyData[3];
            EPG_nml = new ReallyData[3];
            EPG_gls = new ReallyData[3];
            EPG_spc = new ReallyData[3];
            EPG_ilm = new ReallyData[3];
            EPG_ao = new ReallyData[3];
            EPG_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            EPG_col[0].name = "col";
            EPG_col[0].seek = 9613676544;
            EPG_col[0].length = 131072;
            EPG_col[0].seeklength = 128;
            while (i <= 2)
            {
                EPG_col[i].name = "col";
                EPG_col[i].seek = EPG_col[i - 1].seek + EPG_col[i - 1].length;
                EPG_col[i].length = EPG_col[i - 1].length * 4;
                EPG_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            EPG_nml[0].name = "nml";
            EPG_nml[0].seek = 9616494592;
            EPG_nml[0].length = 262144;
            EPG_nml[0].seeklength = 128;
            while (i <= 2)
            {
                EPG_nml[i].name = "nml";
                EPG_nml[i].seek = EPG_nml[i - 1].seek + EPG_nml[i - 1].length;
                EPG_nml[i].length = EPG_nml[i - 1].length * 4;
                EPG_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            EPG_gls[0].name = "gls";
            EPG_gls[0].seek = 9621999616;
            EPG_gls[0].length = 131072;
            EPG_gls[0].seeklength = 128;
            while (i <= 2)
            {
                EPG_gls[i].name = "gls";
                EPG_gls[i].seek = EPG_gls[i - 1].seek + EPG_gls[i - 1].length;
                EPG_gls[i].length = EPG_gls[i - 1].length * 4;
                EPG_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            EPG_spc[0].name = "spc";
            EPG_spc[0].seek = 9624752128;
            EPG_spc[0].length = 131072;
            EPG_spc[0].seeklength = 128;
            while (i <= 2)
            {
                EPG_spc[i].name = "spc";
                EPG_spc[i].seek = EPG_spc[i - 1].seek + EPG_spc[i - 1].length;
                EPG_spc[i].length = EPG_spc[i - 1].length * 4;
                EPG_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            EPG_ilm[0].name = "ilm";
            EPG_ilm[0].seek = 9627504640;
            EPG_ilm[0].length = 131072;
            EPG_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                EPG_ilm[i].name = "ilm";
                EPG_ilm[i].seek = EPG_ilm[i - 1].seek + EPG_ilm[i - 1].length;
                EPG_ilm[i].length = EPG_ilm[i - 1].length * 4;
                EPG_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            EPG_ao[0].name = "ao";
            EPG_ao[0].seek = 9630257152;
            EPG_ao[0].length = 131072;
            EPG_ao[0].seeklength = 128;
            while (i <= 2)
            {
                EPG_ao[i].name = "ao";
                EPG_ao[i].seek = EPG_ao[i - 1].seek + EPG_ao[i - 1].length;
                EPG_ao[i].length = EPG_ao[i - 1].length * 4;
                EPG_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            EPG_cav[0].name = "cav";
            EPG_cav[0].seek = 9633009664;
            EPG_cav[0].length = 131072;
            EPG_cav[0].seeklength = 128;
            while (i <= 2)
            {
                EPG_cav[i].name = "cav";
                EPG_cav[i].seek = EPG_cav[i - 1].seek + EPG_cav[i - 1].length;
                EPG_cav[i].length = EPG_cav[i - 1].length * 4;
                EPG_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
