using AdventOfCode.Common;
using System;
using System.Collections.Generic;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/23
    /// </summary>
    public class Day23
    {
        private struct Processor
        {
            public int regA;
            public int regB;

            public int GetRegisterValue(string str)
            {
                return str.TrimEnd(',') == "a" ? regA : regB;
            }

            public void SetRegisterValue(string str, int value)
            {
                if (str.TrimEnd(',') == "a")
                    regA = value;
                else
                    regB = value;
            }
        }

        public Day23(Part p)
        {
            var proc = new Processor();
            if (p == Part.Part2)
                proc.regA = 1;

            IList<string> instr = new List<string>();
            for (string line; !string.IsNullOrEmpty(line = Console.ReadLine()); instr.Add(line))
                ;
            int ptr = 0;
            while (ptr < instr.Count)
            {
                var words = instr[ptr].Split(' ');
                var op = words[0].ToUpper();
                switch (op)
                {
                    case "HLF":
                        proc.SetRegisterValue(words[1], proc.GetRegisterValue(words[1]) >> 1);
                        break;
                    case "TPL":
                        proc.SetRegisterValue(words[1], proc.GetRegisterValue(words[1]) * 3);
                        break;
                    case "INC":
                        proc.SetRegisterValue(words[1], proc.GetRegisterValue(words[1]) + 1);
                        break;
                    case "JMP":
                        ptr += short.Parse(words[1]) - 1;
                        break;
                    case "JIE":
                        if (proc.GetRegisterValue(words[1]) % 2 == 0)
                            ptr += short.Parse(words[2]) - 1;
                        break;
                    case "JIO":
                        if (proc.GetRegisterValue(words[1]) == 1)
                            ptr += short.Parse(words[2]) - 1;
                        break;
                }
                ++ptr;
            }
            Console.WriteLine(proc.regB);
        }
    }
}
