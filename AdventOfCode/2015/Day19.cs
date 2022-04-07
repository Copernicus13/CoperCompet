using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/19
    /// </summary>
    public class Day19
    {
        // Part 1
        private readonly IList<string> _set = new List<string>();
        private readonly IDictionary<string, IList<string>> _dict1 =
            new Dictionary<string, IList<string>>();
        // Part 2
        private readonly IDictionary<string, string> _dict2 =
            new SortedDictionary<string, string>(new CustomReverseStringComparer(StringComparer.CurrentCulture));
        private const int N = 43;

        public Day19(Part p)
        {
            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                var words = line.Split(' ');
                if (p == Part.Part1)
                {
                    if (!_dict1.ContainsKey(words[0]))
                        _dict1[words[0]] = new List<string>();
                    _dict1[words[0]].Add(words[2]);
                }
                else if (p == Part.Part2)
                    _dict2[words[2]] = words[0];
            }

            string expected = Console.ReadLine();

            if (p == Part.Part1)
            {
                foreach (var tuple in _dict1)
                    foreach (var value in tuple.Value)
                    {
                        string sub = expected;
                        while (sub.IndexOf(tuple.Key, StringComparison.Ordinal) != -1)
                        {
                            int idx = sub.IndexOf(tuple.Key, StringComparison.Ordinal);
                            int len = sub.Length;
                            sub = sub.Substring(idx + tuple.Key.Length);
                            _set.Add(string.Format("{0}{1}{2}", expected.Substring(0, expected.Length - len + idx), value, sub));
                        }
                    }
                Console.WriteLine(_set.Distinct().Count());
            }
            else if (p == Part.Part2)
            {
                int result = 0;
                while (expected != "e")
                {
                    for (int i = 0; i < _dict2.Count; ++i)
                    {
                        var kvp = _dict2.ElementAt(i);
                        string sub = expected;
                        int idx = sub.LastIndexOf(kvp.Key, StringComparison.Ordinal);
                        bool reset = false;
                        while (idx != -1)
                        {
                            ++result;
                            reset = true;
                            sub = string.Format("{0}{1}{2}", sub.Substring(0, idx), kvp.Value, sub.Substring(idx + kvp.Key.Length));
                            idx = sub.LastIndexOf(kvp.Key, StringComparison.Ordinal);
                        }
                        expected = sub;
                        if (reset)
                            i = -1;
                    }
                }
                Console.WriteLine(result);
            }
        }

        private class CustomReverseStringComparer : IComparer<string>
        {
            private readonly IComparer<string> _baseComparer;

            public CustomReverseStringComparer(IComparer<string> baseComparer)
            {
                _baseComparer = baseComparer;
            }

            public int Compare(string x, string y)
            {
                if (x.Length == y.Length)
                    return -_baseComparer.Compare(x, y);

                return x.Length > y.Length ? -1 : 1;
            }
        }
    }
}