using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam._2016.Qualification
{
    public class CountingSheep
    {
        public CountingSheep()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                long N = long.Parse(Console.ReadLine());

                if (N == 0)
                    Console.WriteLine(string.Format("Case #{0}: INSOMNIA", nbCase));
                else
                {
                    int i = 1;
                    long tmp = N;
                    IList<bool> digits = Enumerable.Repeat(false, 10).ToList();
                    CountDigits(digits, tmp);
                    while (!digits.All(a => a))
                    {
                        tmp = N * ++i;
                        CountDigits(digits, tmp);
                    }
                    Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, tmp));
                }
            }
        }

        private void CountDigits(IList<bool> digits, long N)
        {
            string s = N.ToString();
            foreach (char c in s)
            {
                int a = c - '0';
                digits[a] = true;
            }
        }
    }
}
