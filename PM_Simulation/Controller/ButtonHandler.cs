using PM_Simulation.Resource;
using System;
using System.Runtime.InteropServices;

namespace PM_Simulation.Controller
{
    public class ButtonHandler
    {
        private Button[] Buttons;
        private int selectedIndex = -1;
        private bool isMouseDown = false;

        public ButtonHandler(Button[] buttons)
        {
            Buttons = buttons;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT_RECORD
        {
            public ushort EventType;
            public MOUSE_EVENT_RECORD MouseEvent;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSE_EVENT_RECORD
        {  
            public COORD dwMousePosition;
            public uint dwButtonState;
            public uint dwControlKeyState;
            public uint dwEventFlags;
        }

        private const int STD_INPUT_HANDLE = -10;
        private const ushort MOUSE_EVENT = 0x0002;
        private const uint FROM_LEFT_1ST_BUTTON_PRESSED = 0x0001;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]

        static extern bool ReadConsoleInput(IntPtr hConsoleInput, out INPUT_RECORD lpBuffer, uint nLength, out uint lpNumberOfEventsRead);

        public void Run()
        {
            IntPtr handle = GetStdHandle(STD_INPUT_HANDLE);
            Console.Clear();

            Console.WriteLine("콘솔 창에서 마우스를 클릭하면 좌표가 출력됩니다. (Ctrl + C로 종료)");

            int lastSelectedIndex = -1; // 이전 선택된 버튼 인덱스 저장

            while (DisplayBuffer.Instance().isBufferView)
            {
                // **초기 버튼 표시 (색상: White)**
                for (int i = 0; i < Buttons.Length; i++)
                {
                    ConsoleColor buttonColor = (i == selectedIndex) ? ConsoleColor.Yellow : ConsoleColor.White;

                    // 문자열 전체를 한 번에 전달하도록 변경
                    DisplayBuffer.Instance().SetCharacter(Buttons[i].X, Buttons[i].Y, Buttons[i].Name, buttonColor);
                }

                DisplayBuffer.Instance().Render(); // 초기 버튼 출력

                while (true)
                {
                    ReadConsoleInput(handle, out INPUT_RECORD record, 1, out uint readEvents);

                    if (record.EventType == MOUSE_EVENT)
                    {
                        int mouseX = record.MouseEvent.dwMousePosition.X;
                        int mouseY = record.MouseEvent.dwMousePosition.Y;

                        bool isMouseOverButton = false;

                        for (int i = 0; i < Buttons.Length; i++)
                        {
                            if (mouseX >= Buttons[i].X && mouseX < Buttons[i].X + Buttons[i].Name.Length + 10 &&
                                mouseY == Buttons[i].Y) //마우스가 버튼에 위치함
                            {
                                if (selectedIndex != i)  // 선택된 버튼이 변경되었을 때만 갱신
                                {
                                    selectedIndex = i;
                                }
                                isMouseOverButton = true;

                                if ((record.MouseEvent.dwButtonState & FROM_LEFT_1ST_BUTTON_PRESSED) != 0) //클릭 시작
                                {
                                    isMouseDown = true;
                                }
                                else if (isMouseDown)//클릭 뗌
                                {
                                    Buttons[selectedIndex].ExecuteEffect();
                                    isMouseDown = false;
                                }
                            }
                        }

                        if (!isMouseOverButton)
                        {
                            selectedIndex = -1;
                        }
                    }

                    // **이전 선택된 버튼과 현재 선택된 버튼이 다를 때만 갱신**
                    if (selectedIndex != lastSelectedIndex)
                    {
                        for (int i = 0; i < Buttons.Length; i++)
                        {
                            ConsoleColor buttonColor = (i == selectedIndex) ? ConsoleColor.Yellow : ConsoleColor.White;

                            // 문자열 전체를 한 번에 전달하도록 변경
                            DisplayBuffer.Instance().SetCharacter(Buttons[i].X, Buttons[i].Y, Buttons[i].Name, buttonColor);
                        }
                        DisplayBuffer.Instance().Render();
                        lastSelectedIndex = selectedIndex;  // 이전 선택 인덱스 업데이트
                    }
                }
            }//while1
        }
    }
}
