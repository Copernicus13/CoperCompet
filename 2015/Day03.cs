using System;
using System.Collections.Generic;
using AdventOfCode.Common;

namespace AdventOfCode._2015
{
    public class Day03
    {
        private struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public Point Move(char c)
            {
                switch (c)
                {
                    case '^': --y; break;
                    case 'v': ++y; break;
                    case '<': --x; break;
                    case '>': ++x; break;
                }
                return this;
            }
        }

        private IDictionary<Point, int> _map;

        public Day03(Part p)
        {
            Point current = new Point(0, 0);
            Point current2 = new Point(0, 0);
            if (p == Part.Part1)
                _map = new Dictionary<Point, int> { { current, 1 } };
            else if (p == Part.Part2)
                _map = new Dictionary<Point, int> { { current, 2 } };
            string line = Console.ReadLine();
            for (int i = 0; i < line.Length; ++i)
            {
                Point actual;
                if (i % 2 == 0 || p == Part.Part1)
                    actual = current.Move(line[i]);
                else
                    actual = current2.Move(line[i]);
                if (_map.ContainsKey(actual))
                    ++_map[actual];
                else
                    _map.Add(actual, 1);
            }
            Console.WriteLine(_map.Count);
        }
    }
}
