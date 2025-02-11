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
        public ButtonData buttondata;
        public List<Button> pokemonList= ButtonData.Instance.PokemonButtons();
        //public ButtonHandler buttonView;
        public ButtonHandler2 buttonView2;

        public string lastState;
        public int public_sentiment = 70; //민심
        public int evaluation = 70; //사내평가

        // ViewControl의 유일한 인스턴스를 저장하는 정적 변수
        private static ViewControl instance;

        // 상태 히스토리 관리용 스택
        private Stack<string> screenHistory = new Stack<string>();

        // 상태 추적용 변수 (현재 화면 상태)
        private string currentState = "MainPage";

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

        public void MainPage()
        {
            // 상태 변경
            ChangeState("MainPage");

            DisplayBuffer.Instance().Clear();
            DisplayBuffer.Instance().SetCharacter(35, 10, ascii_art.MainLogo, ConsoleColor.Cyan);
            //buttonView = new ButtonHandler(buttondata.MainMenuButtons); // 시작 화면 생성
            buttonView2 = new ButtonHandler2(ButtonData.Instance.MainMenuButtons); // 시작 화면 생성

            buttonView2.Run();
        }

        public void GamePage()
        {
            // 상태 변경
            ChangeState("GamePage");

            DisplayBuffer.Instance().Clear();
            DisplayBuffer.Instance().SetCharacter(8, 3, "민심: ");
            DisplayBuffer.Instance().SetCharacter(12, 3, public_sentiment.ToString(), scoreColor(public_sentiment));

            DisplayBuffer.Instance().SetCharacter(16, 3, "사내평가: ");
            DisplayBuffer.Instance().SetCharacter(22, 3, evaluation.ToString(), scoreColor(evaluation));
            DisplayBuffer.Instance().SetCharacter(0, 5, "======================================================================================================================================================");
           
            DisplayBuffer.Instance().SetCharacter(23, 7, "출시된 포켓몬 리스트");
            buttonView2 = new ButtonHandler2(ButtonData.Instance.PokemonButtons());
            buttonView2.Run();
            //makepokemonlist();
        }

        public void makepokemonlist()
        {
            //buttonView2 = new ButtonHandler2(ButtonData.Instance.PokemonButtons()); // pokemonList를 사용
            buttonView2 = new ButtonHandler2(pokemonList); // pokemonList를 사용
            buttonView2.Run();
        }

        public void PokemonInfoPage(Pokemon pokemon)
        {
            ChangeState("ChampPage");
            Console.Clear();
            DisplayBuffer.Instance().Clear();

            DisplayBuffer.Instance().SetCharacter(0, 6, $" [{pokemon.Name}] 챔피언 정보");
            DisplayBuffer.Instance().SetCharacter(5, 23, $" 댓글");

            List<Comment> PositiveComments = Comment.GetPositiveComments();
            for (int i = 0; i < 4; i++)
                DisplayBuffer.Instance().SetCharacter(5, i + 25, $"{PositiveComments[i].Content}");

            pokemon.DisplayStats(0, 9);
            pokemon.DisplaySkills(0, 15);
            DisplayBuffer.Instance().SetCharacter(0, 22, "=========================================");
            buttonView2 = new ButtonHandler2(ButtonData.Instance.PokemonPageButtons()); // PokemonPageButtons 사용
            buttonView2.Run();
        }

        public void Testpage()
        {
            // 상태 변경
            ChangeState("TestPage");

            DisplayBuffer.Instance().Clear();
            buttonView2 = new ButtonHandler2(ButtonData.Instance.MainMenuButtons2); // MainMenuButtons2 사용
            buttonView2.Run();
        }

        public void Outpage()
        {
            // 상태 변경
            ChangeState("Outpage");
            DisplayBuffer.Instance().Clear();
            DisplayBuffer.Instance().SetCharacter(65, 15, "게임을 종료할까요?", ConsoleColor.Cyan);
            buttonView2 = new ButtonHandler2(ButtonData.Instance.OutButtons); // OutButtons 사용
            buttonView2.Run();
        }

        // 현재 상태 변경 및 히스토리 저장
        private void ChangeState(string newState)
        {
            if (currentState != null)
            {
                screenHistory.Push(currentState); // 현재 상태를 히스토리에 저장
            }

            currentState = newState; // 새로운 상태로 변경
        }

        // 뒤로 가기 기능 (이전 상태로 돌아가기)
        public void GoBack()
        {
            if (screenHistory.Count > 0)
            {
                lastState = screenHistory.Pop();

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
                    Outpage();
                }
                else
                {
                    Console.SetCursorPosition(0, 30);
                    Console.WriteLine("이전 상태가 없습니다. 아무 키나 눌러 계속하세요");
                    Console.ReadLine();
                    Console.Clear();
                    buttonView2.Run();
                }
            }
            else
            {
                Console.SetCursorPosition(0, 30);
                Console.WriteLine("뒤로 갈 화면이 없습니다. 아무 키나 눌러 계속하세요");
                Console.ReadLine();
                Console.Clear();
                buttonView2.Run();
            }
        }

        public ConsoleColor scoreColor(int score)
        {
            ConsoleColor consoleColor;

            if (score <= 30)
            {
                consoleColor = ConsoleColor.Red;
            }
            else if (score <= 60) { consoleColor = ConsoleColor.Yellow; }
            else { consoleColor = ConsoleColor.Green; }
            return consoleColor;
        }
    }
}
