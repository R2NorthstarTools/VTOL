using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titanfall2_SkinTool.Titanfall2.PilotData
{
    class PilotDataControl
    {
        public string Seek { get; private set; }
        public string Length { get; private set; }
        public string SeekLength { get; private set; }
        public PilotDataControl(string PilotName, int imagecheck)
        {
            string s = PilotName;
            int toname = s.LastIndexOf("\\") + 1;
            string str = s.Substring(toname, s.Length - toname);
            toname = str.IndexOf("_");
            string temp = str.Substring(toname, str.Length - toname);
            s = str.Replace(temp, "");
            if (str.Contains("Stim_") || str.Contains("PhaseShift_") || str.Contains("HoloPilot_") || str.Contains("PulseBlade_") || str.Contains("Grapple_") || str.Contains("AWall_") || str.Contains("Cloak_") || str.Contains("Public_"))
            {
                switch (s)
                {
                    //兴奋剂铁驭
                    case "Stim":
                        Normal_Pilot.Stim.Stim stim = new Normal_Pilot.Stim.Stim(temp,imagecheck);
                        Seek = stim.Seek;
                        Length = stim.Length;
                        SeekLength = stim.SeekLength;
                        break;
                    //相位铁驭
                    case "PhaseShift":
                        Normal_Pilot.PhaseShift.PhaseShift phaseshift = new Normal_Pilot.PhaseShift.PhaseShift(temp, imagecheck);
                        Seek = phaseshift.Seek;
                        Length = phaseshift.Length;
                        SeekLength = phaseshift.SeekLength;
                        break;
                    //幻影铁驭
                    case "HoloPilot":
                        Normal_Pilot.HoloPilot.HoloPilot holopilot = new Normal_Pilot.HoloPilot.HoloPilot(temp, imagecheck);
                        Seek = holopilot.Seek;
                        Length = holopilot.Length;
                        SeekLength = holopilot.SeekLength;
                        break;
                    //脉冲刀铁驭
                    case "PulseBlade":
                        Normal_Pilot.PulseBlade.PulseBlade pulseblade = new Normal_Pilot.PulseBlade.PulseBlade(temp, imagecheck);
                        Seek = pulseblade.Seek;
                        Length = pulseblade.Length;
                        SeekLength = pulseblade.SeekLength;
                        break;
                    //钩爪铁驭
                    case "Grapple":
                        Normal_Pilot.Grapple.Grapple grapple = new Normal_Pilot.Grapple.Grapple(temp, imagecheck);
                        Seek = grapple.Seek;
                        Length = grapple.Length;
                        SeekLength = grapple.SeekLength;
                        break;
                    //A盾铁驭
                    case "AWall":
                        Normal_Pilot.AWall.AWall awall = new Normal_Pilot.AWall.AWall(temp, imagecheck);
                        Seek = awall.Seek;
                        Length = awall.Length;
                        SeekLength = awall.SeekLength;
                        break;
                    //隐身铁驭
                    case "Cloak":
                        Normal_Pilot.Cloak.Cloak cloak = new Normal_Pilot.Cloak.Cloak(temp, imagecheck);
                        Seek = cloak.Seek;
                        Length = cloak.Length;
                        SeekLength = cloak.SeekLength;
                        break; 
                    //公共部分
                    case "Public":
                        Public_Data.Public PublicData = new Public_Data.Public(temp, imagecheck);
                        Seek = PublicData.Seek;
                        Length = PublicData.Length;
                        SeekLength = PublicData.SeekLength;
                        break;
                    default:
                        throw new Exception("BUG!"+"\n"+"Error Pilot Name.");
                }
            }
            else
            {
                throw new Exception("BUG!" + "\n" + "Error File Name.");
            }
        }
    }
}
