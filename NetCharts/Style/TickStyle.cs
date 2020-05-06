namespace NetCharts.Style
{
    public class TickStyle : ElementStyle
    {
        /// <summary>
        /// Should element be drawn
        /// </summary>
        public override bool Draw => Fill != "none" && Length > 0;

        public string Stroke { get; } = "none";
        /// <summary>
        /// Length of the tick
        /// </summary>
        public double Length { get; set; }

        internal TickStyle() 
        {
            Fill = "gray";
        }
    }
}
