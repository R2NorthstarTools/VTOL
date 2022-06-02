using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.TitanData.Public_Data
{
    class Public
    {
        public string Seek { get; private set; }
        public string Length { get; private set; }
        public string SeekLength { get; private set; }
        //兴奋剂铁驭
        public Public(String TitanPart, int imagecheck)
        {
            String str = TitanPart.Substring(1, TitanPart.Length - 5);
            if (str.Contains("Cockpit"))
            {
                Cockpit.Cockpit coc = new Cockpit.Cockpit(str, imagecheck);
                Seek = coc.Seek;
                Length = coc.Length;
                SeekLength = coc.SeekLength;
            }
            else if (str.Contains("Console"))
            {
                //控制台没有ao和cav贴图
                Cockpit.Console con = new Cockpit.Console(str, imagecheck);
                Seek = con.Seek;
                Length = con.Length;
                SeekLength = con.SeekLength;
            }
            else if (str.Contains("Screen"))
            {
                //See <Screen.cs> :(
            }
            else
            {
                throw new Exception("BUG!" + "\n" + "In Titan Part.");
            }
        }
    }
}
