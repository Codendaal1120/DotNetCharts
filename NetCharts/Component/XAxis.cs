using System;
using System.Collections.Generic;
using System.Linq;
using NetCharts.ChartElements;
using NetCharts.Svg;

namespace NetCharts.Component
{
    public sealed class XAxis : Axis
    {
        protected override AxisType Type => AxisType.XAxis;

        private readonly double _sizeOffset;
        
        /// <summary>
        /// The dynamic size axis height
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
                    : LabelStyle.HeightPixels * _sizeOffset;

                return size;
            }
        }

        /// <summary>
        /// Indicates if the axis should start ticks on the major mark
        /// </summary>
        public bool StartOnMajor { get; set; } = true;

        internal XAxis(double dynamicSizeOffset = 1)
        {
            _sizeOffset = dynamicSizeOffset;
             MajorTickStyle.StrokeWidth = 0.5;
             MajorTickStyle.Length = 3;
             BaseLineStyle.StrokeWidth = 0.5;
        }

        internal override IEnumerable<Element> GetSvgElements(ScaleInfo scale, double dynamicOffset, double staticPos, IReadOnlyCollection<string> labels)
        {
            if (scale == null) throw new ArgumentNullException(nameof(scale));
            if (labels == null) throw new ArgumentNullException(nameof(labels));

            var elements = new List<Element>();
            var isMinor = scale.StartOnMajor;
            var majorCount = 0;
            var lastXPos = 0.0;

            for (double i = 0; i <= scale.Max;)
            {
                isMinor = !isMinor;

                var idLabel = isMinor 
                    ? $"{Type.ToString()}-minor-tick-{i}" 
                    : $"{Type.ToString()}-major-tick-{i}";

                var thisStyle = isMinor
                    ? MinorTickStyle
                    : MajorTickStyle;

                var className = isMinor
                    ? $"{Type}-minor-tick"
                    : $"{Type}-major-tick";

                var xPos = (i * scale.Scale) + dynamicOffset;
                var yPos = staticPos + thisStyle.Length + LabelStyle.Size;

                if (thisStyle.Draw)
                {
                    var startPos = new DataPoint(xPos, staticPos);
                    var endPos = new DataPoint(xPos, staticPos + thisStyle.Length);

                    elements.Add(new Path(idLabel, startPos, new[] { new StraightLine(startPos, endPos, endPos) }, style: thisStyle, classes: new[] { className, "tick" }));
                }

                if (!isMinor && LabelStyle.Draw)
                {
                    var label = labels.ElementAt(majorCount);
                    var labelX = xPos - ((label.Length * LabelStyle.WidthPixels) / 1.5);
                    //split label into 2 lines
                    elements.Add(new Text($"{label}", labelX, yPos, TextAnchor.Start, DominantBaseline.Auto, LabelStyle, new[] { $"{Type}-label", "axis-label" }));
                }

                i += scale.MinorInterval;
                if (!isMinor)
                {
                    majorCount += 1;
                }

                lastXPos = xPos;
            }

            if (BaseLineStyle.Draw)
            {
                elements.Add(new Path(
                    $"{Type}--baseline",
                    new DataPoint(dynamicOffset, staticPos),
                    new DataPoint(lastXPos, staticPos),
                    BaseLineStyle));
            }
            

            return elements.ToArray();
        }
    }
}