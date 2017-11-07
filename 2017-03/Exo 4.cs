using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleDev._2017_03
{
    public class Exo4
    {
        public Exo4()
        {
            int N = int.Parse(Console.ReadLine());
            char[] me = Console.ReadLine().ToCharArray();
            int M = int.Parse(Console.ReadLine());
            char[] him = Console.ReadLine().ToCharArray();

            me = string.Concat(me.OrderBy(c => c)).ToCharArray();
            char best = ' ';
            IList<char> best2 = new List<char>();
            while (GetNext(me))
            {
                if (Game(me, him) == '+')
                    break;
                if (Game(me, him) == '=')
                {
                    best = '=';
                    best2 = me.ToList();
                }
            }
            if (best == '=')
                Console.WriteLine(best + " " + string.Concat(best2));
            else
                Console.WriteLine(best + " " + me);
        }

        private char Game(char[] me, char[] him)
        {
            char res = ' ';
            int i = 0;
            int j = 0;
            while (i < me.Length && j < him.Length)
            {
                if (Gagne(me[i], him[j]) == 0)
                    ;
            }
            return res;
        }

        private int Gagne(char c1, char c2)
        {
            if (c1 == c2)
                return 0;
            if (c1 == 'E' && c2 == 'F')
                return 1;
            if (c1 == 'F' && c2 == 'P')
                return 1;
            if (c1 == 'P' && c2 == 'E')
                return 1;
            return -1;
        }

        public static bool GetNext(char[] perm)
        {
            int n = perm.Length;
            int k = -1;

            for (int i = 1; i < n; ++i)
                if (perm[i - 1].CompareTo(perm[i]) < 0)
                    k = i - 1;

            if (k == -1)
            {
                Array.Reverse(perm);
                return false;
            }

            int l = k + 1;
            for (int i = l; i < n; ++i)
                if (perm[k].CompareTo(perm[i]) < 0)
                    l = i;

            var io = perm[k];
            perm[k] = perm[l];
            perm[l] = io;

            Array.Reverse(perm, k + 1, perm.Length - (k + 1));
            return true;
        }

        public static bool GetNext(ref string perm)
        {
            char[] charArray = perm.ToCharArray();
            var result = GetNext(charArray);
            perm = new string(charArray);
            return result;
        }
    }
}
