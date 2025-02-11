using PM_Simulation.Resource;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PM_Simulation.Controller
{
    public class BattleSimulator
    {
        private Pokemon pokemon1;
        private Pokemon pokemon2;
        private int originalHp1;
        private int originalHp2;
        private Random random = new Random();
        //private int posX = 5, posY = 10;
        private DisplayBuffer displayBuffer;
        public BattleSimulator(Pokemon p1, Pokemon p2)
        {
            pokemon1 = p1;
            pokemon2 = p2;
            displayBuffer = DisplayBuffer.Instance();
        }

        public void StartBattle()
        {
            originalHp1 = pokemon1.Hp;
            originalHp2 = pokemon2.Hp;
            Console.Clear();
            displayBuffer.Clear();
            DrawBattleScreen();

            Pokemon attacker, defender;

            if (pokemon1.Spd > pokemon2.Spd)
            {
                attacker = pokemon1;
                defender = pokemon2;
            }
            else if (pokemon1.Spd < pokemon2.Spd)
            {
                attacker = pokemon2;
                defender = pokemon1;
            }
            else
            {
                attacker = (random.Next(2) == 0) ? pokemon1 : pokemon2;
                defender = (attacker == pokemon1) ? pokemon2 : pokemon1;
            }

            while (pokemon1.Hp > 0 && pokemon2.Hp > 0)
            {
                DisplayTurn(attacker);
                Console.ReadLine();
                ISkill selectedSkill = SelectSkillWithWeight(attacker, defender);
                int damage = CalculateDamage(attacker, defender, selectedSkill);
                defender.Hp -= damage;

                DrawBattleScreen();

                if (defender.Hp <= 0)
                {
                    attacker.Wins++;
                    defender.Losses++;
                    DisplayVictory(attacker, defender);
                    ResetBattle();
                    return;
                }
                (attacker, defender) = (defender, attacker); //공격자 방어자 뒤바꾸기
            }
        }

        private ISkill SelectSkillWithWeight(Pokemon attacker, Pokemon defender)
        {
            List<ISkill> skills = attacker.skills;
            if (skills.Count == 1) return skills[0];

            // 스킬별 데미지 기반으로 가중치 부여
            Dictionary<ISkill, double> weightedSkills = new Dictionary<ISkill, double>();
            double totalWeight = 0;

            //최종데미지

            foreach (var skill in skills)
            {
                double weight = Math.Pow(CalculateforSelect(attacker, defender, skill), 1.2); // 데미지가 높을수록 확률 증가
                weightedSkills[skill] = weight;
                totalWeight += weight;
            }

            // 랜덤 값 기반으로 스킬 선택
            double randValue = random.NextDouble() * totalWeight;
            double cumulative = 0;

            foreach (var skill in weightedSkills)
            {
                cumulative += skill.Value;
                if (randValue <= cumulative)
                {
                    return skill.Key;
                }
            }

            return skills[0]; // 기본적으로 첫 번째 스킬 반환
        }

        public int CalculateDamage(Pokemon attacker, Pokemon defender, ISkill selectedSkill)
        {
            Random random = new Random();
            int hitChance = random.Next(0, 100); // 0~99 사이 난수 생성

            if (hitChance < selectedSkill.Accuracy)
            {
                // 크리티컬 여부 (예: 20% 확률로 크리티컬)
                bool isCritical = random.Next(100) < selectedSkill.CriticalRate;
                int criticalMultiplier = isCritical ? 2 : 1;

                // 공격과 방어 능력치 선택
                int attackStat = selectedSkill.Type == "물리" ? attacker.Atk : attacker.SAtk;
                int defenseStat = selectedSkill.Type == "물리" ? defender.Def : defender.SDef;


                double typeBonus = GetTypeBonus(selectedSkill.Type, defender.Types);

                // 기본 데미지 계산 (백분율 적용)
                int baseDamage = (int)(attackStat * (selectedSkill.Damage / 100.0) * typeBonus);

                // 방어자의 저항 계산
                double defenseMultiplier = 1 - (defenseStat / (100.0 + defenseStat));

                // 최종 데미지 적용
                int finalDamage = (int)(baseDamage * defenseMultiplier * criticalMultiplier);

                // 최소 1 이상의 데미지 보장
                if (finalDamage < 1)
                    finalDamage = 1;

                // 데미지 로그 출력
                displayBuffer.SetCharacter(10, 32, $" {attacker.Name}의 {selectedSkill.SkillName}!     ");
                //Console.WriteLine($" {attacker.Name}의 {selectedSkill.SkillName}!     ");


                if (typeBonus == 2.0 || typeBonus == 4.0)
                {
                    displayBuffer.SetCharacter(10, 33, " 효과가 굉장했다!    ");
                    //Console.WriteLine(" 효과가 굉장했다!    ");
                }
                else if(typeBonus == 0.5 || typeBonus == 0.25)
                {
                    displayBuffer.SetCharacter(10, 33, " 효과가 별로인 듯 하다...    ");
                    //Console.WriteLine(" 효과가 별로인 듯 하다...    ");
                }
                else if(typeBonus == 0.0)
                {
                    displayBuffer.SetCharacter(10, 33, $" {defender.Name}에게는 효과가 없는 것 같다...    ");
                    //Console.WriteLine($" {defender.Name}에게는 효과가 없는 것 같다...    ");
                    displayBuffer.RenderstartY();
                    Console.ReadLine();
                    return 0;
                }
                //Console.WriteLine();

                if (isCritical)
                {
                    displayBuffer.SetCharacter(10, 34, $" {defender.Name} 는(은) {finalDamage} 데미지를 입었다!      ");
                    //Console.WriteLine($" {defender.Name}은 {finalDamage} 데미지를 입었다!      ");
                    finalDamage *= 2;
                    displayBuffer.SetCharacter(10, 34, $" 급소에 맞았다! {defender.Name} 는(은) {finalDamage} 데미지를 입었다!      ");
                    //Console.WriteLine($" 급소에 맞았다! {defender.Name}은 {finalDamage} 데미지를 입었다!      ");
                }
                else
                {
                    displayBuffer.SetCharacter(10, 34, $" {defender.Name} 는(은) {finalDamage} 데미지를 입었다!      ");
                    //Console.WriteLine($" {defender.Name}은 {finalDamage} 데미지를 입었다!      ");
                }
                displayBuffer.RenderstartY();
                Console.ReadLine();
                return finalDamage;
            }
            else
            {
                displayBuffer.SetCharacter(10, 32, $" {attacker.Name}의 {selectedSkill.SkillName}!");
                displayBuffer.SetCharacter(10, 33, $" 하지만 {defender.Name} 에게는 맞지 않았다.");

                displayBuffer.RenderstartY();
                Console.ReadLine();
                return 0;
            }
        }

        public int CalculateforSelect(Pokemon attacker, Pokemon defender, ISkill selectedSkill)
        {
            // 공격과 방어 능력치 선택
            int attackStat = selectedSkill.Type == "물리" ? attacker.Atk : attacker.SAtk;
            int defenseStat = selectedSkill.Type == "물리" ? defender.Def : defender.SDef;

            // 기본 데미지 계산 (백분율 적용)
            int baseDamage = (int)(attackStat * (selectedSkill.Damage / 100.0));

            // 방어자의 저항 계산
            double defenseMultiplier = 1 - (defenseStat / (100.0 + defenseStat));

            // 최종 데미지 적용
            int finalDamage = (int)(baseDamage * defenseMultiplier);

            // 최소 1 이상의 데미지 보장
            if (finalDamage < 1)
                finalDamage = 1;

            return finalDamage;
        }
        public static double GetTypeBonus(string attackType, List<string> defenderTypes)
        {
            Dictionary<string, List<string>> typeStrong = new Dictionary<string, List<string>>()
            {
                { "불꽃", new List<string> { "벌레", "풀", "얼음" } },
                { "물", new List<string> { "불꽃", "땅", "바위" } },
                { "전기", new List<string> { "물", "비행" } },
                { "얼음", new List<string> { "풀", "땅", "비행" } },
                { "풀", new List<string> { "물", "땅", "바위" } },
                { "땅", new List<string> { "불꽃", "전기", "바위" } },
                { "바위", new List<string> { "불꽃", "얼음", "비행", "벌레" } },
                { "비행", new List<string> { "풀", "벌레" } },
                { "벌레", new List<string> { "풀", "에스퍼", "페어리" } },
                { "독", new List<string> { "풀", "페어리" } },
                { "고스트", new List<string> { "고스트", "에스퍼" } },
                { "에스퍼", new List<string> { "독" } },
                { "페어리", new List<string> { "드래곤", "격투", "악" } }
            };

            Dictionary<string, List<string>> typeweak = new Dictionary<string, List<string>>()
            {
                { "불꽃", new List<string> { "불꽃", "바위", "물" } },
                { "물", new List<string> { "물", "풀" } },
                { "전기", new List<string> { "전기", "풀" } },
                { "얼음", new List<string> { "얼음", "불꽃" } },
                { "풀", new List<string> { "풀", "벌레", "독", "비행", "불꽃" } },
                { "땅", new List<string> { "벌레", "풀" } },
                { "바위", new List<string> { "땅" } },
                { "비행", new List<string> { "풀", "벌레", "격투" } },
                { "벌레", new List<string> { "풀", "격투", "땅" } },
                { "독", new List<string> { "땅", "바위", "독", "고스트" } },
                { "고스트", new List<string> { "벌레", "독" } },
                { "에스퍼", new List<string> { "에스퍼" } },
                { "페어리", new List<string> { "불꽃", "독" } }
            };

            Dictionary<string, List<string>> typeImmun = new Dictionary<string, List<string>>()
            {
                { "노말", new List<string> { "고스트" } },
                { "고스트", new List<string> { "노말", "격투" } },
                { "전기", new List<string> { "땅" } },
                { "땅", new List<string> { "비행" } }
            };

            double effectiveness = 1.0;

            foreach (var defenderType in defenderTypes)
            {
                if (typeStrong.ContainsKey(attackType) && typeStrong[attackType].Contains(defenderType))
                {
                    effectiveness *= 2.0; // 2배 데미지
                }
                else if (typeweak.ContainsKey(attackType) && typeweak[attackType].Contains(defenderType))
                {
                    effectiveness *= 0.5; // 0.5배 데미지
                }
                else if (typeImmun.ContainsKey(attackType) && typeImmun[attackType].Contains(defenderType))
                {
                    effectiveness *= 0.0; // 무효
                }
            }
            return effectiveness; // 기본 1배 데미지
        }

        private void DrawBattleScreen()
        {
            //int currentHp = pokemon2.Hp;
            int hpBarLength = 10;
            int filledBlocks1 = (pokemon1.Hp * hpBarLength) / originalHp1; // 채울 블록 개수
            int filledBlocks2 = (pokemon2.Hp * hpBarLength) / originalHp2; // 채울 블록 개수

            string hpBar1 = new string('■', filledBlocks1).PadRight(hpBarLength, '□');
            string hpBar2 = new string('■', filledBlocks2).PadRight(hpBarLength, '□');

            displayBuffer.Clear();
            displayBuffer.SetCharacter(10, 5, $"{pokemon1.Name}    | {pokemon1.Types[0]} {pokemon1.Types[1]}");
            displayBuffer.SetCharacter(100, 5, $"{pokemon2.Name}    | {pokemon2.Types[0]} {pokemon2.Types[1]}");

            displayBuffer.SetCharacter(10, 6, $"( HP: {pokemon1.Hp}/{originalHp1} ) ");
            displayBuffer.SetCharacter(105, 6, $"( HP: {pokemon2.Hp}/{originalHp2} ) ");

            displayBuffer.SetCharacter(10, 7, $" {hpBar1} ", ConsoleColor.Green);
            displayBuffer.SetCharacter(95, 7, $" {hpBar2} ", ConsoleColor.Green);
            displayBuffer.RenderstartY();
        }

        private void DisplayTurn(Pokemon attacker)
        {
            displayBuffer.SetCharacter(10, 30, $"{attacker.Name}의 턴!", ConsoleColor.Yellow);
            displayBuffer.RenderstartY();
        }


        private void DisplayVictory(Pokemon winner, Pokemon loser)
        {
            displayBuffer.SetCharacter(10, 35, $"{loser.Name}이(가) 쓰러졌다!", ConsoleColor.Magenta);
            displayBuffer.SetCharacter(10, 36, $"{winner.Name} 승리! 승률: {winner.GetWinRate():F2}%", ConsoleColor.Green);
            displayBuffer.RenderstartY();

            Console.ReadLine();
            displayBuffer.Clear();
            ViewControl.Instance.GamePage();
        }

        private void ResetBattle()
        {
            pokemon1.Hp = originalHp1;
            pokemon2.Hp = originalHp2;
        }

    }

}
