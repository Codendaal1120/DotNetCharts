using System;
using System.Collections.Generic;
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
                    XGridLineStyle = {  MajorLineStyle = { StrokeWidth = 0.5 }, MinorLineStyle = { StrokeWidth = 0.25 }},
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
            testCase.ExpectedResult =
                "<svg class=\".svg\" height=\"500\" width=\"800\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-minor-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-minor-tick-0\" d=\"M 38.24,475.97 L 38.24,475.97 38.24,478.97\"/><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0.5\" d=\"M 92.65,475.97 L 92.65,475.97 92.65,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"80.65725714285716\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">One</text><path class=\"path XAxis-minor-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-minor-tick-1\" d=\"M 147.06,475.97 L 147.06,475.97 147.06,478.97\"/><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1.5\" d=\"M 201.47,475.97 L 201.47,475.97 201.47,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"189.48057142857147\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Two</text><path class=\"path XAxis-minor-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-minor-tick-2\" d=\"M 255.88,475.97 L 255.88,475.97 255.88,478.97\"/><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2.5\" d=\"M 310.3,475.97 L 310.3,475.97 310.3,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"290.3097523809524\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Three</text><path class=\"path XAxis-minor-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-minor-tick-3\" d=\"M 364.71,475.97 L 364.71,475.97 364.71,478.97\"/><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3.5\" d=\"M 419.12,475.97 L 419.12,475.97 419.12,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"403.13013333333333\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Four</text><path class=\"path XAxis-minor-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-minor-tick-4\" d=\"M 473.53,475.97 L 473.53,475.97 473.53,478.97\"/><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4.5\" d=\"M 527.94,475.97 L 527.94,475.97 527.94,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"511.9534476190476\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Five</text><path class=\"path XAxis-minor-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-minor-tick-5\" d=\"M 582.35,475.97 L 582.35,475.97 582.35,478.97\"/><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5.5\" d=\"M 636.77,475.97 L 636.77,475.97 636.77,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"624.7738285714286\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Six</text><path class=\"path XAxis-minor-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-minor-tick-6\" d=\"M 691.18,475.97 L 691.18,475.97 691.18,478.97\"/><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6.5\" d=\"M 745.59,475.97 L 745.59,475.97 745.59,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"725.6030095238096\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Seven</text><path class=\"path XAxis-minor-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-minor-tick-7\" d=\"M 800,475.97 L 800,475.97 800,478.97\"/><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 38.24,475.97 L 38.24,475.97 800,475.97\"/><rect class=\"rect \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" height=\"374.4746\" width=\"761.7632\" transform=\"translate(38.2368 101.5)\"/><path class=\"path x-minor-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-minor--grid-0.5\" d=\"M 92.65,475.97 L 92.65,475.97 92.65,101.5\"/><path class=\"path x-major-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-major--grid-1\" d=\"M 147.06,475.97 L 147.06,475.97 147.06,101.5\"/><path class=\"path x-minor-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-minor--grid-1.5\" d=\"M 201.47,475.97 L 201.47,475.97 201.47,101.5\"/><path class=\"path x-major-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-major--grid-2\" d=\"M 255.88,475.97 L 255.88,475.97 255.88,101.5\"/><path class=\"path x-minor-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-minor--grid-2.5\" d=\"M 310.3,475.97 L 310.3,475.97 310.3,101.5\"/><path class=\"path x-major-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-major--grid-3\" d=\"M 364.71,475.97 L 364.71,475.97 364.71,101.5\"/><path class=\"path x-minor-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-minor--grid-3.5\" d=\"M 419.12,475.97 L 419.12,475.97 419.12,101.5\"/><path class=\"path x-major-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-major--grid-4\" d=\"M 473.53,475.97 L 473.53,475.97 473.53,101.5\"/><path class=\"path x-minor-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-minor--grid-4.5\" d=\"M 527.94,475.97 L 527.94,475.97 527.94,101.5\"/><path class=\"path x-major-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-major--grid-5\" d=\"M 582.35,475.97 L 582.35,475.97 582.35,101.5\"/><path class=\"path x-minor-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-minor--grid-5.5\" d=\"M 636.77,475.97 L 636.77,475.97 636.77,101.5\"/><path class=\"path x-major-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-major--grid-6\" d=\"M 691.18,475.97 L 691.18,475.97 691.18,101.5\"/><path class=\"path x-minor-grid-line grid-line\" fill=\"none\" stroke=\"grey\" stroke-width=\"0.25\" fill-opacity=\"1\" stroke-opacity=\"1\" stroke-dasharray=\"0,0\" id=\"x-minor--grid-6.5\" d=\"M 745.59,475.97 L 745.59,475.97 745.59,101.5\"/><path class=\"path series series-VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"none\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 92.65,475.97 L 92.65,475.97 201.47,475.97 L 201.47,475.97 310.3,475.97 L 310.3,475.97 419.12,475.97 L 419.12,475.97 527.94,475.97 L 527.94,475.97 636.77,475.97 L 636.77,475.97 745.59,475.97\"/><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"7:30\" cx=\"745.59\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"745.59\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">30</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"1:0\" cx=\"92.65\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"92.65\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">0</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"2:0\" cx=\"201.47\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"201.47\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">0</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"3:20\" cx=\"310.3\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"310.3\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">20</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"4:25\" cx=\"419.12\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"419.12\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">25</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"5:5\" cx=\"527.94\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"527.94\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">5</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"6:60\" cx=\"636.77\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"636.77\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">60</text><path class=\"path series series-VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"none\" stroke=\"#34D1BF\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 92.65,475.97 L 92.65,475.97 201.47,475.97 L 201.47,475.97 310.3,475.97 L 310.3,475.97 419.12,475.97 L 419.12,475.97 527.94,475.97 L 527.94,475.97 636.77,475.97 L 636.77,475.97 745.59,475.97\"/><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"7:5\" cx=\"745.59\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"745.59\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">5</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"1:0\" cx=\"92.65\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"92.65\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">0</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"2:10\" cx=\"201.47\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"201.47\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">10</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"3:25\" cx=\"310.3\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"310.3\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">25</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"4:23\" cx=\"419.12\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"419.12\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">23</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"5:27\" cx=\"527.94\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"527.94\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">27</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"6:62\" cx=\"636.77\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"636.77\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">62</text><path class=\"path series series-VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"none\" stroke=\"#D1345B\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 92.65,475.97 L 92.65,475.97 201.47,475.97 L 201.47,475.97 310.3,475.97 L 310.3,475.97 419.12,475.97 L 419.12,475.97 527.94,475.97 L 527.94,475.97 636.77,475.97 L 636.77,475.97 745.59,475.97\"/><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"#D1345B\" stroke=\"#D1345B\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"7:1\" cx=\"745.59\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"745.59\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">1</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"#D1345B\" stroke=\"#D1345B\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"1:3\" cx=\"92.65\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"92.65\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">3</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"#D1345B\" stroke=\"#D1345B\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"2:11\" cx=\"201.47\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"201.47\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">11</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"#D1345B\" stroke=\"#D1345B\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"3:13\" cx=\"310.3\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"310.3\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">13</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"#D1345B\" stroke=\"#D1345B\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"4:18\" cx=\"419.12\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"419.12\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">18</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"#D1345B\" stroke=\"#D1345B\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"5:9\" cx=\"527.94\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"527.94\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">9</text><circle class=\"circle data-point data-point_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"#D1345B\" stroke=\"#D1345B\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"6:0\" cx=\"636.77\" cy=\"475.97\" r=\"2\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"636.77\" y=\"466.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">0</text><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"107.62\" y=\"53.852666666666664\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">VeryVeryVeryVeryVeryVeryLongSeries1</text><circle class=\"circle \" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-VeryVeryVeryVeryVeryVeryLongSeries1\" cx=\"91.87\" cy=\"48.6164\" r=\"6.75\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"400\" y=\"53.852666666666664\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">VeryVeryVeryVeryVeryVeryLongSeries2</text><circle class=\"circle \" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-VeryVeryVeryVeryVeryVeryLongSeries2\" cx=\"384.25\" cy=\"48.6164\" r=\"6.75\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"253.81\" y=\"79.35266666666666\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">VeryVeryVeryVeryVeryVeryLongSeries3</text><circle class=\"circle \" fill=\"#D1345B\" stroke=\"#D1345B\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-VeryVeryVeryVeryVeryVeryLongSeries3\" cx=\"238.06\" cy=\"74.1164\" r=\"6.75\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"349.26800000000003\" y=\"25\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"20px\" font-family=\"Arial\">Test Case 1</text></g></svg>";
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
            testCase.ExpectedResult =
                "<svg class=\".svg\" height=\"500\" width=\"800\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0.5\" d=\"M 96.27,472.51 L 96.27,472.51 96.27,477.51\"/><text class=\"text XAxis-label axis-label\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"81.51222857142858\" y=\"493.5072\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"16px\" font-family=\"Arial\">One</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1.5\" d=\"M 204.54,472.51 L 204.54,472.51 204.54,477.51\"/><text class=\"text XAxis-label axis-label\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"189.77828571428572\" y=\"493.5072\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"16px\" font-family=\"Arial\">Two</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2.5\" d=\"M 312.8,472.51 L 312.8,472.51 312.8,477.51\"/><text class=\"text XAxis-label axis-label\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"288.2054095238095\" y=\"493.5072\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"16px\" font-family=\"Arial\">Three</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3.5\" d=\"M 421.07,472.51 L 421.07,472.51 421.07,477.51\"/><text class=\"text XAxis-label axis-label\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"401.39093333333335\" y=\"493.5072\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"16px\" font-family=\"Arial\">Four</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4.5\" d=\"M 529.33,472.51 L 529.33,472.51 529.33,477.51\"/><text class=\"text XAxis-label axis-label\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"509.65699047619046\" y=\"493.5072\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"16px\" font-family=\"Arial\">Five</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5.5\" d=\"M 637.6,472.51 L 637.6,472.51 637.6,477.51\"/><text class=\"text XAxis-label axis-label\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"622.8425142857142\" y=\"493.5072\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"16px\" font-family=\"Arial\">Six</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6.5\" d=\"M 745.87,472.51 L 745.87,472.51 745.87,477.51\"/><text class=\"text XAxis-label axis-label\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"721.2696380952381\" y=\"493.5072\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"16px\" font-family=\"Arial\">Seven</text><path class=\"path \" fill=\"none\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 42.14,472.51 L 42.14,472.51 800,472.51\"/><path class=\"path \" fill=\"none\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"YAxis--baseline\" d=\"M 42.14,472.51 L 42.14,472.51 42.14,0\"/><path class=\"path series series-Series1\" fill=\"none\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 96.27,472.51 L 96.27,472.51 204.54,472.51 L 204.54,472.51 312.8,472.51 L 312.8,472.51 421.07,472.51 L 421.07,472.51 529.33,472.51 L 529.33,472.51 637.6,472.51 L 637.6,472.51 745.87,472.51\"/><circle class=\"circle data-point data-point_Series1\" fill=\"none\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"7:30\" cx=\"745.87\" cy=\"472.51\" r=\"3\"/><text class=\"text data-point-text data-point-text_Series1\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"745.87\" y=\"475.51\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"3px\" font-family=\"Arial\">30</text><circle class=\"circle data-point data-point_Series1\" fill=\"none\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"1:10\" cx=\"96.27\" cy=\"472.51\" r=\"3\"/><text class=\"text data-point-text data-point-text_Series1\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"96.27\" y=\"475.51\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"3px\" font-family=\"Arial\">10</text><circle class=\"circle data-point data-point_Series1\" fill=\"none\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"2:0\" cx=\"204.54\" cy=\"472.51\" r=\"3\"/><text class=\"text data-point-text data-point-text_Series1\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"204.54\" y=\"475.51\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"3px\" font-family=\"Arial\">0</text><circle class=\"circle data-point data-point_Series1\" fill=\"none\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"3:20\" cx=\"312.8\" cy=\"472.51\" r=\"3\"/><text class=\"text data-point-text data-point-text_Series1\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"312.8\" y=\"475.51\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"3px\" font-family=\"Arial\">20</text><circle class=\"circle data-point data-point_Series1\" fill=\"none\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"4:25\" cx=\"421.07\" cy=\"472.51\" r=\"3\"/><text class=\"text data-point-text data-point-text_Series1\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"421.07\" y=\"475.51\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"3px\" font-family=\"Arial\">25</text><circle class=\"circle data-point data-point_Series1\" fill=\"none\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"5:5\" cx=\"529.33\" cy=\"472.51\" r=\"3\"/><text class=\"text data-point-text data-point-text_Series1\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"529.33\" y=\"475.51\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"3px\" font-family=\"Arial\">5</text><circle class=\"circle data-point data-point_Series1\" fill=\"none\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"6:60\" cx=\"637.6\" cy=\"472.51\" r=\"3\"/><text class=\"text data-point-text data-point-text_Series1\" fill=\"black\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"637.6\" y=\"475.51\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"3px\" font-family=\"Arial\">60</text><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"350.662\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Series1</text><circle class=\"circle \" fill=\"green\" stroke=\"green\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-Series1\" cx=\"334.912\" cy=\"18.6164\" r=\"6.75\"/></g></svg>";
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
            testCase.ExpectedResult =
                "<svg class=\".svg\" height=\"600\" width=\"1180\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0.5\" d=\"M 114.92,577.97 L 114.92,577.97 114.92,580.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"102.9251142857143\" y=\"593.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">One</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1.5\" d=\"M 278.78,577.97 L 278.78,577.97 278.78,580.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"266.7841428571429\" y=\"593.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Two</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2.5\" d=\"M 442.63,577.97 L 442.63,577.97 442.63,580.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"422.6490380952381\" y=\"593.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Three</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3.5\" d=\"M 606.49,577.97 L 606.49,577.97 606.49,580.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"590.5051333333334\" y=\"593.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Four</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4.5\" d=\"M 770.35,577.97 L 770.35,577.97 770.35,580.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"754.364161904762\" y=\"593.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Five</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5.5\" d=\"M 934.21,577.97 L 934.21,577.97 934.21,580.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"922.2202571428571\" y=\"593.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Six</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6.5\" d=\"M 1098.07,577.97 L 1098.07,577.97 1098.07,580.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1078.0851523809524\" y=\"593.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Seven</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 32.99,577.97 L 32.99,577.97 1180,577.97\"/><path class=\"path series series-Series1\" fill=\"none\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 114.92,577.97 C 147.69,577.97 213.24,577.97 278.78,577.97 C 344.32,577.97 377.09,577.97 442.63,577.97 C 508.17,577.97 540.95,577.97 606.49,577.97 C 672.03,577.97 704.81,577.97 770.35,577.97 C 835.89,577.97 868.67,577.97 934.21,577.97 C 999.75,577.97 1065.3,577.97 1098.07,577.97\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"540.662\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Series1</text><circle class=\"circle \" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-Series1\" cx=\"524.912\" cy=\"18.6164\" r=\"6.75\"/></g></svg>";
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
            testCase.ExpectedResult =
                "<svg class=\".svg\" height=\"500\" width=\"800\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0.5\" d=\"M 87.77,477.97 L 87.77,477.97 87.77,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"75.78225714285716\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">One</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1.5\" d=\"M 197.35,477.97 L 197.35,477.97 197.35,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"185.35557142857147\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Two</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2.5\" d=\"M 306.92,477.97 L 306.92,477.97 306.92,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"286.9347523809524\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Three</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3.5\" d=\"M 416.49,477.97 L 416.49,477.97 416.49,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"400.50513333333333\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Four</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4.5\" d=\"M 526.07,477.97 L 526.07,477.97 526.07,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"510.0784476190476\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Five</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5.5\" d=\"M 635.64,477.97 L 635.64,477.97 635.64,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"623.6488285714286\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Six</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6.5\" d=\"M 745.21,477.97 L 745.21,477.97 745.21,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"725.2280095238096\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Seven</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 32.99,477.97 L 32.99,477.97 800,477.97\"/><path class=\"path series series-Series1\" fill=\"none\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 87.77,477.97 C 109.69,477.97 153.52,477.97 197.35,477.97 C 241.18,477.97 263.09,477.97 306.92,477.97 C 350.75,477.97 372.66,477.97 416.49,477.97 C 460.32,477.97 482.24,477.97 526.07,477.97 C 569.9,477.97 591.81,477.97 635.64,477.97 C 679.47,477.97 723.3,477.97 745.21,477.97\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"350.662\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Series1</text><circle class=\"circle \" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-Series1\" cx=\"334.912\" cy=\"18.6164\" r=\"6.75\"/></g></svg>";
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
            testCase.ExpectedResult =
                "<svg class=\".svg\" height=\"500\" width=\"800\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0.5\" d=\"M 87.77,477.97 L 87.77,477.97 87.77,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"75.78225714285716\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">One</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1.5\" d=\"M 197.35,477.97 L 197.35,477.97 197.35,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"185.35557142857147\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Two</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2.5\" d=\"M 306.92,477.97 L 306.92,477.97 306.92,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"286.9347523809524\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Three</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3.5\" d=\"M 416.49,477.97 L 416.49,477.97 416.49,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"400.50513333333333\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Four</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4.5\" d=\"M 526.07,477.97 L 526.07,477.97 526.07,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"510.0784476190476\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Five</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5.5\" d=\"M 635.64,477.97 L 635.64,477.97 635.64,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"623.6488285714286\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Six</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6.5\" d=\"M 745.21,477.97 L 745.21,477.97 745.21,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"725.2280095238096\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Seven</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 32.99,477.97 L 32.99,477.97 800,477.97\"/><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"13.991200000000003\" y=\"482.82150322580645\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">0</text><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"7.995600000000003\" y=\"424.68227465437786\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">10</text><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"7.995600000000003\" y=\"366.5430460829493\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">20</text><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"7.995600000000003\" y=\"308.4038175115207\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">30</text><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"7.995600000000003\" y=\"250.26458894009215\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">40</text><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"7.995600000000003\" y=\"192.12536036866356\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">50</text><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"7.995600000000003\" y=\"133.986131797235\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">60</text><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"7.995600000000003\" y=\"75.84690322580646\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">70</text><path class=\"path series series-VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"none\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 87.77,419.84 C 109.69,431.47 153.52,489.6 197.35,477.97 C 241.18,466.34 263.09,390.77 306.92,361.7 C 350.75,332.63 372.66,315.19 416.49,332.63 C 460.32,350.07 482.24,489.6 526.07,448.9 C 569.9,408.2 591.81,158.21 635.64,129.14 C 679.47,100.07 723.3,268.68 745.21,303.56\"/><path class=\"path series series-VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"none\" stroke=\"#34D1BF\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 87.77,477.97 C 109.69,466.34 153.52,448.91 197.35,419.84 C 241.18,390.77 263.09,347.75 306.92,332.63 C 350.75,317.51 372.66,346.58 416.49,344.25 C 460.32,341.92 482.24,366.35 526.07,321 C 569.9,275.65 591.81,91.93 635.64,117.51 C 679.47,143.09 723.3,382.62 745.21,448.9\"/><path class=\"path series series-VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"none\" stroke=\"#D1345B\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 87.77,460.53 C 109.69,451.23 153.52,425.65 197.35,414.02 C 241.18,402.39 263.09,410.53 306.92,402.39 C 350.75,394.25 372.66,368.67 416.49,373.32 C 460.32,377.97 482.24,404.72 526.07,425.65 C 569.9,446.58 591.81,468.67 635.64,477.97 C 679.47,487.27 723.3,473.32 745.21,472.16\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"107.62\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">VeryVeryVeryVeryVeryVeryLongSeries1</text><circle class=\"circle \" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-VeryVeryVeryVeryVeryVeryLongSeries1\" cx=\"91.87\" cy=\"18.6164\" r=\"6.75\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"400\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">VeryVeryVeryVeryVeryVeryLongSeries2</text><circle class=\"circle \" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-VeryVeryVeryVeryVeryVeryLongSeries2\" cx=\"384.25\" cy=\"18.6164\" r=\"6.75\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"253.81\" y=\"49.352666666666664\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">VeryVeryVeryVeryVeryVeryLongSeries3</text><circle class=\"circle \" fill=\"#D1345B\" stroke=\"#D1345B\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-VeryVeryVeryVeryVeryVeryLongSeries3\" cx=\"238.06\" cy=\"44.1164\" r=\"6.75\"/></g></svg>";
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
            testCase.ExpectedResult = "<svg class=\".svg\" height=\"500\" width=\"800\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0.5\" d=\"M 87.77,477.97 L 87.77,477.97 87.77,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"75.78225714285716\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">One</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1.5\" d=\"M 197.35,477.97 L 197.35,477.97 197.35,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"185.35557142857147\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Two</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2.5\" d=\"M 306.92,477.97 L 306.92,477.97 306.92,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"286.9347523809524\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Three</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3.5\" d=\"M 416.49,477.97 L 416.49,477.97 416.49,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"400.50513333333333\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Four</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4.5\" d=\"M 526.07,477.97 L 526.07,477.97 526.07,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"510.0784476190476\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Five</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5.5\" d=\"M 635.64,477.97 L 635.64,477.97 635.64,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"623.6488285714286\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Six</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6.5\" d=\"M 745.21,477.97 L 745.21,477.97 745.21,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"725.2280095238096\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Seven</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 32.99,477.97 L 32.99,477.97 800,477.97\"/><path class=\"path series series-VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"none\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 87.77,477.97 L 87.77,477.97 197.35,477.97 L 197.35,477.97 306.92,477.97 L 306.92,477.97 416.49,477.97 L 416.49,477.97 526.07,477.97 L 526.07,477.97 635.64,477.97 L 635.64,477.97 745.21,477.97\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"745.21\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">30</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"87.77\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">0</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"197.35\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">0</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"306.92\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">20</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"416.49\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">25</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"526.07\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">5</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries1\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"635.64\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">60</text><path class=\"path series series-VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"none\" stroke=\"#34D1BF\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 87.77,477.97 L 87.77,477.97 197.35,477.97 L 197.35,477.97 306.92,477.97 L 306.92,477.97 416.49,477.97 L 416.49,477.97 526.07,477.97 L 526.07,477.97 635.64,477.97 L 635.64,477.97 745.21,477.97\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"745.21\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">5</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"87.77\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">0</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"197.35\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">10</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"306.92\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">25</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"416.49\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">23</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"526.07\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">27</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries2\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"635.64\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">62</text><path class=\"path series series-VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"none\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 87.77,477.97 L 87.77,477.97 197.35,477.97 L 197.35,477.97 306.92,477.97 L 306.92,477.97 416.49,477.97 L 416.49,477.97 526.07,477.97 L 526.07,477.97 635.64,477.97 L 635.64,477.97 745.21,477.97\"/><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"745.21\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">1</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"87.77\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">3</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"197.35\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">11</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"306.92\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">13</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"416.49\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">18</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"526.07\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">9</text><text class=\"text data-point-text data-point-text_VeryVeryVeryVeryVeryVeryLongSeries3\" fill=\"grey\" stroke=\"black\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"635.64\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">0</text><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"107.62\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">VeryVeryVeryVeryVeryVeryLongSeries1</text><circle class=\"circle \" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-VeryVeryVeryVeryVeryVeryLongSeries1\" cx=\"91.87\" cy=\"18.6164\" r=\"6.75\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"400\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">VeryVeryVeryVeryVeryVeryLongSeries2</text><circle class=\"circle \" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-VeryVeryVeryVeryVeryVeryLongSeries2\" cx=\"384.25\" cy=\"18.6164\" r=\"6.75\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"253.81\" y=\"49.352666666666664\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">VeryVeryVeryVeryVeryVeryLongSeries3</text><circle class=\"circle \" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-VeryVeryVeryVeryVeryVeryLongSeries3\" cx=\"238.06\" cy=\"44.1164\" r=\"6.75\"/></g></svg>"; 
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
            testCase.ExpectedResult =
                "<svg class=\".svg\" height=\"500\" width=\"800\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0\" d=\"M 32.99,477.97 L 32.99,477.97 32.99,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"20.995600000000003\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">One</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1\" d=\"M 158.32,477.97 L 158.32,477.97 158.32,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"146.33113333333336\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Two</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2\" d=\"M 283.66,477.97 L 283.66,477.97 283.66,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"263.6725333333333\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Three</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3\" d=\"M 408.99,477.97 L 408.99,477.97 408.99,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"393.00513333333333\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Four</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4\" d=\"M 534.33,477.97 L 534.33,477.97 534.33,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"518.3406666666667\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Five</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5\" d=\"M 659.66,477.97 L 659.66,477.97 659.66,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"647.6732666666667\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Six</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6\" d=\"M 785,477.97 L 785,477.97 785,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"765.0146666666667\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Seven</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 32.99,477.97 L 32.99,477.97 785,477.97\"/><path class=\"path series series-Series1\" fill=\"none\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 32.99,477.97 L 32.99,477.97 158.32,477.97 L 158.32,477.97 283.66,477.97 L 283.66,477.97 408.99,477.97 L 408.99,477.97 534.33,477.97 L 534.33,477.97 659.66,477.97 L 659.66,477.97 785,477.97\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"350.662\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Series1</text><circle class=\"circle \" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-Series1\" cx=\"334.912\" cy=\"18.6164\" r=\"6.75\"/></g></svg>";
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
            testCase.ExpectedResult =
                "<svg class=\".svg\" height=\"500\" width=\"800\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0.5\" d=\"M 86.7,477.97 L 86.7,477.97 86.7,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"74.71082857142858\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">One</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1.5\" d=\"M 194.13,477.97 L 194.13,477.97 194.13,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"182.14128571428574\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Two</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2.5\" d=\"M 301.56,477.97 L 301.56,477.97 301.56,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"281.5776095238095\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Three</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3.5\" d=\"M 408.99,477.97 L 408.99,477.97 408.99,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"393.00513333333333\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Four</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4.5\" d=\"M 516.42,477.97 L 516.42,477.97 516.42,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"500.4355904761904\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Five</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5.5\" d=\"M 623.85,477.97 L 623.85,477.97 623.85,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"611.8631142857142\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Six</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6.5\" d=\"M 731.28,477.97 L 731.28,477.97 731.28,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"711.2994380952381\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Seven</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 32.99,477.97 L 32.99,477.97 785,477.97\"/><path class=\"path series series-Series1\" fill=\"none\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 86.7,477.97 L 86.7,477.97 194.13,477.97 L 194.13,477.97 301.56,477.97 L 301.56,477.97 408.99,477.97 L 408.99,477.97 516.42,477.97 L 516.42,477.97 623.85,477.97 L 623.85,477.97 731.28,477.97\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"350.662\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Series1</text><circle class=\"circle \" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-Series1\" cx=\"334.912\" cy=\"18.6164\" r=\"6.75\"/></g></svg>";
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
            testCase.ExpectedResult =
                "<svg class=\".svg\" height=\"300\" width=\"400\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0.5\" d=\"M 59.2,277.97 L 59.2,277.97 59.2,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"47.21082857142857\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">One</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1.5\" d=\"M 111.63,277.97 L 111.63,277.97 111.63,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"99.64128571428571\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Two</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2.5\" d=\"M 164.06,277.97 L 164.06,277.97 164.06,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"144.0776095238095\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Three</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3.5\" d=\"M 216.49,277.97 L 216.49,277.97 216.49,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"200.50513333333333\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Four</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4.5\" d=\"M 268.92,277.97 L 268.92,277.97 268.92,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"252.9355904761905\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Five</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5.5\" d=\"M 321.35,277.97 L 321.35,277.97 321.35,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"309.3631142857143\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Six</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6.5\" d=\"M 373.78,277.97 L 373.78,277.97 373.78,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"353.7994380952381\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Seven</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 32.99,277.97 L 32.99,277.97 400,277.97\"/><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"13.991200000000003\" y=\"282.82150322580645\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">0</text><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"-15.986799999999995\" y=\"39.84690322580645\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">100000</text><path class=\"path series series-Series1\" fill=\"none\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 164.06,277.93 L 164.06,277.93 216.49,277.91 L 216.49,277.91 268.92,277.96 L 268.92,277.96 321.35,277.83 L 321.35,277.83 373.78,277.9\"/><path class=\"path series series-Series2\" fill=\"none\" stroke=\"#34D1BF\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 59.2,277.97 L 59.2,277.97 111.63,277.95 L 111.63,277.95 164.06,277.97 L 164.06,277.97 216.49,277.97 L 216.49,277.97 268.92,277.91 L 268.92,277.91 321.35,277.82\"/><path class=\"path series series-Series3\" fill=\"none\" stroke=\"#D1345B\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 59.2,277.97 L 59.2,277.97 111.63,277.95 L 111.63,277.95 164.06,277.94 L 164.06,277.94 216.49,277.93 L 216.49,277.93 268.92,277.95 L 268.92,277.95 321.35,277.97 L 321.35,277.97 373.78,277.97\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"51.98599999999999\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Series1</text><circle class=\"circle \" fill=\"#3454D1\" stroke=\"#3454D1\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-Series1\" cx=\"36.23599999999999\" cy=\"18.6164\" r=\"6.75\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"150.66199999999998\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Series2</text><circle class=\"circle \" fill=\"#34D1BF\" stroke=\"#34D1BF\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-Series2\" cx=\"134.91199999999998\" cy=\"18.6164\" r=\"6.75\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"249.33799999999997\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Series3</text><circle class=\"circle \" fill=\"#D1345B\" stroke=\"#D1345B\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-Series3\" cx=\"233.58799999999997\" cy=\"18.6164\" r=\"6.75\"/></g></svg>";
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
            testCase.ExpectedResult = "<svg class=\".svg\" height=\"500\" width=\"800\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0.5\" d=\"M 71.94,477.97 L 71.94,477.97 71.94,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"47.96067142857143\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Oct-19</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1.5\" d=\"M 125.87,477.97 L 125.87,477.97 125.87,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"101.89081428571428\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Nov-19</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2.5\" d=\"M 179.8,477.97 L 179.8,477.97 179.8,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"155.82095714285714\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Dec-19</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3.5\" d=\"M 233.73,477.97 L 233.73,477.97 233.73,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"209.7511\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Jan-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4.5\" d=\"M 287.66,477.97 L 287.66,477.97 287.66,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"263.6812428571429\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Feb-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5.5\" d=\"M 341.59,477.97 L 341.59,477.97 341.59,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"317.61138571428575\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Mar-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6.5\" d=\"M 395.52,477.97 L 395.52,477.97 395.52,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"371.5415285714286\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Apr-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-7.5\" d=\"M 449.45,477.97 L 449.45,477.97 449.45,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"425.4716714285715\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">May-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-8.5\" d=\"M 503.38,477.97 L 503.38,477.97 503.38,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"479.40181428571435\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Jun-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-9.5\" d=\"M 557.31,477.97 L 557.31,477.97 557.31,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"533.3319571428572\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Jul-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-10.5\" d=\"M 611.24,477.97 L 611.24,477.97 611.24,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"587.2621\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Aug-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-11.5\" d=\"M 665.17,477.97 L 665.17,477.97 665.17,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"641.1922428571429\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Sep-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-12.5\" d=\"M 719.1,477.97 L 719.1,477.97 719.1,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"695.1223857142858\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Oct-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-13.5\" d=\"M 773.03,477.97 L 773.03,477.97 773.03,480.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"749.0525285714286\" y=\"493.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Nov-20</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 44.98,477.97 L 44.98,477.97 800,477.97\"/><path class=\"path series series-Usage\" fill=\"none\" stroke=\"#4674C5\" stroke-width=\"3\" fill-opacity=\"1\" stroke-opacity=\"1\" d=\"M 71.94,477.97 L 71.94,477.97 125.87,477.97 L 125.87,477.97 179.8,477.97 L 179.8,477.97 233.73,477.97 L 233.73,477.97 287.66,477.97 L 287.66,477.97 341.59,477.98 L 341.59,477.98 395.52,477.98 L 395.52,477.98 449.45,477.98 L 449.45,477.98 503.38,477.98 L 503.38,477.98 557.31,477.98 L 557.31,477.98 611.24,477.98 L 611.24,477.98 665.17,477.98 L 665.17,477.98 719.1,477.98 L 719.1,477.98 773.03,477.98\"/><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"773.03\" y=\"477.98\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">1146</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"71.94\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">10</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"125.87\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">0</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"179.8\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">15</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"233.73\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">105</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"287.66\" y=\"477.97\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">133</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"341.59\" y=\"477.98\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">292</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"395.52\" y=\"477.98\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">227</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"449.45\" y=\"477.98\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">215</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"503.38\" y=\"477.98\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">237</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"557.31\" y=\"477.98\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">320</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"611.24\" y=\"477.98\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">295</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"665.17\" y=\"477.98\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">371</text><text class=\"text data-point-text data-point-text_Usage\" fill=\"grey\" stroke=\"#3D3D3D\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"719.1\" y=\"477.98\" text-anchor=\"Middle\" dominant-baseline=\"Middle\" font-size=\"9px\" font-family=\"Arial\">740</text><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"357.58\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Usage</text><circle class=\"circle \" fill=\"#4674C5\" stroke=\"#4674C5\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"legend-Usage\" cx=\"341.83\" cy=\"18.6164\" r=\"6.75\"/></g></svg>";
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
            testCase.ExpectedResult = "<svg class=\".svg\" height=\"300\" width=\"1500\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0\" d=\"M 32.99,277.97 L 32.99,277.97 32.99,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"13.00146666666667\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">1 Jan</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1\" d=\"M 274.99,277.97 L 274.99,277.97 274.99,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"255.0036666666667\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">2 Jan</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2\" d=\"M 516.99,277.97 L 516.99,277.97 516.99,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"497.0058666666667\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">3 Jan</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3\" d=\"M 758.99,277.97 L 758.99,277.97 758.99,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"739.0080666666668\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">4 Jan</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4\" d=\"M 1001,277.97 L 1001,277.97 1001,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"981.0102666666668\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">5 Jan</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5\" d=\"M 1243,277.97 L 1243,277.97 1243,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1223.0124666666666\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">6 Jan</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6\" d=\"M 1485,277.97 L 1485,277.97 1485,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1465.0146666666667\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">7 Jan</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 32.99,277.97 L 32.99,277.97 1485,277.97\"/><path class=\"path series series-Fuel usage\" fill=\"#4674C5\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"0.4\" stroke-opacity=\"1\" d=\"M 32.99,277.97 C 81.39,277.97 178.19,277.97 274.99,277.97 C 371.79,277.97 420.19,277.97 516.99,277.97 C 613.79,277.97 662.19,277.97 758.99,277.97 C 855.79,277.97 904.2,277.97 1001,277.97 C 1097.8,277.97 1146.2,277.97 1243,277.97 C 1339.8,277.97 1436.6,277.97 1485,277.97 L 1485,277.97 1485,277.97 L 1485,277.97 32.99,277.97\"/><path class=\"path series series-Diesel usage\" fill=\"#267F00\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"0.4\" stroke-opacity=\"1\" d=\"M 32.99,277.97 C 81.39,277.97 178.19,277.97 274.99,277.97 C 371.79,277.97 420.19,277.97 516.99,277.97 C 613.79,277.97 662.19,277.97 758.99,277.97 C 855.79,277.97 904.2,277.97 1001,277.97 C 1097.8,277.97 1146.2,277.97 1243,277.97 C 1339.8,277.97 1436.6,277.97 1485,277.97 L 1485,277.97 1485,277.97 L 1485,277.97 32.99,277.97\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"623.652\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Fuel usage</text><circle class=\"circle \" fill=\"#4674C5\" stroke=\"#4674C5\" stroke-width=\"1\" fill-opacity=\"0.4\" stroke-opacity=\"1\" id=\"legend-Fuel usage\" cx=\"607.902\" cy=\"18.6164\" r=\"6.75\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"743.0820000000001\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Diesel usage</text><circle class=\"circle \" fill=\"#267F00\" stroke=\"#267F00\" stroke-width=\"1\" fill-opacity=\"0.4\" stroke-opacity=\"1\" id=\"legend-Diesel usage\" cx=\"727.3320000000001\" cy=\"18.6164\" r=\"6.75\"/></g></svg>";
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
            testCase.ExpectedResult = "<svg class=\".svg\" height=\"300\" width=\"1500\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0\" d=\"M 44.98,277.97 L 44.98,277.97 44.98,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"20.995599999999996\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Oct-19</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1\" d=\"M 155.75,277.97 L 155.75,277.97 155.75,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"131.76652307692308\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Nov-19</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2\" d=\"M 266.52,277.97 L 266.52,277.97 266.52,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"242.53744615384613\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Dec-19</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3\" d=\"M 377.29,277.97 L 377.29,277.97 377.29,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"353.30836923076924\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Jan-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4\" d=\"M 488.06,277.97 L 488.06,277.97 488.06,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"464.0792923076923\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Feb-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5\" d=\"M 598.83,277.97 L 598.83,277.97 598.83,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"574.8502153846154\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Mar-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6\" d=\"M 709.6,277.97 L 709.6,277.97 709.6,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"685.6211384615384\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Apr-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-7\" d=\"M 820.37,277.97 L 820.37,277.97 820.37,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"796.3920615384615\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">May-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-8\" d=\"M 931.15,277.97 L 931.15,277.97 931.15,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"907.1629846153845\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Jun-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-9\" d=\"M 1041.92,277.97 L 1041.92,277.97 1041.92,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1017.9339076923076\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Jul-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-10\" d=\"M 1152.69,277.97 L 1152.69,277.97 1152.69,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1128.7048307692307\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Aug-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-11\" d=\"M 1263.46,277.97 L 1263.46,277.97 1263.46,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1239.4757538461538\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Sep-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-12\" d=\"M 1374.23,277.97 L 1374.23,277.97 1374.23,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1350.2466769230768\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Oct-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-13\" d=\"M 1485,277.97 L 1485,277.97 1485,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1461.0176\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Nov-20</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 44.98,277.97 L 44.98,277.97 1485,277.97\"/><path class=\"path series series-Usage\" fill=\"#4674C5\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"0.4\" stroke-opacity=\"1\" d=\"M 44.98,277.97 C 67.13,277.97 111.44,277.97 155.75,277.97 C 200.06,277.97 222.21,277.97 266.52,277.97 C 310.83,277.97 332.98,277.97 377.29,277.97 C 421.6,277.97 443.75,277.97 488.06,277.97 C 532.37,277.97 554.52,277.97 598.83,277.97 C 643.14,277.97 665.29,277.97 709.6,277.97 C 753.91,277.97 776.06,277.97 820.37,277.97 C 864.68,277.97 886.84,277.97 931.15,277.97 C 975.46,277.97 997.61,277.97 1041.92,277.97 C 1086.23,277.97 1108.38,277.97 1152.69,277.97 C 1197,277.97 1219.15,277.98 1263.46,277.98 C 1307.77,277.98 1329.92,277.98 1374.23,277.98 C 1418.54,277.98 1462.85,277.98 1485,277.98 L 1485,277.98 1485,277.97 L 1485,277.97 44.98,277.97\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"1:10\" cx=\"44.98\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"1:10\" cx=\"155.75\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"2:0\" cx=\"266.52\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"3:15\" cx=\"377.29\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"4:105\" cx=\"488.06\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"5:133\" cx=\"598.83\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"6:292\" cx=\"709.6\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"7:227\" cx=\"820.37\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"8:215\" cx=\"931.15\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"9:237\" cx=\"1041.92\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"10:320\" cx=\"1152.69\" cy=\"277.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"11:295\" cx=\"1263.46\" cy=\"277.98\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"12:371\" cx=\"1374.23\" cy=\"277.98\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"13:740\" cx=\"1485\" cy=\"277.98\" r=\"3\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"707.58\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Usage</text><circle class=\"circle \" fill=\"#4674C5\" stroke=\"#4674C5\" stroke-width=\"1\" fill-opacity=\"0.4\" stroke-opacity=\"1\" id=\"legend-Usage\" cx=\"691.83\" cy=\"18.6164\" r=\"6.75\"/></g></svg>";
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
            testCase.ExpectedResult = "<svg class=\".svg\" height=\"300\" width=\"1500\" xmlns=\"http://www.w3.org/2000/svg\"><g class=\"g \"><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-0\" d=\"M 38.98,277.97 L 38.98,277.97 38.98,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"15\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Feb-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-1\" d=\"M 198.54,277.97 L 198.54,277.97 198.54,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"174.55751111111113\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Mar-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-2\" d=\"M 358.1,277.97 L 358.1,277.97 358.1,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"334.1150222222222\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Apr-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-3\" d=\"M 517.65,277.97 L 517.65,277.97 517.65,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"493.67253333333326\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">May-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-4\" d=\"M 677.21,277.97 L 677.21,277.97 677.21,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"653.2300444444444\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Jun-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-5\" d=\"M 836.77,277.97 L 836.77,277.97 836.77,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"812.7875555555555\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Jul-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-6\" d=\"M 996.33,277.97 L 996.33,277.97 996.33,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"972.3450666666665\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Aug-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-7\" d=\"M 1155.88,277.97 L 1155.88,277.97 1155.88,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1131.9025777777777\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Sep-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-8\" d=\"M 1315.44,277.97 L 1315.44,277.97 1315.44,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1291.4600888888888\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Oct-20</text><path class=\"path XAxis-major-tick tick\" fill=\"gray\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis-major-tick-9\" d=\"M 1475,277.97 L 1475,277.97 1475,280.97\"/><text class=\"text XAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"1451.0176\" y=\"293.9746\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">Nov-20</text><path class=\"path \" fill=\"none\" stroke=\"grey\" stroke-width=\"0.5\" fill-opacity=\"1\" stroke-opacity=\"1\" id=\"XAxis--baseline\" d=\"M 38.98,277.97 L 38.98,277.97 1475,277.97\"/><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"19.986800000000002\" y=\"282.82150322580645\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">0</text><text class=\"text YAxis-label axis-label\" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"-3.9955999999999996\" y=\"39.84690322580645\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"13px\" font-family=\"Arial\">10000</text><path class=\"path series series-Usage\" fill=\"#4674C5\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"0.4\" stroke-opacity=\"1\" d=\"M 38.98,260.97 C 70.89,260.73 134.72,259.99 198.54,259.75 C 262.36,259.51 294.28,260.5 358.1,259.75 C 421.92,259 453.83,256.39 517.65,255.99 C 581.47,255.59 613.39,257.18 677.21,257.73 C 741.03,258.28 772.95,258.21 836.77,258.73 C 900.59,259.25 932.51,259.45 996.33,260.31 C 1060.15,261.17 1092.06,263.56 1155.88,263.03 C 1219.7,262.5 1251.62,259.45 1315.44,257.64 C 1379.26,255.83 1443.09,254.72 1475,253.99 L 1475,253.99 1475,277.97 L 1475,277.97 38.98,277.97\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"1:700\" cx=\"38.98\" cy=\"260.97\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"1:700\" cx=\"198.54\" cy=\"259.75\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"2:750\" cx=\"358.1\" cy=\"259.75\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"3:750\" cx=\"517.65\" cy=\"255.99\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"4:905\" cx=\"677.21\" cy=\"257.73\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"5:833\" cx=\"836.77\" cy=\"258.73\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"6:792\" cx=\"996.33\" cy=\"260.31\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"7:727\" cx=\"1155.88\" cy=\"263.03\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"8:615\" cx=\"1315.44\" cy=\"257.64\" r=\"3\"/><circle class=\"circle data-point data-point_Usage\" fill=\"#4674C5\" stroke=\"white\" stroke-width=\"2\" fill-opacity=\"1\" stroke-opacity=\"1\" label=\"9:837\" cx=\"1475\" cy=\"253.99\" r=\"3\"/><text class=\"text \" fill=\"grey\" stroke=\"none\" stroke-width=\"1\" fill-opacity=\"1\" stroke-opacity=\"1\" x=\"707.58\" y=\"23.852666666666668\" text-anchor=\"Start\" dominant-baseline=\"Auto\" font-size=\"15px\" font-family=\"Arial\">Usage</text><circle class=\"circle \" fill=\"#4674C5\" stroke=\"#4674C5\" stroke-width=\"1\" fill-opacity=\"0.4\" stroke-opacity=\"1\" id=\"legend-Usage\" cx=\"691.83\" cy=\"18.6164\" r=\"6.75\"/></g></svg>";
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

            testCase.SetName("Debug - 1 Axis Labels not centered");
            testCase.SetDescription("Debug - 1 Axis Labels not centered");
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

            testCase.SetName("Debug 3 - Exception during Y axis export");
            testCase.SetDescription("Exception when exporting YAxis data");
            return testCase;
        }

        #endregion Debug


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
