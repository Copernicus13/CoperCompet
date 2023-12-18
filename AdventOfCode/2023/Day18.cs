using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Data;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/18
    /// </summary>
    public class Day18
    {
        private const int MapWidth = 1000;
        private const int MapHeight = 1000;

        private readonly Point[] _dirTab = { new(1, 0), new(0, 1), new(-1, 0), new(0, -1) };
        public enum DirName { R, D, L, U };

        public struct Point
        {
            public long X;
            public long Y;

            public Point(long x, long y)
            {
                X = x;
                Y = y;
            }
        }

        public record Data(char Dir, int nbMeter, Color Color);

        /// <remarks>For part1, adjust line 72 to fill correctly</remarks>
        public Day18(Part p)
        {
            string line;
            var map = new List<List<char>>();
            var instr = new List<string>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                instr.Add(line);

            char[,] tab = new char[MapHeight, MapWidth];
            for (int y = 0; y < MapHeight; ++y)
                for (int x = 0; x < MapWidth; ++x)
                    tab[y, x] = '.';

            if (p == Part.Part1)
            {
                var pt = new Point(MapWidth >> 1, MapHeight >> 1);
                long minX = MapWidth, maxX = 0, minY = MapHeight, maxY = 0;
                foreach (string ins in instr)
                {
                    var dir = (DirName)Enum.Parse(typeof(DirName), ins.Split(' ')[0]);
                    int length = int.Parse(ins.Split(' ')[1]);
                    tab[pt.Y, pt.X] = '#';
                    for (int i = 0; i < length; ++i)
                    {
                        pt.X += _dirTab[(int)dir].X;
                        pt.Y += _dirTab[(int)dir].Y;
                        tab[pt.Y, pt.X] = '#';
                        minX = Math.Min(minX, pt.X);
                        maxX = Math.Max(maxX, pt.X);
                        minY = Math.Min(minY, pt.Y);
                        maxY = Math.Max(maxY, pt.Y);
                    }
                }
                // Filling coordinate is manually adjusted for my input
                Fill(tab, minX + 334, minY + 1);
                Console.WriteLine(tab.ToList().Count(c => c == '#'));
            }
            else
            {
                var pt = new Point(0, 0);
                long perimeter = 0;
                var d = new List<Point> { pt };
                foreach (string ins in instr)
                {
                    var j = ins.Split('#')[1].TrimEnd(')');
                    var dir = (DirName)Enum.Parse(typeof(DirName), j[5..]);
                    int length = int.Parse(j[..5], NumberStyles.HexNumber);
                    perimeter += length;
                    d.Add(
                        new Point(d.Last().X + _dirTab[(int)dir].X * length,
                            d.Last().Y + _dirTab[(int)dir].Y * length));
                }
                Console.WriteLine(ShoeLace(d) + perimeter / 2 + 1);
            }
        }

        private long ShoeLace(List<Point> points)
        {
            checked
            {
                long result = 0;
                for (var i = 1; i < points.Count; ++i)
                    result += points[i - 1].X * points[i].Y - points[i].X * points[i - 1].Y;
                result += points.Last().X * points.First().Y - points.First().X * points.Last().Y;
                return result / 2;
            }
        }

        private void Fill(char[,] tab, long x, long y)
        {
            var queue = new Queue<Point>();
            queue.Enqueue(new Point(x, y));
            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                if (tab[p.Y, p.X] != '.')
                    continue;
                tab[p.Y, p.X] = '#';
                foreach (var dir in _dirTab)
                {
                    var curX = p.X + dir.X;
                    var curY = p.Y + dir.Y;
                    if (curX >= 0 && curX < tab.GetLength(1) &&
                        curY >= 0 && curY < tab.GetLength(0) &&
                        tab[curY, curX] == '.')
                    {
                        queue.Enqueue(new Point(curX, curY));
                    }
                }
            }
        }
    }
}