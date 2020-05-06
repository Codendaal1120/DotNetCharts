namespace NetCharts.Svg
{
    internal class ViewBox 
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public ViewBox(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{X} {Y} {Width} {Height}";
        }
    }
}