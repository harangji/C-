using System;
using System.Linq;

namespace PM_Simulation.Controller
{
    public class DisplayBuffer
    {
        public bool isBufferView = true;
        private struct DisplayChar
        {
            public char Character;
            public ConsoleColor Color;
        }

        private DisplayChar[,] buffer;

        private static DisplayBuffer instance;
        private static readonly object lockObj = new object();

        private const int DefaultWidth = 130; //출력크기설정
        private const int DefaultHeight = 30;

        private DisplayBuffer()
        {
            buffer = new DisplayChar[DefaultWidth, DefaultHeight];
            Clear();
        }

        public static DisplayBuffer Instance()
        {
            if (instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new DisplayBuffer();
                    }
                }
            }
            return instance;
        }

        public void SetCharacter(int startX, int startY, string characters, ConsoleColor color = ConsoleColor.White)
        {
            string[] lines = characters.Split('\n'); // 줄 단위로 분할

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Trim('\r');  // \r 제거
            }

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (startX + x >= 0 && startX + x < DefaultWidth && startY + y >= 0 && startY + y < DefaultHeight)
                    {
                            if (startX + x >= 0 && startX + x < DefaultWidth && startY + y >= 0 && startY + y < DefaultHeight)
                            {
                                buffer[startX + x, startY + y] = new DisplayChar { Character = lines[y][x], Color = color };
                            }
                        }
                    }
                }
            }
     

        public void Clear()
        {
            for (int y = 0; y < DefaultHeight; y++)
            {
                for (int x = 0; x < DefaultWidth; x++)
                {
                    buffer[x, y] = new DisplayChar { Character = '-', Color = ConsoleColor.White };
                }
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(0, 0);
            //buffer[0, 0] = new DisplayChar { Character = 't', Color = ConsoleColor.White };
            //buffer[10, 1] = new DisplayChar { Character = 'e', Color = ConsoleColor.White };
            for (int y = 0; y < DefaultHeight; y++)
            {
                for (int x = 0; x < DefaultWidth; x++)
                {
                    Console.ForegroundColor = buffer[x, y].Color;
                    Console.Write(buffer[x, y].Character);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
