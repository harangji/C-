using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public enum Pattern
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
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

    public class Card
    {
        public Pattern Pat { get; }
        public Number Num { get; }

        public Card(Pattern suit, Number rank)
        {
            Pat = suit;
            Num = rank;
        }
    }

    public class Hand
    {
        public List<Card> Cards { get; }

        public Hand(List<Card> cards)
        {
            Cards = cards;
        }

        public string EvaluateHand()
        {
            if (IsRoyalFlush()) return "로열 플러시";
            if (IsStraightFlush()) return "스트레이트 플러시";
            if (IsFourOfAKind()) return "포카드";
            if (IsFullHouse()) return "풀 하우스";
            if (IsFlush()) return "플러시";
            if (IsStraight()) return "스트레이트";
            if (IsThreeOfAKind()) return "쓰리 오브 어 카인드";
            if (IsTwoPair()) return "투 페어";
            if (IsOnePair()) return "원 페어";
            return "하이 카드";
        }

        private bool IsRoyalFlush()
        {
            return IsStraightFlush() && Cards.Any(c => c.Num == Number.Ace);
        }

        private bool IsStraightFlush()
        {
            return IsFlush() && IsStraight();
        }

        private bool IsFourOfAKind()
        {
            return Cards.GroupBy(c => c.Num).Any(g => g.Count() == 4);
        }

        private bool IsFullHouse()
        {
            var groups = Cards.GroupBy(c => c.Num).ToList();
            return groups.Count == 2 && groups.Any(g => g.Count() == 3);
        }

        private bool IsFlush()
        {
            return Cards.Select(c => c.Pat).Distinct().Count() == 1;
        }

        private bool IsStraight()
        {
            var ranks = Cards.Select(c => (int)c.Num).OrderBy(r => r).ToList();
            return ranks.Zip(ranks.Skip(1), (a, b) => b - a).All(diff => diff == 1);
        }

        private bool IsThreeOfAKind()
        {
            return Cards.GroupBy(c => c.Num).Any(g => g.Count() == 3);
        }

        private bool IsTwoPair()
        {
            return Cards.GroupBy(c => c.Num).Count(g => g.Count() == 2) == 2;
        }

        private bool IsOnePair()
        {
            return Cards.GroupBy(Card => Card.Num).Any(g => g.Count() == 2);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var hand1 = new Hand(new List<Card>
        {
            new Card(Pattern.Hearts, Number.Ace),
            new Card(Pattern.Hearts, Number.King),
            new Card(Pattern.Hearts, Number.Queen),
            new Card(Pattern.Hearts, Number.Jack),
            new Card(Pattern.Hearts, Number.Ten)
        });

            var hand2 = new Hand(new List<Card>
        {
            new Card(Pattern.Spades, Number.Ace),
            new Card(Pattern.Spades, Number.Two),
            new Card(Pattern.Spades, Number.Three),
            new Card(Pattern.Spades, Number.Four),
            new Card(Pattern.Spades, Number.Five)
        });

            string result1 = hand1.EvaluateHand();
            string result2 = hand2.EvaluateHand();

            Console.WriteLine($"Hand 1: {result1}");
            Console.WriteLine($"Hand 2: {result2}");
        }
    }
}