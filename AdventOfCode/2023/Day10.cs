using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;
using CoperAlgoLib.Data;
using CoperAlgoLib.Geometry;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/10
    /// </summary>
    public class Day10
    {
        private readonly Point[] _dir = { new(-1, 0), new(0, -1), new(1, 0), new(0, 1) };
        private enum DirName { Left, Up, Right, Down, Special };

        private struct Position
        {
            public Point Pos;
            public DirName DirName;
            public int Distance;
        }

        private static readonly char[] SourceArray = { '─', '│', '┌', '┐', '└', '┘', 'S' };

        /// <remarks>Adjust line 123 to start correctly</remarks>
        public Day10(Part p)
        {
            int result = 0;
            string line = Console.ReadLine()!;
            char[,] tab = new char[line.Length, line.Length];
            for (var x = 0; x < line.Length; ++x)
                tab[0, x] = line[x];
            for (int y = 1; !string.IsNullOrEmpty(line = Console.ReadLine()!); ++y)
                for (var x = 0; x < line.Length; ++x)
                    tab[y, x] = line[x];

            var indexStart = tab.ToList().IndexOf('S');
            var currentPos =
                new Position
                {
                    Pos = new Point(indexStart % tab.GetLength(1), indexStart / tab.GetLength(1)),
                    DirName = DirName.Special,
                    Distance = 0
                };

            char currentChar = char.MinValue;
            while (currentChar != 'S')
            {
                currentPos.DirName = NextDir(currentPos.DirName, currentChar);
                ++currentPos.Distance;
                currentPos.Pos = new Point(
                    currentPos.Pos.X + _dir[(int)currentPos.DirName].X,
                    currentPos.Pos.Y + _dir[(int)currentPos.DirName].Y);
                currentChar = tab[currentPos.Pos.Y, currentPos.Pos.X];
                tab[currentPos.Pos.Y, currentPos.Pos.X] = PrettyPrint(currentChar); // for part 2
            }

            if (p == Part.Part1)
                result = currentPos.Distance / 2;
            else if (p == Part.Part2)
            {
                for (int y = 0; y < tab.GetLength(0); ++y)
                    for (var x = 0; x < tab.GetLength(1); ++x)
                        if (!SourceArray.Contains(tab[y, x]))
                            tab[y, x] = ' ';

                // Expand map by factor 2
                char[,] tab2 = new char[tab.GetLength(0) * 2, tab.GetLength(1) * 2];
                for (int y = 0; y < tab.GetLength(0); ++y)
                    for (int x = 0; x < tab.GetLength(1); ++x)
                    {
                        tab2[2 * y, 2 * x] = tab[y, x];
                        tab2[2 * y, 2 * x + 1] = ExtendChar(DirName.Right, tab[y, x]);
                        tab2[2 * y + 1, 2 * x] = ExtendChar(DirName.Down, tab[y, x]);
                        tab2[2 * y + 1, 2 * x + 1] = ExtendChar(DirName.Special, tab[y, x]);
                    }

                Fill(tab2, 0, 0);
                Fill(tab2, 0, tab2.GetLength(0) - 1);
                Fill(tab2, tab2.GetLength(1) - 1, 0);
                Fill(tab2, tab2.GetLength(1) - 1, tab2.GetLength(0) - 1);

                // Shrink map by 2
                for (int y = 0; y < tab.GetLength(0); ++y)
                    for (var x = 0; x < tab.GetLength(1); ++x)
                        tab[y, x] = tab2[y * 2, x * 2];

                result = tab.ToList().Count(c => c == ' ');
            }
            Console.WriteLine(result);
        }

        private void Fill(char[,] tab, int x, int y)
        {
            var queue = new Queue<Point>();
            queue.Enqueue(new Point(x, y));
            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                if (tab[p.Y, p.X] != ' ')
                    continue;
                tab[p.Y, p.X] = 'x';
                foreach (var dir in _dir)
                {
                    var curX = p.X + dir.X;
                    var curY = p.Y + dir.Y;
                    if (curX >= 0 && curX < tab.GetLength(1) &&
                        curY >= 0 && curY < tab.GetLength(0) &&
                        tab[curY, curX] == ' ')
                    {
                        queue.Enqueue(new Point(curX, curY));
                    }
                }
            }
        }

        private static DirName NextDir(DirName currentDir, char currentChar) =>
            (currentDir, currentChar) switch
            {
                // Start is manually adjusted for my input
                (DirName.Special, char.MinValue) => DirName.Down,

                (DirName.Left, '-') => DirName.Left,
                (DirName.Left, 'L') => DirName.Up,
                (DirName.Left, 'F') => DirName.Down,
                (DirName.Up, '|') => DirName.Up,
                (DirName.Up, '7') => DirName.Left,
                (DirName.Up, 'F') => DirName.Right,
                (DirName.Right, '-') => DirName.Right,
                (DirName.Right, 'J') => DirName.Up,
                (DirName.Right, '7') => DirName.Down,
                (DirName.Down, '|') => DirName.Down,
                (DirName.Down, 'J') => DirName.Left,
                (DirName.Down, 'L') => DirName.Right,
                _ => throw new Exception("Invalid input")
            };

        private static char ExtendChar(DirName currentDir, char currentChar) =>
            (currentDir, currentChar) switch
            {
                (DirName.Special, 'S') => 'S',
                (DirName.Right, 'S') => 'S',
                (DirName.Right, '─') => '─',
                (DirName.Right, '┌') => '─',
                (DirName.Right, '└') => '─',
                (DirName.Down, 'S') => 'S',
                (DirName.Down, '┌') => '│',
                (DirName.Down, '│') => '│',
                (DirName.Down, '┐') => '│',
                _ => ' '
            };

        private static char PrettyPrint(char currentChar) =>
            currentChar switch
            {
                'S' => 'S',
                '-' => '─',
                'L' => '└',
                'F' => '┌',
                '|' => '│',
                '7' => '┐',
                'J' => '┘',
                _ => throw new Exception("Invalid input")
            };
    }
}