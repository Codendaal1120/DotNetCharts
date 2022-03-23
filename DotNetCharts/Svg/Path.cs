using System;
using System.Linq;
using System.Xml;
using DotNetCharts.ChartElements;
using DotNetCharts.Style;

namespace DotNetCharts.Svg
{
    internal class Path : Element
    {
        public override ElementStyle Style { get; }

        private string _pathString;

        /// <summary>
        /// A collection of lines to form a path
        /// </summary>
        /// <param name="id">The svg element id</param>
        /// <param name="root">the root node name</param>
        /// <param name="startPoint">The starting point of the path</param>
        /// <param name="style">Path style</param>
        /// <param name="classes">css Classes</param>
        private Path(string id, string root, DataPoint startPoint, ElementStyle style = null, string[] classes = null)
        {
            Id = id;
            RootName = root;

            if (startPoint == null) throw new ArgumentNullException(nameof(startPoint));

            if (style == null)
            {
                style = new ElementStyle();
            }
            Style = style;
            _pathString = $"M {startPoint} ";
            Classes = classes;
        }

        public Path(
            string id, 
            DataPoint startPoint, 
            CurvedLine[] lines, 
            StraightLine[] fillLines = null,
            ElementStyle style = null,
            string[] classes = null) : this(id, "path", startPoint, style)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));
            Classes = classes;
            _pathString += string.Join(" ", lines.Select(x => $"C {x.FirstControlPoint} {x.SecondControlPoint} {x.StartPoint}"));
            AddFillLinesToPathString(fillLines);
        }

        public Path(
            string id, 
            DataPoint startPoint, 
            StraightLine[] lines,
            StraightLine[] fillLines = null,
            ElementStyle style = null,
            string[] classes = null) : this(id, "path", startPoint, style, classes: classes)
        {
            if (lines == null) throw new ArgumentNullException(nameof(lines));
            _pathString += string.Join(" ", lines.Select(x => $"L {x.StartPoint} {x.EndPointPoint}"));
            AddFillLinesToPathString(fillLines);
        }

        public Path(
            string id,
            DataPoint startPoint,
            DataPoint endPoint,
            ElementStyle style = null,
            string[] classes = null) : this(id, "path", startPoint, style, classes: classes)
        {
            _pathString += $"L {startPoint} {endPoint}";
        }

        public override void WriteXml(XmlWriter writer)
        {
            WriteXmlAttributes(writer);
            if (!string.IsNullOrWhiteSpace(Id)) writer.WriteAttributeString("id", Id);
            writer.WriteAttributeString("d", _pathString);
            writer.WriteEndElement();
        }

        private void AddFillLinesToPathString(StraightLine[] fillLines)
        {
            if (fillLines == null || !fillLines.Any())
            {
                return;
            }

            //Add the points in reverse order
            for (var i = fillLines.Length-1; i > 0; i--)
            {
                _pathString += $" L {fillLines[i].EndPointPoint} {fillLines[i].StartPoint}";
            }
        }
    }
}
