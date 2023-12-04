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
            public int IdGame { get; set; }
            public IList<int> WinningNumbers { get; } = new List<int>();
            public IList<int> MyNumbers { get; } = new List<int>();

            private bool IsWinner => WinningNumbers.Intersect(MyNumbers).Any();
            public int NbWinner => WinningNumbers.Intersect(MyNumbers).Count();
            public int Score => IsWinner ? (int)Math.Pow(2, NbWinner - 1) : 0;

        }

        public Day04(Part p)
        {
            var result = 0;
            string line;
            IList<(int NbWinner, int NbCard)> win = new List<(int NbWinner, int NbCard)>();
            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
            {
                if (p == Part.Part1)
                    result += ParseLine(line).Score;
                else if (p == Part.Part2)
                {
                    var game = ParseLine(line);
                    win.Add((game.NbWinner, 1));
                }
            }

            if (p == Part.Part2)
            {
                for (int i = 0; i < win.Count; ++i)
                {
                    for (int x = 0; x < win[i].NbCard; ++x)
                        for (int j = i + 1; j < win.Count && j < i + 1 + win[i].NbWinner; ++j)
                            win[j] = (win[j].NbWinner, win[j].NbCard + 1);
                }
                result = win.Sum(s => s.NbCard);
            }
            Console.WriteLine(result);
        }

        private Game ParseLine(string line)
        {
            var result = new Game { IdGame = int.Parse(line.Substring(4, line.IndexOf(':') - 4)) };
            var allNumbers = line.Split(':')[1].Split('|').Select(s => s.Trim()).ToList();
            foreach (var winningNumber in allNumbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries))
                result.WinningNumbers.Add(int.Parse(winningNumber));
            foreach (var winningNumber in allNumbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries))
                result.MyNumbers.Add(int.Parse(winningNumber));
            return result;
        }
    }
}