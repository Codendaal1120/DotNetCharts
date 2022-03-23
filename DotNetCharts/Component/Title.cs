using System.Collections.Generic;
using DotNetCharts.Style;
using DotNetCharts.Svg;

namespace DotNetCharts.Component
{
    public class Title
    {
        public bool Draw => LabelStyle.Draw && Text.Length > 0;
        public double Height => Draw ? LabelStyle.Size + (Padding * 2) : 0;
        public double Width => Text.Length * LabelStyle.WidthPixels;
        public double Padding { get; set; } = 5.0;
        public string Text { get; set; } = string.Empty;
        public TextStyle LabelStyle { get; } = new TextStyle() { Size = 20 };
        
        private double _chartHeight;
        private double _chartWidth;

        internal void CalculateSize(double chartHeight, double chartWidth)
        {
            _chartHeight = chartHeight;
            _chartWidth = chartWidth;
        }

        internal IEnumerable<Element> GetSvgElements()
        {
            var elements = new List<Element>();

            if (!Draw) return elements;

            var xPos = ((_chartWidth / 2) - (Width / 2));
            var yPos = LabelStyle.Size + Padding;

            elements.Add(new Text(Text, xPos, yPos, TextAnchor.Start, DominantBaseline.Auto, LabelStyle));

            return elements;
        }
    }
}
