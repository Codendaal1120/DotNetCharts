using System.Collections.Generic;
using DotNetCharts.ChartElements;
using DotNetCharts.Style;
using DotNetCharts.Svg;

namespace DotNetCharts.Component
{
    public abstract class Axis
    {
        public TickStyle MajorTickStyle { get; } = new TickStyle();
        public TickStyle MinorTickStyle { get; } = new TickStyle();
        public TextStyle LabelStyle { get; }
        public ElementStyle BaseLineStyle { get; } = new ElementStyle() { StrokeWidth = 0 };
        public bool Draw => DynamicSize > 0;

        public abstract double DynamicSize { get; }

        protected abstract AxisType Type { get; }

        internal abstract IEnumerable<Element> GetSvgElements(ScaleInfo scale, double dynamicOffset, double staticPos, IReadOnlyCollection<string> labels);

        protected Axis()
        {
            LabelStyle = new TextStyle() { Size = 13 };
        }
    }
}