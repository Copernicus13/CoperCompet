using System;
using System.Linq;

namespace GoogleCodeJam._2017.Qualification
{
    public class OversizedPancakeFlipper
    {
        public OversizedPancakeFlipper()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                string str = Console.ReadLine();

                string pancakes = str.Split(' ')[0];
                int K = int.Parse(str.Split(' ')[1]);

                int i = 0;
                bool b = false;
                bool c = false;
                while (pancakes.Any(a => a == '-'))
                {
                    ++i;
                    int j = pancakes.IndexOf('-');
                    if (j >= pancakes.Length - K)
                    {
                        if (b)
                        {
                            Console.WriteLine("Case #{0}: IMPOSSIBLE", nbCase);
                            c = true;
                            break;
                        }
                        b = true;
                        pancakes = Turn(pancakes, pancakes.Length - K, K);
                    }
                    else
                        pancakes = Turn(pancakes, j, K);
                }
                if (!c)
                    Console.WriteLine("Case #{0}: {1}", nbCase, i);
            }
        }

        private static string Turn(string pancakes, int startIndex, int length)
        {
            char[] tab = pancakes.ToCharArray();
            if (pancakes.Length < startIndex + length)
                return pancakes;
            for (int i = startIndex; i < startIndex + length; ++i)
                tab[i] = tab[i] == '+' ? '-' : '+';
            return new string(tab);
        }
    }
}
