using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Attachment
{
    class HoloReflexSight
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] HoloReflexSight_col;
        public ReallyData[] HoloReflexSight_nml;
        public ReallyData[] HoloReflexSight_gls;
        public ReallyData[] HoloReflexSight_spc;
        //public ReallyData[] HoloReflexSight_ilm;
        //public ReallyData[] HoloReflexSight_ao;
        //public ReallyData[] HoloReflexSight_cav;
        public HoloReflexSight()
        {
            int i = 1;

            HoloReflexSight_col = new ReallyData[2];
            HoloReflexSight_nml = new ReallyData[2];
            HoloReflexSight_gls = new ReallyData[2];
            HoloReflexSight_spc = new ReallyData[2];
            //HoloReflexSight_ao = new ReallyData[2];
            //HoloReflexSight_cav = new ReallyData[2];
            //1为1024x1024,0为512x512

            HoloReflexSight_col[0].name = "col";
            HoloReflexSight_col[0].seek = 9386659840;
            HoloReflexSight_col[0].length = 131072;
            HoloReflexSight_col[0].seeklength = 128;
            while (i <= 1)
            {
                HoloReflexSight_col[i].name = "col";
                HoloReflexSight_col[i].seek = HoloReflexSight_col[i - 1].seek + HoloReflexSight_col[i - 1].length;
                HoloReflexSight_col[i].length = HoloReflexSight_col[i - 1].length * 4;
                HoloReflexSight_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            HoloReflexSight_nml[0].name = "nml";
            HoloReflexSight_nml[0].seek = 9387380736;
            HoloReflexSight_nml[0].length = 262144;
            HoloReflexSight_nml[0].seeklength = 128;
            while (i <= 1)
            {
                HoloReflexSight_nml[i].name = "nml";
                HoloReflexSight_nml[i].seek = HoloReflexSight_nml[i - 1].seek + HoloReflexSight_nml[i - 1].length;
                HoloReflexSight_nml[i].length = HoloReflexSight_nml[i - 1].length * 4;
                HoloReflexSight_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            HoloReflexSight_gls[0].name = "gls";
            HoloReflexSight_gls[0].seek = 9388691456;
            HoloReflexSight_gls[0].length = 131072;
            HoloReflexSight_gls[0].seeklength = 128;
            while (i <= 1)
            {
                HoloReflexSight_gls[i].name = "gls";
                HoloReflexSight_gls[i].seek = HoloReflexSight_gls[i - 1].seek + HoloReflexSight_gls[i - 1].length;
                HoloReflexSight_gls[i].length = HoloReflexSight_gls[i - 1].length * 4;
                HoloReflexSight_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            HoloReflexSight_spc[0].name = "spc";
            HoloReflexSight_spc[0].seek = 9389346816;
            HoloReflexSight_spc[0].length = 131072;
            HoloReflexSight_spc[0].seeklength = 128;
            while (i <= 1)
            {
                HoloReflexSight_spc[i].name = "spc";
                HoloReflexSight_spc[i].seek = HoloReflexSight_spc[i - 1].seek + HoloReflexSight_spc[i - 1].length;
                HoloReflexSight_spc[i].length = HoloReflexSight_spc[i - 1].length * 4;
                HoloReflexSight_spc[i].seeklength = 128;
                i++;
            }
            i = 1;
/*
            HoloReflexSight_ao[0].name = "ao";
            HoloReflexSight_ao[0].seek = 8783728640;
            HoloReflexSight_ao[0].length = 131072;
            HoloReflexSight_ao[0].seeklength = 128;
            while (i <= 1)
            {
                HoloReflexSight_ao[i].name = "ao";
                HoloReflexSight_ao[i].seek = HoloReflexSight_ao[i - 1].seek + HoloReflexSight_ao[i - 1].length;
                HoloReflexSight_ao[i].length = HoloReflexSight_ao[i - 1].length * 4;
                HoloReflexSight_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            HoloReflexSight_cav[0].name = "cav";
            HoloReflexSight_cav[0].seek = 8784384000;
            HoloReflexSight_cav[0].length = 131072;
            HoloReflexSight_cav[0].seeklength = 128;
            while (i <= 1)
            {
                HoloReflexSight_cav[i].name = "cav";
                HoloReflexSight_cav[i].seek = HoloReflexSight_cav[i - 1].seek + HoloReflexSight_cav[i - 1].length;
                HoloReflexSight_cav[i].length = HoloReflexSight_cav[i - 1].length * 4;
                HoloReflexSight_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
        }
    }
}
