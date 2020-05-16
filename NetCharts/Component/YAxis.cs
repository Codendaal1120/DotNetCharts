using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NetCharts.ChartElements;
using NetCharts.Svg;

namespace NetCharts.Component
{
    public sealed class YAxis : Axis
    {
        protected override AxisType Type => AxisType.YAxis;

        private int _maxLabelSize;

        /// <summary>
        /// The dynamic size of the axis width
        /// </summary>
        public override double DynamicSize
        {
            get
            {
                double size = 0;
                size += MajorTickStyle.Draw ? MajorTickStyle.Length : 0;
                size += !MajorTickStyle.Draw && MinorTickStyle.Draw ? MinorTickStyle.Length : 0;
                size += !LabelStyle.Draw
                    ? 0
                    : (LabelStyle.WidthPixels * _maxLabelSize);

                return size;
            }
        }

        internal YAxis(int maxLabelLength)
        {
            MajorTickStyle.StrokeWidth = 0;
            _maxLabelSize = maxLabelLength;
        }

        internal override IEnumerable<Element> GetSvgElements(ScaleInfo scale, double dynamicOffset, double staticPos, IReadOnlyCollection<string> labels)
        {
            if (scale == null) throw new ArgumentNullException(nameof(scale));
            if (labels == null) throw new ArgumentNullException(nameof(labels));

            var elements = new List<Element>();
            var majorCount = labels.Count -1;
            var lastYPos = 0.0;

            for (var i = scale.Max; i >= 0;)
            {
                var isMinor = !labels.Contains(i.ToString(CultureInfo.InvariantCulture));

                var idLabel = isMinor 
                    ? $"{Type.ToString()}-minor-tick-{i}" 
                    : $"{Type.ToString()}-major-tick-{i}";

                var className = isMinor
                    ? $"{Type}-minor-tick"
                    : $"{Type}-major-tick";

                var thisStyle = isMinor
                    ? MinorTickStyle
                    : MajorTickStyle;

                var xPos = staticPos;
                var yPos = (i * scale.Scale) + dynamicOffset;
                
                if (thisStyle.Draw)
                {
                    var startPos = new DataPoint(xPos, yPos);
                    var endPos = new DataPoint(xPos - thisStyle.Length, yPos);

                    elements.Add(new Path(idLabel, startPos, new[] { new StraightLine(startPos, endPos, endPos) }, style: thisStyle, classes: new[] { className, "tick" } ));
                }

                if (!isMinor && LabelStyle.Draw)
                {
                    var label = labels.ElementAt(majorCount);
                    //elements are spaced with the width LabelStyle.Size
                    elements.Add(new Text($"{label}", xPos - LabelStyle.Size, yPos, TextAnchor.End, DominantBaseline.Middle, LabelStyle, new []{ $"{Type}-label", "axis-label" }));
                }

                i -= scale.MinorInterval;
                if (!isMinor)
                {
                    majorCount -= 1;
                }

                lastYPos = yPos;
            }

            if (BaseLineStyle.Draw)
            {
                elements.Add(new Path(
                    $"{Type}--baseline",
                    new DataPoint(staticPos, dynamicOffset),
                    new DataPoint(staticPos, lastYPos),
                    BaseLineStyle));
            }

            return elements.ToArray();
        }
    }
}