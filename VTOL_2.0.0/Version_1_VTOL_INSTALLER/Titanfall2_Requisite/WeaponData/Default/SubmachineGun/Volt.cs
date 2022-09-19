using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.SubmachineGun
{
    class Volt
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] Volt_col;
        public ReallyData[] Volt_nml;
        public ReallyData[] Volt_gls;
        public ReallyData[] Volt_spc;
        public ReallyData[] Volt_ilm;
        public ReallyData[] Volt_ao;
        public ReallyData[] Volt_cav;
        public Volt()
        {
            int i = 1;

            Volt_col = new ReallyData[3];
            Volt_nml = new ReallyData[3];
            Volt_gls = new ReallyData[3];
            Volt_spc = new ReallyData[3];
            Volt_ilm = new ReallyData[3];
            Volt_ao = new ReallyData[3];
            Volt_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            Volt_col[0].name = "col";
            Volt_col[0].seek = 8856670208;
            Volt_col[0].length = 262144;
            Volt_col[0].seeklength = 148;
            while (i <= 2)
            {
                Volt_col[i].name = "col";
                Volt_col[i].seek = Volt_col[i - 1].seek + Volt_col[i - 1].length;
                Volt_col[i].length = Volt_col[i - 1].length * 4;
                Volt_col[i].seeklength = 148;
                i++;
            }
            i = 1;

            Volt_nml[0].name = "nml";
            Volt_nml[0].seek = 8862240768;
            Volt_nml[0].length = 262144;
            Volt_nml[0].seeklength = 128;
            while (i <= 2)
            {
                Volt_nml[i].name = "nml";
                Volt_nml[i].seek = Volt_nml[i - 1].seek + Volt_nml[i - 1].length;
                Volt_nml[i].length = Volt_nml[i - 1].length * 4;
                Volt_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Volt_gls[0].name = "gls";
            Volt_gls[0].seek = 8867745792;
            Volt_gls[0].length = 131072;
            Volt_gls[0].seeklength = 128;
            while (i <= 2)
            {
                Volt_gls[i].name = "gls";
                Volt_gls[i].seek = Volt_gls[i - 1].seek + Volt_gls[i - 1].length;
                Volt_gls[i].length = Volt_gls[i - 1].length * 4;
                Volt_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Volt_spc[0].name = "spc";
            Volt_spc[0].seek = 8870563840;
            Volt_spc[0].length = 262144;
            Volt_spc[0].seeklength = 148;
            while (i <= 2)
            {
                Volt_spc[i].name = "spc";
                Volt_spc[i].seek = Volt_spc[i - 1].seek + Volt_spc[i - 1].length;
                Volt_spc[i].length = Volt_spc[i - 1].length * 4;
                Volt_spc[i].seeklength = 148;
                i++;
            }
            i = 1;

            Volt_ilm[0].name = "ilm";
            Volt_ilm[0].seek = 8876068864;
            Volt_ilm[0].length = 131072;
            Volt_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                Volt_ilm[i].name = "ilm";
                Volt_ilm[i].seek = Volt_ilm[i - 1].seek + Volt_ilm[i - 1].length;
                Volt_ilm[i].length = Volt_ilm[i - 1].length * 4;
                Volt_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Volt_ao[0].name = "ao";
            Volt_ao[0].seek = 8878821376;
            Volt_ao[0].length = 131072;
            Volt_ao[0].seeklength = 128;
            while (i <= 2)
            {
                Volt_ao[i].name = "ao";
                Volt_ao[i].seek = Volt_ao[i - 1].seek + Volt_ao[i - 1].length;
                Volt_ao[i].length = Volt_ao[i - 1].length * 4;
                Volt_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Volt_cav[0].name = "cav";
            Volt_cav[0].seek = 8881573888;
            Volt_cav[0].length = 131072;
            Volt_cav[0].seeklength = 128;
            while (i <= 2)
            {
                Volt_cav[i].name = "cav";
                Volt_cav[i].seek = Volt_cav[i - 1].seek + Volt_cav[i - 1].length;
                Volt_cav[i].length = Volt_cav[i - 1].length * 4;
                Volt_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
