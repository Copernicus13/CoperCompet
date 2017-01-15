using System;

namespace AdventOfCode._2015
{
    /// <summary>
    /// http://adventofcode.com/2015/day/18
    /// </summary>
    public class Day18
    {
        private const int N = 100;

        public Day18(Part p)
        {
            bool[,] list = new bool[N, N];
            string line;
            int i = 0;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                for (int j = 0; j < line.Length; ++j)
                    list[i, j] = line[j] == '#';
                ++i;
            }

            int result = 0;
            for (int a = 0; a < 100; ++a)
            {
                result = 0;
                if (p == Part.Part2)
                    list[0, 0] = list[N - 1, 0] = list[0, N - 1] = list[N - 1, N - 1] = true;
                bool[,] copy = new bool[N, N];
                Array.Copy(list, copy, N * N);
                for (i = 0; i < N; ++i)
                    for (int j = 0; j < N; ++j)
                    {
                        list[i, j] = GetLightStatus(copy, i, j);
                        if (list[i, j])
                            ++result;
                    }
            }
            if (p == Part.Part2)
            {
                if (!list[0, 0])
                    ++result;
                if (!list[N - 1, 0])
                    ++result;
                if (!list[0, N - 1])
                    ++result;
                if (!list[N - 1, N - 1])
                    ++result;
            }

            Console.WriteLine(result);
        }

        private bool GetLightStatus(bool[,] list, int x, int y)
        {
            int countOn = 0;
            for (int i = -1; i <= 1; ++i)
            {
                if (x + i < 0 || x + i > N - 1)
                    continue;
                for (int j = -1; j <= 1; ++j)
                {
                    if (y + j < 0 || y + j > N - 1 || i == 0 && j == 0)
                        continue;
                    if (list[x + i, y + j])
                        ++countOn;
                }
            }
            return countOn == 3 || list[x, y] && countOn == 2;
        }
    }
}