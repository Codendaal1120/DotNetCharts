using System;
using System.Collections.Generic;
using System.Linq;
using NetCharts.ChartElements;
using NetCharts.Style;
using NetCharts.Svg;

namespace NetCharts.Component
{
    public class Legend
    {
        public bool Draw => LabelStyle.Draw;
        public double Padding { get; set; } = 5.0;
        public double Height { get; private set; }
        public double Width { get; private set; }
        public LegendLayout FieldLayout { get; set; } = LegendLayout.Horizontal;
        public LegendIcon LegendIcon { get; set; } = LegendIcon.Circle;
        public TextStyle LabelStyle { get; } = new TextStyle() { Size = 15 };

        private int _labelLineCount = 1;
        private double _chartHeight;
        private double _chartWidth;
        private double IconSize => LabelStyle.Draw ? LabelStyle.Size * 0.9 : 13.0;
        private double Spacing => LabelStyle.Draw ? LabelStyle.Size * 1.4 : 13.0;
        private readonly Dictionary<int, List<ChartSeries>> _seriesInPos = new Dictionary<int, List<ChartSeries>>();
        private readonly IReadOnlyCollection<ChartSeries> _series;

        public Legend(IEnumerable<ChartSeries> series)
        {
            if (series == null) throw new ArgumentNullException(nameof(series));

            _series = series.ToArray();
        }

        internal void CalculateSize(double chartHeight, double chartWidth)
        {
            _chartHeight = chartHeight;
            _chartWidth = chartWidth;

            //assuming the legend is on the top or bottom
            var baseHeight = LabelStyle.Size;
            //Width = _series.Sum(s => GetLabelWidth(s.SeriesName));
            Height = baseHeight + Padding;

            Width = 0;
            _labelLineCount = 1;
            var localWidth = 0.0;
            foreach (var ser in _series)
            {
                localWidth += GetLabelWidth(ser.SeriesName);

                if (localWidth > chartWidth)
                {
                    _labelLineCount++;
                    localWidth = 0;
                }

                AddSeriesToLine(ser, _labelLineCount);
                Width = Math.Max(localWidth, Width);
            }

            Height = _labelLineCount > 1 ? ((baseHeight + (Spacing * 0.5)) * _labelLineCount) + Padding : Height;
        }

        internal IEnumerable<Element> GetSvgElements(double yOffset = 0)
        {
            var elements = new List<Element>();

            if (!Draw) return elements;

            var iconOffsetY = 0.0;
            var iconSpacing = (Spacing * 0.75);

            foreach (var kvp in _seriesInPos)
            {
                var lineSpacing = kvp.Key > 1 ? (Spacing * 0.5) : 0;
                var lineWidth = kvp.Value.Sum(s => GetLabelWidth(s.SeriesName));
                var xPos = ((_chartWidth / 2) - (lineWidth / 2));
                var yPos = Padding + lineSpacing + (LabelStyle.Size * kvp.Key) + yOffset;

                foreach (var series in kvp.Value)
                {
                    var inc = IconSize + Spacing + iconSpacing;

                    if (LabelStyle.Draw)
                    {
                        //compensate for icon
                        var labelY = yPos + (LabelStyle.HeightPixels / 4.5);
                        elements.Add(new Text($"{series.SeriesName}", xPos, labelY, TextAnchor.Start, DominantBaseline.Auto, LabelStyle));
                        inc += LabelStyle.WidthPixels * series.SeriesName.Length;
                        iconOffsetY = LabelStyle.WidthPixels * 0.2;
                    }

                    var legendColor = series.Style.ElementStyle.StrokeColor == "none"
                        ? series.Style.ElementStyle.Fill
                        : series.Style.ElementStyle.StrokeColor;

                    switch (LegendIcon)
                    {
                        case LegendIcon.Circle:
                            var radius = IconSize / 2.0;
                            elements.Add(new Circle($"legend-{series.SeriesName}", null, xPos - iconSpacing, yPos - iconOffsetY, radius,
                                new CircleStyle() { Fill = legendColor, StrokeColor = legendColor, FillOpacity = series.Style.ElementStyle.FillOpacity}));
                            break;

                        case LegendIcon.Line:
                            //TODO
                            break;

                        case LegendIcon.Square:
                            //TODO
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    xPos += inc;
                }
            }

            return elements;
        }

        private double GetLabelWidth(string label) => (label.Length * LabelStyle.WidthPixels) + IconSize + Spacing + (Spacing * 0.75);

        private void AddSeriesToLine(ChartSeries series, int lineNumber)
        {
            if (_seriesInPos.TryGetValue(lineNumber, out var seriesList))
            {
                seriesList.Add(series);
                return;
            }

            _seriesInPos.Add(lineNumber, new List<ChartSeries> { series });
        }
    }
}
