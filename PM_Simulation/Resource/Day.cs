using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Simulation.Resource
{
    using System;
    using System.Collections.Generic;

    class Day
    {
        public int DayNumber { get; private set; }
        public List<string> NewChampions { get; private set; }

        public Day(int dayNumber)
        {
            DayNumber = dayNumber;
            NewChampions = new List<string>();

            GenerateDailyUpdates();
        }

        // 새로운 일차마다 발생하는 변화 (예시: 챔피언 추가)
        private void GenerateDailyUpdates()
        {
            if (DayNumber % 2 == 0)
            {
                NewChampions.Add($"챔피언 {DayNumber}");
            }
            // 민심 = 판별식( 1등과 꼴등의 승률차이? )
        }

        public void ShowDayInfo()
        {
            Console.WriteLine($"📅 {DayNumber}일차가 시작되었습니다!");
            if (NewChampions.Count > 0)
            {
                Console.WriteLine("  - 추가된 챔피언: " + string.Join(", ", NewChampions));
            }
            Console.WriteLine();
        }
    }

    class Game
    {
        private int currentDay;
        private List<Day> dayHistory;

        public Game()
        {
            currentDay = 0;
            dayHistory = new List<Day>();
        }

        public void NextDay()
        {
            currentDay++;
            Day newDay = new Day(currentDay);
            dayHistory.Add(newDay);
            newDay.ShowDayInfo();
        }
    }

}
