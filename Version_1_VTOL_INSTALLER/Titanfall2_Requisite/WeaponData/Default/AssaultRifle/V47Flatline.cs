using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AssaultRifle
{
    class V47Flatline
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] V47Flatline_col;
        public ReallyData[] V47Flatline_nml;
        public ReallyData[] V47Flatline_gls;
        public ReallyData[] V47Flatline_spc;
        public ReallyData[] V47Flatline_ilm;
        public ReallyData[] V47Flatline_ao;
        public ReallyData[] V47Flatline_cav;
        public V47Flatline()
        {
            int i = 1;

            V47Flatline_col = new ReallyData[3];
            V47Flatline_nml = new ReallyData[3];
            V47Flatline_gls = new ReallyData[3];
            V47Flatline_spc = new ReallyData[3];
            V47Flatline_ilm = new ReallyData[3];
            V47Flatline_ao = new ReallyData[3];
            V47Flatline_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            V47Flatline_col[0].name = "col";
            V47Flatline_col[0].seek = 9188085760;
            V47Flatline_col[0].length = 131072;
            V47Flatline_col[0].seeklength = 128;
            while (i <= 2)
            {
                V47Flatline_col[i].name = "col";
                V47Flatline_col[i].seek = V47Flatline_col[i - 1].seek + V47Flatline_col[i - 1].length;
                V47Flatline_col[i].length = V47Flatline_col[i - 1].length * 4;
                V47Flatline_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            V47Flatline_nml[0].name = "nml";
            V47Flatline_nml[0].seek = 9190903808;
            V47Flatline_nml[0].length = 262144;
            V47Flatline_nml[0].seeklength = 128;
            while (i <= 2)
            {
                V47Flatline_nml[i].name = "nml";
                V47Flatline_nml[i].seek = V47Flatline_nml[i - 1].seek + V47Flatline_nml[i - 1].length;
                V47Flatline_nml[i].length = V47Flatline_nml[i - 1].length * 4;
                V47Flatline_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            V47Flatline_gls[0].name = "gls";
            V47Flatline_gls[0].seek = 9196408832;
            V47Flatline_gls[0].length = 131072;
            V47Flatline_gls[0].seeklength = 128;
            while (i <= 2)
            {
                V47Flatline_gls[i].name = "gls";
                V47Flatline_gls[i].seek = V47Flatline_gls[i - 1].seek + V47Flatline_gls[i - 1].length;
                V47Flatline_gls[i].length = V47Flatline_gls[i - 1].length * 4;
                V47Flatline_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            V47Flatline_spc[0].name = "spc";
            V47Flatline_spc[0].seek = 9199161344;
            V47Flatline_spc[0].length = 131072;
            V47Flatline_spc[0].seeklength = 128;
            while (i <= 2)
            {
                V47Flatline_spc[i].name = "spc";
                V47Flatline_spc[i].seek = V47Flatline_spc[i - 1].seek + V47Flatline_spc[i - 1].length;
                V47Flatline_spc[i].length = V47Flatline_spc[i - 1].length * 4;
                V47Flatline_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            V47Flatline_ilm[0].name = "ilm";
            V47Flatline_ilm[0].seek = 9201913856;
            V47Flatline_ilm[0].length = 131072;
            V47Flatline_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                V47Flatline_ilm[i].name = "ilm";
                V47Flatline_ilm[i].seek = V47Flatline_ilm[i - 1].seek + V47Flatline_ilm[i - 1].length;
                V47Flatline_ilm[i].length = V47Flatline_ilm[i - 1].length * 4;
                V47Flatline_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            V47Flatline_ao[0].name = "ao";
            V47Flatline_ao[0].seek = 9204666368;
            V47Flatline_ao[0].length = 131072;
            V47Flatline_ao[0].seeklength = 128;
            while (i <= 2)
            {
                V47Flatline_ao[i].name = "ao";
                V47Flatline_ao[i].seek = V47Flatline_ao[i - 1].seek + V47Flatline_ao[i - 1].length;
                V47Flatline_ao[i].length = V47Flatline_ao[i - 1].length * 4;
                V47Flatline_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            V47Flatline_cav[0].name = "cav";
            V47Flatline_cav[0].seek = 9207418880;
            V47Flatline_cav[0].length = 131072;
            V47Flatline_cav[0].seeklength = 128;
            while (i <= 2)
            {
                V47Flatline_cav[i].name = "cav";
                V47Flatline_cav[i].seek = V47Flatline_cav[i - 1].seek + V47Flatline_cav[i - 1].length;
                V47Flatline_cav[i].length = V47Flatline_cav[i - 1].length * 4;
                V47Flatline_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
