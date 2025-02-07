using System;

namespace PM_Simulation.Resource
{
    public class Button
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public IButton Command { get; set; }  // 버튼 클릭 시 실행할 메서드


        public Button(string name, int x, int y, IButton command)
        {
            Name = name;
            X = x;
            Y = y;
            Command = command;
        }

        // 버튼 클릭 시 실행하는 메서드
        public void ExecuteEffect()
        {
            Command.Execute();
        }
    }
}
