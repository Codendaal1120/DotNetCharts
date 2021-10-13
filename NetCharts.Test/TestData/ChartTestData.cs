using System;
using System.Collections.Generic;
using System.IO;
using NetCharts.ChartElements;
using NetCharts.Component;
using NetCharts.Style;
using Newtonsoft.Json;
using NUnit.Framework;

namespace NetCharts.Test.TestData
{
    internal static class ChartTestData
    {
        //todo: test legend on sides
        //todo : test all legend icon types
        //TODO : Test curves with single point

        #region Line chart data

        public static IEnumerable<TestCaseData> CreateLineChartSucceeds
        {
            get
            {
                yield return LineChartWithAllElements();
                yield return BasicLineChart();
                yield return BasicCurvedLineChart();
                yield return CurvedLineChartWithDataPoints();
                yield return CurvedLineChartWithMultipleSeries();
                yield return StraightLineChartWithCustomDataPoints();
                yield return BasicLineCharWithXStartOnMinor();
                yield return BasicLineChartWithDashedAndDottedGridlines();
                yield return ChartWithPartialSeries();
                yield return LineChartWithDashSeries();
                yield return DocumentationSample1();
                yield return DocumentationSample2();
                yield return DocumentationSample3();
                yield return DocumentationSample4();
            }
        }

        /// <summary>
        /// Test case 1
        /// </summary>
        private static TestCaseData LineChartWithAllElements()
        {
            var testData = GetTestDataSet1();

            var chart = new LineChart(testData.series, testData.labels, drawDefaultDataPointLabels: true, drawDefaultDataMarkers: true)
            {
                Height = 500,
                Width = 800,
                BackgroundColor = "#CCCCCC",
                LineType = LineType.Straight,
                Legend = { LegendIcon = LegendIcon.Circle, LabelStyle = { }},
                XAxis =
                {
                    MinorTickStyle = { StrokeWidth = 0.25, Length = 3 },
                    MajorTickStyle = { StrokeWidth = 0.5, Length = 5 }
                },
                YAxis =
                {
                    MinorTickStyle = { StrokeWidth = 0.25, Length = 3 },
                    MajorTickStyle = { StrokeWidth = 0.5, Length = 5 }
                },
                ChartArea =
                {
                    ChartAreaStyle = { StrokeWidth = 0.5 },
                    XGridLineStyle = { MajorLineStyle = { StrokeWidth = 0.5 }, MinorLineStyle = { StrokeWidth = 0.25 }},
                    YGridLineStyle = { MajorLineStyle = { StrokeWidth = 0.5 }, MinorLineStyle = { StrokeWidth = 0.25 }},
                },
                Title = { Text = "Test Case 1",  },
                DrawDebug = false
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 1 - Test most chart features");
            testCase.SetDescription("Test case 1 : line chart with 3 series and the following all elements draw :\r\n" +
                                    "- Straight lines\r\n" +
                                    "- DataPoints drawn\r\n" +
                                    "- DataPointLabels drawn\r\n" +
                                    "- Major and minor X grid lines\r\n" +
                                    "- Major and minor Y grid lines\r\n" +
                                    "- X axis with labels, minor and major ticks\r\n" +
                                    "- Y axis with labels, minor and major ticks\r\n" +
                                    "- Legend with label and circle icon\r\n");
            testCase.ExpectedResult = GetExpectedResults("TestCase-1.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 2
        /// </summary>
        private static TestCaseData BasicLineChart()
        {
            var testData = GetTestDataSet2();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 500,
                Width = 800,
                ChartArea = { 
                    SeriesStyles = new[]
                    {
                        new LineSeriesStyle()
                        {
                            LabelStyle =
                            {
                                Fill = "black", 
                                Size = 3
                            },
                            DataPointLabelPosition = Position.Bottom,
                            ElementStyle =
                            {
                                Fill = "none", 
                                StrokeColor = "green"
                            },
                            MarkerStyle = new MarkerStyle()
                            {
                                StrokeColor = "black",
                                Radius = 3
                            }
                        }, 
                    }
                },
                XAxis =
                {
                    LabelStyle = { Size = 16, Fill = "black" },
                    MajorTickStyle = { StrokeWidth = 1, Length = 5, StrokeColor = "green" },
                    BaseLineStyle = { StrokeWidth = 1, StrokeColor = "green" }
                },
                YAxis =
                {
                    LabelStyle = { Size = 16, Fill = "black" },
                    MajorTickStyle = { StrokeWidth = 1, Length = 5, StrokeColor = "green" },
                    BaseLineStyle = { StrokeWidth = 1, StrokeColor = "green" }
                },
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 2 - Test default straight line chart");
            testCase.SetDescription("Test case 2 : line chart with 1 series and the following all elements draw :\r\n" +
                                    "- Straight lines\r\n" +
                                    "- X axis with labels, and major ticks\r\n" +
                                    "- Y axis with labels, and major ticks\r\n" +
                                    "- Legend with label and circle icon\r\n");
            testCase.ExpectedResult = GetExpectedResults("TestCase-2.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 3
        /// </summary>
        private static TestCaseData BasicCurvedLineChart()
        {
            var testData = GetTestDataSet2();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 600,
                Width = 1180,
                LineType = LineType.Curved,
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 3 - Test default curved line chart");
            testCase.SetDescription("Test case 3 : line chart with 1 series and the following all elements draw :\r\n" +
                                    "- curved lines\r\n" +
                                    "- X axis with labels, and major ticks\r\n" +
                                    "- Y axis with labels, and major ticks\r\n" +
                                    "- Legend with label and circle icon\r\n");
            testCase.ExpectedResult = GetExpectedResults("TestCase-3.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 4
        /// </summary>
        private static TestCaseData CurvedLineChartWithDataPoints()
        {
            //TODO : DataPoints are not drawn at the correct position

            var testData = GetTestDataSet2();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 500,
                Width = 800,
                LineType = LineType.Curved,
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 4 - Test data markers");
            testCase.SetDescription("Test case 4 : line chart with 1 series and the following all elements draw :\r\n" +
                                    "- curved lines\r\n" +
                                    "- DataPoints drawn\r\n" +
                                    "- X axis with labels, and major ticks\r\n" +
                                    "- Y axis with labels, and major ticks\r\n" +
                                    "- Legend with label and circle icon\r\n");
            testCase.ExpectedResult = GetExpectedResults("TestCase-4.xml");
            return testCase;
        }
        
        /// <summary>
        /// Test case 5
        /// </summary>
        private static TestCaseData CurvedLineChartWithMultipleSeries()
        {
            var testData = GetTestDataSet3();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 500,
                Width = 800,
                LineType = LineType.Curved,
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 5 - Test multiple series");
            testCase.SetDescription("Test case 5 : Curved line chart with 3 series with long names to force legend overflow :\r\n" +
                                    "- curved lines\r\n" +
                                    "- X axis with labels, and major ticks\r\n" +
                                    "- Y axis with labels, and major ticks\r\n" +
                                    "- Legend with label and circle icon\r\n");
            testCase.ExpectedResult = GetExpectedResults("TestCase-5.xml");
            return testCase;
        }
        
        /// <summary>
        /// Test case 6
        /// </summary>
        private static TestCaseData StraightLineChartWithCustomDataPoints()
        {
            var testData = GetTestDataSet1();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 500,
                Width = 800,
                LineType = LineType.Straight,
                ChartArea = { SeriesStyles = new[]
                {
                    new LineSeriesStyle() { ElementStyle = { StrokeColor = "#3454D1" }, MarkerStyle = { StrokeWidth = 0 }, LabelStyle = { Size = 9, StrokeColor = "black" }, DataPointLabelPosition = Position.Centre },
                    new LineSeriesStyle() { ElementStyle = { StrokeColor = "#34D1BF" }, MarkerStyle = { StrokeWidth = 0 }, LabelStyle = { Size = 9, StrokeColor = "black" }, DataPointLabelPosition = Position.Centre },
                }}
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 6 - Test custom series style.");
            testCase.SetDescription("Test case 6 : Straight line chart with custom data points, only dataPoint labels are drawn in centre position");
            testCase.ExpectedResult = GetExpectedResults("TestCase-6.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 7
        /// </summary>
        private static TestCaseData BasicLineCharWithXStartOnMinor()
        {
            var testData = GetTestDataSet2();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 500,
                Width = 800,
                DrawDebug = false,
                PaddingRight = 15,
                XAxis =
                {
                    StartOnMajor = true,
                },
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 7 - Test xAxis start on major.");
            testCase.SetDescription("Test case 7 : Basic line chart with XAxis Starting on the major tick, as apposed to the default minor tick");
            testCase.ExpectedResult = GetExpectedResults("TestCase-7.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 8
        /// </summary>
        private static TestCaseData BasicLineChartWithDashedAndDottedGridlines()
        {
            var testData = GetTestDataSet2();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 500,
                Width = 800,
                DrawDebug = false,
                PaddingRight = 15,
                ChartArea =
                {
                    YGridLineStyle =
                    {
                        MajorLineStyle = { StrokeWidth = 0.7, StrokeStyle = LineStyle.Dashed }, 
                        MinorLineStyle = { StrokeWidth = 0.5, StrokeStyle = LineStyle.Dotted }
                    }
                }
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 8 - Test path stroke style");
            testCase.SetDescription("Test case 8 : Basic line chart with dashed major and dotted minor gridlines");
            testCase.ExpectedResult = GetExpectedResults("TestCase-8.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 9
        /// </summary>
        private static TestCaseData ChartWithPartialSeries()
        {
            var testData = GetTestDataSet4();

            var chart = new LineChart(testData.series, testData.labels);
            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 9 - Test partial series");
            testCase.SetDescription("Test case 9 : Test chart with partial series");
            testCase.ExpectedResult = GetExpectedResults("TestCase-9.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 12
        /// </summary>
        private static TestCaseData LineChartWithDashSeries()
        {
            var testData = GetTestDataSet2();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 500,
                Width = 800,
                ChartArea = {
                    ChartAreaStyle = { StrokeWidth = 0.5 },
                    SeriesStyles = new[]
                    {
                        new LineSeriesStyle()
                        {
                            LabelStyle =
                            {
                                Fill = "black",
                                Size = 3
                            },
                            DataPointLabelPosition = Position.Bottom,
                            ElementStyle =
                            {
                                Fill = "none",
                                StrokeColor = "green",
                                StrokeStyle = LineStyle.Dashed
                            },
                            MarkerStyle = new MarkerStyle()
                            {
                                StrokeColor = "black",
                                Radius = 3
                            }
                        },
                    }
                },
                XAxis =
                {
                    LabelStyle = { Size = 16, Fill = "black" },
                    MajorTickStyle = { StrokeWidth = 1, Length = 5, StrokeColor = "green" },
                    BaseLineStyle = { StrokeWidth = 1, StrokeColor = "green" }
                },
                YAxis =
                {
                    LabelStyle = { Size = 16, Fill = "black" },
                    MajorTickStyle = { StrokeWidth = 1, Length = 5, StrokeColor = "green" },
                    BaseLineStyle = { StrokeWidth = 1, StrokeColor = "green" }
                },
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 12 - Test dashed line type");
            testCase.SetDescription("Test case 12 : line chart with 1 series dashed line");
            testCase.ExpectedResult = GetExpectedResults("TestCase-12.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 20
        /// </summary>
        private static TestCaseData DocumentationSample1()
        {
            var testData = DocumentationSampleDataSet1();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 500,
                Width = 800,
                LineType = LineType.Straight,
                ChartArea = { 
                    SeriesStyles = new[] 
                    {
                        new LineSeriesStyle()
                        {
                            ElementStyle = { StrokeColor = "#4674C5", StrokeWidth = 3, StrokeOpacity = 1 }, 
                            MarkerStyle = { StrokeWidth = 0 }, 
                            LabelStyle = { Size = 9, StrokeColor = "#3D3D3D" }, DataPointLabelPosition = Position.Centre
                        },

                    },
                    YGridLineStyle = { MajorLineStyle = { StrokeWidth = 0.7 }, MinorLineStyle = { StrokeWidth = 0.1 }}
                },
                DrawDebug = false

            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 20 - Documentation sample 1.");
            testCase.SetDescription("Test case 20 : Straight line chart with custom data points, only dataPoint labels are drawn in centre position");
            testCase.ExpectedResult = GetExpectedResults("TestCase-20.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 21
        /// </summary>
        private static TestCaseData DocumentationSample2()
        {
            var testData = DocumentationSampleDataSet2();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 300,
                Width = 1500,
                LineType = LineType.Curved,
                PaddingRight = 15,
                XAxis = { StartOnMajor = true },
                ChartArea = {
                    SeriesStyles = new[]
                    {
                        new LineSeriesStyle()
                        {
                            ElementStyle = { StrokeColor = "none", StrokeWidth = 1, Fill = "#4674C5", FillOpacity = 0.4 }, 
                            MarkerStyle = { StrokeWidth = 0 }, 
                            LabelStyle = { Size = 0, StrokeColor = "#3D3D3D" }, 
                            DataPointLabelPosition = Position.Centre
                        },
                        new LineSeriesStyle()
                        {
                            ElementStyle = { StrokeColor = "none", StrokeWidth = 1, Fill = "#267F00", FillOpacity = 0.4 },
                            MarkerStyle = { StrokeWidth = 0 },
                            LabelStyle = { Size = 0, StrokeColor = "#3D3D3D" },
                            DataPointLabelPosition = Position.Centre
                        },

                    },
                    YGridLineStyle =
                    {
                        MajorLineStyle = { StrokeWidth = 0.7, StrokeStyle = LineStyle.Dashed },
                        MinorLineStyle = { StrokeWidth = 0 }
                    }
                },
                DrawDebug = false

            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 21 - Documentation sample 2.");
            testCase.SetDescription("Test case 21 : Curved line chart with custom data points, only dataPoint labels are drawn in centre position");
            testCase.ExpectedResult = GetExpectedResults("TestCase-21.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 22
        /// </summary>
        private static TestCaseData DocumentationSample3()
        {
            var testData = DocumentationSampleDataSet1();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 300,
                Width = 1500,
                LineType = LineType.Curved,
                PaddingRight = 15,
                XAxis = { StartOnMajor = true },
                ChartArea = {
                    SeriesStyles = new[]
                    {
                        new LineSeriesStyle()
                        {
                            ElementStyle = { StrokeColor = "none", StrokeWidth = 1, Fill = "#4674C5", FillOpacity = 0.4 },
                            MarkerStyle = { StrokeWidth = 2, StrokeColor = "white", Fill = "#4674C5", Radius = 3 },
                            LabelStyle = { Size = 0, StrokeColor = "#3D3D3D" },
                            DataPointLabelPosition = Position.Centre
                        }
                    }
                },
                DrawDebug = false
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 22 - Documentation sample 3.");
            testCase.SetDescription("Test case 22 : Curved line with a fill, where the min value is 0");
            testCase.ExpectedResult = GetExpectedResults("TestCase-22.xml");
            return testCase;
        }

        /// <summary>
        /// Test case 23
        /// </summary>
        private static TestCaseData DocumentationSample4()
        {
            var testData = DocumentationSampleDataSet3();

            var chart = new LineChart(testData.series, testData.labels)
            {
                Height = 300,
                Width = 1500,
                LineType = LineType.Curved,
                PaddingRight = 25,
                XAxis = { StartOnMajor = true },
                ChartArea = {
                    SeriesStyles = new[]
                    {
                        new LineSeriesStyle()
                        {
                            ElementStyle = { StrokeColor = "none", StrokeWidth = 1, Fill = "#4674C5", FillOpacity = 0.4 },
                            MarkerStyle = { StrokeWidth = 2, StrokeColor = "white", Fill = "#4674C5", Radius = 3 },
                            LabelStyle = { Size = 0, StrokeColor = "#3D3D3D" },
                            DataPointLabelPosition = Position.Centre
                        }
                    }
                }
                ,
                DrawDebug = false
            };

            var testCase = new TestCaseData(chart);

            testCase.SetName("TestCase 23 - Documentation sample 4.");
            testCase.SetDescription("Test case 23 : Curved line with a fill, where the min value more than 0");
            testCase.ExpectedResult = GetExpectedResults("TestCase-23.xml");
            return testCase;
        }

        public static IEnumerable<TestCaseData> CreateLineChartFails
        {
            get
            {
                yield return LineChartDataWithNullLabels();
                yield return LineChartDataWithNullSeries();
            }
        }

        /// <summary>
        /// Test case 10
        /// </summary>
        private static TestCaseData LineChartDataWithNullSeries()
        {
            var testData = GetTestDataSet1();

            var testCase = new TestCaseData(null, testData.labels);

            testCase.SetName("TestCase 10 - Line chart with NULL series and valid labels");
            testCase.SetDescription("Test case 10 : Argument exception expected");
            return testCase;
        }

        /// <summary>
        /// Test case 11
        /// </summary>
        private static TestCaseData LineChartDataWithNullLabels()
        {
            var testCase = new TestCaseData(GetTestDataSet1().series, null);

            testCase.SetName("TestCase 11 - Line chart with NULL values and valid series");
            testCase.SetDescription("Test case 11 : Argument exception expected");
            return testCase;
        }

        #endregion

        #region Debug

        public static IEnumerable<TestCaseData> DebugTestData
        {
            get
            {
                yield return DebugXAxisLabels();
                yield return DebugPartialSeriesJoining();
                yield return DebugTest3();
                yield return DebugTest4();
                yield return DebugTest5();
                yield return DebugTest6();
            }
        }

        /// <summary>
        /// Debug: 1 Axis Labels not centered
        /// </summary>
        private static TestCaseData DebugXAxisLabels()
        {
            var series = JsonConvert.DeserializeObject<ChartSeries[]>("[ { 'seriesName': 'Skynet', 'dataValues': [ null, null, null, null, null, null, null, null, 82.0, 55.0, 128.0, 3.0, 139.0, 90.0 ], 'dataPoints': [], 'style': null, 'color': null } ]");
            var labels = JsonConvert.DeserializeObject<string[]>("[ 'Mar 2019', 'Apr 2019', 'May 2019', 'Jun 2019', 'Jul 2019', 'Aug 2019', 'Sep 2019', 'Oct 2019', 'Nov 2019', 'Dec 2019', 'Jan 2020', 'Feb 2020', 'Mar 2020', 'Apr 2020' ]");

            var testCase = new TestCaseData(series, labels);

            testCase.SetName("Debug 1 - Axis Labels not centered");
            testCase.SetDescription("Debug 1 - Axis Labels not centered");
            return testCase;
        }

        /// <summary>
        /// Debug: Partial series joining
        /// </summary>
        private static TestCaseData DebugPartialSeriesJoining()
        {
            var series = JsonConvert.DeserializeObject<ChartSeries[]>("[ { 'seriesName': '2019-2020', 'dataValues': [ null, null, null, 82.0, 55.0, 128.0, 3.0, 139.0, 90.0, null, null, null ], 'dataPoints': [], 'style': null, 'color': null }, { 'seriesName': 'Forecast usage', 'dataValues': [ null, null, null, null, null, null, null, null, 90.0, 77.33, 102.11, 89.81 ], 'dataPoints': [], 'style': null, 'color': null } ]");
            var labels = JsonConvert.DeserializeObject<string[]>("[ 'Aug 2019', 'Sep 2019', 'Oct 2019', 'Nov 2019', 'Dec 2019', 'Jan 2020', 'Feb 2020', 'Mar 2020', 'Apr 2020', 'May 2020', 'Jun 2020', 'Jul 2020' ]");

            var testCase = new TestCaseData(series, labels);

            testCase.SetName("Debug 2 - 2 partial series");
            testCase.SetDescription("Debug 2 - 2 partial series needs to appear like a single line, but the first series adds 0 instead of nulls at the end");
            return testCase;
        }

        /// <summary>
        /// Debug: Argument exception
        /// </summary>
        private static TestCaseData DebugTest3()
        {
            var series = JsonConvert.DeserializeObject<ChartSeries[]>("[{\"SeriesName\":\"2019-2020\",\"DataValues\":[null,null,null,null,1.0,0.0,0.0,0.0,2.0,null,null,null],\"DataPoints\":[],\"Style\":null,\"Color\":null},{\"SeriesName\":\"Forecast usage\",\"DataValues\":[null,null,null,null,null,null,null,null,2.0,0.67,0.89,1.19],\"DataPoints\":[],\"Style\":null,\"Color\":null},{\"SeriesName\":\"Trend\",\"DataValues\":[0.12,0.14,0.16,0.19,0.21,0.24,0.26,0.29,0.31,0.34,0.36,0.38],\"DataPoints\":[],\"Style\":{\"IsDefaultStyle\":false,\"LabelStyle\":{\"Font\":\"Arial\",\"Draw\":false,\"StrokeWidth\":0,\"WidthPixels\":0.0,\"HeightPixels\":0.0,\"Size\":0,\"Fill\":\"grey\",\"FillOpacity\":1.0,\"StrokeOpacity\":1.0,\"StrokeColor\":\"none\",\"HasFill\":true,\"Overflow\":0},\"DrawLabel\":false,\"DataPointLabelPosition\":0,\"MarkerStyle\":{\"Radius\":0.0,\"Fill\":\"none\",\"FillOpacity\":1.0,\"StrokeOpacity\":1.0,\"StrokeColor\":\"grey\",\"StrokeWidth\":0.0,\"Draw\":false,\"HasFill\":false,\"Overflow\":0},\"ElementStyle\":{\"Fill\":\"none\",\"FillOpacity\":1.0,\"StrokeOpacity\":0.4,\"StrokeColor\":\"#F37748\",\"StrokeWidth\":4.0,\"Draw\":true,\"HasFill\":false,\"Overflow\":0}},\"Color\":null}]");
            var labels = JsonConvert.DeserializeObject<string[]>("[\"Sep 2019\",\"Oct 2019\",\"Nov 2019\",\"Dec 2019\",\"Jan 2020\",\"Feb 2020\",\"Mar 2020\",\"Apr 2020\",\"May 2020\",\"Jun 2020\",\"Jul 2020\",\"Aug 2020\"]");

            var testCase = new TestCaseData(series, labels);

            testCase.SetName("Debug 3 - Exception during YAxis export");
            testCase.SetDescription("Exception when exporting YAxis data");
            return testCase;
        }

        /// <summary>
        /// Debug: Incorrect dataPoints
        /// </summary>
        private static TestCaseData DebugTest4()
        {
            var series = JsonConvert.DeserializeObject<ChartSeries[]>("[ { \"seriesName\": \"Usage\", \"dataValues\": [ 1332.0, 1536.0, 1631.0, 1900.0, 2367.0, 2285.0, 4245.0, 5499.0, 4595.0, null, null, null, null, null ], \"dataPoints\": [], \"style\": null, \"color\": null } ]");
            var labels = JsonConvert.DeserializeObject<string[]>("[ \"Apr 2019\", \"May 2019\", \"Jun 2019\", \"Jul 2019\", \"Aug 2019\", \"Sep 2019\", \"Oct 2019\", \"Nov 2019\", \"Dec 2019\", \"Jan 2020\", \"Feb 2020\", \"Mar 2020\", \"Apr 2020\", \"May 2020\" ]");

            var testCase = new TestCaseData(series, labels);

            testCase.SetName("Debug 4 - DataPoints looks wrong");
            testCase.SetDescription("Testing dataPoints");
            return testCase;
        }

        /// <summary>
        /// Debug : Weird series
        /// </summary>
        private static TestCaseData DebugTest5()
        {
            var series = new[]
            {
                new ChartSeries("Usage", new double?[]{ null, null, null, null, null, null, null, null, 1.0, 0, 0, 0, 2, 386 }), 
            };

            var labels = new[]
            {
                "Apr 2019","May 2019","Jun 2019","Jul 2019","Aug 2019","Sep 2019","Oct 2019","Nov 2019","Dec 2019","Jan 2020","Feb 2020","Mar 2020","Apr 2020","May 2020"
            };

            var testCase = new TestCaseData(series, labels);

            testCase.SetName("Debug 5 - Weird series");
            testCase.SetDescription("Testing dataPoints");
            return testCase;
        }

        /// <summary>
        /// Debug : Small scale
        /// </summary>
        private static TestCaseData DebugTest6()
        {
            var series = new[]
            {
                new ChartSeries("Usage", new double?[]{ null, null, null, null, null, null, null, null, 2, 6, 0, 1, 5, 19 }),
            };

            var labels = new[]
            {
                "Apr 2019","May 2019","Jun 2019","Jul 2019","Aug 2019","Sep 2019","Oct 2019","Nov 2019","Dec 2019","Jan 2020","Feb 2020","Mar 2020","Apr 2020","May 2020"
            };

            var testCase = new TestCaseData(series, labels);

            testCase.SetName("Debug 6 - Small scale");
            testCase.SetDescription("Testing small scale with minor interval less than 1");
            return testCase;
        }

        #endregion Debug

        private static string GetExpectedResults(string fileName)
        {
            var fullName = $"ExpectedResults/{fileName}";
            return File.Exists(fullName) 
                ? File.ReadAllText(fullName).Trim() 
                : $"INVALID EXPECTED RESULTS AT {DateTime.Now}";
        }

        /// <summary>
        /// 3 chart series
        /// </summary>
        /// <returns></returns>
        private static (ChartSeries[] series, string[] labels) GetTestDataSet1()
        {
            var series = new[]
            {
                new ChartSeries("VeryVeryVeryVeryVeryVeryLongSeries1", new double?[]
                {
                    0,
                    0,
                    20,
                    25,
                    5,
                    60,
                    30
                }),
                new ChartSeries("VeryVeryVeryVeryVeryVeryLongSeries2", new double?[]
                {
                    0.0,
                    10,
                    25,
                    23,
                    27,
                    62,
                    5
                }),
                new ChartSeries("VeryVeryVeryVeryVeryVeryLongSeries3", new double?[]
                {
                    3,
                    11,
                    13,
                    18,
                    9,
                    0.0,
                    1
                })
            };

            var labels = new[]
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven"
            };

            return (series, labels);
        }

        /// <summary>
        /// 1 chart series
        /// </summary>
        /// <returns></returns>
        private static (ChartSeries[] series, string[] labels) GetTestDataSet2()
        {
            var series = new[]
            {
                new ChartSeries("Series1", new double?[]
                {
                    10.0,
                    0,
                    20,
                    25,
                    5,
                    60,
                    30
                })
            };

            var labels = new[]
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven"
            };

            return (series, labels);
        }

        /// <summary>
        /// 3 chart series
        /// </summary>
        /// <returns></returns>
        private static (ChartSeries[] series, string[] labels) GetTestDataSet3()
        {
            var series = new[]
            {
                new ChartSeries("VeryVeryVeryVeryVeryVeryLongSeries1", new double?[]
                {
                    10.0,
                    0,
                    20,
                    25,
                    5,
                    60,
                    30
                }),
                new ChartSeries("VeryVeryVeryVeryVeryVeryLongSeries2", new double?[]
                {
                    0.0,
                    10,
                    25,
                    23,
                    27,
                    62,
                    5
                }),
                new ChartSeries("VeryVeryVeryVeryVeryVeryLongSeries3", new double?[]
                {
                    3,
                    11,
                    13,
                    18,
                    9,
                    0.0,
                    1
                })
            };

            var labels = new[]
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven"
            };

            return (series, labels);
        }

        /// <summary>
        /// 3 chart series, with partial data sets
        /// </summary>
        /// <returns></returns>
        private static (ChartSeries[] series, string[] labels) GetTestDataSet4()
        {
            var series = new[]
            {
                new ChartSeries("Series1", new double?[]
                {
                    null,
                    null,
                    20,
                    25,
                    5,
                    60,
                    30
                }),
                new ChartSeries("Series2", new double?[]
                {
                    0.0,
                    10,
                    null,
                    null,
                    27,
                    62,
                    null
                }),
                new ChartSeries("Series3", new double?[]
                {
                    3,
                    11,
                    13,
                    18,
                    9,
                    0.0,
                    1
                })
            };

            var labels = new[]
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven"
            };

            return (series, labels);
        }

        /// <summary>
        /// 1 chart series
        /// </summary>
        /// <returns></returns>
        private static (ChartSeries[] series, string[] labels) DocumentationSampleDataSet1()
        {
            var series = new[]
            {
                new ChartSeries("Usage", new double?[]
                {
                    10.0,
                    0,
                    15,
                    105,
                    133,
                    292,
                    227,
                    215,
                    237,
                    320,
                    295,
                    371,
                    740,
                    1146
                })
            };

            var labels = new[]
            {
                "Oct-19",
                "Nov-19",
                "Dec-19",
                "Jan-20",
                "Feb-20",
                "Mar-20",
                "Apr-20",
                "May-20",
                "Jun-20",
                "Jul-20",
                "Aug-20",
                "Sep-20",
                "Oct-20",
                "Nov-20"
            };

            return (series, labels);
        }

        /// <summary>
        /// 2 chart series
        /// </summary>
        /// <returns></returns>
        private static (ChartSeries[] series, string[] labels) DocumentationSampleDataSet2()
        {
            var series = new[]
            {
                new ChartSeries("Fuel usage", new double?[]
                {
                    20, 30, 40, 25, 33, 55, 29
                }),
                new ChartSeries("Diesel usage", new double?[]
                {
                    0, 25, 52, 66, 32, 10, 13
                })
            };

            var labels = new[]
            {
                "1 Jan",
                "2 Jan",
                "3 Jan",
                "4 Jan",
                "5 Jan",
                "6 Jan",
                "7 Jan"
            };

            return (series, labels);
        }

        /// <summary>
        /// 1 chart series, with min > 0
        /// </summary>
        /// <returns></returns>
        private static (ChartSeries[] series, string[] labels) DocumentationSampleDataSet3()
        {
            var series = new[]
            {
                new ChartSeries("Usage", new double?[]
                {
                    700.0,
                    750,
                    750,
                    905,
                    833,
                    792,
                    727,
                    615,
                    837,
                    987
                })
            };

            var labels = new[]
            {
                "Feb-20",
                "Mar-20",
                "Apr-20",
                "May-20",
                "Jun-20",
                "Jul-20",
                "Aug-20",
                "Sep-20",
                "Oct-20",
                "Nov-20"
            };

            return (series, labels);
        }
    }
}
