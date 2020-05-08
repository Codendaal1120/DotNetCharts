using System;
using System.Collections.Generic;
using NetCharts.ChartElements;
using NetCharts.Test.TestData;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace NetCharts.Test
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