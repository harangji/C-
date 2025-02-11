using System;
using System.Collections.Generic;
using PM_Simulation.Resource;

namespace PM_Simulation.Resource
{
    public static class PokemonFactory
    {
        public static Pokemon CreatePokemon(string Special, string name, List<string> types)
        {
            switch (Special)
            {
                case "공격형":
                    return new Attacker(name, types);
                case "특공형":
                    return new SpecialAttacker(name, types);
                case "방어형":
                    return new Defender(name, types);
                case "특방형":
                    return new SpecialDefender(name, types);
                case "밸런스형":
                    return new Balanced(name, types);
                case "스피드형":
                    return new Speedster(name, types);
                default:
                    throw new ArgumentException("해당하는 유형이 없습니다.");
            }
        }

        // 공격형 (Attacker)
        public class Attacker : Pokemon
        {
            public Attacker(string name, List<string> types)
                : base(name, 200, 110, 50, 60, 40, 40, "공격형", types, new List<ISkill> { })
            {
            }
        }

        // 특수공격형 (Special Attacker)
        public class SpecialAttacker : Pokemon
        {
            public SpecialAttacker(string name, List<string> types)
                : base(name, 200, 50, 110, 50, 50, 40, "특공형", types, new List<ISkill> { })
            {
            }
        }

        // 방어형 (Defender)
        public class Defender : Pokemon
        {
            public Defender(string name, List<string> types)
                : base(name, 250, 60, 30, 110, 80, 20, "방어형", types, new List<ISkill> { })
            {
            }
        }

        // 특수방어형 (Special Defender)
        public class SpecialDefender : Pokemon
        {
            public SpecialDefender(string name, List<string> types)
                : base(name, 250, 30, 50, 80, 110, 20, "특방형", types, new List<ISkill> { })
            {
            }
        }

        // 밸런스형 (Balanced)
        public class Balanced : Pokemon
        {
            public Balanced(string name, List<string> types)
                : base(name, 220, 70, 70, 70, 70, 50, "밸런스형", types, new List<ISkill> { })
            {
            }
        }

        // 스피드형 (Speedster)
        public class Speedster : Pokemon
        {
            public Speedster(string name, List<string> types)
                : base(name, 200, 70, 60, 40, 40, 90, "스피드형", types, new List<ISkill> { })
            {
            }
        }
    }
}
