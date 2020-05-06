using System;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using NetCharts.Style;

namespace NetCharts.Svg
{
    internal abstract class Element : IXmlSerializable
    {
        public string Id { get; protected set; }
        public string RootName { get; protected set; }
        public string[] Classes { get; protected set; }
        public abstract ElementStyle Style { get; }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotSupportedException();
        }

        public abstract void WriteXml(XmlWriter writer);

        protected void WriteXmlAttributes(XmlWriter writer)
        {
            writer.WriteStartElement(RootName);
            WriteClasses(writer);
            WriteStyle(writer);
        }

        private void WriteStyle(XmlWriter writer)
        {
            if (Style == null) return;

            foreach (var attribute in Style.StyleAttributes)
            {
                writer.WriteAttributeString(attribute.Key, attribute.Value);
            }
        }

        private void WriteClasses(XmlWriter writer)
        {
            var classString = $"{RootName} ";
            if (Classes != null && Classes.Any())
            {
                classString += string.Join(" ", Classes);
            }
            writer.WriteAttributeString("class", classString);
        }
    }
}
