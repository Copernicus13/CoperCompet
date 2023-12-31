﻿using System;
using System.Linq;

namespace GoogleCodeJam._2016.Round1a
{
    public class TheLastWord
    {
        public TheLastWord()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                string str = Console.ReadLine();
                string res = string.Empty;

                foreach (char c in str)
                    if (c < res.FirstOrDefault())
                        res += c;
                    else
                        res = c + res;

                Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, res));
            }
        }
    }
}
