using System;

namespace BattleDev._2016_11
{
    public class Exo2
    {
        public Exo2()
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N / 2; ++i)
            {
                string line = new string('.', N);
                for (int j = 0; j < N / 2 - i; ++j)
                {
                    Console.Write('.');
                }
                Console.Write(new string('*', i * 2 + 1));
                for (int j = N / 2 + i + 1; j < N; ++j)
                {
                    Console.Write('.');
                }
                Console.WriteLine();
            }
            for (int i = N / 2; i >= 0; --i)
            {
                string line = new string('.', N);
                for (int j = 0; j < N / 2 - i; ++j)
                {
                    Console.Write('.');
                }
                Console.Write(new string('*', i * 2 + 1));
                for (int j = N / 2 + i + 1; j < N; ++j)
                {
                    Console.Write('.');
                }
                Console.WriteLine();
            }
        }
    }
}
