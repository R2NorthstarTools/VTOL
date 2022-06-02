using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData.Default.JackParts
{
    class JackHandR
    {
        public struct ReallyData
        {
            public string name;
            public long seek;
            public int length;
            public int seeklength;
        }

        public ReallyData[] JackHandR_col;
        public JackHandR()
        {
            int i = 1;

            JackHandR_col = new ReallyData[3];
            //2为2048x2048,1为1024x1024,0为512x512

            JackHandR_col[0].name = "col";
            JackHandR_col[0].seek = 261099520;
            JackHandR_col[0].length = 131072;
            JackHandR_col[0].seeklength = 128;
            while (i <= 2)
            {
                JackHandR_col[i].name = "col";
                JackHandR_col[i].seek = JackHandR_col[i - 1].seek + JackHandR_col[i - 1].length;
                JackHandR_col[i].length = JackHandR_col[i - 1].length * 4;
                JackHandR_col[i].seeklength = 128;
                i++;
            }
            i = 1;
        }
    }
}
