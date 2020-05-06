using System;
using System.Collections.Generic;
using NetCharts.ChartElements;
using NetCharts.Component;
using NetCharts.Style;
using NetCharts.Svg;

namespace NetCharts
{
    public abstract class Chart
    {
        /// <summary>
        /// Enabled to activate debug markings. Disabled by default.
        /// </summary>
        public bool DrawDebug { get; set; } = false;
        
        public double Width { get; set; }
        public double Height { get; set; }
        public double PaddingLeft { get; set; } = 15;
        public double PaddingRight { get; set; }
        public double PaddingTop { get; set; } = 15;
        public double PaddingBottom { get; set; }
        public Legend Legend { get; }
        public Title Title { get; }

        public abstract ChartType Type { get; }

        protected string[] Labels { get; }

        /// <summary>
        /// Sets chart component dimensions and calculates chart scale to create data points
        /// </summary>
        protected abstract void GenerateChart();

        /// <summary>
        /// Gets the scale info from the chart component.
        /// </summary>
        internal abstract ScaleInfo GetScaleInfo(AxisType type);

        protected abstract double AdditionalPaddingBottom { get; }
        protected abstract double AdditionalPaddingTop { get; }
        protected abstract double AdditionalPaddingLeft { get; }
        protected abstract double AdditionalPaddingRight { get; }

        internal abstract IReadOnlyCollection<Element> GetSvgElements();

        protected Chart(ChartSeries[] series, string[] labels)
        {
            Labels = labels ?? throw new ArgumentNullException(nameof(labels));
            Legend = new Legend(series);
            Title = new Title();
        }

        public string ToSvg()
        {
            ValidateOptions();
            GenerateChart();

            var svg = new Root(Height, Width);
            var group = new Group();
           
            group.Elements.AddRange(GetSvgElements());
            group.Elements.AddRange(GetDebugElements());
            svg.Elements.Add(group);

            return svg.ToXml();
        }

        protected IEnumerable<string> GetLabels()
        {
            return Labels;
        }

        private IEnumerable<Element> GetDebugElements()
        {
            var list = new List<Element>();

            if (!DrawDebug) return list;

            var black10 = true;
            var black100 = true;
            var count100 = 0;
            var blackStyle = new ElementStyle() {Fill = "black", StrokeColor = "black"};
            var whiteStyle = new ElementStyle() {Fill = "grey", StrokeColor = "grey" };

            //X bar
            for (var i = 0; i < Width;)
            {
                var style = black10 ? blackStyle : whiteStyle;
                list.Add(new Rectangle(5, 10, i, Height - 10, style));
               
                black10 = !black10;

                if (count100 == 0)
                {
                    style = black100 ? blackStyle : whiteStyle;
                    list.Add(new Rectangle(5, 100, i, Height - 5, style));
                    black100 = !black100;
                }

                i += 10;
                count100 += 10;

                if (count100 == 100)
                {
                    count100 = 0;
                }
            }

            //Y bar
            for (var i = 0; i < Height;)
            {
                var style = black10 ? blackStyle : whiteStyle;
                list.Add(new Rectangle(10, 5, Width - 10, i, style));

                black10 = !black10;

                if (count100 == 0)
                {
                    style = black100 ? blackStyle : whiteStyle;
                    list.Add(new Rectangle(100, 5, Width - 5, i, style));
                    black100 = !black100;
                }

                i += 10;
                count100 += 10;

                if (count100 == 100)
                {
                    count100 = 0;
                }
            }

            return list;
        }

        private void ValidateOptions()
        {
            if (Height < 50) throw new ArgumentException("Height cannot be less than 50");
            if (Width < 100) throw new ArgumentException("Width cannot be less than 100");
        }

    }
}
