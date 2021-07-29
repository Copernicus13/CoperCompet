using AdventOfCode.Common;
using System;
using System.Linq;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/6
    /// </summary>
    public class Day06
    {
        private readonly bool[,] _grid1;
        private readonly long[,] _grid2;

        public Day06(Part p)
        {
            _grid1 = new bool[1000, 1000];
            _grid2 = new long[1000, 1000];
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                bool? action = null;
                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
                var words = line.Split(' ');
                switch (words[0])
                {
                    case "turn":
                        action = (words[1] == "on" ? true : false);
                        x1 = int.Parse(words[2].Split(',')[0]);
                        y1 = int.Parse(words[2].Split(',')[1]);
                        x2 = int.Parse(words[4].Split(',')[0]);
                        y2 = int.Parse(words[4].Split(',')[1]);
                        break;
                    case "toggle":
                        x1 = int.Parse(words[1].Split(',')[0]);
                        y1 = int.Parse(words[1].Split(',')[1]);
                        x2 = int.Parse(words[3].Split(',')[0]);
                        y2 = int.Parse(words[3].Split(',')[1]);
                        break;
                }
                if (p == Part.Part1)
                    part1(action, x1, y1, x2, y2);
                else if (p == Part.Part2)
                    part2(action, x1, y1, x2, y2);
            }
            if (p == Part.Part1)
                Console.WriteLine(_grid1.Cast<bool>().Count(b => b == true));
            else if (p == Part.Part2)
                Console.WriteLine(_grid2.Cast<long>().Sum());
        }

        private void part1(bool? action, int x1, int y1, int x2, int y2)
        {
            for (int i = x1; i <= x2; ++i)
                for (int j = y1; j <= y2; ++j)
                    _grid1[i, j] = action.HasValue ? action.Value : !_grid1[i, j];
        }

        private void part2(bool? action, int x1, int y1, int x2, int y2)
        {
            for (int i = x1; i <= x2; ++i)
                for (int j = y1; j <= y2; ++j)
                    _grid2[i, j] += action.HasValue ?
                        (action.Value ? 1 : (_grid2[i, j] > 0 ? -1 : 0)) :
                        2;
        }
    }
}
