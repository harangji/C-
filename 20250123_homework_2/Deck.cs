using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250123_homework_2
{
    public enum Pattern
    {
        Spades,
        Diamonds,
        Hearts,
        Clover
    }
    public enum Number
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack = 11,
        Queen,
        King,
        Ace = 14
    }

    /// <summary>
    /// 카드는 class 
    /// Array로 카드를 만들고
    /// 플레이어가 카드를 가지고 가면 List
    /// </summary>

    class Card
    {
        /*
         A
        2 3 4 5 6 7 8 9 10 j q k
         */
        public Number num;
        public Pattern pattern;
        public bool isUse;
       
        public Card(Number _num,Pattern p)
        {
            num = _num;
            pattern = p;
            isUse = false;
        }
        public void Viewing_card()
        {
            //"♠""♣""♥""◆"
            string Pattern_s = string.Empty;
            switch (pattern)
            {
                case Pattern.Spades:
                    Pattern_s = "♠";
                    break;
                case Pattern.Diamonds:
                    Pattern_s = "◆";
                    break;
                case Pattern.Hearts:
                    Pattern_s = "♥";
                    break;
                case Pattern.Clover:
                    Pattern_s = "♣";
                    break;
            }


            /*
             1 2 3 4 5 6 7 8 9 10 11 12 13
             A                    J   Q  K
             */

            string number_s = string.Empty;
            //if (num.Equals(1) || num.Equals(11) ||
            //    num.Equals(12) || num.Equals(13))
            //{
            //    //문자 변경 1 11 12 13 
            //    switch (num)
            //    {
            //        case 1:
            //            number_s = "A";
            //            break;
            //        case 11:
            //            number_s = "J";
            //            break;
            //        case 12:
            //            number_s = "Q";
            //            break;
            //        case 13:
            //            number_s = "K";
            //            break;
            //    }
            //}
            //else
            //{
            //    number_s = num.ToString();
            //}

            Console.Write($"|{Pattern_s} {number_s}|");




        }
    }


    public class Deck
    {
        public void make_cards()
        {
            List<Card> cards_list = new List<Card>();
            //Card[] card_array = new Card[52];

            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 13; k++)
                {
                    cards_list.Add(new Card((Number)2, (Pattern)i));
                    Console.WriteLine((Number)2);
                }


            }

            for (int i = 0; i < cards_list.Count; i++)
            {
                if (i % 13 == 0)
                {
                    Console.WriteLine();
                }
                cards_list[i].Viewing_card();
            }


            List<Card> Player_Card = new List<Card>();
            while (true)
            {
                Console.ReadLine();
                Console.Clear();
                //Card temp = cards_list[0];
                //cards_list.RemoveAt(0);
                Player_Card.Add(CardPick(ref cards_list));
                for (int i = 0; i < Player_Card.Count; i++)
                {
                    Player_Card[i].Viewing_card();
                }
                Console.WriteLine();

            }

        }


        Card CardPick(ref List<Card> cards)
            {
                Card temp = cards[0];
                cards.RemoveAt(0);
                return temp;
            }

        //카드셔플 메서드
        //매개변수로는 카드덱 / (선택)셔플 카운트
        //retrun할 자료-> 섞인 카드덱


        //public static List<Card> Suffle_Card(List<Card> cards, int sufflecount)
        //{
        //    List<Card> return_card = new List<Card>();
        //    return_card = cards;
        //    Card temp_card = new Card(0, 0);
        //    Random rnd = new Random();
        //    int cardcount = return_card.Count;
        //    for (int i = 0; i < sufflecount; i++)
        //    {
        //        int F_index = rnd.Next(0, cardcount);
        //        int S_index = rnd.Next(0, cardcount);
        //        if (F_index.Equals(S_index))
        //        {
        //            S_index = rnd.Next(0, cardcount);
        //        }
        //        temp_card = return_card[F_index];
        //        return_card[F_index] = return_card[S_index];
        //        return_card[S_index] = temp_card;
        //    }
        //    return return_card;
        //}

    }
    }





