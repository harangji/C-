using PM_Simulation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Simulation.Resource
{
    public interface IButton
    {
        void Execute();
    }
    public class TestCommand : IButton
    {
        public void Execute()
        {
            ViewControl.Instance.Testpage();
        }
    }

    public class MainViewCommand : IButton
    {
        public void Execute()
        {
            ViewControl.Instance.MainPage();
        }
    }

    public class ShowChampionListCommand : IButton //챔피언 리스트 출력
    {
        public void Execute()
        {
            ViewControl.Instance.GamePage();
        }
    }
    public class OutCommand : IButton
    {
        public void Execute()
        {
            ViewControl.Instance.Outpage();
        }
    }
    public class ExitGameCommand : IButton
    {
        public void Execute()
        {
            Console.SetCursorPosition(0, 30);
            Console.WriteLine("잘가용");
            Environment.Exit(0);
        }
    }

    public class BackCommand : IButton
    {
        public void Execute()
        {
            ViewControl.Instance.GoBack();
        }
    }
        public class ShowpokemonInfoCommand : IButton
        {
            private Pokemon _pokemon;

        public ShowpokemonInfoCommand(Pokemon pokemon) //챔피언 정보 받아옴
        {
            _pokemon = pokemon;
        }
            
            public void Execute()
            {
                ButtonData.Instance.selectedPokemon = _pokemon;
                ViewControl.Instance.PokemonInfoPage(_pokemon);
            }
        }

    public class BattleButton : IButton
    {
        public void Execute()
        {
            //DisplayBuffer.Instance().Clear();
            MakePokemon.Instance.SelectRandomForBattle();
        }
    }
    //public class NextDayButton : IButton
    //{
    //    public void Execute()
    //    {
    //        DisplayBuffer.Instance().Clear();
    //        Console.WriteLine("다음날");
    //        MakePokemon.Instance.Day2();
    //        Console.WriteLine(MakePokemon.Instance.pokemonList[10].Name);
    //        ViewControl.Instance.GamePage();
    //    }
    //}
    public class NextDayButton : IButton
    {
        public void Execute()
        {
            DisplayBuffer.Instance().Clear();

            DayManager.Instance.NextDay();// Day2 실행하여 포켓몬 추가

            // 버튼 갱신을 위해 다시 GamePage 호출
            ViewControl.Instance.GamePage(); // GamePage는 최신 포켓몬 리스트를 반영하도록 함
        }
    }
    public class PatchCommand : IButton
    {
        public PatchCommand()
        {
            //_pokemon = ButtonData.Instance.selectedPokemon;
        }

        public void Execute()
        {
            Patch patch = new Patch(ButtonData.Instance.selectedPokemon);
        }
    }

    public class RequestButton : IButton
    {
        Request request = new Request();
        public RequestButton()
        {
            //_pokemon = ButtonData.Instance.selectedPokemon;
        }

        public void Execute()
        {

            request.Requestview();
        }
    }

    public class ModifyYesCommand : IButton
    {
        Pokemon p;
        Random _random = new Random();

        public ModifyYesCommand(Pokemon _p)
        {
            p = _p;
        }

        public void Execute()
        {
            int index = _random.Next(5);
            Console.Clear();
            Console.SetCursorPosition(3, 5);
            switch (index)
            {
                case 0:
                    Console.WriteLine($" {p.Name}의 Hp 40 증가");
                    p.Hp += 50;
                    break;
                case 1:
                    Console.WriteLine($" {p.Name}의 Atk 20 증가");
                    p.Atk += 20;
                    break;
                case 2:
                    Console.WriteLine($" {p.Name}의 SAtk 20 증가");
                    p.SAtk += 20;
                    break;
                case 3:
                    Console.WriteLine($" {p.Name}의 Def 30 증가");
                    p.Def += 30;
                    break;
                case 4:
                    Console.WriteLine($" {p.Name}의 SDef 30 증가");
                    p.SDef += 30;
                    break;
                case 5:
                    Console.WriteLine($" {p.Name}의 Spd 20 증가");
                    p.Spd += 20;
                    break;
                default:
                    break;
            }
            ViewControl.Instance.evaluation += 5;
            Console.WriteLine(" 요구사항을 만족하여 사내평가가 5 증가했습니다.");
            Console.WriteLine(" 아무 키나 눌러 계속하기...");
            Console.ReadLine();

            DisplayBuffer.Instance().Clear();

            // 버튼 갱신을 위해 다시 GamePage 호출
            ViewControl.Instance.GamePage();
        }
    }
    public class ModifySkillCommand : IButton
    {
        private Pokemon _pokemon;
        private ISkill _newSkill;
        private Random _random = new Random();

        public ModifySkillCommand(Pokemon pokemon, ISkill newSkill)
        {
            _pokemon = pokemon;
            _newSkill = newSkill;
        }

        public void Execute()
        {
            Console.Clear();
            Console.SetCursorPosition(3, 5);

            if (_pokemon == null || _newSkill == null)
                return;

            // 포켓몬의 기존 스킬 중 하나를 랜덤으로 선택하여 교체
            int skillIndex = _random.Next(_pokemon.skills.Count);
            ISkill oldSkill = _pokemon.skills[skillIndex];

            _pokemon.skills[skillIndex] = _newSkill; // 스킬 교체

            Console.WriteLine($" {_pokemon.Name}의 스킬이 변경되었습니다!");
            Console.WriteLine($" [{oldSkill.SkillName}] → [{_newSkill.SkillName}]");

            ViewControl.Instance.evaluation += 5;
            Console.WriteLine(" 요구사항을 만족하여 사내평가가 5 증가했습니다.");
            Console.WriteLine(" 아무 키나 눌러 계속하기...");
            Console.ReadLine();

            DisplayBuffer.Instance().Clear();

            // 버튼 갱신을 위해 다시 GamePage 호출
            ViewControl.Instance.GamePage();
        }
    }

    public class ModifyNoCommand : IButton
        {
            public ModifyNoCommand()
            {

            }

            public void Execute()
            {
                DisplayBuffer.Instance().Clear();

                // 버튼 갱신을 위해 다시 GamePage 호출
                ViewControl.Instance.GamePage(); 
        }
        }
    }



