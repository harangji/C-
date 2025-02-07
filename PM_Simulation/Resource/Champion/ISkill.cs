using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_Simulation.Resource
{
    public interface ISkill
    {
        void Execute(string name);
    }

    // 기본 공격 스킬
    public class BasicAttack : ISkill
    {
        public void Execute(string name)
        {
            Console.WriteLine($"{name} 이(가) 공격을 사용했습니다!");
        }
    }

    public class FireBlast : ISkill
    {
        public void Execute(string name)
        {
            Console.WriteLine($"{name} 이(가) 지옥불을 사용했습니다!");
        }
    }

    public class IceSpike : ISkill
    {
        public int dmg = 1;
        public void Execute(string name)
        {
            Console.WriteLine($"{name} 이(가) 얼음 창을 사용했습니다! 데미지 {dmg}");
        }
    }
}