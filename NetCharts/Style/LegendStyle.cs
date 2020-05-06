using System;

namespace NetCharts.Style
{
    public enum LegendPosition
    {
        Top = 0,
        Bottom = 1,
        Left = 2,
        Right = 3
    }

    public enum LegendLayout
    {
        Horizontal = 0,
        Vertical = 1
    }

    public enum LegendMarkerShape
    {
        Square = 0,
        Round = 1
    }

    public class LegendStyle
    {
        public bool Draw => LabelStyle.Draw;
        public LegendMarkerShape MarkerShape { get; set; } = LegendMarkerShape.Square;
        public LegendLayout Layout { get; set; } = LegendLayout.Horizontal;
        public LegendPosition Position { get; set; } = LegendPosition.Top;
        public TextStyle LabelStyle { get; } = new TextStyle() { Size = 5 };
        
        internal LegendStyle()
        {

        }
    }
    
    
}
