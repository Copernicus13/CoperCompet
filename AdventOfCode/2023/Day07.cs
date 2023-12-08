using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/7
    /// </summary>
    public class Day07
    {
        private static char _joker;

        private enum HandType
        {
            HighCard = 0,
            OnePair = 2,
            TwoPair = 3,
            Brelan = 4,
            FullHouse = 5,
            Carre = 6,
            CheatCarre = 8
        }

        private class PokerHand : IComparable<PokerHand>
        {
            private readonly Part _part;
            private readonly char[] _cards;
            private string Cards => new string(_cards);

            public int BidAmount { get; }

            public PokerHand(Part p, string strToParse)
            {
                _part = p;
                _cards = strToParse.Split(' ')[0]
                    // To be able to sort using ordinal rule
                    .Replace('A', 'Z').Replace('K', 'Y').Replace('Q', 'X').Replace('J', _joker)
                    .ToCharArray();
                BidAmount = int.Parse(strToParse.Split(' ')[1]);
            }

            private HandType GetResult()
            {
                var win = new Dictionary<char, int>();
                foreach (var card in _cards)
                {
                    if (win.ContainsKey(card) || _part == Part.Part2 && card == _joker)
                        continue;
                    int nbCard = _cards.Count(c => c == card);
                    if (nbCard > 1)
                        win.Add(card, nbCard);
                }
                var result = !win.Any() ?
                    HandType.HighCard :
                    (win.Values.Max(), win.Count) switch
                    {
                        (5, 1) => HandType.CheatCarre,
                        (4, 1) => HandType.Carre,
                        (3, 2) => HandType.FullHouse,
                        (3, 1) => HandType.Brelan,
                        (2, 2) => HandType.TwoPair,
                        (2, 1) => HandType.OnePair,
                        _ => throw new Exception()
                    };
                if (_part == Part.Part2 && _cards.Contains(_joker))
                    result = result switch
                    {
                        HandType.HighCard when _cards.Count(c => c == _joker) == 5 => HandType.CheatCarre,
                        HandType.HighCard or HandType.OnePair or HandType.Brelan =>
                            (HandType)((int)result + _cards.Count(c => c == _joker) * 2),
                        HandType.TwoPair => HandType.FullHouse,
                        HandType.Carre => HandType.CheatCarre,
                        _ => throw new Exception()
                    };
                return result;
            }

            public int CompareTo(PokerHand other)
            {
                if (other is null)
                    return 1;
                var resultX = GetResult();
                var resultY = other.GetResult();
                return resultX == resultY ? string.CompareOrdinal(Cards, other.Cards) : resultX - resultY;
            }
        }

        public Day07(Part p)
        {
            string line;
            var hands = new List<PokerHand>();

            _joker = p == Part.Part1 ? 'V' : '1';

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                hands.Add(new PokerHand(p, line));

            Console.WriteLine(
                hands.Order()
                    .Select((hand, index) => (index + 1) * hand.BidAmount)
                    .Sum());
        }
    }
}