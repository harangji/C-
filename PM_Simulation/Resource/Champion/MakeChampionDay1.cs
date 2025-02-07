using PM_Simulation.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Simulation.Resource
{
    class MakeChampion
    {
        public List<Champion> new_champion;
        //public Champion cham = ChampionFactory.CreateChampion("Warrior", "탑신병자");

        public MakeChampion()
        {
        }

        public List<Champion> Day1()
        {
            new_champion = new List<Champion>();
            new_champion.Add(ChampionFactory.CreateChampion("Warrior", "트린다미워"));
            new_champion.Add(ChampionFactory.CreateChampion("Mage", "대상혁"));
            new_champion.Add(ChampionFactory.CreateChampion("Archer", "호박고구마"));
            new_champion.Add(ChampionFactory.CreateChampion("Warrior", "아무개"));
            new_champion.Add(ChampionFactory.CreateChampion("Mage", "아무개"));
            new_champion.Add(ChampionFactory.CreateChampion("Archer", "아무개"));
            new_champion.Add(ChampionFactory.CreateChampion("Warrior", "아무개"));
            new_champion.Add(ChampionFactory.CreateChampion("Mage", "아무개"));
            new_champion.Add(ChampionFactory.CreateChampion("Archer", "아무개"));
            return new_champion;
        }
    }
}