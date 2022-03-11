using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using DotNetCharts.Style;

namespace DotNetCharts.Svg
{
    [XmlRoot(ElementName = "g")]
    internal class Group : Element
    {
        public override ElementStyle Style { get; }
        public List<Element> Elements = new List<Element>();

        public Group(string[] classes = null, ElementStyle style = null)
        {
            RootName = "g";
            Classes = classes;
            Style = style;
        }

        public override void WriteXml(XmlWriter writer)
        {
            WriteXmlAttributes(writer);

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