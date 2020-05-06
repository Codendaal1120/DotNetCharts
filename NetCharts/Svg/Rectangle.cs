using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using NetCharts.Style;

namespace NetCharts.Svg
{
    internal class Rectangle : Element
    {
        public List<Element> Elements = new List<Element>();
        public double Height { get; set; }
        public double Width { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }

        public override ElementStyle Style { get; }

        public Rectangle(double height, double width, double posX = 0, double posY = 0, ElementStyle style = null, string[] classes = null)
        {
            RootName = "rect";
            Classes = classes;
            Style = style;
            Width = width;
            Height = height;
            PosX = posX;
            PosY = posY;
        }
        
        public override void WriteXml(XmlWriter writer)
        {
            if (writer == null) throw new ArgumentNullException(nameof(writer));

            if (!Style.Draw)
            {
                return;
            }

            WriteXmlAttributes(writer);

            writer.WriteAttributeString("height", Height.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("width", Width.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("transform", $"translate({PosX} {PosY})");

            if (Elements != null)
            {
                foreach (var elem in Elements)
                {
                    elem.WriteXml(writer);
                }
            }
            writer.WriteEndElement();
        }
    }

}
