using PM_Simulation.Controller;
using PM_Simulation.Resource;
using System;
using System.Collections.Generic;

namespace PM_Simulation.Resource
{
    public abstract class Pokemon
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int SAtk { get; set; }
        public int Def { get; set; }
        public int SDef { get; set; }
        public int Spd { get; set; }
        public List<string> Types { get; set; } // 타입을 List<string>으로 변경
        public string Special { get; set; }

        public List<ISkill> skills = new List<ISkill>();

        public int Wins { get; set; } = 0;  // 승리 횟수
        public int Losses { get; set; } = 0; // 패배 횟수

        public Pokemon()
        {
            this.Name = "Unknown";
            this.Hp = 100;
            this.Atk = 100;
            this.SAtk = 100;
            this.Def = 100;
            this.SDef = 100;
            this.Spd = 100;
            this.Special = "Default";
            this.Types = new List<string> { "노말", "불꽃" };

            skills.Add(new BasicAttack());
        }

        public Pokemon(string name, int hp, int atk, int satk, int def, int sdef, int spd, string special, List<string> types, List<ISkill> skills)
        {
            Name = name;
            Hp = hp;
            Atk = atk;
            SAtk = satk;
            Def = def;
            SDef = sdef;
            Spd = spd;
            Special = special;
            Types = new List<string>(types); // 리스트 복사
            this.skills = new List<ISkill>(skills); // 리스트 복사
        }

        public bool HasSkill(ISkill skill)
        {
            foreach (var s in skills)
            {
                if (s.SkillName == skill.SkillName)
                {
                    return false; // 같은 타입의 스킬이 이미 있다면 true 반환
                }
            }
            return true;
        }

        // 스킬 추가
        public void AddSkill(ISkill newSkill)
        {
            if (!skills.Contains(newSkill))
            {
                skills.Add(newSkill);
            }
        }

        // 스킬 추가
        public void AddSkill_Player(ISkill newSkill)
        {
            if (!skills.Contains(newSkill))
            {
                skills.Add(newSkill);
                Console.WriteLine($"{Name}이(가) 새로운 스킬을 배웠습니다!");
            }
        }

        public double GetWinRate()
        {
            int totalBattles = Wins + Losses;
            if (totalBattles == 0)
            {
                return 0; // 아직 전투 기록이 없으면 승률 0
            }
            return (double)Wins / totalBattles * 100;
        }

        // 배운 스킬 출력
        public void DisplaySkills(int x, int y)
        {
            DisplayBuffer.Instance().SetCharacter(x, y, " 스킬 목록");
            for (int i = 0; i < skills.Count; i++)
            {
                DisplayBuffer.Instance().SetCharacter(x, y + 2 + i, $"   {i + 1}. {skills[i].SkillName}");
            }
        }

        public void DisplayStats(int x, int y)
        {
            double PickCount = MakePokemon.Instance.returnAllPickCount();

            if (PickCount == 0){

            }
            else
            {
                double Pickrate = (Wins + Losses) / PickCount;
                DisplayBuffer.Instance().SetCharacter(x, y + 1, $" 픽률: {Pickrate:f2} ");
            }
            string types = string.Join(", ", Types); // 여러 타입을 출력
            DisplayBuffer.Instance().SetCharacter(x, y, $" {Special}  타입: {Types[0]} {Types[1]} HP: {Hp}  공격: {Atk}  특수공격: {SAtk}  방어: {Def}  특수방어: {SDef}  스피드: {Spd}  승률: {GetWinRate():f2} % ");

        }
    }
}
