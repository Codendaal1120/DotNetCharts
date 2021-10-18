using System;
using System.Drawing;

namespace NetCharts.Style
{
    public class TextStyle : ElementStyle
    {
        /// <summary>
        /// Should element be drawn
        /// </summary>
        public override bool Draw => Fill != "none" && Size > 0;

        public string Font = "Arial";

        public override double StrokeWidth => 1;

        /// <summary>
        /// The character size
        /// </summary>
        public double WidthPixels { get; private set; }

        public double HeightPixels { get; private set; }

        public int Size
        {
            get => _size;
            set
            {
                _size = value;
                WidthPixels = _size * 0.4612;
                HeightPixels = _size * 1.1558;
            }
        }

        private int _size;

        internal TextStyle()
        {
            Fill = "grey";
            StrokeColor = "none";
        }

        
    }
}
