namespace DotNetCharts.Style
{
    public class GridLineStyle
    {
        public bool Draw => MajorLineStyle.Draw || MinorLineStyle.Draw;

        public ElementStyle MajorLineStyle { get; } = new ElementStyle() { StrokeWidth = 0 };
        public ElementStyle MinorLineStyle { get; } = new ElementStyle() { StrokeWidth = 0 };
    }
}
