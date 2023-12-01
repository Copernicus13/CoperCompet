using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BattleDev._2016_11
{
    public class Exo4
    {
        public Exo4()
        {
            int N = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();

            int A = int.Parse(line.Split(' ')[0]);
            int B = int.Parse(line.Split(' ')[1]);

            double[,] t = new double[N, N];
            for (int i = 0; i < N; ++i)
            {
                line = Console.ReadLine();
                for (int j = 0; j < N; ++j)
                    t[i, j] = double.Parse(line.Split(' ')[j], CultureInfo.InvariantCulture);
            }

            var p = new List<double>();
            for (int i = 0; i < N; ++i)
            {
                double tmp = 1d;
                for (int j = A; j <= B; ++j)
                    tmp *= 1 - t[i, j];
                p.Add(1 - tmp);
            }

            //double tmp = 1d;
            //for (int j = 0; j <= B; ++j)
            //    tmp *= 1 - t[1, j];

            var res = p.OrderBy(o => o).ToList().First();

            //var res = 1 - tmp;

            Console.WriteLine(res.ToString().Replace(',', '.'));
        }
    }
}
