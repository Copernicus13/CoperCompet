using System;

namespace BattleDev._2014_11
{
    public class Exo4
    {
        public Exo4()
        {
            string line = Console.ReadLine();
            int M = int.Parse(line.Split(' ')[0]);
            int N = int.Parse(line.Split(' ')[1]);

            char[,] map = new char[M, N];
            int[,] poids = new int[M, N];

            for (int i = 0; i < M; ++i)
            {
                line = Console.ReadLine();
                for (int j = 0; j < N; ++j)
                {
                    map[i, j] = line[j];
                    poids[i, j] = line[j] == '#' ? 42 : int.MaxValue;
                }
            }

            int nbBrickToBreak = 0;

            if (map[1, 1] == '#')
                ++nbBrickToBreak;
            if (map[M - 2, N - 2] == '#')
                ++nbBrickToBreak;

            int a = M - 2;
            int b = N - 2;
            FloodFill(map, poids, nbBrickToBreak, a, b, M, N);
            poids.PrintMap();

            Console.WriteLine(poids[1, 1]);
        }

        private void FloodFill(char[,] map, int[,] listePoids, int poids, int x, int y, int width, int height)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
                return;
            if (map[x, y] == '#')
            {
                FloodFill(map, listePoids, poids + 1, x - 1, y, width, height);
                FloodFill(map, listePoids, poids + 1, x, y - 1, width, height);
                return;
            }
            if (listePoids[x, y] <= poids)
                return;
            listePoids[x, y] = poids;
            FloodFill(map, listePoids, poids, x - 1, y, width, height);
            FloodFill(map, listePoids, poids, x + 1, y, width, height);
            FloodFill(map, listePoids, poids, x, y - 1, width, height);
            FloodFill(map, listePoids, poids, x, y + 1, width, height);
        }
    }

    public static class ExtensionExo4
    {
        public static void PrintMap(this int[,] map)
        {
            var width = map.GetLength(0);
            var height = map.GetLength(1);
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                    Console.Write(map[i, j] == int.MaxValue || map[i, j] == 42 ? 9 : map[i, j]);
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        }
    }
}
