using PM_Simulation.Resource;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PM_Simulation.Controller
{
    public class ViewControl
    {
        public ASCII_Art ascii_art = new ASCII_Art();
        public ButtonData buttondata = new ButtonData();

        // ViewControl의 유일한 인스턴스를 저장하는 정적 변수
        private static ViewControl instance;

        // 생성자는 외부에서 접근할 수 없도록 private으로 설정
        private ViewControl() { }

        // ViewControl 인스턴스를 반환하는 정적 메서드
        public static ViewControl Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ViewControl();
                }
                return instance;
            }
        }

        // 상태 히스토리 관리용 큐 (뒤로 가기 구현을 위해)
        private Queue<string> screenHistory = new Queue<string>();

        // 상태 추적용 변수 (현재 화면 상태)
        private string currentState;

        public void MainPage()
        {
            // 상태 변경
            ChangeState("MainPage");

            DisplayBuffer.Instance().Clear();
//            DisplayBuffer.Instance().SetCharacter(0, 0, @"abcd
//sadgadfsg
//sadfsdf");
            DisplayBuffer.Instance().SetCharacter(0, 0, ascii_art.MainLogo);

            ButtonHandler StartButtonHandler = new ButtonHandler(buttondata.MainMenuButtons); // 시작 화면 생성
            StartButtonHandler.Run();
        }

        public void GamePage()
        {
            // 상태 변경
            ChangeState("GamePage");

            DisplayBuffer.Instance().Clear();
            ButtonHandler champListView = new ButtonHandler(buttondata.ChampionButtons());
            champListView.Run();

        }

        public void Testpage()
        {
            // 상태 변경
            ChangeState("TestPage");

            DisplayBuffer.Instance().Clear();
            ButtonHandler testView = new ButtonHandler(buttondata.MainMenuButtons2);
            testView.Run();
        }

        public void Outpage()
        {
            // 상태 변경
            ChangeState("Outpage");

            DisplayBuffer.Instance().Clear();
            Console.WriteLine("게임을 종료할까요?");
            ButtonHandler OutpageView = new ButtonHandler(buttondata.OutButtons);
            OutpageView.Run();
        }

        // 현재 상태 변경 및 히스토리 저장
        private void ChangeState(string newState)
        {
            if (currentState != null)
            {
                screenHistory.Enqueue(currentState); // 현재 상태를 히스토리에 저장
            }

            currentState = newState; // 새로운 상태로 변경
        }

        // 뒤로 가기 기능 (이전 상태로 돌아가기)
        public void GoBack()
        {
            if (screenHistory.Count > 0)
            {
                string lastState = screenHistory.Dequeue(); // 마지막 상태를 가져옴
                Console.Clear();

                // 이전 상태에 맞는 화면을 실행
                if (lastState == "MainPage")
                {
                    MainPage();
                }
                else if (lastState == "GamePage")
                {
                    GamePage();
                }
                else if (lastState == "TestPage")
                {
                    Testpage();
                }
                else if (lastState == "OutPage")
                {
                    Testpage();
                }
                else
                {
                    Console.WriteLine("이전 상태가 없습니다.");
                }
            }
            else
            {
                Console.WriteLine("뒤로 갈 화면이 없습니다.");
            }
        }
    }
}
