namespace DotNetCharts.ChartElements
{
    /// <summary>
    /// Represents a graph line between two data points
    /// </summary>
    internal class StraightLine : ChartLine
    {
        public override LineType Type => LineType.Straight;
        public DataPoint EndPointPoint { get; protected set; }

        public StraightLine(DataPoint startPoint, DataPoint endPoint, DataPoint completePoint)
        {
            StartPoint = startPoint;
            EndPointPoint = endPoint;
            CompletePoint = completePoint;
        }
    }
}
