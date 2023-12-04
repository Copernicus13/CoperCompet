using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/4
    /// </summary>
    public class Day04
    {
        private class Game
        {
            public IList<int> WinningNumbers { get; } = new List<int>();
            public IList<int> MyNumbers { get; } = new List<int>();

            public int NbWinner => WinningNumbers.Intersect(MyNumbers).Count();
            public int Score => NbWinner != 0 ? (int)Math.Pow(2, NbWinner - 1) : 0;
        }

        public Day04(Part p)
        {
            var result = 0;
            string line;
            IList<(int NbWinner, int NbCard)> deck = new List<(int, int)>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
            {
                if (p == Part.Part1)
                    result += ParseLine(line).Score;
                else if (p == Part.Part2)
                    deck.Add((ParseLine(line).NbWinner, 1));
            }

            if (p == Part.Part2)
            {
                for (int i = 0; i < deck.Count; ++i)
                    for (int j = i + 1; j < deck.Count && j < i + 1 + deck[i].NbWinner; ++j)
                        deck[j] = (deck[j].NbWinner, deck[j].NbCard + deck[i].NbCard);

                result = deck.Sum(s => s.NbCard);
            }
            Console.WriteLine(result);
        }

        private Game ParseLine(string line)
        {
            var result = new Game();
            var allNumbers = line.Split(':')[1].Split('|').Select(s => s.Trim()).ToList();
            foreach (var winningNumber in allNumbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries))
                result.WinningNumbers.Add(int.Parse(winningNumber));
            foreach (var winningNumber in allNumbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries))
                result.MyNumbers.Add(int.Parse(winningNumber));
            return result;
        }
    }
}