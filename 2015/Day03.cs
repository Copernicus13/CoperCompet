using System;
using System.Collections.Generic;
using CoperAlgoLib.Geometry;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/3
    /// </summary>
    public class Day03
    {
        private readonly IDictionary<Point, int> _map;

        public Day03(Part p)
        {
            var current = new Point(0, 0);
            var current2 = new Point(0, 0);
            if (p == Part.Part1)
                _map = new Dictionary<Point, int> { { current, 1 } };
            else if (p == Part.Part2)
                _map = new Dictionary<Point, int> { { current, 2 } };
            string line = Console.ReadLine();
            for (int i = 0; i < line.Length; ++i)
            {
                Point actual;
                if (i % 2 == 0 || p == Part.Part1)
                    actual = Move(ref current, line[i]);
                else
                    actual = Move(ref current2, line[i]);
                if (_map.ContainsKey(actual))
                    ++_map[actual];
                else
                    _map.Add(actual, 1);
            }
            Console.WriteLine(_map.Count);
        }

        private static Point Move(ref Point p, char c)
        {
            switch (c)
            {
                case '^': --p.Y; break;
                case 'v': ++p.Y; break;
                case '<': --p.X; break;
                case '>': ++p.X; break;
            }
            return p;
        }
    }
}
