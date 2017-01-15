using System;
using System.Linq;
using CoperAlgoLib.Combinatorics;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/13
    /// </summary>
    public class Day13
    {
        private enum Guest
        {
            Alice,
            Bob,
            Carol,
            David,
            Eric,
            Frank,
            George,
            Mallory,
            Me  // must be the last
        }

        private readonly int[,] _map;

        public Day13(Part p)
        {
            int nbGuests = Enum.GetValues(typeof(Guest)).Length;
            if (p == Part.Part1)
                --nbGuests;

            _map = new int[nbGuests, nbGuests];
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var words = line.TrimEnd('.').Split(' ');
                _map[G2I(words[0]), G2I(words[10])] = int.Parse(words[3]) * (words[2] == "gain" ? 1 : -1);
            }

            int[] perm = Enumerable.Range(0, nbGuests).ToArray();

            int best = int.MinValue;
            do
            {
                best = Math.Max(Calc(perm), best);
            } while (Permutations<object>.GetNext(perm));

            Console.WriteLine(best);
        }

        private int Calc(int[] combination)
        {
            int result = 0;
            for (int i = 0; i < combination.Length - 1; ++i)
                result += _map[combination[i], combination[i + 1]] + _map[combination[i + 1], combination[i]];
            result += _map[combination[combination.Length - 1], combination[0]] + _map[combination[0], combination[combination.Length - 1]];
            return result;
        }

        private static int G2I(string guest)
        {
            return (int)Enum.Parse(typeof(Guest), guest);
        }
    }
}
