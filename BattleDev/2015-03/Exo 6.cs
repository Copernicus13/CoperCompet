using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDev._2015_03
{
    public class Exo6
    {
        public Exo6()
        {
            string line = Console.ReadLine();
            int M = int.Parse(line.Split(' ')[0]);
            int N = int.Parse(line.Split(' ')[1]);

            char[,] map = new char[M, N];

            for (int i = 0; i < M; ++i)
            {
                line = Console.ReadLine();
                for (int j = 0; j < N; ++j)
                    map[i, j] = line[j];
            }

            int longest = 0;

            for (int a = 1; a <= Math.Min(M, N); ++a)
            {
                bool found = false;
                for (int i = 0; i <= M - a; ++i)
                {
                    for (int j = 0; j <= N - a; ++j)
                        if (map.GetSubMap(i, j, a, a).ToList().All(all => all == '#'))
                        {
                            found = true;
                            longest = a;
                        }
                    if (found)
                        break;
                }
                if (!found)
                    break;
            }

            Console.WriteLine(longest);
        }
    }

    public static class Extension
    {
        public static char[,] GetSubMap(this char[,] map, int x, int y, int width, int height)
        {
            char[,] subMap = new char[width, height];
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    subMap[i, j] = map[x + i, y + j];
            return subMap;
        }

        public static List<char> ToList(this char[,] map, bool rowFirst = true)
        {
            var width = map.GetLength(0);
            var height = map.GetLength(1);
            var result = new List<char>();
            if (rowFirst)
                for (int i = 0; i < width; ++i)
                    for (int j = 0; j < height; ++j)
                        result.Add(map[i, j]);
            else
                for (int j = 0; j < height; ++j)
                    for (int i = 0; i < width; ++i)
                        result.Add(map[i, j]);
            return result;
        }
    }
}
