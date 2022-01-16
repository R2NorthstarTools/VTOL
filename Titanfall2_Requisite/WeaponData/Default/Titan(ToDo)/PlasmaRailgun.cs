using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Titan
{
    class PlasmaRailgun
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] PlasmaRailgun_col;
        public ReallyData[] PlasmaRailgun_nml;
        public ReallyData[] PlasmaRailgun_gls;
        public ReallyData[] PlasmaRailgun_spc;
        public ReallyData[] PlasmaRailgun_ilm;
        public ReallyData[] PlasmaRailgun_ao;
        public ReallyData[] PlasmaRailgun_cav;
        public PlasmaRailgun()
        {
            int i = 1;

            PlasmaRailgun_col = new ReallyData[3];
            PlasmaRailgun_nml = new ReallyData[3];
            PlasmaRailgun_gls = new ReallyData[3];
            PlasmaRailgun_spc = new ReallyData[3];
            PlasmaRailgun_ilm = new ReallyData[3];
            PlasmaRailgun_ao = new ReallyData[3];
            PlasmaRailgun_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            PlasmaRailgun_col[0].name = "col";
            PlasmaRailgun_col[0].seek = 9510850560;
            PlasmaRailgun_col[0].length = 131072;
            PlasmaRailgun_col[0].seeklength = 128;
            while (i <= 2)
            {
                PlasmaRailgun_col[i].name = "col";
                PlasmaRailgun_col[i].seek = PlasmaRailgun_col[i - 1].seek + PlasmaRailgun_col[i - 1].length;
                PlasmaRailgun_col[i].length = PlasmaRailgun_col[i - 1].length * 4;
                PlasmaRailgun_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            PlasmaRailgun_nml[0].name = "nml";
            PlasmaRailgun_nml[0].seek = 9513668608;
            PlasmaRailgun_nml[0].length = 262144;
            PlasmaRailgun_nml[0].seeklength = 128;
            while (i <= 2)
            {
                PlasmaRailgun_nml[i].name = "nml";
                PlasmaRailgun_nml[i].seek = PlasmaRailgun_nml[i - 1].seek + PlasmaRailgun_nml[i - 1].length;
                PlasmaRailgun_nml[i].length = PlasmaRailgun_nml[i - 1].length * 4;
                PlasmaRailgun_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            PlasmaRailgun_gls[0].name = "gls";
            PlasmaRailgun_gls[0].seek = 9519173632;
            PlasmaRailgun_gls[0].length = 131072;
            PlasmaRailgun_gls[0].seeklength = 128;
            while (i <= 2)
            {
                PlasmaRailgun_gls[i].name = "gls";
                PlasmaRailgun_gls[i].seek = PlasmaRailgun_gls[i - 1].seek + PlasmaRailgun_gls[i - 1].length;
                PlasmaRailgun_gls[i].length = PlasmaRailgun_gls[i - 1].length * 4;
                PlasmaRailgun_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            PlasmaRailgun_spc[0].name = "spc";
            PlasmaRailgun_spc[0].seek = 9521926144;
            PlasmaRailgun_spc[0].length = 131072;
            PlasmaRailgun_spc[0].seeklength = 128;
            while (i <= 2)
            {
                PlasmaRailgun_spc[i].name = "spc";
                PlasmaRailgun_spc[i].seek = PlasmaRailgun_spc[i - 1].seek + PlasmaRailgun_spc[i - 1].length;
                PlasmaRailgun_spc[i].length = PlasmaRailgun_spc[i - 1].length * 4;
                PlasmaRailgun_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            PlasmaRailgun_ilm[0].name = "ilm";
            PlasmaRailgun_ilm[0].seek = 9524678656;
            PlasmaRailgun_ilm[0].length = 131072;
            PlasmaRailgun_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                PlasmaRailgun_ilm[i].name = "ilm";
                PlasmaRailgun_ilm[i].seek = PlasmaRailgun_ilm[i - 1].seek + PlasmaRailgun_ilm[i - 1].length;
                PlasmaRailgun_ilm[i].length = PlasmaRailgun_ilm[i - 1].length * 4;
                PlasmaRailgun_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            PlasmaRailgun_ao[0].name = "ao";
            PlasmaRailgun_ao[0].seek = 9527431168;
            PlasmaRailgun_ao[0].length = 131072;
            PlasmaRailgun_ao[0].seeklength = 128;
            while (i <= 2)
            {
                PlasmaRailgun_ao[i].name = "ao";
                PlasmaRailgun_ao[i].seek = PlasmaRailgun_ao[i - 1].seek + PlasmaRailgun_ao[i - 1].length;
                PlasmaRailgun_ao[i].length = PlasmaRailgun_ao[i - 1].length * 4;
                PlasmaRailgun_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            PlasmaRailgun_cav[0].name = "cav";
            PlasmaRailgun_cav[0].seek = 9530183680;
            PlasmaRailgun_cav[0].length = 131072;
            PlasmaRailgun_cav[0].seeklength = 128;
            while (i <= 2)
            {
                PlasmaRailgun_cav[i].name = "cav";
                PlasmaRailgun_cav[i].seek = PlasmaRailgun_cav[i - 1].seek + PlasmaRailgun_cav[i - 1].length;
                PlasmaRailgun_cav[i].length = PlasmaRailgun_cav[i - 1].length * 4;
                PlasmaRailgun_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
