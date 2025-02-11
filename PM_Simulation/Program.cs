using PM_Simulation;
using PM_Simulation.Controller;
using PM_Simulation.Resource;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace PM_Simulation
{
        class Program
        {
            // Win32 API: 콘솔 창 크기 변경 방지
            private const int MF_BYCOMMAND = 0x00000000;
            private const int SC_MAXIMIZE = 0xF030; // 최대화 버튼 비활성화
            private const int SC_SIZE = 0xF000;     // 창 크기 조정 비활성화

            [DllImport("user32.dll")]
            private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

            [DllImport("user32.dll")]
            private static extern bool DeleteMenu(IntPtr hMenu, int uPosition, int uFlags);

            [DllImport("kernel32.dll")]
            private static extern IntPtr GetConsoleWindow();

        static void Main()
        {
                Console.CursorVisible = false;
                Console.Title = "PM_Simulation";
                Console.SetWindowSize(150, 45);
                Console.SetBufferSize(150, 45);  // 버퍼 크기를 창 크기와 동일하게 설정

            // 창 크기 조정 및 최대화 버튼 비활성화
            IntPtr hMenu = GetSystemMenu(GetConsoleWindow(), false);
            if (hMenu != IntPtr.Zero)
            {
                DeleteMenu(hMenu, SC_SIZE, MF_BYCOMMAND);   // 크기 조정 비활성화
                DeleteMenu(hMenu, SC_MAXIMIZE, MF_BYCOMMAND); // 최대화 버튼 비활성화
            }

            GameControl games = new GameControl();
            }
        }
}
