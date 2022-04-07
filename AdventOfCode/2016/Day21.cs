using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/21
    /// </summary>
    public class Day21
    {
        public Day21(Part p)
        {
            IList<string> instr = new List<string>();
            for (string line; !string.IsNullOrEmpty(line = Console.ReadLine()); instr.Add(line))
                ;

            char[] toScramble = { };
            if (p == Part.Part1)
                toScramble = "abcdefgh".ToCharArray();
            else if (p == Part.Part2)
            {
                toScramble = "fbgdceah".ToCharArray();
                instr = instr.Reverse().ToList();
            }

            foreach (string line in instr)
            {
                int var1 = 0, var2 = 0;
                var words = line.Split(' ');
                char[] tmpPwd = new char[toScramble.Length];
                switch (words[0])
                {
                    case "swap":
                        switch (words[1])
                        {
                            case "letter":
                                var1 = new string(toScramble).IndexOf(words[2][0]);
                                var2 = new string(toScramble).IndexOf(words[5][0]);
                                break;
                            case "position":
                                var1 = int.Parse(words[2]);
                                var2 = int.Parse(words[5]);
                                break;
                        }
                        Utils.Swap(ref toScramble[var1], ref toScramble[var2]);
                        break;
                    case "rotate":
                        {
                            if (words[1] == "based")
                            {
                                var1 = new string(toScramble).IndexOf(words[6][0]);
                                if (p == Part.Part1)
                                    var1 += var1 >= 4 ? 2 : 1;
                                else if (p == Part.Part2)
                                    var1 = var1 % 2 == 0 ?
                                        var1 == 0 ? toScramble.Length + 1 : var1 / 2 + 5 :
                                        var1 / 2 + 1;
                            }
                            else
                                var1 = int.Parse(words[2]);

                            var copy = (char[])toScramble.Clone();
                            var1 %= copy.Length;
                            if (p == Part.Part1 && (words[1] == "right" || words[1] == "based") ||
                                p == Part.Part2 && (words[1] == "left"))
                            {
                                var1 = copy.Length - var1;
                            }
                            for (int i = 0; i < toScramble.Length; ++i)
                                toScramble[i] = copy[(i + var1) % copy.Length];
                        }
                        break;
                    case "move":
                        if (p == Part.Part1)
                        {
                            var1 = int.Parse(words[2]);
                            var2 = int.Parse(words[5]);
                        }
                        else if (p == Part.Part2)
                        {
                            var2 = int.Parse(words[2]);
                            var1 = int.Parse(words[5]);
                        }
                        var moved = toScramble[var1];
                        toScramble = new string(toScramble)
                            .Remove(var1, 1)
                            .Insert(var2, new string(moved, 1))
                            .ToCharArray();
                        break;
                    case "reverse":
                        var1 = int.Parse(words[2]);
                        var2 = int.Parse(words[4]);
                        toScramble = toScramble
                            .Take(var1)
                            .Union(toScramble.Skip(var1).Take(var2 - var1 + 1).Reverse())
                            .Union(toScramble.Skip(var2 + 1)).ToArray();
                        break;
                }
            }
            Console.WriteLine(toScramble);
        }
    }
}
