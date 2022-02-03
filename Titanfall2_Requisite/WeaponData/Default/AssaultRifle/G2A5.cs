using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.AssaultRifle
{
    class G2A5
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] G2A5_col;
        public ReallyData[] G2A5_nml;
        public ReallyData[] G2A5_gls;
        public ReallyData[] G2A5_spc;
        public ReallyData[] G2A5_ilm;
        public ReallyData[] G2A5_ao;
        public ReallyData[] G2A5_cav;
        public G2A5()
        {
            int i = 1;

            G2A5_col = new ReallyData[3];
            G2A5_nml = new ReallyData[3];
            G2A5_gls = new ReallyData[3];
            G2A5_spc = new ReallyData[3];
            G2A5_ilm = new ReallyData[3];
            G2A5_ao = new ReallyData[3];
            G2A5_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            G2A5_col[0].name = "col";
            G2A5_col[0].seek = 9678229504;
            G2A5_col[0].length = 131072;
            G2A5_col[0].seeklength = 128;
            while (i <= 2)
            {
                G2A5_col[i].name = "col";
                G2A5_col[i].seek = G2A5_col[i - 1].seek + G2A5_col[i - 1].length;
                G2A5_col[i].length = G2A5_col[i - 1].length * 4;
                G2A5_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            G2A5_nml[0].name = "nml";
            G2A5_nml[0].seek = 9681047552;
            G2A5_nml[0].length = 262144;
            G2A5_nml[0].seeklength = 128;
            while (i <= 2)
            {
                G2A5_nml[i].name = "nml";
                G2A5_nml[i].seek = G2A5_nml[i - 1].seek + G2A5_nml[i - 1].length;
                G2A5_nml[i].length = G2A5_nml[i - 1].length * 4;
                G2A5_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            G2A5_gls[0].name = "gls";
            G2A5_gls[0].seek = 9686552576;
            G2A5_gls[0].length = 131072;
            G2A5_gls[0].seeklength = 128;
            while (i <= 2)
            {
                G2A5_gls[i].name = "gls";
                G2A5_gls[i].seek = G2A5_gls[i - 1].seek + G2A5_gls[i - 1].length;
                G2A5_gls[i].length = G2A5_gls[i - 1].length * 4;
                G2A5_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            G2A5_spc[0].name = "spc";
            G2A5_spc[0].seek = 9689305088;
            G2A5_spc[0].length = 131072;
            G2A5_spc[0].seeklength = 128;
            while (i <= 2)
            {
                G2A5_spc[i].name = "spc";
                G2A5_spc[i].seek = G2A5_spc[i - 1].seek + G2A5_spc[i - 1].length;
                G2A5_spc[i].length = G2A5_spc[i - 1].length * 4;
                G2A5_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            G2A5_ilm[0].name = "ilm";
            G2A5_ilm[0].seek = 9692057600;
            G2A5_ilm[0].length = 131072;
            G2A5_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                G2A5_ilm[i].name = "ilm";
                G2A5_ilm[i].seek = G2A5_ilm[i - 1].seek + G2A5_ilm[i - 1].length;
                G2A5_ilm[i].length = G2A5_ilm[i - 1].length * 4;
                G2A5_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            G2A5_ao[0].name = "ao";
            G2A5_ao[0].seek = 9694810112;
            G2A5_ao[0].length = 131072;
            G2A5_ao[0].seeklength = 128;
            while (i <= 2)
            {
                G2A5_ao[i].name = "ao";
                G2A5_ao[i].seek = G2A5_ao[i - 1].seek + G2A5_ao[i - 1].length;
                G2A5_ao[i].length = G2A5_ao[i - 1].length * 4;
                G2A5_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            G2A5_cav[0].name = "cav";
            G2A5_cav[0].seek = 9697562624;
            G2A5_cav[0].length = 131072;
            G2A5_cav[0].seeklength = 128;
            while (i <= 2)
            {
                G2A5_cav[i].name = "cav";
                G2A5_cav[i].seek = G2A5_cav[i - 1].seek + G2A5_cav[i - 1].length;
                G2A5_cav[i].length = G2A5_cav[i - 1].length * 4;
                G2A5_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
