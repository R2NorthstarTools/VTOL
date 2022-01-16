using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.SubmachineGun
{
    class CAR
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] CAR_col;
        public ReallyData[] CAR_nml;
        public ReallyData[] CAR_gls;
        public ReallyData[] CAR_spc;
        public ReallyData[] CAR_ilm;
        public ReallyData[] CAR_ao;
        public ReallyData[] CAR_cav;
        public CAR()
        {
            int i = 1;
            
            CAR_col = new ReallyData[3];
            CAR_nml = new ReallyData[3];
            CAR_gls = new ReallyData[3];
            CAR_spc = new ReallyData[3];
            CAR_ilm = new ReallyData[3];
            CAR_ao = new ReallyData[3];
            CAR_cav = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            CAR_col[0].name = "col";
            CAR_col[0].seek = 9510850560;
            CAR_col[0].length = 131072;
            CAR_col[0].seeklength = 128;
            while (i <= 2)
            {
                CAR_col[i].name = "col";
                CAR_col[i].seek = CAR_col[i - 1].seek + CAR_col[i - 1].length;
                CAR_col[i].length = CAR_col[i - 1].length * 4;
                CAR_col[i].seeklength = 128;
                i++;
            }
            i = 1;

            CAR_nml[0].name = "nml";
            CAR_nml[0].seek = 9513668608;
            CAR_nml[0].length = 262144;
            CAR_nml[0].seeklength = 128;
            while (i <= 2)
            {
                CAR_nml[i].name = "nml";
                CAR_nml[i].seek = CAR_nml[i - 1].seek + CAR_nml[i - 1].length;
                CAR_nml[i].length = CAR_nml[i - 1].length * 4;
                CAR_nml[i].seeklength = 128;
                i++;
            }
            i = 1;

            CAR_gls[0].name = "gls";
            CAR_gls[0].seek = 9519173632;
            CAR_gls[0].length = 131072;
            CAR_gls[0].seeklength = 128;
            while (i <= 2)
            {
                CAR_gls[i].name = "gls";
                CAR_gls[i].seek = CAR_gls[i - 1].seek + CAR_gls[i - 1].length;
                CAR_gls[i].length = CAR_gls[i - 1].length * 4;
                CAR_gls[i].seeklength = 128;
                i++;
            }
            i = 1;

            CAR_spc[0].name = "spc";
            CAR_spc[0].seek = 9521926144;
            CAR_spc[0].length = 131072;
            CAR_spc[0].seeklength = 128;
            while (i <= 2)
            {
                CAR_spc[i].name = "spc";
                CAR_spc[i].seek = CAR_spc[i - 1].seek + CAR_spc[i - 1].length;
                CAR_spc[i].length = CAR_spc[i - 1].length * 4;
                CAR_spc[i].seeklength = 128;
                i++;
            }
            i = 1;

            CAR_ilm[0].name = "ilm";
            CAR_ilm[0].seek = 9524678656;
            CAR_ilm[0].length = 131072;
            CAR_ilm[0].seeklength = 128;
            while (i <= 2)
            {
                CAR_ilm[i].name = "ilm";
                CAR_ilm[i].seek = CAR_ilm[i - 1].seek + CAR_ilm[i - 1].length;
                CAR_ilm[i].length = CAR_ilm[i - 1].length * 4;
                CAR_ilm[i].seeklength = 128;
                i++;
            }
            i = 1;

            CAR_ao[0].name = "ao";
            CAR_ao[0].seek = 9527431168;
            CAR_ao[0].length = 131072;
            CAR_ao[0].seeklength = 128;
            while (i <= 2)
            {
                CAR_ao[i].name = "ao";
                CAR_ao[i].seek = CAR_ao[i - 1].seek + CAR_ao[i - 1].length;
                CAR_ao[i].length = CAR_ao[i - 1].length * 4;
                CAR_ao[i].seeklength = 128;
                i++;
            }
            i = 1;

            CAR_cav[0].name = "cav";
            CAR_cav[0].seek = 9530183680;
            CAR_cav[0].length = 131072;
            CAR_cav[0].seeklength = 128;
            while (i <= 2)
            {
                CAR_cav[i].name = "cav";
                CAR_cav[i].seek = CAR_cav[i - 1].seek + CAR_cav[i - 1].length;
                CAR_cav[i].length = CAR_cav[i - 1].length * 4;
                CAR_cav[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
