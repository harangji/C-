using System;
using System.Linq;
using System.Threading;

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

        private int DefaultWidth; // 출력 크기 설정
        private int DefaultHeight;

        private DisplayChar[,] buffer;

        private static DisplayBuffer instance;
        private static readonly object lockObj = new object();
        string[] lines;




        private DisplayBuffer()
        {
            // 현재 콘솔 창 크기에 맞게 buffer 크기 설정
            this.DefaultWidth = 140;  // 콘솔 창의 너비
            this.DefaultHeight = 40;  // 콘솔 창의 높이

            buffer = new DisplayChar[150, 40];
            Clear();  // 초기화 후 기본값으로 클리어
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
            lines = characters.Split('\n'); // 줄 단위로 분할

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].Trim('\r');  // \r 제거
            }

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (startX >= 0 && startX < DefaultWidth && startY >= 0 && startY < DefaultHeight)
                    {
                        if (startX >= 0 && startX < DefaultWidth && startY >= 0 && startY < DefaultHeight)
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
                    buffer[x, y] = new DisplayChar { Character = ' ', Color = ConsoleColor.White };
                }
            }
        }


        public void RenderstartY(int PrintstartY = 0)
        {
            Console.SetCursorPosition(0, PrintstartY);

            for (int y = 0; y < DefaultHeight - PrintstartY; y++) //출력 시작 행부터
            {
                for (int x = 0; x < DefaultWidth; x++)
                {
                        Console.ForegroundColor = buffer[x, y + PrintstartY].Color;
                        Console.Write(buffer[x, y + PrintstartY].Character);
                }

                Console.WriteLine();
            }
            Console.ResetColor();
        }

        public void ChangeButtonColor(int CindexX, int CindexY, int buttonlenth, ConsoleColor color)
        {
            Console.SetCursorPosition(0, CindexY);
            for (int i = 0; i < buttonlenth; i++)
            {
                buffer[CindexX + i, CindexY].Color = color;
            }

            for (int x = 0; x < DefaultWidth; x++)
            {
                Console.ForegroundColor = buffer[x, CindexY].Color;
                Console.Write(buffer[x, CindexY].Character);
            }
        }


        public void RenderByColumnOrderAnimated(bool leftToRight = true, int delay = 50)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            int startX = leftToRight ? 0 : DefaultWidth - 1;
            int endX = leftToRight ? DefaultWidth : -1;
            int stepX = leftToRight ? 1 : -1;

            for (int x = startX; x != endX; x += stepX)
            {
                for (int y = 0; y < DefaultHeight; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = buffer[x, y].Color;
                    Console.Write(buffer[x, y].Character);
                }
                Thread.Sleep(delay);
            }
            Console.ResetColor();
        }
    }
}
