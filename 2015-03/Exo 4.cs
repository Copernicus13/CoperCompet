using System;

namespace BattleDev._2015_03
{
    public class Exo4
    {
        public Exo4()
        {
            string line = Console.ReadLine();
            int M = int.Parse(line.Split(' ')[0]);
            int N = int.Parse(line.Split(' ')[1]);
            int P = int.Parse(line.Split(' ')[2]);

            char[,] map = new char[M, N];

            int nbHit = 0;
            int nbSunk = 0;

            for (int i = 0; i < M; ++i)
            {
                line = Console.ReadLine();
                for (int j = 0; j < N; ++j)
                    map[i, j] = line[j] == '#' ? 'B' : ' ';
            }

            for (int i = 0; i < P; ++i)
            {
                line = Console.ReadLine();
                int x = int.Parse(line.Split(' ')[0]);
                int y = int.Parse(line.Split(' ')[1]);

                if (map[x, y] == 'B')
                {
                    map[x, y] = 'H';
                    if (!LookFor('B', map, x, y, M, N))
                    {
                        ++nbSunk;
                        if (Get(map, x - 1, y, M, N) == 'H' || Get(map, x + 1, y, M, N) == 'H' ||
                            Get(map, x, y - 1, M, N) == 'H' || Get(map, x, y + 1, M, N) == 'H')
                            --nbHit;
                    }
                    else if (!LookFor('H', map, x, y, M, N))
                        ++nbHit;
                }
            }
            Console.WriteLine($"{nbSunk} {nbHit}");
        }

        private bool LookFor(char c, char[,] map, int x, int y, int M, int N)
        {
            for (int i = 1; i < M; ++i)
            {
                if (Get(map, x - i, y, M, N) == ' ')
                    break;
                if (Get(map, x - i, y, M, N) == c)
                    return true;
            }
            for (int i = 1; i < M; ++i)
            {
                if (Get(map, x + i, y, M, N) == ' ')
                    break;
                if (Get(map, x + i, y, M, N) == c)
                    return true;
            }
            for (int i = 1; i < N; ++i)
            {
                if (Get(map, x, y - i, M, N) == ' ')
                    break;
                if (Get(map, x, y - i, M, N) == c)
                    return true;
            }
            for (int i = 1; i < N; ++i)
            {
                if (Get(map, x, y + i, M, N) == ' ')
                    break;
                if (Get(map, x, y + i, M, N) == c)
                    return true;
            }
            return false;
        }

        private char Get(char[,] map, int x, int y, int M, int N)
        {
            if (x >= 0 && x < M && y >= 0 && y < N)
                return map[x, y];
            return ' ';
        }
    }
}
