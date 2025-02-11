using PM_Simulation.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Simulation.Resource
{
    public class ButtonData
    {
        List<Pokemon> pokemons;
        // 현재 조회 중인 포켓몬 저장
        public Pokemon selectedPokemon;

        private static ButtonData _instance;
        private static readonly object _lock = new object();

        public static ButtonData Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new ButtonData();
                    return _instance;
                }
            }
        }

        public ButtonData()
        {
            //makePokemon = new MakePokemon();
            selectedPokemon = null;
            DayManager.Instance.NextDay();
        }

        // 기존의 배열을 List<Button>으로 수정
        public List<Button> MainMenuButtons = new List<Button>
        {
            new Button("게임 시작", 70, 25, new ShowChampionListCommand()),
            new Button("종료", 70 + 2, 25 + 2, new OutCommand())
        };

        public List<Button> MainMenuButtons2 = new List<Button>
        {
            new Button("메인 메뉴", 30, 10, new MainViewCommand()),
            new Button("옵션", 40, 10, new OutCommand()),
            new Button("<<", 8, 2, new BackCommand())
        };

        public List<Button> PokemonPageButtons()
        {
            List<Button> buttons = new List<Button>();
            buttons.Add(new Button("<<", 8, 2, new BackCommand()));
            buttons.Add(new Button("|패치하기|", 100, 35, new PatchCommand()));
            return buttons;
        }

        public List<Button> OutButtons = new List<Button>
        {
            new Button("네", 70, 20, new ExitGameCommand()),
            new Button("아니오", 80, 20, new BackCommand())
        };


        private List<Button> _pokemonButtons; // 버튼 리스트 캐싱

        public List<Button> PokemonButtons()
        {
                pokemons = MakePokemon.Instance.pokemonList;

                pokemons = pokemons.OrderByDescending(p => p.GetWinRate()).ToList();
            //if (_pokemonButtons == null) // 버튼 리스트가 없으면 생성
            //{
            Console.Clear();
                _pokemonButtons = new List<Button>();

                for (int i = 0; i < pokemons.Count; i++)
                {
                    IButton button = new ShowpokemonInfoCommand(pokemons[i]);
                    _pokemonButtons.Add(new Button(pokemons[i].Name, 25, 9 + (i * 2), button));
                    DisplayBuffer.Instance().SetCharacter(35, 9 + (i * 2), $"{pokemons[i].Types[0]} {pokemons[i].Types[1]}");
                    DisplayBuffer.Instance().SetCharacter(45, 9 + (i * 2), $" 승률 : {pokemons[i].GetWinRate()}");
                }
                _pokemonButtons.Add(new Button("|모의전투|", 100, 35, new BattleButton()));
                _pokemonButtons.Add(new Button("|다음날|", 110, 35, new NextDayButton()));
                _pokemonButtons.Add(new Button("|요구사항|", 120, 35, new RequestButton()));
            
            return _pokemonButtons;
        }
    }
}
