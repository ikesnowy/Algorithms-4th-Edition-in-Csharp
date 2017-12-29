namespace _2._1._19
{
    class ShellSortWorstCase
    {
        public static int[] GetWorst(int[] p, int n)
        {
            int l = 0;
            int?[] a = new int?[n + 1];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = null;
            }
            int P = 40;
            int PAddition = P;
            for (int i = 0; l < 100; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (a[j] == null && IsVisible(j, P))
                    {
                        l++;
                        a[j] = l;
                    }
                }
                P += PAddition;
            }

            int[] b = new int[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = (int)a[i + 1];
            }

            return b;
        }

        public static int FindP()
        {
            int r = 2;
            int s = 2;
            int a = 0;
            int b = 1;

            for (int i = 1; i < 100; i++)
            {
                if (P(i) >= r * (P(i + 1)-b) - a)
                {
                    if (P(i) <= s * (P(i + 1) + a) + b)
                    {
                        return P(i);
                    }
                }
            }

            return 0;
        }

        public static int P(int n)
        {
            int p = 1;
            for (int i = 0; i < n; i++)
            {
                p *= 3;
            }
            return (p - 1) / 2;
        }

        public static bool IsVisible(int i, int j)
        {
            int k = 0;
            while (k <= 100)
            {
                if (j - i >= k * 40 && j - i <= k * 41)
                    return true;
                k++;
            }
            return false;
        }
    }
}
