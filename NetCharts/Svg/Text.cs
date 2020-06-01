using System.Globalization;
using System.Xml;
using NetCharts.Style;

namespace NetCharts.Svg
{
    internal enum TextAnchor
    {
        Start = 0,
        Middle = 1,
        End = 2
    }

    internal enum DominantBaseline
    {
        Auto = 0,
        Middle = 1,
        Inherit = 2
    }

    internal class Text : Element
    {
        public double PosX { get; }
        public double PosY { get; }
        public string Label { get; }
        public TextAnchor Anchor { get; }
        public DominantBaseline DominantBaseline { get; }
        public override ElementStyle Style => _style;

        private readonly TextStyle _style;

        public Text(
            string label, 
            double posX, 
            double posY, 
            TextAnchor anchor = TextAnchor.Middle,
            DominantBaseline baseline = DominantBaseline.Auto,
            TextStyle style = null, 
            string[] classes = null)
        {
            RootName = "text";
            Label = label;
            PosX = posX;
            PosY = posY;
            _style = style;
            Classes = classes;
            Anchor = anchor;
            DominantBaseline = baseline;
        }

        public override void WriteXml(XmlWriter writer)
        {
            WriteXmlAttributes(writer);
            writer.WriteAttributeString("x", PosX.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("y", PosY.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("text-anchor", Anchor.ToString());
            writer.WriteAttributeString("dominant-baseline", DominantBaseline.ToString());
            writer.WriteAttributeString("font-size", $"{_style.Size.ToString(CultureInfo.InvariantCulture)}px");
            writer.WriteAttributeString("font-family", $"{_style.Font}");
            writer.WriteValue(Label);
            writer.WriteEndElement();
        }
    }
}
