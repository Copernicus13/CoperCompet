using System;

namespace GoogleCodeJam.Y2016.Qualification
{
    public class RevengeOfThePancakes
    {
        public RevengeOfThePancakes()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                string str = Console.ReadLine();

                int result = 0;
                for (int i = str.Length - 1; i >= 0; --i)
                {
                    if (result % 2 == 0)
                    {
                        if (str[i] == '-')
                            ++result;
                    }
                    else
                    {
                        if (str[i] == '+')
                            ++result;
                    }
                }

                Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, result));
            }
        }
    }
}
