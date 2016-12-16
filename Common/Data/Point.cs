namespace AdventOfCode.Common.Data
{
    public struct Point<T>
    {
        public T x;
        public T y;

        public Point(T x, T y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct Point // Derivation from Point<int> not allowed for struct
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}