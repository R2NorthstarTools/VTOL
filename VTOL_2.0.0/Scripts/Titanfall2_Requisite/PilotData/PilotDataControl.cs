using System;

namespace VTOL.Titanfall2_Requisite.PilotDataControl
{
    class PilotDataControl
    {
        public string Seek { get; private set; }
        public string Length { get; private set; }
        public string SeekLength { get; private set; }
        public PilotDataControl(string PilotName, int imagecheck)
        {
            string[] name = MainWindow.GetTextureName(PilotName);
            string str = name[0];
            string s = name[1];
            string temp = name[2];
            if (str.Contains("Stim_") || str.Contains("PhaseShift_") || str.Contains("HoloPilot_") || str.Contains("PulseBlade_") || str.Contains("Grapple_") || str.Contains("AWall_") || str.Contains("Cloak_") || str.Contains("Pilot_") || str.Contains("Jack_"))
            {
                switch (s)
                {
                    //兴奋剂铁驭
                    case "Stim":
                        Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Stim.Stim stim = new Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Stim.Stim(temp, imagecheck);
                        Seek = stim.Seek;
                        Length = stim.Length;
                        SeekLength = stim.SeekLength;
                        break;
                    //相位铁驭
                    case "PhaseShift":
                        Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.PhaseShift.PhaseShift phaseshift = new Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.PhaseShift.PhaseShift(temp, imagecheck);
                        Seek = phaseshift.Seek;
                        Length = phaseshift.Length;
                        SeekLength = phaseshift.SeekLength;
                        break;
                    //幻影铁驭
                    case "HoloPilot":
                        Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.HoloPilot.HoloPilot holopilot = new Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.HoloPilot.HoloPilot(temp, imagecheck);
                        Seek = holopilot.Seek;
                        Length = holopilot.Length;
                        SeekLength = holopilot.SeekLength;
                        break;
                    //脉冲刀铁驭
                    case "PulseBlade":
                        Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.PulseBlade.PulseBlade pulseblade = new Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.PulseBlade.PulseBlade(temp, imagecheck);
                        Seek = pulseblade.Seek;
                        Length = pulseblade.Length;
                        SeekLength = pulseblade.SeekLength;
                        break;
                    //钩爪铁驭
                    case "Grapple":
                        Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Grapple.Grapple grapple = new Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Grapple.Grapple(temp, imagecheck);
                        Seek = grapple.Seek;
                        Length = grapple.Length;
                        SeekLength = grapple.SeekLength;
                        break;
                    //A盾铁驭
                    case "AWall":
                        Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.AWall.AWall awall = new Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.AWall.AWall(temp, imagecheck);
                        Seek = awall.Seek;
                        Length = awall.Length;
                        SeekLength = awall.SeekLength;
                        break;
                    //隐身铁驭
                    case "Cloak":
                        Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Cloak.Cloak cloak = new Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Cloak.Cloak(temp, imagecheck);
                        Seek = cloak.Seek;
                        Length = cloak.Length;
                        SeekLength = cloak.SeekLength;
                        break;
                    //公共部分
                    case "Pilot":
                        Titanfall2_SkinTool.Titanfall2.PilotData.Public_Data.Public PublicData = new Titanfall2_SkinTool.Titanfall2.PilotData.Public_Data.Public(temp, imagecheck);
                        Seek = PublicData.Seek;
                        Length = PublicData.Length;
                        SeekLength = PublicData.SeekLength;
                        break;
                    case "Jack":
                        Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Jack.Jack jack = new Titanfall2_SkinTool.Titanfall2.PilotData.Normal_Pilot.Jack.Jack(temp, imagecheck);
                        Seek = jack.Seek;
                        Length = jack.Length;
                        SeekLength = jack.SeekLength;
                        break;
                    default:
                        throw new Exception("BUG!" + "\n" + "Error Pilot Name.");
                }
            }
            else
            {
                throw new Exception("BUG!" + "\n" + "Error File Name.");
            }
        }
    }
}
