using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Grenadier
{
    class SMR
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] SMR_col;
        public ReallyData[] SMR_nml;
        public ReallyData[] SMR_gls;
        public ReallyData[] SMR_spc;
        //public ReallyData[] SMR_ilm;
        public ReallyData[] SMR_ao;
        public ReallyData[] SMR_cav;
        public SMR()
        {
            int i = 1;

            SMR_col = new ReallyData[3];
            SMR_nml = new ReallyData[3];
            SMR_gls = new ReallyData[3];
            SMR_spc = new ReallyData[3];
            SMR_ao = new ReallyData[3];
            SMR_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            SMR_col[0].name = "col";
            SMR_col[0].seek = 9952890880;
            SMR_col[0].length = 262144;
            SMR_col[0].seeklength = 148;
            while (i <= 2)
            {
                SMR_col[i].name = "col";
                SMR_col[i].seek = SMR_col[i - 1].seek + SMR_col[i - 1].length;
                SMR_col[i].length = SMR_col[i - 1].length * 4;
                SMR_col[i].seeklength = 148;
                i++;
            }
            i = 1;

            SMR_nml[0].name = "nml";
            SMR_nml[0].seek = 9958461440;
            SMR_nml[0].length = 262144;
            SMR_nml[0].seeklength = 128;
            while (i <= 2)
            {
                SMR_nml[i].name = "nml";
                SMR_nml[i].seek = SMR_nml[i - 1].seek + SMR_nml[i - 1].length;
                SMR_nml[i].length = SMR_nml[i - 1].length * 4;
                SMR_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            SMR_gls[0].name = "gls";
            SMR_gls[0].seek = 9963966464;
            SMR_gls[0].length = 131072;
            SMR_gls[0].seeklength = 128;
            while (i <= 2)
            {
                SMR_gls[i].name = "gls";
                SMR_gls[i].seek = SMR_gls[i - 1].seek + SMR_gls[i - 1].length;
                SMR_gls[i].length = SMR_gls[i - 1].length * 4;
                SMR_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            SMR_spc[0].name = "spc";
            SMR_spc[0].seek = 9966718976;
            SMR_spc[0].length = 131072;
            SMR_spc[0].seeklength = 128;
            while (i <= 2)
            {
                SMR_spc[i].name = "spc";
                SMR_spc[i].seek = SMR_spc[i - 1].seek + SMR_spc[i - 1].length;
                SMR_spc[i].length = SMR_spc[i - 1].length * 4;
                SMR_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            SMR_ao[0].name = "ao";
            SMR_ao[0].seek = 9969471488;
            SMR_ao[0].length = 131072;
            SMR_ao[0].seeklength = 128;
            while (i <= 2)
            {
                SMR_ao[i].name = "ao";
                SMR_ao[i].seek = SMR_ao[i - 1].seek + SMR_ao[i - 1].length;
                SMR_ao[i].length = SMR_ao[i - 1].length * 4;
                SMR_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            SMR_cav[0].name = "cav";
            SMR_cav[0].seek = 9972224000;
            SMR_cav[0].length = 131072;
            SMR_cav[0].seeklength = 128;
            while (i <= 2)
            {
                SMR_cav[i].name = "cav";
                SMR_cav[i].seek = SMR_cav[i - 1].seek + SMR_cav[i - 1].length;
                SMR_cav[i].length = SMR_cav[i - 1].length * 4;
                SMR_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
