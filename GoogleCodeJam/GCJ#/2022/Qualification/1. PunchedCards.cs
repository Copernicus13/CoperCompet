using System;
using System.Linq;

namespace GoogleCodeJam._2022.Qualification
{
    public class PunchedCards
    {
        public PunchedCards()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                string line = Console.ReadLine();
                int R = int.Parse(line.Split(' ')[0]);
                int C = int.Parse(line.Split(' ')[1]);

                Console.WriteLine($"Case #{nbCase}:");
                Console.WriteLine(".." + string.Join(string.Empty, Enumerable.Repeat("+-", C - 1)) + "+");
                Console.WriteLine(".." + string.Join(string.Empty, Enumerable.Repeat("|.", C - 1)) + "|");
                for (int y = 0; y < R - 1; ++y)
                {
                    Console.WriteLine(string.Join(string.Empty, Enumerable.Repeat("+-", C)) + "+");
                    Console.WriteLine(string.Join(string.Empty, Enumerable.Repeat("|.", C)) + "|");
                }
                Console.WriteLine(string.Join(string.Empty, Enumerable.Repeat("+-", C)) + "+");
            }
        }
    }
}
