using System;

namespace Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Cloak
{
    class Cloak
    {
        //隐身铁驭
        public string Seek { get; private set; }
        public string Length { get; private set; }
        public string SeekLength { get; private set; }
        public Cloak(String PilotPart, int imagecheck)
        {
            String str = PilotPart.Substring(1, PilotPart.Length - 5);
            if (str.Contains("fbody"))
            {
                Part.fbody fb = new Part.fbody(str, imagecheck);
                Seek = fb.Seek;
                Length = fb.Length;
                SeekLength = fb.SeekLength;
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
            else if (str.Contains("helmet"))
            {
                Part.helmet he = new Part.helmet(str, imagecheck);
                Seek = he.Seek;
                Length = he.Length;
                SeekLength = he.SeekLength;
            }
            else if (str.Contains("ghillie"))
            {
                Part.ghillie gh = new Part.ghillie(str, imagecheck);
                Seek = gh.Seek;
                Length = gh.Length;
                SeekLength = gh.SeekLength;
            }
            else if (str.Contains("cards"))
            {
                //wtf this part,texture the same with ghillie?
                throw new Exception("BUG!" + "\n" + "In Texture Part.");
            }
            else
            {
                throw new Exception("BUG!" + "\n" + "In Pilot Part.");
            }
        }
    }
}
