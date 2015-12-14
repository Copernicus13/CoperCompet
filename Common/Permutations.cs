using System;

namespace AdventOfCode.Common
{
    public static class Permutations
    {
        public static bool GetNext(int[] perm)
        {
            int n = perm.Length;
            int k = -1;

            for (int i = 1; i < n; ++i)
                if (perm[i - 1] < perm[i])
                    k = i - 1;

            if (k == -1)
            {
                Array.Reverse(perm);
                return false;
            }

            int l = k + 1;
            for (int i = l; i < n; ++i)
                if (perm[k] < perm[i])
                    l = i;

            Utils.Swap(ref perm[k], ref perm[l]);

            Array.Reverse(perm, k + 1, perm.Length - (k + 1));
            return true;
        }
    }
}
