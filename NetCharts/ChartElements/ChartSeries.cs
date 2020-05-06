using System;
using System.Globalization;
using System.Linq;
using NetCharts.Style;

namespace NetCharts.ChartElements
{
    public class ChartSeries
    {
        public string SeriesName { get; }
        public double[] DataValues { get; }
        public DataPoint[] DataPoints => _dataPoints != null && _dataPoints.Any()
            ? _dataPoints
            : throw new InvalidOperationException("No dataPoints found, ensure that InitDataPoints has executed");
        public SeriesStyle Style { get; set; }

        public string Color { get; set; }

        private DataPoint[] _dataPoints;

        public ChartSeries(string seriesName, double[] dataValues)
        {
            SeriesName = seriesName ?? throw new ArgumentNullException(nameof(seriesName));
            DataValues = dataValues ?? throw new ArgumentNullException(nameof(dataValues));
        }

        internal void InitDataPoints(double scaleX, double scaleY, double offSetX, double offSetY)
        {
            _dataPoints = DataValues.Select((x, i) => 
                new DataPoint((i * scaleX) + offSetX, offSetY - (x * scaleY), (i + 1).ToString(), x.ToString(CultureInfo.InvariantCulture))).ToArray();
        }
    }
}
