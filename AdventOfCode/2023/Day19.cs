using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/19
    /// </summary>
    public class Day19
    {
        private enum State
        {
            Unknown,
            Accepted,
            Rejected
        }

        private class MetalPart
        {
            public Dictionary<char, int> Ranks { get; }

            public State State { get; set; }

            public MetalPart(string config)
            {
                Ranks = new Dictionary<char, int>();
                State = State.Unknown;
                foreach (string rank in config.Split(','))
                    Ranks.Add(rank[0], int.Parse(rank[2..]));
            }
        }

        private readonly Dictionary<string, List<string>> _workflow;
        private readonly List<MetalPart> _parts;

        public Day19(Part p)
        {
            long result = 0;
            string line;
            _workflow = new Dictionary<string, List<string>>();
            _parts = new List<MetalPart>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                _workflow.Add(line.Split('{')[0], line.Split('{')[1].TrimEnd('}').Split(',').ToList());

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                _parts.Add(new MetalPart(line[1..^1]));

            if (p == Part.Part1)
                result = AnalyzeParts();
            else if (p == Part.Part2)
                result = 0L;

            Console.WriteLine(result);
        }

        private long AnalyzeParts()
        {
            foreach (var metalPart in _parts)
            {
                string nextFlow = "in";
                while (metalPart.State == State.Unknown)
                {
                    var operations = _workflow[nextFlow];
                    foreach (string ope in operations)
                    {
                        if (ope.Length == 1)
                        {
                            metalPart.State = ope == "A" ? State.Accepted : State.Rejected;
                            break;
                        }
                        if (!ope.Contains(':'))
                        {
                            nextFlow = ope;
                            break;
                        }
                        string[] str = ope[2..].Split(':');
                        if (ope[1] == '<' && metalPart.Ranks[ope[0]] < int.Parse(str[0]) ||
                            ope[1] == '>' && metalPart.Ranks[ope[0]] > int.Parse(str[0]))
                        {
                            if (str[1].Length == 1)
                                metalPart.State = str[1] == "A" ? State.Accepted : State.Rejected;
                            nextFlow = str[1];
                            break;
                        }
                    }
                }
            }
            return _parts.Where(w => w.State == State.Accepted)
                .Select(s => s.Ranks.Values.Sum())
                .Sum();
        }
    }
}