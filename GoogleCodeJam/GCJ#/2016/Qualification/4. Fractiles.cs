using System;

namespace GoogleCodeJam.Y2016.Qualification
{
    public class Fractiles
    {
        public Fractiles()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                string line = Console.ReadLine();
                int K = int.Parse(line.Split(' ')[0]);
                int C = int.Parse(line.Split(' ')[1]);
                int S = int.Parse(line.Split(' ')[2]);

                string result = string.Empty;

                for (long i = 1, j = 0; j < S; ++j)
                {
                    result += i + " ";
                    i += Convert.ToInt64(Math.Pow(K, C - 1));
                }

                Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, result.TrimEnd()));
            }
        }
    }
}
