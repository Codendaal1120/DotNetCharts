using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace NetCharts.Style
{
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
        public double StrokeWidth { get; set; } = 1;

        /// <summary>
        /// Should element be drawn
        /// </summary>
        public virtual bool Draw => Math.Abs(StrokeWidth) > 0 && (StrokeColor != "none" || HasFill);

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
            };

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
