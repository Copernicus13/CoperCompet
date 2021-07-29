using AdventOfCode.Common;
using System;
using System.Collections.Generic;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/23
    /// </summary>
    public class Day23
    {
        private readonly IDictionary<string, int> dict = new Dictionary<string, int>();

        public Day23(Part p)
        {
            IList<string> instr = new List<string>();
            for (string line; !string.IsNullOrEmpty(line = Console.ReadLine()); instr.Add(line))
                ;

            dict["a"] = p == Part.Part1 ? 7 : 12;
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
                                i += getOperand(words[2]) - 1;
                            break;
                        case "tgl":
                            {
                                var tip = i + getOperand(words[1]);
                                instr[tip] = toggle(instr[tip]);
                            }
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
            int res;
            return int.TryParse(v, out res) ? res : dict[v];
        }

        private string toggle(string instr)
        {
            string[,] transform =
                {
                    { "inc", "dec", "jnz", "cpy", "tgl" },
                    { "dec", "inc", "cpy", "jnz", "inc" }
                };

            for (int i = 0; i < transform.GetLength(1); ++i)
                if (instr.IndexOf(transform[0, i], 0, 3) != -1)
                    return instr.Replace(transform[0, i], transform[1, i]);

            return instr;
        }
    }
}
