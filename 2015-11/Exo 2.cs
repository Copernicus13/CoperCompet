using System;

namespace BattleDev._2015_11
{
    public class Exo2
    {
        public Exo2()
        {
            string line = Console.ReadLine();
            float T = int.Parse(line.Split(' ')[0]);
            float D = int.Parse(line.Split(' ')[1]);
            float res = 100f;

            for (int i = 0; i < D; ++i)
            {
                res += res * (T / 100f);
            }

            Console.WriteLine(Math.Round(res - 100f, 2));
        }
    }
}
