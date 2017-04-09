using System;
using System.Collections.Generic;

namespace GoogleCodeJam._2017.Qualification
{
    public class TidyNumbers
    {
        private IList<long> _List;

        public TidyNumbers()
        {
            _List = new List<long>();

            int T = int.Parse(Console.ReadLine());

            for (int a = 0; a <= 9; ++a)
                for (int b = a; b <= 9; ++b)
                    for (int c = b; c <= 9; ++c)
                        for (int d = c; d <= 9; ++d)
                            for (int e = d; e <= 9; ++e)
                                for (int f = e; f <= 9; ++f)
                                    for (int g = f; g <= 9; ++g)
                                        for (int h = g; h <= 9; ++h)
                                            for (int i = h; i <= 9; ++i)
                                                for (int j = i; j <= 9; ++j)
                                                    for (int k = j; k <= 9; ++k)
                                                        for (int l = k; l <= 9; ++l)
                                                            for (int m = l; m <= 9; ++m)
                                                                for (int n = m; n <= 9; ++n)
                                                                    for (int o = n; o <= 9; ++o)
                                                                        for (int p = o; p <= 9; ++p)
                                                                            for (int q = p; q <= 9; ++q)
                                                                                for (int r = q; r <= 9; ++r)
                                                                                    _List.Add(
                                                                                        a * 100000000000000000L +
                                                                                        b * 10000000000000000L +
                                                                                        c * 1000000000000000L +
                                                                                        d * 100000000000000L +
                                                                                        e * 10000000000000L +
                                                                                        f * 1000000000000L +
                                                                                        g * 100000000000L +
                                                                                        h * 10000000000L +
                                                                                        i * 1000000000L +
                                                                                        j * 100000000L +
                                                                                        k * 10000000L +
                                                                                        l * 1000000L +
                                                                                        m * 100000L +
                                                                                        n * 10000L +
                                                                                        o * 1000L +
                                                                                        p * 100L +
                                                                                        q * 10L +
                                                                                        r);

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                long number = long.Parse(Console.ReadLine());

                Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, FindTidy(number)));
            }
        }

        private long FindTidy(long number)
        {
            for (int i = _List.Count - 1; i >= 0; --i)
                if (number >= _List[i])
                    return _List[i];
            return 0;
        }
    }
}
