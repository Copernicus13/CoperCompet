using System;

namespace GoogleCodeJam._2016.Qualification
{
    public class CoinJam
    {
        public CoinJam()
        {
            int N = 16;
            int J = 50;

            Console.WriteLine("Case #1:");

            for (int result = (1 << N - 1) + 1; result < 1 << N; result += 2)
            {
                bool ok = true;
                for (int i = 2; i <= 10; ++i)
                    ok &= !isPrime(toBase(result, i));
                if (ok)
                {
                    Console.WriteLine(string.Format("{0} {1}", Convert.ToString(result, 2), divisorsOf(result)));
                    if (--J < 0)
                        break;
                }
            }
        }

        private static bool isPrime(long value)
        {
            if (value <= 1)
                return false;
            else if (value <= 3)
                return true;
            else if (value % 2 == 0 || value % 3 == 0)
                return false;
            long i = 5;
            while (i * i <= value)
            {
                if (value % i == 0 || value % (i + 2) == 0)
                    return false;
                i += 6;
            }
            return true;
        }

        private static long toBase(int value, int targetBase)
        {
            string str = Convert.ToString(value, 2);
            long result = 0;
            int idx = str.Length;
            foreach (var c in str)
            {
                --idx;
                if (c == '1')
                    result += Convert.ToInt64(Math.Pow(targetBase, idx));
            }

            return result;
        }

        private static string divisorsOf(int value)
        {
            string result = string.Empty;
            for (int i = 2; i <= 10; ++i)
            {
                long number = toBase(value, i), div = 2;
                while (number % div != 0)
                    ++div;
                if (string.IsNullOrEmpty(result))
                    result += div;
                else
                    result += " " + div;
            }
            return result;
        }
    }
}
