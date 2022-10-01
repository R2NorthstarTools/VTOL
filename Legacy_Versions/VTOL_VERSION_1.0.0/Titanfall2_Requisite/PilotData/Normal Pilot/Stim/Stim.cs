using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Stim
{
    class Stim
    {
        public string Seek { get; private set; }
        public string Length { get; private set; }
        public string SeekLength { get; private set; }
        //兴奋剂铁驭
        public Stim(String PilotPart,int imagecheck)
        {
            String str = PilotPart.Substring(1,PilotPart.Length-5);
            if (str.Contains("fbody"))
            {
                Part.fbody fb = new Part.fbody(str,imagecheck);
                Seek = fb.Seek;
                Length = fb.Length;
                SeekLength = fb.SeekLength;
            }
            else if (str.Contains("fgear"))
            {
                Part.fgear fg = new Part.fgear(str, imagecheck);
                Seek = fg.Seek;
                Length = fg.Length;
                SeekLength = fg.SeekLength;
            }
            else if (str.Contains("fjumpkit"))
            {
                Part.fjumpkit fj = new Part.fjumpkit(str, imagecheck);
                Seek = fj.Seek;
                Length = fj.Length;
                SeekLength = fj.SeekLength;
            }
            else if (str.Contains("head"))
            {
                Part.head he = new Part.head(str, imagecheck);
                Seek = he.Seek;
                Length = he.Length;
                SeekLength = he.SeekLength;
            }
            else if (str.Contains("gauntlet"))
            {
                Part.gauntlet ga = new Part.gauntlet(str, imagecheck);
                Seek = ga.Seek;
                Length = ga.Length;
                SeekLength = ga.SeekLength;
            }
            else if (str.Contains("mbody"))
            {
                Part.mbody mb = new Part.mbody(str, imagecheck);
                Seek = mb.Seek;
                Length = mb.Length;
                SeekLength = mb.SeekLength;
            }
            else if (str.Contains("gear"))
            {
                Part.gear g = new Part.gear(str, imagecheck);
                Seek = g.Seek;
                Length = g.Length;
                SeekLength = g.SeekLength;
            }
            else if (str.Contains("jumpkit"))
            {
                Part.jumpkit j = new Part.jumpkit(str, imagecheck);
                Seek = j.Seek;
                Length = j.Length;
                SeekLength = j.SeekLength;
            }
            else
            {
                throw new Exception("BUG!"+"\n"+"In Pilot Part.");
            }
        }
    }
}
