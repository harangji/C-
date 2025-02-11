using PM_Simulation.Resource;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;  // List 사용을 위해 추가

namespace PM_Simulation.Controller
{
    public class ButtonHandler2
    {
        private List<Button> Buttons;  // 배열에서 List<Button>으로 변경
        private MouseHandler mouseHandler;
        private int lastSelectedIndex = -1;

        public ButtonHandler2(List<Button> buttons)  // 매개변수도 List<Button>으로 변경
        {
            Buttons = buttons;
            mouseHandler = new MouseHandler(buttons);  // MouseHandler도 List<Button>으로 변경된 생성자 호출
            DisplayBuffer.Instance().RenderstartY();
        }

        public void Run()
        {
            for (int i = 0; i < Buttons.Count; i++)  // Buttons.Length -> Buttons.Count로 변경
            {
                ConsoleColor buttonColor = ConsoleColor.White;

                // 문자열 전체를 한 번에 전달하도록 변경
                DisplayBuffer.Instance().SetCharacter(Buttons[i].X, Buttons[i].Y, Buttons[i].Name, buttonColor);
            }

            // STD_INPUT_HANDLE을 얻어서 MouseHandler에 전달
            IntPtr handle = GetStdHandle(STD_INPUT_HANDLE);

            // 버튼 초기화 및 표시
            DisplayButtons();

            while (DisplayBuffer.Instance().isBufferView)
            {
                // 마우스 이벤트 처리
                mouseHandler.HandleMouseEvents(handle);

                // 선택된 버튼 인덱스 얻기
                int selectedIndex = mouseHandler.GetSelectedIndex();

                // 선택된 버튼 변경 시 버튼 색상 업데이트
                if (selectedIndex != lastSelectedIndex)
                {
                    DisplayButtons(selectedIndex);
                    lastSelectedIndex = selectedIndex;
                }

                System.Threading.Thread.Sleep(10); // 이벤트 루프 대기
            }
        }

        private void DisplayButtons(int selectedIndex = -1)
        {
            for (int i = 0; i < Buttons.Count; i++)  // Buttons.Length -> Buttons.Count로 변경
            {
                ConsoleColor buttonColor = (i == selectedIndex) ? ConsoleColor.Yellow : ConsoleColor.White;
                DisplayBuffer.Instance().ChangeButtonColor(Buttons[i].X, Buttons[i].Y, Buttons[i].Name.Length, buttonColor);
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        private const int STD_INPUT_HANDLE = -10;
    }
}
