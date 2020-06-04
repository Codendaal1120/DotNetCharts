namespace NetCharts.Style
{
    public class LineSeriesStyle : SeriesStyle
    {
        public bool IsDefaultStyle { get; } = false;
        public TextStyle LabelStyle { get; } = new TextStyle() { Size = 0 };
        public bool DrawLabel => LabelStyle.Draw;
        public Position DataPointLabelPosition { get; set; } = Position.Top;

        public MarkerStyle MarkerStyle
        {
            get =>
                _dataPointStyle ?? (_dataPointStyle = new MarkerStyle()
                {
                    Fill = ElementStyle.Fill,
                    StrokeColor = ElementStyle.StrokeColor
                });
            set => _dataPointStyle = value;
        }

        private MarkerStyle _dataPointStyle;
        
        public LineSeriesStyle() : this(false)
        {
        }

        internal LineSeriesStyle(SeriesStyle style)
        {
            ElementStyle = style.ElementStyle;
        }

        internal LineSeriesStyle(bool isDefault = true)
        {
            IsDefaultStyle = isDefault;
        }

    }
}