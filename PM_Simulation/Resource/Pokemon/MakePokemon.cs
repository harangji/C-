using PM_Simulation.Controller;
using PM_Simulation.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Simulation.Resource
{
    class MakePokemon
    {
        private static MakePokemon _instance;

        public static MakePokemon Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MakePokemon();
                return _instance;
            }
        }

        public List<Pokemon> pokemonList = new List<Pokemon>();

        private Random random = new Random();
        int PickCount;

        // 챔피언 타입별 배울 수 있는 스킬 리스트
        public Dictionary<string, List<ISkill>> skillPool = new Dictionary<string, List<ISkill>>()
        {
            { "노말", new List<ISkill> { new BasicAttack(), new Flamethrower(), new RazorLeaf(), new Earthquake(), new Freezingbeam() } },
            { "불꽃", new List<ISkill> { new Flamethrower(), new Flame_Baptism(), new Firework() } },
            { "물", new List<ISkill>   { new WaterPulse(), new AquaTail(), new HydroPump(), new IceSpike() } },
            { "풀", new List<ISkill>   { new RazorLeaf(), new Earthquake(), new FairyWind(), new MudShot() } },
            { "바위", new List<ISkill> { new RockSlide(), new StoneEdge(), new RockThrow(), new Earthquake() } },
            { "땅", new List<ISkill>   { new Earthquake(), new MudShot(), new SandTomb(), new RockSlide() } },
            { "전기", new List<ISkill> { new Thunderbolt(), new ThunderWave(), new VoltTackle(), new BasicAttack() } },
            { "얼음", new List<ISkill> { new IceSpike(), new Freezingbeam(), new IcicleCrash(), new Blizzard() } },
            { "비행", new List<ISkill> { new AirSlash(), new Hurricane(), new WingAttack(), new RazorLeaf() } },
            { "벌레", new List<ISkill> { new XScissor(), new BugBuzz(), new LeechLife(), new PoisonSting() } },
            { "독", new List<ISkill>     { new PoisonSting(), new SludgeBomb(), new Toxic(), new BugBuzz() } },
            { "고스트", new List<ISkill> { new ShadowBall(), new NightShade(), new Hex(), new Psychic() } },
            { "에스퍼", new List<ISkill> { new Psychic(), new Firework(), new Freezingbeam(), new ShadowBall() } },
            { "페어리", new List<ISkill> { new FairyWind(), new RazorLeaf(), new Freezingbeam(), new Psychic(), new AirSlash() } }
        };

        private Pokemon CreatePokemonWithRandomSkill(string special, string name, List<string> types)
        {
            Pokemon champ = PokemonFactory.CreatePokemon(special, name, types);
            bool No4skills = true;

            foreach (var type in types)
            {
                if (skillPool.ContainsKey(type))
                {
                    int skillCount = 0; // 추가된 스킬의 수
                    List<ISkill> availableSkills = new List<ISkill>(skillPool[type]); // 가능한 스킬 복사
                    // 중복되지 않는 스킬 찾기
                    while (availableSkills.Count > 0 && No4skills == true)
                    {
                        ISkill randomSkill = availableSkills[random.Next(availableSkills.Count)];

                        if (champ.HasSkill(randomSkill)) // 이미 배운 스킬인지 체크
                        {
                            champ.AddSkill(randomSkill);
                            skillCount++;
                            if (skillCount >= 4)
                            {
                                No4skills = false;
                            }
                        }
                        else
                        {
                            availableSkills.Remove(randomSkill); // 중복되면 제거 후 다시 시도
                        }
                    }
                }
            }
            return champ;
        }

        public List<Pokemon> Day1()
        {
            pokemonList.Add(CreatePokemonWithRandomSkill("공격형", "피카츄", new List<string> { "전기", "" }));
            pokemonList.Add(CreatePokemonWithRandomSkill("공격형", "파이리", new List<string> { "불꽃", "" }));
            pokemonList.Add(CreatePokemonWithRandomSkill("방어형", "꼬부기", new List<string> { "물", "" }));
            pokemonList.Add(CreatePokemonWithRandomSkill("방어형", "이상해씨", new List<string> { "풀", "" }));
            pokemonList.Add(CreatePokemonWithRandomSkill("밸런스형", "피죤투", new List<string> { "노말", "비행" }));
            return pokemonList;
        }

        public List<Pokemon> Day2()
        {
            pokemonList.Add(CreatePokemonWithRandomSkill("공격형", "독침붕", new List<string> { "벌레", "독" }));
            pokemonList.Add(CreatePokemonWithRandomSkill("특공형", "푸린", new List<string> { "노말", "페어리" }));
            pokemonList.Add(CreatePokemonWithRandomSkill("방어형", "롱스톤", new List<string> { "바위", "땅" }));
            DisplayBuffer.Instance().Clear();
            DisplayBuffer.Instance().SetCharacter(10, 20, @"
------------------------------
 새로운 포켓몬이 추가되었습니다!  

    독침붕, 푸린, 롱스톤 
-----------------------------");
            DisplayBuffer.Instance().RenderstartY();
            Console.WriteLine("아무 키나 눌러 계속하세요...");
            Console.ReadLine();
            return pokemonList;
        }

        public List<Pokemon> Day3()
        {
            pokemonList.Add(CreatePokemonWithRandomSkill("공격형", "스라크", new List<string> { "벌레", "비행" }));
            pokemonList.Add(CreatePokemonWithRandomSkill("특공형", "팬텀", new List<string> { "고스트", "독" }));
            pokemonList.Add(CreatePokemonWithRandomSkill("방어형", "마임맨", new List<string> { "에스퍼", "페어리" }));
            DisplayBuffer.Instance().Clear();
            DisplayBuffer.Instance().SetCharacter(10, 20, @"
------------------------------
 새로운 포켓몬이 추가되었습니다!  

    스라크, 팬텀, 마임맨 
-----------------------------");
            DisplayBuffer.Instance().RenderstartY();
            Console.WriteLine("아무 키나 눌러 계속하세요...");
            Console.ReadLine();
            return pokemonList;
        }
        public void SelectRandomForBattle()
        {
            Console.WriteLine(pokemonList[0]);
            if (pokemonList.Count < 2)
            {
                Console.WriteLine("포켓몬이 2마리 이상 필요합니다.");
                return;
            }
            Random random = new Random();

            // 랜덤으로 두 마리 선택
            List<Pokemon> selectedPokemons = new List<Pokemon>();
            while (selectedPokemons.Count < 2)
            {
                Pokemon selected = pokemonList[random.Next(pokemonList.Count)];
                if (!selectedPokemons.Contains(selected))
                {
                    selectedPokemons.Add(selected);
                }
            }

            Battlego(selectedPokemons);
        }

        public void Battlego(List<Pokemon> selectedPokemons)
        {
            //Console.SetCursorPosition(0, 30);
            //Console.WriteLine($"전투 시작: {selectedPokemons[0].Name} vs {selectedPokemons[1].Name}");

            // BattleSimulator 실행
            BattleSimulator simulator = new BattleSimulator(selectedPokemons[0], selectedPokemons[1]);
            simulator.StartBattle();
        }

        public int returnAllPickCount()
        {
            PickCount = 0;
            foreach (var p in pokemonList)
            {
                PickCount += (p.Wins + p.Losses);
            }
            return PickCount;
        }

    }
}
