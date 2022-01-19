using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Titan
{
    class XO16
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        //枪身部分
        public ReallyData[] XO16_col;
        public ReallyData[] XO16_nml;
        public ReallyData[] XO16_gls;
        public ReallyData[] XO16_spc;
        public ReallyData[] XO16_ilm;
        public ReallyData[] XO16_ao;
        public ReallyData[] XO16_cav;

        //弹夹部分
        public ReallyData[] XO16_clip_col;
        public ReallyData[] XO16_clip_nml;
        public ReallyData[] XO16_clip_gls;
        public ReallyData[] XO16_clip_spc;
        public ReallyData[] XO16_clip_ilm;
        public ReallyData[] XO16_clip_ao;
        public ReallyData[] XO16_clip_cav;
        public XO16()
        {
            int i = 1;

            //弹夹部分
            XO16_clip_col = new ReallyData[3];
            XO16_clip_nml = new ReallyData[3];
            XO16_clip_gls = new ReallyData[3];
            XO16_clip_spc = new ReallyData[3];
            XO16_clip_ilm = new ReallyData[3];
            XO16_clip_ao = new ReallyData[3];//共用ao
            XO16_clip_cav = new ReallyData[3];

            //枪身部分
            XO16_col = new ReallyData[3];
            XO16_nml = new ReallyData[3];
            XO16_gls = new ReallyData[3];
            XO16_spc = new ReallyData[3];
            XO16_ilm = new ReallyData[3];
            XO16_ao = new ReallyData[3];
            XO16_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            //弹夹部分
            XO16_col[0].name = "col";
            XO16_col[0].seek = 10257108992;
            XO16_col[0].length = 131072;
            XO16_col[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_col[i].name = "col";
                XO16_col[i].seek = XO16_col[i - 1].seek + XO16_col[i - 1].length;
                XO16_col[i].length = XO16_col[i - 1].length * 4;
                XO16_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_nml[0].name = "nml";
            XO16_nml[0].seek = 10259927040;
            XO16_nml[0].length = 262144;
            XO16_nml[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_nml[i].name = "nml";
                XO16_nml[i].seek = XO16_nml[i - 1].seek + XO16_nml[i - 1].length;
                XO16_nml[i].length = XO16_nml[i - 1].length * 4;
                XO16_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_gls[0].name = "gls";
            XO16_gls[0].seek = 10265432064;
            XO16_gls[0].length = 131072;
            XO16_gls[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_gls[i].name = "gls";
                XO16_gls[i].seek = XO16_gls[i - 1].seek + XO16_gls[i - 1].length;
                XO16_gls[i].length = XO16_gls[i - 1].length * 4;
                XO16_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_spc[0].name = "spc";
            XO16_spc[0].seek = 10268184576;
            XO16_spc[0].length = 131072;
            XO16_spc[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_spc[i].name = "spc";
                XO16_spc[i].seek = XO16_spc[i - 1].seek + XO16_spc[i - 1].length;
                XO16_spc[i].length = XO16_spc[i - 1].length * 4;
                XO16_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_ilm[0].name = "ilm";
            XO16_ilm[0].seek = 10270937088;
            XO16_ilm[0].length = 131072;
            XO16_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_ilm[i].name = "ilm";
                XO16_ilm[i].seek = XO16_ilm[i - 1].seek + XO16_ilm[i - 1].length;
                XO16_ilm[i].length = XO16_ilm[i - 1].length * 4;
                XO16_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_ao[0].name = "ao";
            XO16_ao[0].seek = 10273689600;
            XO16_ao[0].length = 131072;
            XO16_ao[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_ao[i].name = "ao";
                XO16_ao[i].seek = XO16_ao[i - 1].seek + XO16_ao[i - 1].length;
                XO16_ao[i].length = XO16_ao[i - 1].length * 4;
                XO16_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_cav[0].name = "cav";
            XO16_cav[0].seek = 10276442112;
            XO16_cav[0].length = 131072;
            XO16_cav[0].seeklength = 128;
            while (i <= 2)
            {
                XO16_cav[i].name = "cav";
                XO16_cav[i].seek = XO16_cav[i - 1].seek + XO16_cav[i - 1].length;
                XO16_cav[i].length = XO16_cav[i - 1].length * 4;
                XO16_cav[i].seeklength = 128;
                i++;
            }
            i = 1;

            //弹夹部分
            XO16_clip_col[0].name = "col";
            XO16_clip_col[0].seek = 10237775872;
            XO16_clip_col[0].length = 65536;
            XO16_clip_col[0].seeklength = 128;
            while (i <= 1)
            {
                XO16_clip_col[i].name = "col";
                XO16_clip_col[i].seek = XO16_clip_col[i - 1].seek + XO16_clip_col[i - 1].length;
                XO16_clip_col[i].length = XO16_clip_col[i - 1].length * 4;
                XO16_clip_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_clip_nml[0].name = "nml";
            XO16_clip_nml[0].seek = 10240593920;
            XO16_clip_nml[0].length = 131072;
            XO16_clip_nml[0].seeklength = 128;
            while (i <= 1)
            {
                XO16_clip_nml[i].name = "nml";
                XO16_clip_nml[i].seek = XO16_clip_nml[i - 1].seek + XO16_clip_nml[i - 1].length;
                XO16_clip_nml[i].length = XO16_clip_nml[i - 1].length * 4;
                XO16_clip_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_clip_gls[0].name = "gls";
            XO16_clip_gls[0].seek = 10246098944;
            XO16_clip_gls[0].length = 65536;
            XO16_clip_gls[0].seeklength = 128;
            while (i <= 1)
            {
                XO16_clip_gls[i].name = "gls";
                XO16_clip_gls[i].seek = XO16_clip_gls[i - 1].seek + XO16_clip_gls[i - 1].length;
                XO16_clip_gls[i].length = XO16_clip_gls[i - 1].length * 4;
                XO16_clip_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_clip_spc[0].name = "spc";
            XO16_clip_spc[0].seek = 10248851456;
            XO16_clip_spc[0].length = 65536;
            XO16_clip_spc[0].seeklength = 128;
            while (i <= 1)
            {
                XO16_clip_spc[i].name = "spc";
                XO16_clip_spc[i].seek = XO16_clip_spc[i - 1].seek + XO16_clip_spc[i - 1].length;
                XO16_clip_spc[i].length = XO16_clip_spc[i - 1].length * 4;
                XO16_clip_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_clip_ilm[0].name = "ilm";
            XO16_clip_ilm[0].seek = 10251603968;
            XO16_clip_ilm[0].length = 65536;
            XO16_clip_ilm[0].seeklength = 128;
            while (i <= 1)
            {
                XO16_clip_ilm[i].name = "ilm";
                XO16_clip_ilm[i].seek = XO16_clip_ilm[i - 1].seek + XO16_clip_ilm[i - 1].length;
                XO16_clip_ilm[i].length = XO16_clip_ilm[i - 1].length * 4;
                XO16_clip_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_clip_ao[0].name = "ao";
            XO16_clip_ao[0].seek = 10234892288;
            XO16_clip_ao[0].length = 65536;
            XO16_clip_ao[0].seeklength = 128;
            while (i <= 1)
            {
                XO16_clip_ao[i].name = "ao";
                XO16_clip_ao[i].seek = XO16_clip_ao[i - 1].seek + XO16_clip_ao[i - 1].length;
                XO16_clip_ao[i].length = XO16_clip_ao[i - 1].length * 4;
                XO16_clip_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            XO16_clip_cav[0].name = "cav";
            XO16_clip_cav[0].seek = 10254356480;
            XO16_clip_cav[0].length = 65536;
            XO16_clip_cav[0].seeklength = 128;
            while (i <= 1)
            {
                XO16_clip_cav[i].name = "cav";
                XO16_clip_cav[i].seek = XO16_clip_cav[i - 1].seek + XO16_clip_cav[i - 1].length;
                XO16_clip_cav[i].length = XO16_clip_cav[i - 1].length * 4;
                XO16_clip_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
