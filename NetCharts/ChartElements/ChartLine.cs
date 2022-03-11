namespace DotNetCharts.ChartElements
{
    public abstract class ChartLine
    {
        public abstract LineType Type { get; }

        /// <summary>
        /// The Starting point of the line
        /// </summary>
        public DataPoint StartPoint { get; protected set; }

        /// <summary>
        /// The point to complete the data point chain.
        /// This could be the origin point or the destination point, based on the line type.
        /// </summary>
        public DataPoint CompletePoint { get; protected set; }
    }
}
