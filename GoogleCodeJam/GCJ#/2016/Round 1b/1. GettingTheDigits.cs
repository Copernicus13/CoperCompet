using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam._2016.Round1b
{
    public class GettingTheDigits
    {
        private IList<string> lol = new List<string>
            {
                "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE"
            };

        private IDictionary<char, int> dict = new Dictionary<char, int>();

        public GettingTheDigits()
        {
            int T = int.Parse(Console.ReadLine());

            for (int nbCase = 1; nbCase <= T; ++nbCase)
            {
                int[] nbApp = new int[10];
                string str = Console.ReadLine();
                string res = string.Empty;

                dict.Clear();
                for (char c = 'A'; c <= 'Z'; ++c)
                    dict.Add(c, 0);

                foreach (char c in str)
                    ++dict[c];

                nbApp[0] = dict['Z'];
                nbApp[2] = dict['W'];
                nbApp[6] = dict['X'];
                nbApp[8] = dict['G'];
                RemoveLetters(dict, 0, nbApp[0]);
                RemoveLetters(dict, 2, nbApp[2]);
                RemoveLetters(dict, 6, nbApp[6]);
                RemoveLetters(dict, 8, nbApp[8]);
                nbApp[3] = dict['H'];
                RemoveLetters(dict, 3, nbApp[3]);
                nbApp[7] = dict['S'];
                RemoveLetters(dict, 7, nbApp[7]);
                nbApp[5] = dict['V'];
                RemoveLetters(dict, 5, nbApp[5]);
                nbApp[4] = dict['F'];
                RemoveLetters(dict, 4, nbApp[4]);
                nbApp[9] = dict['I'];
                RemoveLetters(dict, 9, nbApp[9]);
                nbApp[1] = dict['N'];
                RemoveLetters(dict, 1, nbApp[1]);

                for (char c = '0'; c <= '9'; ++c)
                    res += string.Join(string.Empty, Enumerable.Repeat(c, nbApp[c - '0']));

                Console.WriteLine(string.Format("Case #{0}: {1}", nbCase, res));
            }
        }

        private void RemoveLetters(IDictionary<char, int> dict, int v, int w)
        {
            foreach (char c in lol[v])
                dict[c] -= w;
        }
    }
}
