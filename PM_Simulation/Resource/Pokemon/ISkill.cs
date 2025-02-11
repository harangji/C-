using System;

namespace PM_Simulation.Resource
{
    public interface ISkill
    {
        string SkillName { get; }
        string Rank { get; }
        string AttackType { get; }
        string Type { get; }
        int Damage { get; }
        double Accuracy { get; }
        double CriticalRate { get; }
        string AsciiArt { get; }
    }

    public abstract class SkillBase : ISkill
    {
        public abstract string SkillName { get; }
        public abstract string Rank { get; }
        public abstract string AttackType { get; }
        public abstract string Type { get; }
        public abstract int Damage { get; }
        public abstract double Accuracy { get; }
        public abstract double CriticalRate { get; }
        public abstract string AsciiArt { get; }
    }

    public class BasicAttack : SkillBase
    {
        public override string SkillName => "몸통박치기";
        public override string Rank => "C";
        public override string AttackType => "물리";
        public override string Type => "노말";
        public override int Damage => 40;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class Flame_Baptism : SkillBase
    {
        public override string SkillName => "불꽃세례";
        public override string Rank => "B";
        public override string AttackType => "특수";
        public override string Type => "불꽃";
        public override int Damage => 40;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class Firework : SkillBase
    {
        public override string SkillName => "불꽃채찍";
        public override string Rank => "B";
        public override string AttackType => "물리";
        public override string Type => "불꽃";
        public override int Damage => 40;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class IceSpike : SkillBase
    {
        public override string SkillName => "얼음 뭉치";
        public override string Rank => "B";
        public override string AttackType => "물리";
        public override string Type => "얼음";
        public override int Damage => 40;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

        public class Freezingbeam : SkillBase
        {
            public override string SkillName => "냉동 빔";
            public override string Rank => "A";
            public override string AttackType => "특수";
            public override string Type => "얼음";
            public override int Damage => 50;
            public override double Accuracy => 90.0;
            public override double CriticalRate => 5.0;
            public override string AsciiArt => " ";
        }
    public class Thunderbolt : SkillBase
    {
        public override string SkillName => "10만 볼트";
        public override string Rank => "A";
        public override string AttackType => "특수";
        public override string Type => "전기";
        public override int Damage => 55;
        public override double Accuracy => 95.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => "";
    }

    public class Flamethrower : SkillBase
    {
        public override string SkillName => "화염방사";
        public override string Rank => "A";
        public override string AttackType => "특수";
        public override string Type => "불꽃";
        public override int Damage => 60;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => "";
    }

    public class WaterPulse : SkillBase
    {
        public override string SkillName => "물의 파동";
        public override string Rank => "B";
        public override string AttackType => "특수";
        public override string Type => "물";
        public override int Damage => 45;
        public override double Accuracy => 95.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => "";
    }

    public class RazorLeaf : SkillBase
    {
        public override string SkillName => "잎날가르기";
        public override string Rank => "B";
        public override string AttackType => "물리";
        public override string Type => "풀";
        public override int Damage => 50;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 10.0;
        public override string AsciiArt => "";
    }

    public class AirSlash : SkillBase
    {
        public override string SkillName => "에어 슬래시";
        public override string Rank => "A";
        public override string AttackType => "특수";
        public override string Type => "비행";
        public override int Damage => 55;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 10.0;
        public override string AsciiArt => "";
    }

    public class PoisonSting : SkillBase
    {
        public override string SkillName => "독침";
        public override string Rank => "C";
        public override string AttackType => "물리";
        public override string Type => "독";
        public override int Damage => 35;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => "";
    }

    public class FairyWind : SkillBase
    {
        public override string SkillName => "요정의 바람";
        public override string Rank => "B";
        public override string AttackType => "특수";
        public override string Type => "페어리";
        public override int Damage => 40;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => "";
    }

    public class RockSlide : SkillBase
    {
        public override string SkillName => "스톤샤워";
        public override string Rank => "A";
        public override string AttackType => "물리";
        public override string Type => "바위";
        public override int Damage => 60;
        public override double Accuracy => 85.0;
        public override double CriticalRate => 10.0;
        public override string AsciiArt => "";
    }

    public class Earthquake : SkillBase
    {
        public override string SkillName => "지진";
        public override string Rank => "S";
        public override string AttackType => "물리";
        public override string Type => "땅";
        public override int Damage => 75;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 0.0;
        public override string AsciiArt => "";
    }

    public class XScissor : SkillBase
    {
        public override string SkillName => "시저 크로스";
        public override string Rank => "A";
        public override string AttackType => "물리";
        public override string Type => "벌레";
        public override int Damage => 55;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 10.0;
        public override string AsciiArt => "✂️";
    }

    public class ShadowBall : SkillBase
    {
        public override string SkillName => "섀도볼";
        public override string Rank => "A";
        public override string AttackType => "특수";
        public override string Type => "고스트";
        public override int Damage => 60;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => "";
    }

    public class Psychic : SkillBase
    {
        public override string SkillName => "사이코키네시스";
        public override string Rank => "S";
        public override string AttackType => "특수";
        public override string Type => "에스퍼";
        public override int Damage => 70;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => "";
    }

    public class CriticalRate100 : SkillBase
    {
        public override string SkillName => "크리티컬100";
        public override string Rank => "S";
        public override string AttackType => "특수";
        public override string Type => "풀";
        public override int Damage => 50;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 100.0;
        public override string AsciiArt => " ";
    }

    public class Accuracy0 : SkillBase
    {
        public override string SkillName => "명중0";
        public override string Rank => "S";
        public override string AttackType => "특수";
        public override string Type => "풀";
        public override int Damage => 50;
        public override double Accuracy => 0.0;
        public override double CriticalRate => 100.0;
        public override string AsciiArt => " ";
    }
    public class AquaTail : SkillBase
    {
        public override string SkillName => "아쿠아 테일";
        public override string Rank => "A";
        public override string AttackType => "물리";
        public override string Type => "물";
        public override int Damage => 60;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class HydroPump : SkillBase
    {
        public override string SkillName => "하이드로 펌프";
        public override string Rank => "S";
        public override string AttackType => "특수";
        public override string Type => "물";
        public override int Damage => 80;
        public override double Accuracy => 85.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class StoneEdge : SkillBase
    {
        public override string SkillName => "스톤 엣지";
        public override string Rank => "A";
        public override string AttackType => "물리";
        public override string Type => "바위";
        public override int Damage => 65;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 10.0;
        public override string AsciiArt => " ";
    }

    public class RockThrow : SkillBase
    {
        public override string SkillName => "록 스로우";
        public override string Rank => "B";
        public override string AttackType => "물리";
        public override string Type => "바위";
        public override int Damage => 50;
        public override double Accuracy => 95.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class MudShot : SkillBase
    {
        public override string SkillName => "머드 샷";
        public override string Rank => "B";
        public override string AttackType => "특수";
        public override string Type => "땅";
        public override int Damage => 45;
        public override double Accuracy => 95.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class SandTomb : SkillBase
    {
        public override string SkillName => "모래지옥";
        public override string Rank => "B";
        public override string AttackType => "특수";
        public override string Type => "땅";
        public override int Damage => 50;
        public override double Accuracy => 85.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class ThunderWave : SkillBase
    {
        public override string SkillName => "전기 쇼크";
        public override string Rank => "B";
        public override string AttackType => "특수";
        public override string Type => "전기";
        public override int Damage => 40;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class VoltTackle : SkillBase
    {
        public override string SkillName => "볼트 태클";
        public override string Rank => "A";
        public override string AttackType => "물리";
        public override string Type => "전기";
        public override int Damage => 65;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 10.0;
        public override string AsciiArt => " ";
    }

    public class IcicleCrash : SkillBase
    {
        public override string SkillName => "고드름 떨구기";
        public override string Rank => "A";
        public override string AttackType => "물리";
        public override string Type => "얼음";
        public override int Damage => 60;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class Blizzard : SkillBase
    {
        public override string SkillName => "눈보라";
        public override string Rank => "S";
        public override string AttackType => "특수";
        public override string Type => "얼음";
        public override int Damage => 80;
        public override double Accuracy => 70.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class Hurricane : SkillBase
    {
        public override string SkillName => "폭풍";
        public override string Rank => "S";
        public override string AttackType => "특수";
        public override string Type => "비행";
        public override int Damage => 80;
        public override double Accuracy => 70.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class WingAttack : SkillBase
    {
        public override string SkillName => "날개치기";
        public override string Rank => "B";
        public override string AttackType => "물리";
        public override string Type => "비행";
        public override int Damage => 45;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class BugBuzz : SkillBase
    {
        public override string SkillName => "벌레의 울음소리";
        public override string Rank => "A";
        public override string AttackType => "특수";
        public override string Type => "벌레";
        public override int Damage => 60;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class LeechLife : SkillBase
    {
        public override string SkillName => "흡혈";
        public override string Rank => "B";
        public override string AttackType => "물리";
        public override string Type => "벌레";
        public override int Damage => 50;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class SludgeBomb : SkillBase
    {
        public override string SkillName => "오물폭탄";
        public override string Rank => "A";
        public override string AttackType => "특수";
        public override string Type => "독";
        public override int Damage => 60;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class Toxic : SkillBase
    {
        public override string SkillName => "맹독";
        public override string Rank => "B";
        public override string AttackType => "특수";
        public override string Type => "독";
        public override int Damage => 40;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class NightShade : SkillBase
    {
        public override string SkillName => "나이트 쉐이드";
        public override string Rank => "B";
        public override string AttackType => "특수";
        public override string Type => "고스트";
        public override int Damage => 45;
        public override double Accuracy => 100.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

    public class Hex : SkillBase
    {
        public override string SkillName => "저주";
        public override string Rank => "A";
        public override string AttackType => "특수";
        public override string Type => "고스트";
        public override int Damage => 60;
        public override double Accuracy => 90.0;
        public override double CriticalRate => 5.0;
        public override string AsciiArt => " ";
    }

}
