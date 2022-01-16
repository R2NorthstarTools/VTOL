using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.Titan
{
    class LeadWall
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] LeadWall_col;
        public ReallyData[] LeadWall_nml;
        public ReallyData[] LeadWall_gls;
        public ReallyData[] LeadWall_spc;
        public ReallyData[] LeadWall_ilm;
        public ReallyData[] LeadWall_ao;
        public ReallyData[] LeadWall_cav;
        public LeadWall()
        {
            int i = 1;

            LeadWall_col = new ReallyData[3];
            LeadWall_nml = new ReallyData[3];
            LeadWall_gls = new ReallyData[3];
            LeadWall_spc = new ReallyData[3];
            LeadWall_ilm = new ReallyData[3];
            LeadWall_ao = new ReallyData[3];
            LeadWall_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            LeadWall_col[0].name = "col";
            LeadWall_col[0].seek = 9510850560;
            LeadWall_col[0].length = 131072;
            LeadWall_col[0].seeklength = 128;
            while (i <= 2)
            {
                LeadWall_col[i].name = "col";
                LeadWall_col[i].seek = LeadWall_col[i - 1].seek + LeadWall_col[i - 1].length;
                LeadWall_col[i].length = LeadWall_col[i - 1].length * 4;
                LeadWall_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            LeadWall_nml[0].name = "nml";
            LeadWall_nml[0].seek = 9513668608;
            LeadWall_nml[0].length = 262144;
            LeadWall_nml[0].seeklength = 128;
            while (i <= 2)
            {
                LeadWall_nml[i].name = "nml";
                LeadWall_nml[i].seek = LeadWall_nml[i - 1].seek + LeadWall_nml[i - 1].length;
                LeadWall_nml[i].length = LeadWall_nml[i - 1].length * 4;
                LeadWall_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            LeadWall_gls[0].name = "gls";
            LeadWall_gls[0].seek = 9519173632;
            LeadWall_gls[0].length = 131072;
            LeadWall_gls[0].seeklength = 128;
            while (i <= 2)
            {
                LeadWall_gls[i].name = "gls";
                LeadWall_gls[i].seek = LeadWall_gls[i - 1].seek + LeadWall_gls[i - 1].length;
                LeadWall_gls[i].length = LeadWall_gls[i - 1].length * 4;
                LeadWall_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            LeadWall_spc[0].name = "spc";
            LeadWall_spc[0].seek = 9521926144;
            LeadWall_spc[0].length = 131072;
            LeadWall_spc[0].seeklength = 128;
            while (i <= 2)
            {
                LeadWall_spc[i].name = "spc";
                LeadWall_spc[i].seek = LeadWall_spc[i - 1].seek + LeadWall_spc[i - 1].length;
                LeadWall_spc[i].length = LeadWall_spc[i - 1].length * 4;
                LeadWall_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            LeadWall_ilm[0].name = "ilm";
            LeadWall_ilm[0].seek = 9524678656;
            LeadWall_ilm[0].length = 131072;
            LeadWall_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                LeadWall_ilm[i].name = "ilm";
                LeadWall_ilm[i].seek = LeadWall_ilm[i - 1].seek + LeadWall_ilm[i - 1].length;
                LeadWall_ilm[i].length = LeadWall_ilm[i - 1].length * 4;
                LeadWall_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            LeadWall_ao[0].name = "ao";
            LeadWall_ao[0].seek = 9527431168;
            LeadWall_ao[0].length = 131072;
            LeadWall_ao[0].seeklength = 128;
            while (i <= 2)
            {
                LeadWall_ao[i].name = "ao";
                LeadWall_ao[i].seek = LeadWall_ao[i - 1].seek + LeadWall_ao[i - 1].length;
                LeadWall_ao[i].length = LeadWall_ao[i - 1].length * 4;
                LeadWall_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            LeadWall_cav[0].name = "cav";
            LeadWall_cav[0].seek = 9530183680;
            LeadWall_cav[0].length = 131072;
            LeadWall_cav[0].seeklength = 128;
            while (i <= 2)
            {
                LeadWall_cav[i].name = "cav";
                LeadWall_cav[i].seek = LeadWall_cav[i - 1].seek + LeadWall_cav[i - 1].length;
                LeadWall_cav[i].length = LeadWall_cav[i - 1].length * 4;
                LeadWall_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
