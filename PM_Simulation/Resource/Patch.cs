using PM_Simulation.Controller;
using System;
using System.Collections.Generic;

namespace PM_Simulation.Resource
{
    public class Patch
    {
        public Patch(Pokemon p) { ApplyPatch(p); }

        public void ApplyPatch(Pokemon p)
        {
            Console.Clear();
            Console.SetCursorPosition(1, 3);

            //Random random = new Random();
            //List<Pokemon> pokemonList = MakePokemon.Instance.pokemonList;
            //if (pokemonList.Count == 0)
            //{
            //    Console.WriteLine("포켓몬 리스트가 비어 있습니다.");
            //    return;
            //}

            //Pokemon selectedPokemon = pokemonList[random.Next(pokemonList.Count)];
            Pokemon selectedPokemon = p;

            Console.WriteLine($" 선택된 포켓몬: {selectedPokemon.Name}  승률{selectedPokemon.GetWinRate():f2}");

            Console.WriteLine("  1. 상향");
            Console.WriteLine("  2. 하향");
            Console.WriteLine("  3. 돌아가기");

            Console.Write(" 선택: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BuffPokemon(selectedPokemon);
                    break;
                case "2":
                    NerfPokemon(selectedPokemon);
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
            Console.WriteLine("패치를 종료합니다.");
            Console.ReadLine();
            Console.Clear();
            ViewControl.Instance.GamePage();
        }

        private void BuffPokemon(Pokemon pokemon)
        {
            pokemon.Hp += 10;
            pokemon.Atk += 10;
            pokemon.SAtk += 10;
            pokemon.Def += 10;
            pokemon.SDef += 10;
            pokemon.Spd += 10;
            Console.WriteLine($"{pokemon.Name}이(가) 상향되었습니다! (모든 능력치 +10)");
        }

        private void NerfPokemon(Pokemon pokemon)
        {
            pokemon.Hp -= 10;
            pokemon.Atk -= 10;
            pokemon.SAtk -= 10;
            pokemon.Def -= 10;
            pokemon.SDef -= 10;
            pokemon.Spd -= 10;
            Console.WriteLine($"{pokemon.Name}이(가) 하향되었습니다! (모든 능력치 -10)");
        }
    }
}
