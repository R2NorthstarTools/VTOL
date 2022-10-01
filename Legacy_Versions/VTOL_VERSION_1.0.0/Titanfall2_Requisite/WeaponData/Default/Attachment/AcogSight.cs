using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Attachment
{
    class AcogSight
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] AcogSight_col;
        public ReallyData[] AcogSight_nml;
        public ReallyData[] AcogSight_gls;
        public ReallyData[] AcogSight_spc;
        //public ReallyData[] AcogSight_ilm;
        public ReallyData[] AcogSight_ao;
        public ReallyData[] AcogSight_cav;
        public AcogSight()
        {
            int i = 1;

            AcogSight_col = new ReallyData[2];
            AcogSight_nml = new ReallyData[2];
            AcogSight_gls = new ReallyData[2];
            AcogSight_spc = new ReallyData[2];
            AcogSight_ao = new ReallyData[2];
            AcogSight_cav = new ReallyData[2];
            //1为1024x1024,0为512x512

            AcogSight_col[0].name = "col";
            AcogSight_col[0].seek = 8780386304;
            AcogSight_col[0].length = 131072;
            AcogSight_col[0].seeklength = 128;
            while (i <= 1)
            {
                AcogSight_col[i].name = "col";
                AcogSight_col[i].seek = AcogSight_col[i - 1].seek + AcogSight_col[i - 1].length;
                AcogSight_col[i].length = AcogSight_col[i - 1].length * 4;
                AcogSight_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            AcogSight_nml[0].name = "nml";
            AcogSight_nml[0].seek = 8781107200;
            AcogSight_nml[0].length = 262144;
            AcogSight_nml[0].seeklength = 128;
            while (i <= 1)
            {
                AcogSight_nml[i].name = "nml";
                AcogSight_nml[i].seek = AcogSight_nml[i - 1].seek + AcogSight_nml[i - 1].length;
                AcogSight_nml[i].length = AcogSight_nml[i - 1].length * 4;
                AcogSight_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            AcogSight_gls[0].name = "gls";
            AcogSight_gls[0].seek = 8782417920;
            AcogSight_gls[0].length = 131072;
            AcogSight_gls[0].seeklength = 128;
            while (i <= 1)
            {
                AcogSight_gls[i].name = "gls";
                AcogSight_gls[i].seek = AcogSight_gls[i - 1].seek + AcogSight_gls[i - 1].length;
                AcogSight_gls[i].length = AcogSight_gls[i - 1].length * 4;
                AcogSight_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            AcogSight_spc[0].name = "spc";
            AcogSight_spc[0].seek = 8783073280;
            AcogSight_spc[0].length = 131072;
            AcogSight_spc[0].seeklength = 128;
            while (i <= 1)
            {
                AcogSight_spc[i].name = "spc";
                AcogSight_spc[i].seek = AcogSight_spc[i - 1].seek + AcogSight_spc[i - 1].length;
                AcogSight_spc[i].length = AcogSight_spc[i - 1].length * 4;
                AcogSight_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            AcogSight_ao[0].name = "ao";
            AcogSight_ao[0].seek = 8783728640;
            AcogSight_ao[0].length = 131072;
            AcogSight_ao[0].seeklength = 128;
            while (i <= 1)
            {
                AcogSight_ao[i].name = "ao";
                AcogSight_ao[i].seek = AcogSight_ao[i - 1].seek + AcogSight_ao[i - 1].length;
                AcogSight_ao[i].length = AcogSight_ao[i - 1].length * 4;
                AcogSight_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            AcogSight_cav[0].name = "cav";
            AcogSight_cav[0].seek = 8784384000;
            AcogSight_cav[0].length = 131072;
            AcogSight_cav[0].seeklength = 128;
            while (i <= 1)
            {
                AcogSight_cav[i].name = "cav";
                AcogSight_cav[i].seek = AcogSight_cav[i - 1].seek + AcogSight_cav[i - 1].length;
                AcogSight_cav[i].length = AcogSight_cav[i - 1].length * 4;
                AcogSight_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
