using System.Globalization;
using System.Xml;
using DotNetCharts.Style;

namespace DotNetCharts.Svg
{
    internal class Circle : Element
    {
        public double Radius { get; }
        public double PosX { get; }
        public double PosY { get; }
        public string Label { get; }

        public Circle(string id, string label, double posX, double posY, double radius = 2, CircleStyle style = null, string[] classes = null)
        {
            RootName = "circle";
            Id = id;
            PosX = posX;
            PosY = posY;
            Style = style ?? new CircleStyle();
            Classes = classes;
            Radius = radius;
            Label = label;
        }

        public override ElementStyle Style { get; }

        public override void WriteXml(XmlWriter writer)
        {
            WriteXmlAttributes(writer);
            if (!string.IsNullOrWhiteSpace(Id)) writer.WriteAttributeString("id", Id);
            if (!string.IsNullOrWhiteSpace(Label)) writer.WriteAttributeString("label", Label);
            writer.WriteAttributeString("cx", PosX.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("cy", PosY.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("r", Radius.ToString(CultureInfo.InvariantCulture));
            writer.WriteEndElement();
        }
    }
}
