using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/12
    /// </summary>
    public class Day12
    {
        private readonly IDictionary<string, int> dict = new Dictionary<string, int>();

        public Day12(Part p)
        {
            IList<string> instr = new List<string>();
            for (string line; !string.IsNullOrEmpty(line = Console.ReadLine()); instr.Add(line))
                ;

            if (p == Part.Part2)
                dict["c"] = 1;
            for (int i = 0; i < instr.Count; ++i)
            {
                var words = instr[i].Split(' ');
                try
                {
                    switch (words[0])
                    {
                        case "cpy":
                            dict[words[2]] = getOperand(words[1]);
                            break;
                        case "inc":
                            ++dict[words[1]];
                            break;
                        case "dec":
                            --dict[words[1]];
                            break;
                        case "jnz":
                            if (getOperand(words[1]) != 0)
                                i += int.Parse(words[2]) - 1;
                            break;
                    }
                }
                catch (Exception)
                {
                }
            }
            Console.WriteLine(Environment.NewLine + dict["a"]);
        }

        private int getOperand(string v)
        {
            return isDigit(v) ? int.Parse(v) : dict[v];
        }

        private static bool isDigit(string v)
        {
            return v.All(c => char.IsDigit(c));
        }
    }
}
