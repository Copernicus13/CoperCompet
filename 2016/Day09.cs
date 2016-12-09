using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode._2016
{
    public class Day09
    {
        public Day09(Part p)
        {
            string line;
            IList<string> tab = new List<string>();
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                tab.Add(line);

            for (int i = 0; i < tab.Count; ++i)
                Console.WriteLine(CountLength(p, tab[i]));
        }

        private long CountLength(Part p, string actual)
        {
            long myLength = 0;
            for (int j = 0; j < actual.Length; ++j)
            {
                if (actual[j] == '(' && actual.Substring(j + 1).Contains(")") && actual.Substring(j + 1).Contains("x"))
                {
                    int o = int.Parse(actual.Substring(j + 1).Split('x')[0]);
                    int q = int.Parse(actual.Substring(j + 1).Split('x')[1].Split(')')[0]);
                    if (p == Part.Part1)
                        myLength += o * q;
                    else if (p == Part.Part2)
                        myLength += CountLength(p, actual.Substring(j + actual.Substring(j).Split(')')[0].Length + 1, o)) * q;
                    j += o + actual.Substring(j).Split(')')[0].Length;
                }
                else
                    ++myLength;
            }
            return myLength;
        }
    }
}
