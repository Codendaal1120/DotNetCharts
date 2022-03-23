using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DotNetCharts.ChartElements;
using DotNetCharts.Style;
using DotNetCharts.Svg;

namespace DotNetCharts.Component
{
    public class LineChartArea : ChartArea
    {
        /// <summary>
        /// Style for the vertical grid lines (for X axis)
        /// </summary>
        public GridLineStyle XGridLineStyle { get; } = new GridLineStyle();

        /// <summary>
        /// Style for the horizontal grid lines (for Y axis)
        /// </summary>
        public GridLineStyle YGridLineStyle { get; } = new GridLineStyle();

        /// <summary>
        /// Indicate if the default styles should include the data point
        /// </summary>
        internal bool DrawDefaultDataPointMarkers { get; set; }

        /// <summary>
        /// Indicate if the default styles should include the data point label
        /// </summary>
        internal bool DrawDefaultDataPointLabels { get; set; }

        internal LineType LineType { get; set; } = LineType.Straight;

        internal LineChartArea(IEnumerable<ChartSeries> series) : base(series)
        {
        }

        internal override IEnumerable<Element> GetSvgElements(ScaleInfo xScaleInfo, ScaleInfo yScaleInfo, IReadOnlyCollection<string> valueLabels, bool drawDebug)
        {
            AssignStyles();
            var elements = GetBoundingBox();
            elements = elements.Concat(GetGridLines(xScaleInfo, yScaleInfo, valueLabels));
            elements = elements.Concat(GetDebugElements(drawDebug));
            elements = LineType == LineType.Curved 
                ? elements.Concat(GetCurvedPaths())
                : elements.Concat(GetStraightPaths());
            
            return elements;
        }

        protected override void BuildDefaultSeriesStyles()
        {
            var strokeWidth = DrawDefaultDataPointMarkers ? 0.5 : 0.0;
            var labelSize = DrawDefaultDataPointLabels ? 9 : 0;
            SeriesStyles = new[]
            {
                new LineSeriesStyle(true) { ElementStyle = { StrokeColor = "#3454D1" }, MarkerStyle = { StrokeColor = "#3454D1", Fill = "#3454D1", StrokeWidth = strokeWidth }, LabelStyle = { Size = labelSize, StrokeColor = "black" }},
                new LineSeriesStyle(true) { ElementStyle = { StrokeColor = "#34D1BF" }, MarkerStyle = { StrokeColor = "#34D1BF", Fill = "#34D1BF", StrokeWidth = strokeWidth }, LabelStyle = { Size = labelSize, StrokeColor = "black" }},
                new LineSeriesStyle(true) { ElementStyle = { StrokeColor = "#D1345B" }, MarkerStyle = { StrokeColor = "#D1345B", Fill = "#D1345B", StrokeWidth = strokeWidth }, LabelStyle = { Size = labelSize, StrokeColor = "black" }},
                new LineSeriesStyle(true) { ElementStyle = { StrokeColor = "#34D1BF" }, MarkerStyle = { StrokeColor = "#34D1BF", Fill = "#34D1BF", StrokeWidth = strokeWidth }, LabelStyle = { Size = labelSize, StrokeColor = "black" }},
                new LineSeriesStyle(true) { ElementStyle = { StrokeColor = "#0A2463" }, MarkerStyle = { StrokeColor = "#0A2463", Fill = "#0A2463", StrokeWidth = strokeWidth }, LabelStyle = { Size = labelSize, StrokeColor = "black" }},
                new LineSeriesStyle(true) { ElementStyle = { StrokeColor = "#87E752" }, MarkerStyle = { StrokeColor = "#87E752", Fill = "#87E752", StrokeWidth = strokeWidth }, LabelStyle = { Size = labelSize, StrokeColor = "black" }},
            };
        }

        private IEnumerable<Element> GetGridLines(ScaleInfo xScaleInfo, ScaleInfo yScaleInfo, IReadOnlyCollection<string> valueLabels)
        {
            var elements = GetVerticalGridLines(xScaleInfo);
            elements = elements.Concat(GetHorizontalGridLines(yScaleInfo, valueLabels));
            return elements;
        }

        private IEnumerable<Element> GetHorizontalGridLines(ScaleInfo scale, IReadOnlyCollection<string> valueLabels)
        {
            var elements = new List<Element>();

            if (!YGridLineStyle.Draw) return elements;
            
            var loopStart = scale.MinorInterval;

            var loopEnd = scale.Max;

            for (var i = loopStart; i <= loopEnd;)
            {
                var isMajor = valueLabels.Contains(i.ToString(CultureInfo.InvariantCulture));
                var yPos = BottomRightY - ((i) * scale.Scale);
                var startPos = new DataPoint(TopLeftX, yPos);
                var endPos = new DataPoint(BottomRightX, yPos);
                var className = isMajor 
                    ? "y-major-grid-line" 
                    : "y-minor-grid-line";

                var draw = isMajor
                    ? YGridLineStyle.MajorLineStyle.Draw
                    : YGridLineStyle.MinorLineStyle.Draw;

                if (draw)
                {
                    elements.Add(new Path(
                        isMajor ? $"y-major--grid-{i}" : $"y-minor--grid-{i}",
                        startPos,
                        new[]
                        {
                            new StraightLine(startPos, endPos, startPos)
                        },
                        null,
                        isMajor ? YGridLineStyle.MajorLineStyle : YGridLineStyle.MinorLineStyle,
                        new[] { className, "grid-line" }));
                }

                i += scale.MinorInterval;
            }

            return elements;
        }

        private IEnumerable<Element> GetVerticalGridLines(ScaleInfo scale)
        {
            var elements = new List<Element>();

            if (!XGridLineStyle.Draw) return elements;

            var loopStart = scale.StartOnMajor 
                ? 0
                : scale.MinorInterval;

            var loopEnd = scale.StartOnMajor 
                ? scale.Max
                : scale.Max - scale.MinorInterval;

            var isMajor = scale.StartOnMajor;

            for (var i = loopStart; i <= loopEnd;)
            {
                var xPos = ((i) * scale.Scale) + TopLeftX;
                var startPos = new DataPoint(xPos, BottomRightY);
                var endPos = new DataPoint(xPos, TopLeftY);

                var className = isMajor ? "x-major-grid-line" : "x-minor-grid-line";

                var draw = isMajor
                    ? YGridLineStyle.MajorLineStyle.Draw
                    : YGridLineStyle.MinorLineStyle.Draw;

                if (draw)
                {
                    elements.Add(new Path(
                        isMajor ? $"x-major--grid-{i}" : $"x-minor--grid-{i}",
                        startPos,
                        new[]
                        {
                            new StraightLine(startPos, endPos, startPos)
                        },
                        null,
                        isMajor
                            ? XGridLineStyle.MajorLineStyle
                            : XGridLineStyle.MinorLineStyle,
                        new[] { className, "grid-line" })
                    );
                }

                i += scale.MinorInterval;
                isMajor = !isMajor;
            }

            return elements;
        }

        private IEnumerable<Element> GetBoundingBox()
        {
            var elements = new List<Element>
            {
                new Rectangle(Height, Width, TopLeftX, TopLeftY, ChartAreaStyle),
            };

            return elements;
        }
        
        private IEnumerable<Element> GetCurvedPaths()
        {
            var elements = new List<Element>();

            foreach (var series in Series)
            {
                if (!series.DataPoints.Any())
                {
                    continue;
                }

                var curves = GetCurves(series.DataPoints);
                StraightLine[] fillLines = null;

                if (series.Style.ElementStyle.HasFill)
                {
                    fillLines = GetFillLines(series);
                    //add connected path
                }

                elements.Add(new Path(null, series.DataPoints[0], curves, fillLines, series.Style.ElementStyle, new []{ "series", $"series-{series.SeriesName}" }));
                elements.AddRange(GetDataPointMarker(series, GetSeriesStyle(series), curves));
            }

            return elements;
        }

        private IEnumerable<Element> GetStraightPaths()
        {
            var elements = new List<Element>();

            foreach (var series in Series)
            {
                if (!series.DataPoints.Any())
                {
                    continue;
                }

                var lines = GetLines(series.DataPoints);
                StraightLine[] fillLines = null;

                if (series.Style.ElementStyle.HasFill)
                {
                    fillLines = GetFillLines(series);
                    //add connected path
                }

                var startPoint = series.DataPoints.First(d => d != null);
                elements.Add(new Path(null, startPoint, lines, fillLines, series.Style.ElementStyle, new[] { "series", $"series-{series.SeriesName}" }));
                elements.AddRange(GetDataPointMarker(series, GetSeriesStyle(series), lines));
            }

            return elements;
        }

        private LineSeriesStyle GetSeriesStyle(ChartSeries series)
        {
            if (series.Style is LineSeriesStyle lineStyle)
            {
                return lineStyle;
            }

            return series.Style == null 
                ? GetNextSeriesStyle() 
                : new LineSeriesStyle(series.Style);
        }

        private IEnumerable<Element> GetDataPointMarker(ChartSeries series, LineSeriesStyle style, IReadOnlyCollection<ChartLine> lines)
        {
            var elements = new List<Element>();

            if (!lines.Any()) return elements;

            elements.AddRange(CreateDataPoint(
                lines.Last().CompletePoint.X,
                lines.Last().CompletePoint.Y,
                lines.Last().CompletePoint.XValue,
                lines.Last().CompletePoint.YValue,
                series.SeriesName,
                style));

            for (var i = 0; i < lines.Count; i++)
            {
                elements.AddRange(CreateDataPoint(
                    lines.ElementAt(i).StartPoint.X,
                    lines.ElementAt(i).StartPoint.Y,
                    series.DataPoints[i].XValue,
                    series.DataPoints[i].YValue,
                    series.SeriesName,
                    style));
            }

            return elements;
        }

        private Text CreateDataPointLabel(double dataPointX, double dataPointY, string value, string seriesName, LineSeriesStyle style)
        {
            var xPos = dataPointX;
            var yPos = 0.0;

            switch (style.DataPointLabelPosition)
            {
                case Position.Top:
                    yPos = dataPointY - style.LabelStyle.Size;
                    break;

                case Position.Centre:
                    yPos = dataPointY;
                    break;

                case Position.Bottom:
                    yPos = dataPointY + style.LabelStyle.Size;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            return new Text(value, xPos, yPos, TextAnchor.Middle, DominantBaseline.Middle, style.LabelStyle, new []{ $"data-point-text data-point-text_{seriesName}" });
        }

        private IEnumerable<Element> CreateDataPoint(double dataPointX, double dataPointY, string xValue, string yValue, string seriesName, LineSeriesStyle style)
        {
            var elements = new List<Element>();

            if (style.MarkerStyle.Draw)
            {
                elements.Add(new Circle(
                    null,
                    $"{xValue}:{yValue}",
                    dataPointX,
                    dataPointY,
                    style.MarkerStyle.Radius,
                    style: style.MarkerStyle, classes: new[] { $"data-point data-point_{seriesName}" }));
            }
            
            if (style.DrawLabel)
            {
                elements.Add(CreateDataPointLabel(dataPointX, dataPointY, yValue, seriesName, style));
            }

            return elements;
        }

        /// <summary>
        /// Gets the bezier curves
        /// </summary>
        private CurvedLine[] GetCurves(DataPoint[] dataPoints)
        {
            var lastIndex = dataPoints.Length - 1;
            var curves = new List<CurvedLine>();

            if (dataPoints.Length == 1)
            {
                var curve = new CurvedLine(
                     dataPoints[0],
                    dataPoints[0],
                    dataPoints[0],
                    dataPoints[0],
                    dataPoints[0]);

                curves.Add(curve);
            }

            for (var i = 1; i < dataPoints.Length; i++)
            {
                var curve = new CurvedLine(
                    i < 2 ? null : dataPoints[i - 2],
                    dataPoints[i - 1],
                    dataPoints[i],
                    i == lastIndex ? null : dataPoints[i + 1],
                    dataPoints[0]);

                curves.Add(curve);
            }

            //if (style.HasFill)
            //{
            //    var bottomLeft = new DataPoint(TopLeftX, BottomRightY);
            //    var bottomRight = new DataPoint(BottomRightX, BottomRightY);
            //    curves.Add(new StraightLine(
            //        curves.First().StartPoint,
            //        bottomLeft,
            //        bottomLeft));

            //    curves.Add(new StraightLine(
            //        bottomLeft,
            //        bottomRight,
            //        bottomRight));

            //    curves.Add(new StraightLine(
            //        bottomRight,
            //        curves.Last().EndPointPoint,
            //        lines.Last().EndPointPoint));
            //}

            return curves.ToArray();
        }

        /// <summary>
        /// Gets the straight lines
        /// </summary>
        private StraightLine[] GetLines(DataPoint[] dataPoints)
        {
            var lines = new List<StraightLine>();

            if (dataPoints.Length == 1)
            {
                var line = new StraightLine(
                    dataPoints[0],
                    dataPoints[0],
                    dataPoints[0]);

                lines.Add(line);
            }

            for (var i = 1; i < dataPoints.Length; i++)
            {
                var line = new StraightLine(
                    dataPoints[i - 1],
                    dataPoints[i],
                    dataPoints[dataPoints.Length - 1]);

                lines.Add(line);
            }

            //if (style.HasFill)
            //{
            //    var bottomLeft = new DataPoint(TopLeftX, BottomRightY);
            //    var bottomRight = new DataPoint(BottomRightX, BottomRightY);
            //    lines.Add(new StraightLine(
            //        lines.First().StartPoint,
            //        bottomLeft,
            //        bottomLeft));

            //    lines.Add(new StraightLine(
            //        bottomLeft,
            //        bottomRight,
            //        bottomRight));

            //    lines.Add(new StraightLine(
            //        bottomRight,
            //        lines.Last().EndPointPoint,
            //        lines.Last().EndPointPoint));
            //}

            return lines.ToArray();
        }

        private StraightLine[] GetFillLines(ChartSeries series)
        {
            var bottomLeft = new DataPoint(TopLeftX, BottomRightY);
            var bottomRight = new DataPoint(BottomRightX, BottomRightY);
            return new[]
            {
                new StraightLine(
                    series.DataPoints.First(),
                    bottomLeft,
                    bottomLeft),
                new StraightLine(
                    bottomLeft,
                    bottomRight,
                    bottomRight),
                new StraightLine(
                    bottomRight,
                    series.DataPoints.Last(),
                    series.DataPoints.Last())
            };
        }

        private Element GetFillPath(StraightLine[] lines, ChartSeries series)
        {
            return new Path(
                "chart-filler", 
                series.DataPoints.First(), 
                lines.ToArray(), 
                null,
                new ElementStyle()
                {
                    Fill = series.Style.ElementStyle.Fill, 
                    FillOpacity = series.Style.ElementStyle.FillOpacity ,
                    StrokeColor = "black"
                });
        }

    }
}