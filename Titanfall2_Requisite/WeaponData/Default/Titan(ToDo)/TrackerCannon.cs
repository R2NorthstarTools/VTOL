using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Titan
{
    class TrackerCannon
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] TrackerCannon_col;
        public ReallyData[] TrackerCannon_nml;
        public ReallyData[] TrackerCannon_gls;
        public ReallyData[] TrackerCannon_spc;
        public ReallyData[] TrackerCannon_ilm;
        public ReallyData[] TrackerCannon_ao;
        public ReallyData[] TrackerCannon_cav;
        public TrackerCannon()
        {
            int i = 1;

            TrackerCannon_col = new ReallyData[3];
            TrackerCannon_nml = new ReallyData[3];
            TrackerCannon_gls = new ReallyData[3];
            TrackerCannon_spc = new ReallyData[3];
            TrackerCannon_ilm = new ReallyData[3];
            TrackerCannon_ao = new ReallyData[3];
            TrackerCannon_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            TrackerCannon_col[0].name = "col";
            TrackerCannon_col[0].seek = 9510850560;
            TrackerCannon_col[0].length = 131072;
            TrackerCannon_col[0].seeklength = 128;
            while (i <= 2)
            {
                TrackerCannon_col[i].name = "col";
                TrackerCannon_col[i].seek = TrackerCannon_col[i - 1].seek + TrackerCannon_col[i - 1].length;
                TrackerCannon_col[i].length = TrackerCannon_col[i - 1].length * 4;
                TrackerCannon_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            TrackerCannon_nml[0].name = "nml";
            TrackerCannon_nml[0].seek = 9513668608;
            TrackerCannon_nml[0].length = 262144;
            TrackerCannon_nml[0].seeklength = 128;
            while (i <= 2)
            {
                TrackerCannon_nml[i].name = "nml";
                TrackerCannon_nml[i].seek = TrackerCannon_nml[i - 1].seek + TrackerCannon_nml[i - 1].length;
                TrackerCannon_nml[i].length = TrackerCannon_nml[i - 1].length * 4;
                TrackerCannon_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            TrackerCannon_gls[0].name = "gls";
            TrackerCannon_gls[0].seek = 9519173632;
            TrackerCannon_gls[0].length = 131072;
            TrackerCannon_gls[0].seeklength = 128;
            while (i <= 2)
            {
                TrackerCannon_gls[i].name = "gls";
                TrackerCannon_gls[i].seek = TrackerCannon_gls[i - 1].seek + TrackerCannon_gls[i - 1].length;
                TrackerCannon_gls[i].length = TrackerCannon_gls[i - 1].length * 4;
                TrackerCannon_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            TrackerCannon_spc[0].name = "spc";
            TrackerCannon_spc[0].seek = 9521926144;
            TrackerCannon_spc[0].length = 131072;
            TrackerCannon_spc[0].seeklength = 128;
            while (i <= 2)
            {
                TrackerCannon_spc[i].name = "spc";
                TrackerCannon_spc[i].seek = TrackerCannon_spc[i - 1].seek + TrackerCannon_spc[i - 1].length;
                TrackerCannon_spc[i].length = TrackerCannon_spc[i - 1].length * 4;
                TrackerCannon_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            TrackerCannon_ilm[0].name = "ilm";
            TrackerCannon_ilm[0].seek = 9524678656;
            TrackerCannon_ilm[0].length = 131072;
            TrackerCannon_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                TrackerCannon_ilm[i].name = "ilm";
                TrackerCannon_ilm[i].seek = TrackerCannon_ilm[i - 1].seek + TrackerCannon_ilm[i - 1].length;
                TrackerCannon_ilm[i].length = TrackerCannon_ilm[i - 1].length * 4;
                TrackerCannon_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            TrackerCannon_ao[0].name = "ao";
            TrackerCannon_ao[0].seek = 9527431168;
            TrackerCannon_ao[0].length = 131072;
            TrackerCannon_ao[0].seeklength = 128;
            while (i <= 2)
            {
                TrackerCannon_ao[i].name = "ao";
                TrackerCannon_ao[i].seek = TrackerCannon_ao[i - 1].seek + TrackerCannon_ao[i - 1].length;
                TrackerCannon_ao[i].length = TrackerCannon_ao[i - 1].length * 4;
                TrackerCannon_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            TrackerCannon_cav[0].name = "cav";
            TrackerCannon_cav[0].seek = 9530183680;
            TrackerCannon_cav[0].length = 131072;
            TrackerCannon_cav[0].seeklength = 128;
            while (i <= 2)
            {
                TrackerCannon_cav[i].name = "cav";
                TrackerCannon_cav[i].seek = TrackerCannon_cav[i - 1].seek + TrackerCannon_cav[i - 1].length;
                TrackerCannon_cav[i].length = TrackerCannon_cav[i - 1].length * 4;
                TrackerCannon_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
