using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Jack
{
    class Jack
    {
        public string Seek { get; private set; }
        public string Length { get; private set; }
        public string SeekLength { get; private set; }
        //Jack Cooper Hands LOL
        public Jack(String PilotPart,int imagecheck)
        {
            String str = PilotPart.Substring(1,PilotPart.Length-5);
            if (str.Contains("gauntlet"))
            {
                Part.gauntlet ga = new Part.gauntlet(str, imagecheck);
                Seek = ga.Seek;
                Length = ga.Length;
                SeekLength = ga.SeekLength;
            }
            else if (str.Contains("gauntletr"))
            {
                Part.gauntletr gar = new Part.gauntletr(str, imagecheck);
                Seek = gar.Seek;
                Length = gar.Length;
                SeekLength = gar.SeekLength;
            }
            else
            {
                throw new Exception("BUG!"+"\n"+"In Pilot Part.");
            }
        }
    }
}
