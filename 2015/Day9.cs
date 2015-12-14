using System;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day9
    {
        private enum City
        {
            Faerun,
            Tristram,
            Tambi,
            Norrath,
            Snowdin,
            Straylight,
            AlphaCentauri,
            Arbre
        }

        private readonly int[,] _map = new int[8, 8];

        public Day9(Part p)
        {
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var words = line.Split(' ');
                _map[C2I(words[0]), C2I(words[2])] = int.Parse(words[4]);
                _map[C2I(words[2]), C2I(words[0])] = int.Parse(words[4]);
            }

            int[] perm = new[] { 0, 1, 2, 3, 4, 5, 6, 7 };

            int best = 0;
            if (p == Part.Part1)
            {
                best = int.MaxValue;
                do
                {
                    best = Math.Min(Calc(perm), best);
                } while (Permutations.GetNext(perm));
            }
            else if (p == Part.Part2)
            {
                best = int.MinValue;
                do
                {
                    best = Math.Max(Calc(perm), best);
                } while (Permutations.GetNext(perm));
            }
            Console.WriteLine(best);
        }

        private int Calc(int[] combination)
        {
            int result = 0;
            for (int i = 0; i < combination.Length - 1; ++i)
                result += _map[combination[i], combination[i + 1]];
            return result;
        }

        private static int C2I(string city)
        {
            return (int)Enum.Parse(typeof(City), city);
        }
    }
}
