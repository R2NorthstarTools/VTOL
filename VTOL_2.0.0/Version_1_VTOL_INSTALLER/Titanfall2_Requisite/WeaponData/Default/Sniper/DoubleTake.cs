using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Sniper
{
    class DoubleTake
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] DoubleTake_col;
        public ReallyData[] DoubleTake_nml;
        public ReallyData[] DoubleTake_gls;
        public ReallyData[] DoubleTake_spc;
        //public ReallyData[] DoubleTake_ilm;
        public ReallyData[] DoubleTake_ao;
        public ReallyData[] DoubleTake_cav;
        public DoubleTake()
        {
            int i = 1;

            DoubleTake_col = new ReallyData[3];
            DoubleTake_nml = new ReallyData[3];
            DoubleTake_gls = new ReallyData[3];
            DoubleTake_spc = new ReallyData[3];
            DoubleTake_ao = new ReallyData[3];
            DoubleTake_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            DoubleTake_col[0].name = "col";
            DoubleTake_col[0].seek = 9580515328;
            DoubleTake_col[0].length = 262144;
            DoubleTake_col[0].seeklength = 148;
            while (i <= 2)
            {
                DoubleTake_col[i].name = "col";
                DoubleTake_col[i].seek = DoubleTake_col[i - 1].seek + DoubleTake_col[i - 1].length;
                DoubleTake_col[i].length = DoubleTake_col[i - 1].length * 4;
                DoubleTake_col[i].seeklength = 148;
                i++;
            }
            i = 1;

            DoubleTake_nml[0].name = "nml";
            DoubleTake_nml[0].seek = 9586085888;
            DoubleTake_nml[0].length = 262144;
            DoubleTake_nml[0].seeklength = 128;
            while (i <= 2)
            {
                DoubleTake_nml[i].name = "nml";
                DoubleTake_nml[i].seek = DoubleTake_nml[i - 1].seek + DoubleTake_nml[i - 1].length;
                DoubleTake_nml[i].length = DoubleTake_nml[i - 1].length * 4;
                DoubleTake_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            DoubleTake_gls[0].name = "gls";
            DoubleTake_gls[0].seek = 9591590912;
            DoubleTake_gls[0].length = 131072;
            DoubleTake_gls[0].seeklength = 128;
            while (i <= 2)
            {
                DoubleTake_gls[i].name = "gls";
                DoubleTake_gls[i].seek = DoubleTake_gls[i - 1].seek + DoubleTake_gls[i - 1].length;
                DoubleTake_gls[i].length = DoubleTake_gls[i - 1].length * 4;
                DoubleTake_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            DoubleTake_spc[0].name = "spc";
            DoubleTake_spc[0].seek = 9594408960;
            DoubleTake_spc[0].length = 262144;
            DoubleTake_spc[0].seeklength = 148;
            while (i <= 2)
            {
                DoubleTake_spc[i].name = "spc";
                DoubleTake_spc[i].seek = DoubleTake_spc[i - 1].seek + DoubleTake_spc[i - 1].length;
                DoubleTake_spc[i].length = DoubleTake_spc[i - 1].length * 4;
                DoubleTake_spc[i].seeklength = 148;
                i++;
            }
            i = 1;

            DoubleTake_ao[0].name = "ao";
            DoubleTake_ao[0].seek = 9599913984;
            DoubleTake_ao[0].length = 131072;
            DoubleTake_ao[0].seeklength = 128;
            while (i <= 2)
            {
                DoubleTake_ao[i].name = "ao";
                DoubleTake_ao[i].seek = DoubleTake_ao[i - 1].seek + DoubleTake_ao[i - 1].length;
                DoubleTake_ao[i].length = DoubleTake_ao[i - 1].length * 4;
                DoubleTake_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            DoubleTake_cav[0].name = "cav";
            DoubleTake_cav[0].seek = 9602666496;
            DoubleTake_cav[0].length = 131072;
            DoubleTake_cav[0].seeklength = 128;
            while (i <= 2)
            {
                DoubleTake_cav[i].name = "cav";
                DoubleTake_cav[i].seek = DoubleTake_cav[i - 1].seek + DoubleTake_cav[i - 1].length;
                DoubleTake_cav[i].length = DoubleTake_cav[i - 1].length * 4;
                DoubleTake_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
