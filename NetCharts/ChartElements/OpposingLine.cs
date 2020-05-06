namespace NetCharts.ChartElements
{
    internal class OpposingLine
    {
        public double Length { get; }
        public double Angle { get; }

        public OpposingLine(double length, double angle)
        {
            Length = length;
            Angle = angle;
        }
    }
}
