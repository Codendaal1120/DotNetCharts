using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace NetCharts.Style
{
    public enum LineStyle
    {
        Solid = 0,
        Dotted = 1,
        Dashed = 2,
    }

    public class ElementStyle 
    {
        /// <summary>
        /// Fill color
        /// </summary>
        public string Fill { get; set; } = "none";

        /// <summary>
        /// Fill Opacity 1 == fully visible
        /// </summary>
        public double FillOpacity { get; set; } = 1;

        /// <summary>
        /// Stroke Opacity 1 == fully visible
        /// </summary>
        public double StrokeOpacity { get; set; } = 1;

        /// <summary>
        /// Stroke color
        /// </summary>
        public string StrokeColor { get; set; } = "grey";

        /// <summary>
        /// Width of the stroke
        /// </summary>
        public virtual double StrokeWidth { get; set; } = 1;

        /// <summary>
        /// The line style
        /// </summary>
        public LineStyle StrokeStyle { get; set; } = LineStyle.Solid;

        /// <summary>
        /// Should element be drawn
        /// </summary>
        public virtual bool Draw => StrokeWidth > 0 && (StrokeColor != "none" || HasFill);

        public bool HasFill => Fill != "none";

        public Overflow Overflow { get; } = Overflow.Visible;

        internal virtual Dictionary<string, string> StyleAttributes => PrivateStyleAttributes;

        protected virtual Dictionary<string, string> PrivateStyleAttributes =>
            new Dictionary<string, string>()
            {
                { "fill", Fill },
                { "stroke", StrokeColor },
                { "stroke-width", StrokeWidth.ToString(CultureInfo.InvariantCulture) },
                { "fill-opacity", FillOpacity.ToString(CultureInfo.InvariantCulture) },
                { "stroke-opacity", StrokeOpacity.ToString(CultureInfo.InvariantCulture) },
                { "stroke-dasharray", DashString },
            };

        private string DashString
        {
            get
            {
                switch (StrokeStyle)
                {
                    case LineStyle.Dotted:

                        return StrokeWidth >= 1
                            ? $"{ StrokeWidth * 2 },{ StrokeWidth * 2 }"
                            : "1.7, 1.7";

                    case LineStyle.Dashed:

                        return StrokeWidth >= 1
                            ? $"{ StrokeWidth * 5 },{ StrokeWidth * 5 }"
                            : "5 ,5";
                }

                return "0,0";
            }
        }

        internal ElementStyle()
        {
        }
    }

    public enum Overflow
    {
        [Description("Default. The overflow is not clipped. The content renders outside the element's box")]
        Visible = 0,

        [Description("The overflow is clipped, and the rest of the content will be invisible")]
        Hidden = 1,

        [Description("The overflow is clipped, and a scrollbar is added to see the rest of the content")]
        Scroll = 2,

        [Description("Similar to scroll, but it adds scrollbars only when necessary")]
        Auto = 3
    }

}
