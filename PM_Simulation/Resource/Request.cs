using PM_Simulation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PM_Simulation.Resource
{
    class Request
    {
        private Random _random = new Random();
        List<Button> yesor = new List<Button>();
        Pokemon pokemon;

        public Request()
        {
            pokemon = GetRandomPokemon();
        }

        public Pokemon GetRandomPokemon()
        {
            List<Pokemon> pokemons = MakePokemon.Instance.pokemonList;

            if (pokemons.Count == 0)
                return null;

            int index = _random.Next(pokemons.Count);
            return pokemons[index];
        }

        public void Requestview()
        {

            Console.Clear();
            DisplayBuffer.Instance().Clear();
            int x1 = 10, y1 = 10;
            int x2 = 10, y2 = 20;

            ModifyPokemon(x1, y1);
            ModifySkill(x2, y2);

            ViewControl.Instance.buttonView2 = new ButtonHandler2(yesor);
            ViewControl.Instance.buttonView2.Run();
        }



        public void ModifyPokemon(int x, int y)
        {
            if (pokemon == null)
                return;

            //Console.WriteLine($"{pokemon.Name}의 랜덤 능력치 증가시키기 (20~40) (Y/N)");

            DisplayBuffer.Instance().SetCharacter(x, y - 2, $"! {pokemon.Name}의 랜덤 능력치 증가시키기 (20~40)   ");
            yesor.Add(new Button("|수락하기|", x, y, new ModifyYesCommand(pokemon)));
            yesor.Add(new Button("|거절하기|", x + 10, y, new ModifyNoCommand()));

            return;
        }

        public void ModifySkill(int x, int y)
        {
            Pokemon pokemon = GetRandomPokemon();
            List<ISkill> availableSkills = new List<ISkill>();

            // 포켓몬의 타입 중 하나를 랜덤으로 선택
            string randomType;
            do
            {
                randomType = pokemon.Types[_random.Next(1)];
            } while (string.IsNullOrWhiteSpace(randomType)); // 공백이거나 null인 경우 다시 선택

            //Console.WriteLine(randomType);
            //Console.ReadLine();
            availableSkills = MakePokemon.Instance.skillPool[randomType];
            ISkill newSkill = availableSkills[_random.Next(availableSkills.Count)]; // 랜덤 스킬 선택


            // 변경 요청 메시지 표시
            DisplayBuffer.Instance().SetCharacter(x, y - 2, $"! {pokemon.Name}의 스킬 변경 요청");
            DisplayBuffer.Instance().SetCharacter(x, y-1, $"추가할 스킬: {newSkill.SkillName} (속성: {newSkill.Type})");

            // 수락/거절 버튼 추가
            yesor.Add(new Button("|수락하기|", x, y + 3, new ModifySkillCommand(pokemon, newSkill)));
            yesor.Add(new Button("|거절하기|", x + 10, y + 3, new ModifyNoCommand()));
            return;
        }

    }
}