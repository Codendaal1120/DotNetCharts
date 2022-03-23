using System;

namespace DotNetCharts.ChartElements
{
    /// <summary>
    /// Represents a graph line between two data points
    /// </summary>
    internal class CurvedLine : ChartLine
    {
        public override LineType Type => LineType.Curved;
        public DataPoint FirstControlPoint { get; }
        public DataPoint SecondControlPoint { get; }
        public double Smoothing { get; }

        public CurvedLine(DataPoint pointA, DataPoint pointB, DataPoint pointC, DataPoint pointD, DataPoint originPoint)
        {
            Smoothing = 0.2;
            StartPoint = pointC;
            CompletePoint = originPoint;
            FirstControlPoint = GetControlPoint(pointA, pointB, pointC, false);
            SecondControlPoint = GetControlPoint(pointB, pointC, pointD, true);
        }

        private DataPoint GetControlPoint(DataPoint previousPoint, DataPoint currentPoint, DataPoint nextPoint, bool reverse)
        {
            var opposingLine = GetOpposingLine(
                previousPoint ?? currentPoint,
                nextPoint ?? currentPoint);

            // If is end-control-point, add PI to the angle to go backward
            var angle = reverse ? Math.PI + opposingLine.Angle : opposingLine.Angle;
            var length = opposingLine.Length * Smoothing;

            var x = currentPoint.X + Math.Cos(angle) * length;
            var y = currentPoint.Y + Math.Sin(angle) * length;

            return new DataPoint(x, y);
        }

        private OpposingLine GetOpposingLine(DataPoint pointA, DataPoint pointB)
        {
            var lengthX = pointB.X - pointA.X;
            var lengthY = pointB.Y - pointA.Y;

            return new OpposingLine(
                Math.Sqrt(Math.Pow(lengthX, 2) + Math.Pow(lengthY, 2)),
                Math.Atan2(lengthY, lengthX));
        }

    }
}
