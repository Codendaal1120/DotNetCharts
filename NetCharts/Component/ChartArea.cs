using System;
using System.Collections.Generic;
using System.Linq;
using NetCharts.ChartElements;
using NetCharts.Style;
using NetCharts.Svg;

namespace NetCharts.Component
{
    public abstract class ChartArea
    {
        public double TopLeftX { get; private set; }
        public double TopLeftY { get; private set; }
        public double BottomRightX { get; private set; }
        public double BottomRightY { get; private set; }
        public double Width => BottomRightX - TopLeftX;
        public double Height => BottomRightY - TopLeftY;
        /// <summary>
        /// ChartAreaStyle for the chart area, not the contents (series)
        /// </summary>
        public ElementStyle ChartAreaStyle { get; } = new ElementStyle() { StrokeWidth = 0 };
        /// <summary>
        /// Collection of styles to assign to series
        /// </summary>
        public IReadOnlyCollection<LineSeriesStyle> SeriesStyles { get; set; } 
        public IReadOnlyCollection<ChartSeries> Series { get; }

        private int _lastStyleIndex = -1;

        internal abstract IEnumerable<Element> GetSvgElements(ScaleInfo xScaleInfo, ScaleInfo yScaleInfo, IReadOnlyCollection<string> valueLabels, bool drawDebug);
        protected abstract void BuildDefaultSeriesStyles();

        internal ChartArea(IEnumerable<ChartSeries> series)
        {
            Series = series.ToArray();
        }

        private LineSeriesStyle GetNextSeriesStyle()
        {
            _lastStyleIndex++;

            if (_lastStyleIndex == SeriesStyles.Count)
            {
                _lastStyleIndex = 0;
            }

            return SeriesStyles.ElementAt(_lastStyleIndex);
        }

        /// <summary>
        /// Calculates the chart area size and determines the binding corners.
        /// </summary>
        internal void SizeChartArea(double height, double paddingTop, double paddingBottom, double width, double paddingLeft, double paddingRight)
        {
            CalculateChartAreaWidth(width, paddingLeft, paddingRight);
            CalculateChartAreaHeight(height, paddingTop, paddingBottom);
        }

        protected void AssignStyles()
        {
            if (SeriesStyles == null)
            {
                BuildDefaultSeriesStyles();
            }

            foreach (var ser in Series)
            {
                if (ser.Style == null)
                {
                    ser.Style = GetNextSeriesStyle();
                }
            }
        }

        internal IEnumerable<Element> GetDebugElements(bool drawDebug)
        {
            if (!drawDebug) yield break;

            yield return new Circle("c1", null, TopLeftX, TopLeftY, 0.5, new CircleStyle() { StrokeColor = "red" });
            yield return new Circle("c1", null, BottomRightX, BottomRightY, 0.5, new CircleStyle() { StrokeColor = "red" });
        }

        internal void CreateDataPoints(ScaleInfo xScaleInfo, ScaleInfo yScaleInfo)
        {
            var offSetX = xScaleInfo.StartOnMajor 
                ? 0
                : xScaleInfo.MinorInterval * xScaleInfo.Scale;

            foreach (var series in Series)
            {
                series.InitDataPoints(xScaleInfo.Scale, yScaleInfo.Scale, TopLeftX + offSetX, BottomRightY);
            }
        }

        /// <summary>
        /// Calculate the chart area width
        /// </summary>
        private void CalculateChartAreaWidth(double width, double paddingLeft, double paddingRight)
        {
            if (width < 0) throw new ArgumentOutOfRangeException(nameof(width));
            if (paddingLeft < 0) throw new ArgumentOutOfRangeException(nameof(paddingLeft));
            if (paddingRight < 0) throw new ArgumentOutOfRangeException(nameof(paddingRight));

            TopLeftX = paddingLeft + (ChartAreaStyle.StrokeWidth / 2);
            BottomRightX = width - paddingRight;
        }

        /// <summary>
        /// Calculate the chart area height
        /// </summary>
        private void CalculateChartAreaHeight(double height, double paddingTop, double paddingBottom)
        {
            if (paddingTop < 0) throw new ArgumentOutOfRangeException(nameof(paddingTop));
            if (height < 0) throw new ArgumentOutOfRangeException(nameof(height));

            TopLeftY = paddingTop + (ChartAreaStyle.StrokeWidth);
            BottomRightY = height - paddingBottom - 4; //Need some extra space to avoid bottom cutoff
        }
    }
}