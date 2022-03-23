namespace DotNetCharts.Style
{
    public class CircleStyle : ElementStyle
    {
    }

    public class MarkerStyle : CircleStyle
    {
        public double Radius { get; set; } = 2;
    }
}
