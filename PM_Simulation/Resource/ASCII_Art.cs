using PM_Simulation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Simulation.Resource
{
    public class ASCII_Art
    {
        public string MainLogo = @"
______ ___  ___         _____  _                    _         _    _               
| ___ \|  \/  |        /  ___|(_)                  | |       | |  (_)              
| |_/ /| .  . |        \ `--.  _  _ __ ___   _   _ | |  __ _ | |_  _   ___   _ __  
|  __/ | |\/| |         `--. \| || '_ ` _ \ | | | || | / _` || __|| | / _ \ | '_ \ 
| |    | |  | |        /\__/ /| || | | | | || |_| || || (_| || |_ | || (_) || | | |
\_|    \_|  |_/        \____/ |_||_| |_| |_| \__,_||_| \__,_| \__||_| \___/ |_| |_|
";


        public void DrawASCII_Art(int startX, int startY, String asciiart)
        {
            string[] lines = asciiart.Split('\n'); // 줄 단위로 분할
            Console.WriteLine(lines[0]);
            Console.WriteLine(lines[2]);

            //for (int y = 0; y < lines.Length; y++)
            //{
            //    for (int x = 0; x < lines[y].Length; x++)
            //    {
            //        DisplayBuffer.Instance().SetCharacter(startX + x, startY + y, MainLogo, ConsoleColor.Cyan);
            //    }
            //}
        }
    }


}

