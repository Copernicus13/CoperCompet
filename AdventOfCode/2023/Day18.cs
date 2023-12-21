using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Data;
using CoperAlgoLib.Geometry;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/18
    /// </summary>
    public class Day18
    {
        private const int MapWidth = 1000;
        private const int MapHeight = 1000;

        // Ordered specifically for the problem
        private readonly PointL[] _dirTab = { new(1, 0), new(0, 1), new(-1, 0), new(0, -1) };
        public enum DirName { R, D, L, U };

        /// <remarks>For part1, adjust line 57 to fill correctly</remarks>
        public Day18(Part p)
        {
            long result = 0;
            string line;
            var instr = new List<string>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                instr.Add(line);

            char[,] tab = new char[MapHeight, MapWidth];
            for (int y = 0; y < MapHeight; ++y)
                for (int x = 0; x < MapWidth; ++x)
                    tab[y, x] = '.';

            if (p == Part.Part1)
            {
                var pt = new PointL(MapWidth >> 1, MapHeight >> 1);
                long minX = MapWidth, minY = MapHeight;
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
                        minY = Math.Min(minY, pt.Y);
                    }
                }
                // Filling coordinate is manually adjusted for my input
                Fill(tab, minX + 334, minY + 1);
                result = tab.ToList().Count(c => c == '#');
            }
            else if (p == Part.Part2)
            {
                var startPoint = new PointL(0, 0);
                long perimeter = 0;
                var vertices = new List<PointL> { startPoint };
                foreach (string ins in instr)
                {
                    string code = ins.Split('#')[1].TrimEnd(')');
                    var dir = (DirName)Enum.Parse(typeof(DirName), code[5..]);
                    int length = int.Parse(code[..5], NumberStyles.HexNumber);
                    perimeter += length;
                    vertices.Add(
                        new PointL(vertices.Last().X + _dirTab[(int)dir].X * length,
                            vertices.Last().Y + _dirTab[(int)dir].Y * length));
                }
                result = ShoeLace(vertices) + perimeter / 2 + 1;
            }
            Console.WriteLine(result);
        }

        private static long ShoeLace(List<PointL> points)
        {
            checked
            {
                long result = 0;
                for (int i = 1; i < points.Count; ++i)
                    result += points[i - 1].X * points[i].Y - points[i].X * points[i - 1].Y;
                result += points.Last().X * points.First().Y - points.First().X * points.Last().Y;
                return result / 2;
            }
        }

        private void Fill(char[,] tab, long x, long y)
        {
            var queue = new Queue<PointL>();
            queue.Enqueue(new PointL(x, y));
            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                if (tab[p.Y, p.X] != '.')
                    continue;
                tab[p.Y, p.X] = '#';
                foreach (var dir in _dirTab)
                {
                    long curX = p.X + dir.X;
                    long curY = p.Y + dir.Y;
                    if (curX >= 0 && curX < tab.GetLength(1) &&
                        curY >= 0 && curY < tab.GetLength(0) &&
                        tab[curY, curX] == '.')
                    {
                        queue.Enqueue(new PointL(curX, curY));
                    }
                }
            }
        }
    }
}