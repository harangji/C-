using System;
using System.Collections.Generic;
using PM_Simulation.Resource;

namespace PM_Simulation.Controller
{
    public class MultiBattleSimulator
    {
        private Pokemon pokemon1;
        private Pokemon pokemon2;
        private int originalHp1;
        private int originalHp2;
        private Random random = new Random();


        // 생성자에서 포켓몬 리스트를 받아 랜덤으로 두 마리 선택
        public MultiBattleSimulator(int _battleCount)
        {

            // 배틀 시뮬레이션 실행
            for(int i=0; i< _battleCount; i++)
            {
                SimulateMultipleBattles();
            }

        }

        private Pokemon SelectRandomPokemon(List<Pokemon> pokemonList)
        {
            Pokemon selected;
            do
            {
                selected = pokemonList[random.Next(pokemonList.Count)];
            } while (selected == pokemon1 || selected == pokemon2); // 선택된 포켓몬이 이미 선택된 포켓몬과 같지 않도록

            return selected;
        }

        public (int wins1, int wins2) SimulateMultipleBattles()
        {
            pokemon1 = SelectRandomPokemon(MakePokemon.Instance.pokemonList);
            pokemon2 = SelectRandomPokemon(MakePokemon.Instance.pokemonList);

            int wins1 = 0, wins2 = 0;

            for (int i = 0; i < 2; i++) //2판
            {
                if (SimulateBattle())
                    wins1++;
                else
                    wins2++;
            }

            return (wins1, wins2);
        }

        private bool SimulateBattle()
        {
            originalHp1 = pokemon1.Hp;
            originalHp2 = pokemon2.Hp;

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
                ISkill selectedSkill = SelectSkillWithWeight(attacker, defender);
                int damage = CalculateDamage(attacker, defender, selectedSkill);
                defender.Hp -= damage;

                if (defender.Hp <= 0)
                {
                    attacker.Wins++;
                    defender.Losses++;
                    ResetBattle();
                    return attacker == pokemon1;
                }

                (attacker, defender) = (defender, attacker);
            }
            return false;
        }

        private ISkill SelectSkillWithWeight(Pokemon attacker, Pokemon defender)
        {
            List<ISkill> skills = attacker.skills;
            if (skills.Count == 1) return skills[0];

            Dictionary<ISkill, double> weightedSkills = new Dictionary<ISkill, double>();
            double totalWeight = 0;

            foreach (var skill in skills)
            {
                double weight = Math.Pow(CalculateforSelect(attacker, defender, skill), 1.2);
                weightedSkills[skill] = weight;
                totalWeight += weight;
            }

            double randValue = random.NextDouble() * totalWeight;
            double cumulative = 0;

            foreach (var skill in weightedSkills)
            {
                cumulative += skill.Value;
                if (randValue <= cumulative)
                    return skill.Key;
            }

            return skills[0];
        }

        private int CalculateDamage(Pokemon attacker, Pokemon defender, ISkill selectedSkill)
        {
            if (random.Next(100) < selectedSkill.Accuracy)
            {
                bool isCritical = random.Next(100) < selectedSkill.CriticalRate;
                int criticalMultiplier = isCritical ? 2 : 1;
                int attackStat = selectedSkill.Type == "물리" ? attacker.Atk : attacker.SAtk;
                int defenseStat = selectedSkill.Type == "물리" ? defender.Def : defender.SDef;
                double typeBonus = BattleSimulator.GetTypeBonus(selectedSkill.Type, defender.Types);

                int baseDamage = (int)(attackStat * (selectedSkill.Damage / 100.0) * typeBonus);
                double defenseMultiplier = 1 - (defenseStat / (150.0 + defenseStat));
                int finalDamage = (int)(baseDamage * defenseMultiplier * criticalMultiplier);

                return Math.Max(finalDamage, 1);
            }
            return 0;
        }

        private int CalculateforSelect(Pokemon attacker, Pokemon defender, ISkill selectedSkill)
        {
            int attackStat = selectedSkill.Type == "물리" ? attacker.Atk : attacker.SAtk;
            int defenseStat = selectedSkill.Type == "물리" ? defender.Def : defender.SDef;
            int baseDamage = (int)(attackStat * (selectedSkill.Damage / 100.0));
            double defenseMultiplier = 1 - (defenseStat / (100.0 + defenseStat));
            return Math.Max((int)(baseDamage * defenseMultiplier), 1);
        }

        private void ResetBattle()
        {
            pokemon1.Hp = originalHp1;
            pokemon2.Hp = originalHp2;
        }
    }
}
