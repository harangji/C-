using PM_Simulation.Resource;
using System;
using System.Collections.Generic;

namespace PM_Simulation.Resource
{
    public abstract class Champion
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Cri { get; set; }
        public string Type { get; set; }

        protected ISkill skill;

        public Champion()
        {
            this.Name = "Unknown";
            this.Hp = 500;
            this.Mp = 200;
            this.Atk = 100;
            this.Def = 50;
            this.Cri = 10;
            this.Type = "Default";
            this.skill = new BasicAttack();
        }

        public Champion(string name, int hp, int mp, int atk, int def, int cri, string type, ISkill skill)
        {
            Name = name;
            Hp = hp;
            Mp = mp;
            Atk = atk;
            Def = def;
            Cri = cri;
            Type = type;
            this.skill = skill;
        }


        // 스킬 사용
        public void UseSkill()
        {
            skill.Execute(Name);
        }

        // 스킬 변경 가능 (전략 패턴 활용)
        public void SetSkill(ISkill newSkill)
        {
            skill = newSkill;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"[챔피언: {Name}] HP: {Hp}, MP: {Mp}, 공격력: {Atk}, 방어력: {Def}, 치명타: {Cri}, 타입: {Type}");
        }
    }
}