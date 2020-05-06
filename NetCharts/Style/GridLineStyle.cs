namespace NetCharts.Style
{
    public class GridLineStyle
    {
        public bool Draw => MajorLineStyle.Draw || MinorLineStyle.Draw;

        public PathStyle MajorLineStyle { get; } = new PathStyle() { StrokeWidth = 0 };
        public PathStyle MinorLineStyle { get; } = new PathStyle() { StrokeWidth = 0 };
    }
}
