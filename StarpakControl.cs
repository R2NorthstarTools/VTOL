using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Created By zxcPandora at https://github.com/zxcPandora/Titanfall2-SkinTool
namespace Northstar_Manger
{
    class StarpakControl
    {
        public StarpakControl(string name, Int64 seek, int length, int type, string GamePath, string SelectedGame, int imagecheck, string Action)
        {                       //ToDo:Change to the Struct
            string FileName = null;
            string ControlPath = null;
            byte[] byData = new byte[length];
            switch (SelectedGame)
            {
                case "Titanfall2":
                    ControlPath = GamePath + "\\r2\\paks\\Win64\\";
                    if (name.Contains("WingmanElite") || name.Contains("R101"))
                    {
                        FileName = "pc_stream(03).starpak";
                    }
                    else
                    {
                        FileName = "pc_stream.starpak";
                    }
                    break;
                //Fixed
               
                default:
                    throw new Exception("Error!");
            }

            try
            {
                FileStream aFile = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                aFile.Seek(type, SeekOrigin.Begin);
                aFile.Read(byData, 0, length);

                //Fixed
                FileStream fswrite = new FileStream(ControlPath + FileName, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                fswrite.Seek(seek, SeekOrigin.Begin);
                fswrite.Write(byData, 0, length);

                aFile.Close();
                fswrite.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }
    }
}
