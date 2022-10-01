using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.LightMachineGun
{
    class Devotion
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        //枪身部分
        public ReallyData[] Devotion_col;
        public ReallyData[] Devotion_nml;
        public ReallyData[] Devotion_gls;
        public ReallyData[] Devotion_spc;
        public ReallyData[] Devotion_ilm;
        public ReallyData[] Devotion_ao;
        //public ReallyData[] Devotion_cav;

        //弹夹部分
        public ReallyData[] Devotion_clip_col;
        public ReallyData[] Devotion_clip_nml;
        public ReallyData[] Devotion_clip_gls;
        public ReallyData[] Devotion_clip_spc;
        public ReallyData[] Devotion_clip_ilm;
        public ReallyData[] Devotion_clip_ao;
        public ReallyData[] Devotion_clip_cav;
        public Devotion()
        {
            int i = 1;

            //枪身部分
            Devotion_col = new ReallyData[3];
            Devotion_nml = new ReallyData[3];
            Devotion_gls = new ReallyData[3];
            Devotion_spc = new ReallyData[3];
            Devotion_ilm = new ReallyData[3];
            Devotion_ao = new ReallyData[3];

            //弹夹部分
            Devotion_clip_col = new ReallyData[3];
            Devotion_clip_nml = new ReallyData[3];
            Devotion_clip_gls = new ReallyData[3];
            Devotion_clip_spc = new ReallyData[3];
            Devotion_clip_ilm = new ReallyData[3];
            Devotion_clip_ao = new ReallyData[3];
            Devotion_clip_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            //枪身部分
            Devotion_col[0].name = "col";
            Devotion_col[0].seek = 8831766528;
            Devotion_col[0].length = 131072;
            Devotion_col[0].seeklength = 128;
            while (i <= 2)
            {
                Devotion_col[i].name = "col";
                Devotion_col[i].seek = Devotion_col[i - 1].seek + Devotion_col[i - 1].length;
                Devotion_col[i].length = Devotion_col[i - 1].length * 4;
                Devotion_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_nml[0].name = "nml";
            Devotion_nml[0].seek = 8834584576;
            Devotion_nml[0].length = 262144;
            Devotion_nml[0].seeklength = 128;
            while (i <= 2)
            {
                Devotion_nml[i].name = "nml";
                Devotion_nml[i].seek = Devotion_nml[i - 1].seek + Devotion_nml[i - 1].length;
                Devotion_nml[i].length = Devotion_nml[i - 1].length * 4;
                Devotion_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_gls[0].name = "gls";
            Devotion_gls[0].seek = 8840089600;
            Devotion_gls[0].length = 131072;
            Devotion_gls[0].seeklength = 128;
            while (i <= 2)
            {
                Devotion_gls[i].name = "gls";
                Devotion_gls[i].seek = Devotion_gls[i - 1].seek + Devotion_gls[i - 1].length;
                Devotion_gls[i].length = Devotion_gls[i - 1].length * 4;
                Devotion_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_spc[0].name = "spc";
            Devotion_spc[0].seek = 8842842112;
            Devotion_spc[0].length = 131072;
            Devotion_spc[0].seeklength = 128;
            while (i <= 2)
            {
                Devotion_spc[i].name = "spc";
                Devotion_spc[i].seek = Devotion_spc[i - 1].seek + Devotion_spc[i - 1].length;
                Devotion_spc[i].length = Devotion_spc[i - 1].length * 4;
                Devotion_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_ilm[0].name = "ilm";
            Devotion_ilm[0].seek = 8845594624;
            Devotion_ilm[0].length = 131072;
            Devotion_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                Devotion_ilm[i].name = "ilm";
                Devotion_ilm[i].seek = Devotion_ilm[i - 1].seek + Devotion_ilm[i - 1].length;
                Devotion_ilm[i].length = Devotion_ilm[i - 1].length * 4;
                Devotion_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_ao[0].name = "ao";
            Devotion_ao[0].seek = 8848347136;
            Devotion_ao[0].length = 131072;
            Devotion_ao[0].seeklength = 128;
            while (i <= 2)
            {
                Devotion_ao[i].name = "ao";
                Devotion_ao[i].seek = Devotion_ao[i - 1].seek + Devotion_ao[i - 1].length;
                Devotion_ao[i].length = Devotion_ao[i - 1].length * 4;
                Devotion_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            //弹夹部分
            Devotion_clip_col[0].name = "col";
            Devotion_clip_col[0].seek = 8829145088;
            Devotion_clip_col[0].length = 65536;
            Devotion_clip_col[0].seeklength = 128;
            while (i <= 1)
            {
                Devotion_clip_col[i].name = "col";
                Devotion_clip_col[i].seek = Devotion_clip_col[i - 1].seek + Devotion_clip_col[i - 1].length;
                Devotion_clip_col[i].length = Devotion_clip_col[i - 1].length * 4;
                Devotion_clip_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_clip_nml[0].name = "nml";
            Devotion_clip_nml[0].seek = 8829472768;
            Devotion_clip_nml[0].length = 131072;
            Devotion_clip_nml[0].seeklength = 128;
            while (i <= 1)
            {
                Devotion_clip_nml[i].name = "nml";
                Devotion_clip_nml[i].seek = Devotion_clip_nml[i - 1].seek + Devotion_clip_nml[i - 1].length;
                Devotion_clip_nml[i].length = Devotion_clip_nml[i - 1].length * 4;
                Devotion_clip_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_clip_gls[0].name = "gls";
            Devotion_clip_gls[0].seek = 8830128128;
            Devotion_clip_gls[0].length = 65536;
            Devotion_clip_gls[0].seeklength = 128;
            while (i <= 1)
            {
                Devotion_clip_gls[i].name = "gls";
                Devotion_clip_gls[i].seek = Devotion_clip_gls[i - 1].seek + Devotion_clip_gls[i - 1].length;
                Devotion_clip_gls[i].length = Devotion_clip_gls[i - 1].length * 4;
                Devotion_clip_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_clip_spc[0].name = "spc";
            Devotion_clip_spc[0].seek = 8830455808;
            Devotion_clip_spc[0].length = 65536;
            Devotion_clip_spc[0].seeklength = 128;
            while (i <= 1)
            {
                Devotion_clip_spc[i].name = "spc";
                Devotion_clip_spc[i].seek = Devotion_clip_spc[i - 1].seek + Devotion_clip_spc[i - 1].length;
                Devotion_clip_spc[i].length = Devotion_clip_spc[i - 1].length * 4;
                Devotion_clip_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_clip_ilm[0].name = "ilm";
            Devotion_clip_ilm[0].seek = 8830783488;
            Devotion_clip_ilm[0].length = 65536;
            Devotion_clip_ilm[0].seeklength = 128;
            while (i <= 1)
            {
                Devotion_clip_ilm[i].name = "ilm";
                Devotion_clip_ilm[i].seek = Devotion_clip_ilm[i - 1].seek + Devotion_clip_ilm[i - 1].length;
                Devotion_clip_ilm[i].length = Devotion_clip_ilm[i - 1].length * 4;
                Devotion_clip_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_clip_ao[0].name = "ao";
            Devotion_clip_ao[0].seek = 8831111168;
            Devotion_clip_ao[0].length = 65536;
            Devotion_clip_ao[0].seeklength = 128;
            while (i <= 1)
            {
                Devotion_clip_ao[i].name = "ao";
                Devotion_clip_ao[i].seek = Devotion_clip_ao[i - 1].seek + Devotion_clip_ao[i - 1].length;
                Devotion_clip_ao[i].length = Devotion_clip_ao[i - 1].length * 4;
                Devotion_clip_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            Devotion_clip_cav[0].name = "cav";
            Devotion_clip_cav[0].seek = 8831438848;
            Devotion_clip_cav[0].length = 65536;
            Devotion_clip_cav[0].seeklength = 128;
            while (i <= 1)
            {
                Devotion_clip_cav[i].name = "cav";
                Devotion_clip_cav[i].seek = Devotion_clip_cav[i - 1].seek + Devotion_clip_cav[i - 1].length;
                Devotion_clip_cav[i].length = Devotion_clip_cav[i - 1].length * 4;
                Devotion_clip_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
