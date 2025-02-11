using PM_Simulation.Resource;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;  // List 사용을 위해 추가

namespace PM_Simulation.Controller
{
    public class MouseHandler
    {
        private List<Button> Buttons;  // 배열에서 List<Button>으로 변경
        private int selectedIndex = -1;
        private int mouseX;
        private int mouseY;
        private bool isMouseDown = false;
        private bool isMouseOverButton;

        public MouseHandler(List<Button> buttons)  // 매개변수도 List<Button>으로 변경
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
        static extern bool ReadConsoleInput(IntPtr hConsoleInput, out INPUT_RECORD lpBuffer, uint nLength, out uint lpNumberOfEventsRead);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetStdHandle(int nStdHandle);
        public IntPtr GetConsoleHandle()
        {
            return GetStdHandle(STD_INPUT_HANDLE);
        }
        public void HandleMouseEvents(IntPtr handle)
        {
            ReadConsoleInput(handle, out INPUT_RECORD record, 1, out uint readEvents);

            if (record.EventType == MOUSE_EVENT)
            {
                mouseX = record.MouseEvent.dwMousePosition.X;
                mouseY = record.MouseEvent.dwMousePosition.Y;

                isMouseOverButton = false;

                for (int i = 0; i < Buttons.Count; i++)  // Buttons.Length -> Buttons.Count로 변경
                {
                    if (mouseX >= Buttons[i].X && mouseX < Buttons[i].X + Buttons[i].Name.Length + 4 &&
                        mouseY == Buttons[i].Y) // 마우스가 버튼 위에 있을 때
                    {
                        if (selectedIndex != i)
                        {
                            selectedIndex = i;
                        }
                        isMouseOverButton = true;

                        if ((record.MouseEvent.dwButtonState & FROM_LEFT_1ST_BUTTON_PRESSED) != 0) // 클릭 시작
                        {
                            isMouseDown = true;
                        }
                        else if (isMouseDown) // 클릭 종료
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
        }

        public int GetSelectedIndex()
        {
            return selectedIndex;
        }
    }
}
