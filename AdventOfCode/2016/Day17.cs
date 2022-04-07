using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AdventOfCode.Common;
using CoperAlgoLib.Geometry;

namespace AdventOfCode._2016
{
    /// <summary>
    /// http://adventofcode.com/2016/day/17
    /// </summary>
    public class Day17
    {
        private string _LitteralDir = "UDLR";
        private Point[] _Dir =
            {
                new Point(0, -1), new Point(0, 1), new Point(-1, 0), new Point(1, 0)
            };

        public Day17(Part p)
        {
            string input = Console.ReadLine();

            using (var md5 = MD5.Create())
            {
                Console.WriteLine(SearchPath(input, md5, p == Part.Part1));
            }
        }

        private string SearchPath(string input, MD5 md5, bool shortest)
        {
            var longestPath = -1;
            var queue = new Queue<string>(new[] { string.Empty });
            while (queue.Any())
            {
                var currentString = queue.Dequeue();
                var currentLoc = GetLoc(currentString);
                var allowedDir = CalcMd5(md5, string.Format("{0}{1}", input, currentString));
                for (int i = 0; i < _Dir.Length; ++i)
                {
                    var x = currentLoc.X + _Dir[i].X;
                    var y = currentLoc.Y + _Dir[i].Y;
                    if (x >= 0 && x < 4 && y >= 0 && y < 4 && allowedDir[i])
                    {
                        if (shortest && x == 3 && y == 3)
                            return currentString + _LitteralDir[i];
                        if (!shortest && x == 3 && y == 3)
                            longestPath = currentString.Length + 1;
                        if (shortest || x != 3 || y != 3)
                            queue.Enqueue(currentString + _LitteralDir[i]);
                    }
                }
            }
            if (!shortest && longestPath != -1)
                return longestPath.ToString();
            return "IMPOSSIBLE";
        }

        private Point GetLoc(string currentString)
        {
            var p = new Point(0, 0);
            foreach (char c in currentString)
            {
                var idx = _LitteralDir.IndexOf(c);
                p.X += _Dir[idx].X;
                p.Y += _Dir[idx].Y;
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
