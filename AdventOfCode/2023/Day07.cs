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
        private static readonly char Joker = 'R';

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

        private class PokerHand
        {
            private readonly char[] cards;

            public string Cards => new string(cards);
            public int BidAmount { get; }

            public PokerHand(string strToParse)
            {
                cards = strToParse.Split(' ')[0].Replace("J", Joker.ToString()).ToCharArray();
                BidAmount = int.Parse(strToParse.Split(' ')[1]);
            }

            public HandType GetResult(Part p)
            {
                IDictionary<char, int> win = new Dictionary<char, int>();
                foreach (var card in cards)
                {
                    if (win.ContainsKey(card) || p == Part.Part2 && card == Joker)
                        continue;
                    int nbCard = cards.Count(c => c == card);
                    if (nbCard > 1)
                        win.Add(card, nbCard);
                }

                var result = ComputeHand(win);
                if (p == Part.Part2 && cards.Contains(Joker))
                {
                    int nbJoker = cards.Count(c => c == Joker);

                    result = result switch
                    {
                        HandType.HighCard when nbJoker == 5 => HandType.CheatCarre,
                        HandType.HighCard or HandType.OnePair or HandType.Brelan =>
                            (HandType)((int)result + nbJoker * 2),
                        HandType.TwoPair => HandType.FullHouse,
                        HandType.Carre => HandType.CheatCarre,
                        _ => throw new Exception()
                    };
                }
                return result;
            }

            private static HandType ComputeHand(IDictionary<char, int> win)
            {
                return !win.Any() ? HandType.HighCard :
                    win.Count == 1 ? win.First().Value switch
                    {
                        5 => HandType.CheatCarre,
                        4 => HandType.Carre,
                        3 => HandType.Brelan,
                        2 => HandType.OnePair,
                        _ => throw new Exception()
                    } :
                    win.Values.Max() switch
                    {
                        3 => HandType.FullHouse,
                        2 => HandType.TwoPair,
                        _ => throw new Exception()
                    };
            }
        }


        private class PokerHandComparer : IComparer<PokerHand>
        {
            private readonly Part _part;

            public PokerHandComparer(Part p)
            {
                _part = p;
            }

            public int Compare(PokerHand? x, PokerHand? y)
            {
                switch (x, y)
                {
                    case (not null, null):
                        return 1;
                    case (null, null):
                        return 0;
                    case (null, not null):
                        return -1;
                }
                var resultX = x.GetResult(_part);
                var resultY = y.GetResult(_part);
                return resultX == resultY ? Compare(x.Cards, y.Cards) : resultX - resultY;
            }

            private int Compare(string x, string y)
            {
                int idx = 0;
                foreach (var xSpan in x.AsSpan())
                {
                    var curX = xSpan;
                    var curY = y[idx++];
                    if (curX == curY)
                        continue;
                    if (_part == Part.Part2)
                    {
                        if (curX == Joker)
                            curX = '1';
                        if (curY == Joker)
                            curY = '1';
                    }
                    if (char.IsDigit(curX) && char.IsDigit(curY))
                        return curX.CompareTo(curY);
                    if (char.IsDigit(curX) && !char.IsDigit(curY))
                        return -1;
                    return !char.IsDigit(curX) && char.IsDigit(curY) ? 1 : -curX.CompareTo(curY);
                }
                return 0;
            }
        }

        public Day07(Part p)
        {
            string line;
            var hands = new List<PokerHand>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                hands.Add(new PokerHand(line));

            Console.WriteLine(
                hands.Order(new PokerHandComparer(p))
                    .Select((hand, index) => (index + 1) * hand.BidAmount)
                    .Sum());
        }
    }
}