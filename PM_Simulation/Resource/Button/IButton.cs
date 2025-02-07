using PM_Simulation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Simulation.Resource
{
    public interface IButton
    {
        void Execute();
    }
    public class TestCommand : IButton
    {
        public void Execute()
        {
            ViewControl.Instance.Testpage();
        }
    }

    public class MainViewCommand : IButton
    {
        public void Execute()
        {
            ViewControl.Instance.MainPage();
        }
    }

    public class ShowChampionListCommand : IButton //챔피언 리스트 출력
    {
        public void Execute()
        {
            ViewControl.Instance.GamePage();
        }
    }
    public class OutCommand : IButton
    {
        public void Execute()
        {
            ViewControl.Instance.Outpage();
        }
    }
    public class ExitGameCommand : IButton
    {
        public void Execute()
        {
            Console.WriteLine("게임을 종료합니다.");
            Environment.Exit(0);
        }
    }

    public class BackCommand : IButton
    {
        public void Execute()
        {
            ViewControl.Instance.GoBack();
        }
    }
        public class ShowChampionInfoCommand : IButton
        {
            private Champion _champion;
            public ShowChampionInfoCommand(Champion champion) //챔피언 정보 받아옴
            {
                _champion = champion;
            }

            public void Execute()
            {
                DisplayBuffer.Instance().Clear();
                Console.Clear();
                Console.SetCursorPosition(0, 30);
                Console.WriteLine("\n=====================================");
                Console.WriteLine($"[{_champion.Name}] 챔피언 정보");
                _champion.DisplayStats();  // 챔피언의 상세 정보 출력
                Console.WriteLine("=====================================\n");
            }
        }
}
