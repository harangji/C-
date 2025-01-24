using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250123_homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            SevenPoker game = new SevenPoker();
            game.Gamestart();
        }


        public void Shuffle()
        {
            for (int pattern = 0; pattern < 4; pattern++)
            {
                for (int number = 1; number < 53; number++)
                {
                    switch (pattern)
                    {
                        case 0:
                            //Spade
                            
                            break;

                        case 1:
                            //Diamonds

                            break;

                        case 2:
                            //Heart

                            break;

                        case 3:
                            //Clover

                            break;

                    }
                }
            }

        }

    }
}