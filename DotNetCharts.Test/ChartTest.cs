using System;
using System.Collections.Generic;
using DotNetCharts.ChartElements;
using DotNetCharts.Test.TestData;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace DotNetCharts.Test
{
    internal class Tests
    {
        #region Line Charts

        private static IEnumerable<TestCaseData> CanCreateLineCharts => ChartTestData.CreateLineChartSucceeds;

        [TestCaseSource(nameof(CanCreateLineCharts))]
        public string CanCreateLineChart(Chart chart)
        {
            PrintTestDetails();
            var xml = chart.ToSvg();
            WriteFileOut(xml, TestContext.CurrentContext.Test.Name);
            return xml;
        }

        private static IEnumerable<TestCaseData> CanNotCreateLineCharts => ChartTestData.CreateLineChartFails;

        [TestCaseSource(nameof(CanNotCreateLineCharts))]
        public void CanNotCreateLineChart(ChartSeries[] series, string[] labels)
        {
            PrintTestDetails();
            object TestDelegate() => new LineChart(series, labels);
            Assert.That((ActualValueDelegate<object>) TestDelegate, Throws.TypeOf<ArgumentNullException>());
        }

        private static IEnumerable<TestCaseData> DebugData1 => ChartTestData.DebugTestData1;
        private static IEnumerable<TestCaseData> DebugData2 => ChartTestData.DebugTestData2;

        [TestCaseSource(nameof(DebugData1))]
        public void DebugTest1(ChartSeries[] series, string[] labels)
        {
            PrintTestDetails();
            var chart = new LineChart(series, labels, true) 
            { 
                Height = 600, 
                Width = 1000,
                YAxis =
                {
                    LabelStyle = { Size = 11, Font = "Algerian" },
                    MinorTickStyle = { StrokeWidth = 0.25, Length = 3 },
                    MajorTickStyle = { StrokeWidth = 1, Length = 5 }
                },
            };
            var svg = chart.ToSvg();
            //WriteFileOut(svg, TestContext.CurrentContext.Test.Name);
            Assert.IsNotNull(svg);
        }


        [TestCaseSource(nameof(DebugData2))]
        public void DebugTest2(Chart chart)
        {
            PrintTestDetails();
            var svg = chart.ToSvg();
            WriteFileOut(svg, TestContext.CurrentContext.Test.Name);
            Assert.IsNotNull(svg);
        }

        #endregion

        private void WriteFileOut(string xml, string name)
        {
            using var file = new System.IO.StreamWriter($"../../../{name}.xml", false);
            file.WriteLine(xml);
        }

        private void PrintTestDetails()
        {
            TestContext.Out.WriteLine(TestContext.CurrentContext.Test.Name);
            TestContext.Out.WriteLine("");
            TestContext.Out.WriteLine(TestContext.CurrentContext.Test.Properties.Get("Description"));
        }
    }
}