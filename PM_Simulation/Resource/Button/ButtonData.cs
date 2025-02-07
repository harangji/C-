using PM_Simulation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Simulation.Resource
{
    public class ButtonData
    {


        public Button[] MainMenuButtons =
        {
            new Button("게임 시작", 60, 25, new ShowChampionListCommand()),
            new Button("옵션", 60 +10, 25, new OutCommand()),
            new Button("종료", 60 +20, 25, new OutCommand()),
            new Button("테스트화면2", 60, 25+2, new TestCommand())
        };

        public Button[] MainMenuButtons2 =
        {
            new Button("메인 메뉴", 30, 10, new MainViewCommand()),
            new Button("옵션", 40, 10, new OutCommand()),
            new Button("<", 8, 2, new BackCommand())
        };

        public Button[] OutButtons =
        {
            new Button("네", 30, 10, new ExitGameCommand()),
            new Button("아니오", 40, 10, new BackCommand())
        };

        // 챔피언 버튼을 생성
        public Button[] ChampionButtons()
        {
            Console.Clear();
            MakeChampion makeChampion = new MakeChampion();
            List<Champion> champions = makeChampion.Day1();
            Button[] buttons = new Button[champions.Count];

            for (int i = 0; i < champions.Count; i++)
            {
                int index = i;
                IButton button = new ShowChampionInfoCommand(champions[index]);
                buttons[i] = new Button(champions[i].Name, 30, 10 + (i*2), button);
            }

            return buttons;
        }
    }
}