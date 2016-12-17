using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AdventOfCode.Common;
using AdventOfCode.Common.Data;

namespace AdventOfCode._2016
{
    public class Day17
    {
        private Point[] _Dir =
            {
                new Point(0, -1), new Point(0, 1), new Point(-1, 0), new Point(1, 0)
            };
        private string _LitteralDir = "UDLR";

        public Day17(Part p)
        {
            string input = Console.ReadLine();

            using (var md5 = MD5.Create())
            {
                if (p == Part.Part1)
                    Console.WriteLine(SearchPath(input, md5, true));
                else if (p == Part.Part2)
                    Console.WriteLine(SearchPath(input, md5, false));
            }
        }

        private string SearchPath(string input, MD5 md5, bool shortest)
        {
            IList<int> allPaths = new List<int>();
            var queue = new Queue<string>();
            queue.Enqueue(input);
            var currentString = string.Empty;
            while (queue.Any())
            {
                currentString = queue.Dequeue();
                if (currentString.Length > 5000)
                    continue;
                var currentLoc = GetLoc(input, currentString);

                var allowedDir = CalcMd5(md5, currentString);
                for (int i = 0; i < _Dir.Length; ++i)
                {
                    var x = currentLoc.x + _Dir[i].x;
                    var y = currentLoc.y + _Dir[i].y;
                    if (x >= 0 && x < 4 && y >= 0 && y < 4 && allowedDir[i])
                    {
                        if (shortest && x == 3 && y == 3)
                            return currentString.Substring(input.Length) + _LitteralDir[i];
                        if (!shortest && x == 3 && y == 3)
                            allPaths.Add(currentString.Length - input.Length + 1);
                        if (shortest || x != 3 || y != 3)
                            queue.Enqueue(currentString + _LitteralDir[i]);
                    }
                }
            }
            if (!shortest && allPaths.Any())
                return allPaths.Max().ToString();
            return "IMPOSSIBLE";
        }

        private Point GetLoc(string input, string currentString)
        {
            var p = new Point(0, 0);
            foreach (char c in currentString.Substring(input.Length))
            {
                var idx = _LitteralDir.IndexOf(c);
                p.x += _Dir[idx].x;
                p.y += _Dir[idx].y;
            }
            return p;
        }

        private bool[] CalcMd5(MD5 md5, string val)
        {
            string hash = BitConverter.ToString(md5.ComputeHash(
                Encoding.ASCII.GetBytes(val))).Replace("-", string.Empty);
            return new bool[4] { hash[0] > 'A', hash[1] > 'A', hash[2] > 'A', hash[3] > 'A' };
        }
    }
}
