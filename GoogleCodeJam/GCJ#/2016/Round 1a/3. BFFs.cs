using System;
using System.Collections.Generic;

namespace GoogleCodeJam._2016.Round1a
{
    public class BFFs
    {
        public BFFs()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                int N = int.Parse(Console.ReadLine());

                string s = Console.ReadLine();
                //IList<int> list = new List<int>();
                int[] a = new int[1500];
                int[] v = new int[1500];
                int[] d = new int[1500];

                for (int i = 0; i < N; ++i)
                    a[i] = int.Parse(s.Split(' ')[i]);
                    //list.Add(int.Parse(s.Split(' ')[i]));

                int ans = 0;
                int j = 0;
                for (int i = 1; i < N; ++i)
                {
                    for (j = 1; j < N; ++j)
                        v[j] = 0;
                    int k = 0;
                    j = i;
                    while (true)
                    {
                        v[j] = 1;
                        j = a[j];
                        ++k;
                        if (v[j] != 0)
                            break;
                    }
                    if (j == i)
                        ans = Math.Max(ans, k);
                }
                for (j = 1; j < N; ++j)
                    v[j] = d[j] = 0;
                for (j = 1; j < N; ++j)
                    for (int i = 1; i < N; ++i)
                        if (a[a[i]] != i)
                            d[a[i]] = Math.Max(d[a[i]], d[i] + 1);

                int ans2 = 0;
                for (int i = 1; i < N; ++i)
                    if (v[i] == 0 && a[a[i]] == i)
                    {
                        ans2 += 2 + d[i] + d[a[i]];
                        v[i] = v[a[i]] = 1;
                    }
                ans = Math.Max(ans, ans2);
                Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, ans));
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
