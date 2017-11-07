namespace CoperAlgoLib.Geometry
{
    public struct Rectangle
    {
        public static readonly Rectangle Empty = new Rectangle(default(int), default(int), default(int), default(int));

        #region Fields

        private Point _Origin;
        private Size _Size;

        #endregion

        #region Properties

        public int X
        {
            get { return _Origin.X; }
            set { _Origin.X = value; }
        }

        public int Y
        {
            get { return _Origin.Y; }
            set { _Origin.Y = value; }
        }

        public int Width
        {
            get { return _Size.Width; }
            set { _Size.Width = value; }
        }

        public int Height
        {
            get { return _Size.Height; }
            set { _Size.Height = value; }
        }

        public int X1 { get { return X; } }

        public int Y1 { get { return Y; } }

        public int X2 { get { return X + Width; } }

        public int Y2 { get { return Y + Height; } }

        #endregion

        public Rectangle(Point location, Size size)
        {
            _Origin = location;
            _Size = size;
        }

        public Rectangle(int x, int y, int width, int height)
        {
            _Origin = new Point(x, y);
            _Size = new Size(width, height);
        }

        public static Rectangle FromLTRB(int x1, int y1, int x2, int y2)
        {
            return new Rectangle(new Point(x1, y1), new Size(x2 - x1, y2 - y1));
        }

        public bool ContainsIncludingEdge(Point point)
        {
            return X1 <= point.X && X2 >= point.X && Y1 <= point.Y && Y2 >= point.Y;
        }
    }
}
