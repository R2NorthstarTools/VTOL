using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AntiTitan
{
    class ION
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] ION_col;
        public ReallyData[] ION_nml;
        public ReallyData[] ION_gls;
        public ReallyData[] ION_spc;
        public ReallyData[] ION_ilm;
        public ReallyData[] ION_ao;
        public ReallyData[] ION_cav;
        public ION()
        {
            int i = 1;

            ION_col = new ReallyData[4];
            ION_nml = new ReallyData[4];
            ION_gls = new ReallyData[4];
            ION_spc = new ReallyData[4];
            ION_ilm = new ReallyData[4];
            ION_ao = new ReallyData[4];
            ION_cav = new ReallyData[4];
            //3为4096x40962为2048x2048,1为1024x1024,0为512x512
            //浪人大剑没有ilm,col和spc是BC7U
            //col,spc = BC7U
            //nml = BC5U gls BC4U

            ION_col[0].name = "col";
            ION_col[0].seek = 6592925696;
            ION_col[0].length = 262144;
            ION_col[0].seeklength = 148;
            while (i <= 3)
            {
                ION_col[i].name = "col";
                ION_col[i].seek = ION_col[i - 1].seek + ION_col[i - 1].length;
                ION_col[i].length = ION_col[i - 1].length * 4;
                ION_col[i].seeklength = 148;
                i++;
            }
            i = 1;

            ION_nml[0].name = "nml";
            ION_nml[0].seek = 6615273472;
            ION_nml[0].length = 262144;
            ION_nml[0].seeklength = 128;
            while (i <= 3)
            {
                ION_nml[i].name = "nml";
                ION_nml[i].seek = ION_nml[i - 1].seek + ION_nml[i - 1].length;
                ION_nml[i].length = ION_nml[i - 1].length * 4;
                ION_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            ION_gls[0].name = "gls";
            ION_gls[0].seek = 6637555712;
            ION_gls[0].length = 131072;
            ION_gls[0].seeklength = 128;
            while (i <= 3)
            {
                ION_gls[i].name = "gls";
                ION_gls[i].seek = ION_gls[i - 1].seek + ION_gls[i - 1].length;
                ION_gls[i].length = ION_gls[i - 1].length * 4;
                ION_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            ION_spc[0].name = "spc";
            ION_spc[0].seek = 6648762368;
            ION_spc[0].length = 262144;
            ION_spc[0].seeklength = 148;
            while (i <= 3)
            {
                ION_spc[i].name = "spc";
                ION_spc[i].seek = ION_spc[i - 1].seek + ION_spc[i - 1].length;
                ION_spc[i].length = ION_spc[i - 1].length * 4;
                ION_spc[i].seeklength = 148;
                i++;
            }
            i = 1;

            ION_ilm[0].name = "ilm";
            ION_ilm[0].seek = 6671044608;
            ION_ilm[0].length = 131072;
            ION_ilm[0].seeklength = 128;
            while (i <= 3)
            {
                ION_ilm[i].name = "ilm";
                ION_ilm[i].seek = ION_ilm[i - 1].seek + ION_ilm[i - 1].length;
                ION_ilm[i].length = ION_ilm[i - 1].length * 4;
                ION_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            ION_ao[0].name = "ao";
            ION_ao[0].seek = 6682185728;
            ION_ao[0].length = 131072;
            ION_ao[0].seeklength = 128;
            while (i <= 3)
            {
                ION_ao[i].name = "ao";
                ION_ao[i].seek = ION_ao[i - 1].seek + ION_ao[i - 1].length;
                ION_ao[i].length = ION_ao[i - 1].length * 4;
                ION_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            ION_cav[0].name = "cav";
            ION_cav[0].seek = 6693326848;
            ION_cav[0].length = 131072;
            ION_cav[0].seeklength = 128;
            while (i <= 3)
            {
                ION_cav[i].name = "cav";
                ION_cav[i].seek = ION_cav[i - 1].seek + ION_cav[i - 1].length;
                ION_cav[i].length = ION_cav[i - 1].length * 4;
                ION_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}