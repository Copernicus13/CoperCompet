using System;

namespace GoogleCodeJam._2017.Qualification
{
    public class FashionShow
    {
        public FashionShow()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                string line = Console.ReadLine();
                int K = int.Parse(line.Split(' ')[0]);
                int C = int.Parse(line.Split(' ')[1]);
                int S = int.Parse(line.Split(' ')[2]);

                Console.WriteLine("Case #{0}: {1}", nbCase, 0);
            }
        }
    }
}
