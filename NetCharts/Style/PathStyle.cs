using System;
using System.Collections.Generic;

namespace NetCharts.Style
{
    public enum LineStyle
    {
        Solid = 0,
        Dotted = 1,
        Dashed = 2,
    }

    public class PathStyle : ElementStyle
    {
        /// <summary>
        /// The line style
        /// </summary>
        public LineStyle StrokeStyle { get; set; } = LineStyle.Solid;

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

        internal override Dictionary<string, string> StyleAttributes
        {
            get
            {
                var dic = PrivateStyleAttributes;
                dic.Add("stroke-dasharray", DashString);
                return dic;
            }
        }

        internal PathStyle()
        {
        }

    }
}
