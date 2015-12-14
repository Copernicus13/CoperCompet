using System;

namespace AdventOfCode.Common
{
    public static class Permutations
    {
        public static bool GetNext<T>(T[] perm) where T : IComparable
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

            Utils.Swap(ref perm[k], ref perm[l]);

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
