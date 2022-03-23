using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DotNetCharts.Svg
{
    //https://www.w3.org/TR/SVG/paths.html#PathDataLinetoCommands

    [XmlRoot(ElementName = "svg", Namespace = "http://www.w3.org/2000/svg")]
    internal class Root : IXmlSerializable
    {
        public ViewBox ViewBox { get; set; }
        public List<Element> Elements = new List<Element>();

        private double _height;
        private double _width;

        public Root(double height, double width)
        {
            _height = height;
            _width = width;
        }

        public string ToXml()
        {
            using (var ms = new MemoryStream())
            {
                var ser = new DataContractSerializer(GetType());
                ser.WriteObject(ms, this);
                ms.Close();
                return Encoding.ASCII.GetString(ms.ToArray());
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotSupportedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("class", ".svg");
            writer.WriteAttributeString("height", _height.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("width", _width.ToString(CultureInfo.InvariantCulture));

            if (ViewBox != null)
            {
                writer.WriteAttributeString("viewBox", ViewBox.ToString());
            }

            if (Elements != null)
            {
                foreach (var elem in Elements)
                {
                    elem.WriteXml(writer);
                }
            }
        }
    }
}
