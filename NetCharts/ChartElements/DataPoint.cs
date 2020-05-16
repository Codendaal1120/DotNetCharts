using System;

namespace NetCharts.ChartElements
{
    /// <summary>
    /// Represents a data point on a chart
    /// </summary>
    public class DataPoint
    {
        public string XValue { get; }
        public string YValue { get; }
        public double X { get; }
        public double Y { get; }

        public DataPoint(double x, double y, string xValue = null, string yValue = null)
        {
            X = Math.Round(x, 2);
            Y = Math.Round(y, 2);
            YValue = yValue;
            XValue = xValue;
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
