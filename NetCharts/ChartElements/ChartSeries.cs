using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NetCharts.Style;

namespace NetCharts.ChartElements
{
    public class ChartSeries
    {
        public string SeriesName { get; }
        public double?[] DataValues { get; }
        public DataPoint[] DataPoints => _dataPoints != null && _dataPoints.Any()
            ? _dataPoints
            : new DataPoint[0];

        public SeriesStyle Style { get; set; }

        public string Color { get; set; }

        private DataPoint[] _dataPoints;

        public ChartSeries(string seriesName, double?[] dataValues)
        {
            SeriesName = seriesName ?? throw new ArgumentNullException(nameof(seriesName));
            DataValues = dataValues ?? throw new ArgumentNullException(nameof(dataValues));
        }

        /// <summary>
        /// Creates dataPoints from the actual values.
        /// Null points are not permitted in the middle of 2 valid points, these will be replaced with 0
        /// </summary>
        internal void InitDataPoints(double scaleX, double scaleY, double offSetX, double offSetY)
        {
            var dataStarted = false;
            var dataList = new List<DataPoint>();
            for (var i = 0; i < DataValues.Length; i++)
            {
                if (!dataStarted && DataValues[i].HasValue)
                {
                    dataStarted = true;
                }

                if (!dataStarted) continue;

                if (!DataValues[i].HasValue)
                {
                    dataList.Add(new DataPoint(
                        (i * scaleX) + offSetX,
                        offSetY - (0 * scaleY),
                        (i + 1).ToString(),
                        "0"));

                    continue;
                }

                dataList.Add(new DataPoint(
                    (i * scaleX) + offSetX, 
                    offSetY - (DataValues[i].Value * scaleY), 
                    (i + 1).ToString(), 
                    DataValues[i].Value.ToString(CultureInfo.InvariantCulture)));
            }

            _dataPoints = dataList.ToArray();
        }
    }
}
