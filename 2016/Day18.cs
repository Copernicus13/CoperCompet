using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/18
    /// </summary>
    public class Day18
    {
        public Day18(Part p)
        {
            string line = Console.ReadLine();

            IList<string> tiles = new List<string> { line };

            var nbLoop = p == Part.Part1 ? 39 : 399999;

            for (int i = 0; i < nbLoop; ++i)
                tiles.Add(GetNextTiles(tiles[i]));

            Console.WriteLine(tiles.Aggregate(0, (a, b) => a + b.Count(c => c == '.')));
        }

        private string GetNextTiles(string previousTiles)
        {
            char[] res = new string('.', previousTiles.Length).ToCharArray();
            for (int i = 0; i < previousTiles.Length; ++i)
            {
                char left = i - 1 < 0 ? '.' : previousTiles[i - 1];
                char center = previousTiles[i];
                char right = i + 1 >= previousTiles.Length ? '.' : previousTiles[i + 1];

                if (left == '^' && center == '^' && right == '.' ||
                    left == '.' && center == '^' && right == '^' ||
                    left == '^' && center == '.' && right == '.' ||
                    left == '.' && center == '.' && right == '^')
                {
                    res[i] = '^';
                }
            }
            return new string(res);
        }
    }
}