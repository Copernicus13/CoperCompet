using System;

namespace BattleDev._2016_03
{
    public class Exo5
    {
        public Exo5()
        {
            int n = int.Parse(Console.ReadLine());
            int[] list = new int[n];

            for (int i = 0; i < n; ++i)
                list[i] = int.Parse(Console.ReadLine());

            long res = 0;
            for (int i = 0; i < n; ++i)
            {
                long big = 0;
                var z = list[i];
                for (int j = i + 1; j < n; ++j)
                {
                    var k = list[j];
                    if (z == k && z > big)
                    {
                        res += j - i;
                        break;
                    }
                    big = Math.Max(big, k);
                }
            }
            Console.WriteLine(res);
        }
    }
}
