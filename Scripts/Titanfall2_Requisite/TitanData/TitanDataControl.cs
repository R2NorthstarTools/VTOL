using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTOL;
namespace VTOL.Titanfall2_Requisite.TitanDataControl
{
    class TitanDataControl
    {
        public string Seek { get; private set; }
        public string Length { get; private set; }
        public string SeekLength { get; private set; }
        public TitanDataControl(string TitanData, int imagecheck)
        {
            string[] name = MainWindow.GetTextureName(TitanData);
            string str = name[0];
            string s = name[1];
            string temp = name[2];
            if (str.Contains("Titan_"))
            {
                switch (s)
                {
                    //公共部分
                    case "Titan":
                        Titanfall2_SkinTool.Titanfall2.PilotData.Public_Data.Public PublicData = new Titanfall2_SkinTool.Titanfall2.PilotData.Public_Data.Public(temp, imagecheck);
                        Seek = PublicData.Seek;
                        Length = PublicData.Length;
                        SeekLength = PublicData.SeekLength;
                        break;
                    default:
                        throw new Exception("BUG!" + "\n" + "Error Titan Data.");
                }
            }
            else
            {
                throw new Exception("BUG!" + "\n" + "Error Titan Data File.");
            }
        }
    }
}
