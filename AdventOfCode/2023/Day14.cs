using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Common;
using CoperAlgoLib.Data;

namespace AdventOfCode._2023
{
    /// <summary>
    /// https://adventofcode.com/2023/day/14
    /// </summary>
    public class Day14
    {
        // Ordered specifically for the problem
        private enum DirName { Up, Left, Down, Right };

        public Day14(Part p)
        {
            long result;
            string line;
            var map = new List<List<char>>();

            while (!string.IsNullOrEmpty(line = Console.ReadLine()!))
                map.Add(line.ToList());

            char[,] tab = map.ToJaggedArray();
            if (p == Part.Part1)
            {
                Tilt(tab, DirName.Up);
                result = CalcTotalLoad(tab);
            }
            else
            {
                var dict = new Dictionary<string, int>();
                int cptBeforeCycle = -1;
                while (!dict.ContainsKey(new string(tab.ToList().ToArray())))
                {
                    dict.Add(new string(tab.ToList().ToArray()), CalcTotalLoad(tab));
                    foreach (var direction in Enum.GetValues<DirName>())
                        Tilt(tab, direction);
                    ++cptBeforeCycle;
                }
                dict.Clear();
                int cptCycle = 0;
                while (!dict.ContainsKey(new string(tab.ToList().ToArray())))
                {
                    dict.Add(new string(tab.ToList().ToArray()), CalcTotalLoad(tab));
                    foreach (var direction in Enum.GetValues<DirName>())
                        Tilt(tab, direction);
                    ++cptCycle;
                }
                // ReSharper disable once IntDivisionByZero
                result = dict.ElementAt((1000000000 - cptBeforeCycle) % cptCycle - 1).Value;
            }
            Console.WriteLine(result);
        }

        private static int CalcTotalLoad(char[,] tab)
        {
            int result = 0;
            int coef = tab.GetLength(0);
            for (int y = 0; y < tab.GetLength(0); ++y, --coef)
                result += tab.GetRow(y).Count(c => c == 'O') * coef;
            return result;
        }

        private static void Tilt(char[,] tab, DirName direction)
        {
            int dim = direction is DirName.Up or DirName.Down ? 1 : 0;
            for (int i = 0; i < tab.GetLength(dim); ++i)
            {
                var lineResult = new StringBuilder();
                var line = new string(GetLine(tab, dim, i));
                foreach (var list in line.Split('#'))
                {
                    var nbRoundedRocks = list.Count(c => c == 'O');
                    if (direction is DirName.Up or DirName.Left)
                    {
                        lineResult.Append('O', nbRoundedRocks);
                        lineResult.Append('.', list.Length - nbRoundedRocks);
                    }
                    else
                    {
                        lineResult.Append('.', list.Length - nbRoundedRocks);
                        lineResult.Append('O', nbRoundedRocks);
                    }
                    lineResult.Append('#');
                }

                for (int j = 0; j < tab.GetLength(dim == 1 ? 0 : 1); ++j)
                    if (direction is DirName.Up or DirName.Down)
                        tab[j, i] = lineResult[j];
                    else
                        tab[i, j] = lineResult[j];
            }
        }

        private static char[] GetLine(char[,] tab, int dim, int idx) =>
            dim == 0 ? tab.GetRow(idx) : tab.GetColumn(idx);
    }
}