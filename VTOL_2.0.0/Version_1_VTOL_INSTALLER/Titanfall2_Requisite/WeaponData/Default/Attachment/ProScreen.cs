using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Attachment
{
    class ProScreen
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] ProScreen_col;
        public ReallyData[] ProScreen_nml;
        public ReallyData[] ProScreen_gls;
        public ReallyData[] ProScreen_spc;
        public ReallyData[] ProScreen_ilm;
        public ReallyData[] ProScreen_ao;
        public ReallyData[] ProScreen_cav;
        public ProScreen()
        {

            ProScreen_col = new ReallyData[1];
            ProScreen_nml = new ReallyData[1];
            ProScreen_gls = new ReallyData[1];
            ProScreen_spc = new ReallyData[1];
            ProScreen_ilm = new ReallyData[1];
            ProScreen_ao = new ReallyData[1];
            ProScreen_cav = new ReallyData[1];
            //0为512x512

            ProScreen_col[0].name = "col";
            ProScreen_col[0].seek = 9395638272;
            ProScreen_col[0].length = 131072;
            ProScreen_col[0].seeklength = 128;
/*
            while (i <= 1)
            {
                ProScreen_col[i].name = "col";
                ProScreen_col[i].seek = ProScreen_col[i - 1].seek + ProScreen_col[i - 1].length;
                ProScreen_col[i].length = ProScreen_col[i - 1].length * 4;
                ProScreen_col[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
            ProScreen_nml[0].name = "nml";
            ProScreen_nml[0].seek = 9395834880;
            ProScreen_nml[0].length = 262144;
            ProScreen_nml[0].seeklength = 128;
/*
            while (i <= 1)
            {
                ProScreen_nml[i].name = "nml";
                ProScreen_nml[i].seek = ProScreen_nml[i - 1].seek + ProScreen_nml[i - 1].length;
                ProScreen_nml[i].length = ProScreen_nml[i - 1].length * 4;
                ProScreen_nml[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
            ProScreen_gls[0].name = "gls";
            ProScreen_gls[0].seek = 9396097024;
            ProScreen_gls[0].length = 131072;
            ProScreen_gls[0].seeklength = 128;
/*
            while (i <= 1)
            {
                ProScreen_gls[i].name = "gls";
                ProScreen_gls[i].seek = ProScreen_gls[i - 1].seek + ProScreen_gls[i - 1].length;
                ProScreen_gls[i].length = ProScreen_gls[i - 1].length * 4;
                ProScreen_gls[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
            ProScreen_spc[0].name = "spc";
            ProScreen_spc[0].seek = 9396228096;
            ProScreen_spc[0].length = 131072;
            ProScreen_spc[0].seeklength = 128;
/*
            while (i <= 1)
            {
                ProScreen_spc[i].name = "spc";
                ProScreen_spc[i].seek = ProScreen_spc[i - 1].seek + ProScreen_spc[i - 1].length;
                ProScreen_spc[i].length = ProScreen_spc[i - 1].length * 4;
                ProScreen_spc[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
            ProScreen_ilm[0].name = "ilm";
            ProScreen_ilm[0].seek = 9396359168;
            ProScreen_ilm[0].length = 131072;
            ProScreen_ilm[0].seeklength = 128;
/*
            while (i <= 1)
            {
                ProScreen_ilm[i].name = "ilm";
                ProScreen_ilm[i].seek = ProScreen_ilm[i - 1].seek + ProScreen_ilm[i - 1].length;
                ProScreen_ilm[i].length = ProScreen_ilm[i - 1].length * 4;
                ProScreen_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
            ProScreen_ao[0].name = "ao";
            ProScreen_ao[0].seek = 9396490240;
            ProScreen_ao[0].length = 131072;
            ProScreen_ao[0].seeklength = 128;
/* 
            while (i <= 1)
            {
                ProScreen_ao[i].name = "ao";
                ProScreen_ao[i].seek = ProScreen_ao[i - 1].seek + ProScreen_ao[i - 1].length;
                ProScreen_ao[i].length = ProScreen_ao[i - 1].length * 4;
                ProScreen_ao[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
            ProScreen_cav[0].name = "cav";
            ProScreen_cav[0].seek = 9396621312;
            ProScreen_cav[0].length = 131072;
            ProScreen_cav[0].seeklength = 128;
/*            
            while (i <= 1)
            {
                ProScreen_cav[i].name = "cav";
                ProScreen_cav[i].seek = ProScreen_cav[i - 1].seek + ProScreen_cav[i - 1].length;
                ProScreen_cav[i].length = ProScreen_cav[i - 1].length * 4;
                ProScreen_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
*/
        }
    }
}
