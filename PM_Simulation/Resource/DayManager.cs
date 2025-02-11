using PM_Simulation.Controller;
using System;
using System.Collections.Generic;

namespace PM_Simulation.Resource
{
    public class DayManager
    {
        public int currentDay = 0;

        // 싱글톤 인스턴스를 저장할 정적 변수
        private static DayManager instance;

        // 외부에서 인스턴스를 접근할 수 있도록 하는 프로퍼티
        public static DayManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DayManager();
                }
                return instance;
            }
        }

        private DayManager()
        {

        }

        // 새로운 날로 넘어가는 메서드
        public void NextDay()
        {
            currentDay++;
            ExecuteDayMethod();
        }

        // 현재 날짜에 맞는 메서드를 실행하는 메서드
        private void ExecuteDayMethod()
        {

            switch (currentDay)
            {
                case 1:
                    MakePokemon.Instance.Day1();
                    break;
                case 2:
                    MultiBattleSimulator multiBattle = new MultiBattleSimulator(30);
                    MakePokemon.Instance.Day2();
                    ViewControl.Instance.public_sentiment += 5;
                    break;
                case 3:
                    multiBattle = new MultiBattleSimulator(30);
                    MakePokemon.Instance.Day3();
                    ViewControl.Instance.public_sentiment += 5;
                    break;
                // 추가적인 case 문을 필요에 맞게 작성하세요
                default:
                    Console.WriteLine($"[ERROR] Day{currentDay} 메서드가 존재하지 않습니다.");
                    break;
            }
        }

    }
}
