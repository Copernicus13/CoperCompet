using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2021
{
    /// <summary>
    /// http://adventofcode.com/2021/day/3
    /// </summary>
    public class Day03
    {
        public Day03(Part p)
        {
            const int NB_BITS = 12;
            int cpt = 0;
            int[] bits = new int[NB_BITS];
            IList<string> data = new List<string>();
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                ++cpt;
                data.Add(line);
                for (int i = 0; i < NB_BITS; ++i)
                    if (line[i] == '1')
                        ++bits[i];
            }

            char[] gamma = new char[NB_BITS],
                   epsilon = new char[NB_BITS];
            for (int i = 0; i < NB_BITS; ++i)
            {
                gamma[i] = bits[i] > cpt >> 1 ? '1' : '0';
                epsilon[i] = bits[i] > cpt >> 1 ? '0' : '1';
            }

            if (p == Part.Part1)
                Console.WriteLine(
                    Convert.ToInt32(new string(gamma), 2) *
                    Convert.ToInt32(new string(epsilon), 2));
            else if (p == Part.Part2)
            {
                var oxygenData = data.Where(w => w[0] == gamma[0]).ToList();
                var co2Data = data.Where(w => w[0] == epsilon[0]).ToList();
                for (int i = 1; i < NB_BITS; ++i)
                {
                    oxygenData = oxygenData.Where(w => w[i] == MostCommonBit(oxygenData, i)).ToList();
                    if (co2Data.Count() > 1)
                        co2Data = co2Data.Where(w => w[i] == LeastCommonBit(co2Data, i)).ToList();
                }
                Console.WriteLine(
                    Convert.ToInt32(new string(oxygenData.Single()), 2) *
                    Convert.ToInt32(new string(co2Data.Single()), 2));
            }
        }

        private char MostCommonBit(IEnumerable<string> list, int pos)
        {
            var nbZero = list.Select(s => s[pos]).Count(c => c == '0');
            var nbOnes = list.Select(s => s[pos]).Count(c => c == '1');
            return nbOnes >= nbZero ? '1' : '0';
        }

        private char LeastCommonBit(IEnumerable<string> list, int pos) =>
            MostCommonBit(list, pos) == '1' ? '0' : '1';
    }
}
