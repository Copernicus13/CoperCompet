using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day07
    {
        private readonly IDictionary<string, ushort> dict = new Dictionary<string, ushort>();

        public Day07(Part p)
        {
            if (p == Part.Part2)
                dict["b"] = 956;
            IList<string> instr = new List<string>();
            int cpt = 0;
            for (string line; !string.IsNullOrEmpty(line = Console.ReadLine()); instr.Add(line))
                ;
            for (int i = 0; i < instr.Count; ++i)
            {
                var words = instr[i].Split(' ');
                try
                {
                    if (p == Part.Part2 && instr[i].EndsWith("-> b"))
                        continue;
                    if (isDigit(words[0]) && words[1] == "->")
                    {
                        dict[words[2]] = ushort.Parse(words[0]);
                        continue;
                    }
                    if (words[0] == "NOT")
                    {
                        dict[words[3]] = (ushort)~dict[words[1]];
                        continue;
                    }
                    switch (words[1])
                    {
                        case "AND":
                            dict[words[4]] = (ushort)(getOperand(words[0]) & getOperand(words[2]));
                            break;
                        case "OR":
                            dict[words[4]] = (ushort)(getOperand(words[0]) | getOperand(words[2]));
                            break;
                        case "LSHIFT":
                            dict[words[4]] = (ushort)(getOperand(words[0]) << ushort.Parse(words[2]));
                            break;
                        case "RSHIFT":
                            dict[words[4]] = (ushort)(getOperand(words[0]) >> ushort.Parse(words[2]));
                            break;
                        case "->":
                            dict[words[2]] = dict[words[0]];
                            break;
                    }
                    if (i > cpt)
                    {
                        Console.Write('.');
                        cpt = i;
                    }
                }
                catch (Exception)
                {
                    instr.Add(instr[i]);
                    instr.RemoveAt(i--);
                }
            }
            Console.WriteLine(Environment.NewLine + dict["a"]);
        }

        private ushort getOperand(string v)
        {
            return isDigit(v) ? ushort.Parse(v) : dict[v];
        }

        private static bool isDigit(string v)
        {
            return v.All(c => char.IsDigit(c));
        }
    }
}
