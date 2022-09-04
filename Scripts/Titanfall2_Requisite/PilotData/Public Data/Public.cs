using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.PilotData.Public_Data
{
    class Public
    {
        public string Seek { get; private set; }
        public string Length { get; private set; }
        public string SeekLength { get; private set; }
        //兴奋剂铁驭
        public Public(String PilotPart, int imagecheck)
        {
            String str = PilotPart.Substring(1, PilotPart.Length - 5);
            if (str.Contains("skeleton"))
            {
                //Todo:Didn't found this part.
            }
            else if (str.Contains("head"))
            {
                Part.head he = new Part.head(str, imagecheck);
                Seek = he.Seek;
                Length = he.Length;
                SeekLength = he.SeekLength;
            }
            else
            {
                throw new Exception("BUG!" + "\n" + "In Pilot Part.");
            }
        }
    }
}
