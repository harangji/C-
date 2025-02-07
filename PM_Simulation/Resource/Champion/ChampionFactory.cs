using System;
using PM_Simulation.Resource;

namespace PM_Simulation.Resource
{
    public static class ChampionFactory
    {
        public static Champion CreateChampion(string type, string name)
        {
            switch (type)
            {
                case "Warrior":
                    return new Warrior(name);
                case "Mage":
                    return new Mage(name);
                case "Archer":
                    return new Archer(name);
                default:
                    throw new ArgumentException("잘못된 챔피언 타입입니다.");
            }
        }

        // 전사 (Warrior) 클래스
        public class Warrior : Champion
        {
            public Warrior(string name) : base( name, 200, 50, 30, 20, 10, "근접", new BasicAttack()) { }
        }

        // 마법사 (Mage) 클래스
        public class Mage : Champion
        {
            public Mage(string name) : base(name, 100, 150, 25, 10, 5, "원거리", new FireBlast()) { }
        }

        // 궁수 (Archer) 클래스
        public class Archer : Champion
        {
            public Archer(string name) : base(name, 120, 80, 35, 15, 20, "원거리", new IceSpike()) { }
        }
    }
}