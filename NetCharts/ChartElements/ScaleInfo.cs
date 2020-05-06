namespace NetCharts.ChartElements
{
    internal class ScaleInfo
    {
        public AxisType Type { get; set; }
        public bool StartOnMajor { get; set; } = false;
        public double Scale { get; set; }
        public double Max { get; set; }
        public double MajorInterval { get; set; }
        public double MinorInterval { get; set; }
    }
}
