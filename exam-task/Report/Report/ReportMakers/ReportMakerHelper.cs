using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report
{
	public static class ReportMakerHelper
	{
		public static string MeanAndStdHtmlReport(IEnumerable<Measurement> data)
		{
			return MakeReport(data, new MeanAndStdCalculator(), new HtmlReportMaker());
		}

		public static string MedianMarkdownReport(IEnumerable<Measurement> data)
		{
			return MakeReport(data, new MedianCalculator(), new MarkdownReportMaker());
		}

		public static string MeanAndStdMarkdownReport(IEnumerable<Measurement> measurements)
		{
			return MakeReport(measurements, new MeanAndStdCalculator(), new MarkdownReportMaker());
		}

		public static string MedianHtmlReport(IEnumerable<Measurement> measurements)
		{
			return MakeReport(measurements, new MeanAndStdCalculator(), new MarkdownReportMaker());
		}


        public static string MakeReport(
			IEnumerable<Measurement> measurements,
			IStatisticsCalculator calculator,
			IReportMaker maker)
        {
            var data = measurements.ToList();
            var result = new StringBuilder();
            result.Append(maker.MakeCaption(calculator.Caption));
            result.Append(maker.BeginList());
            result.Append(maker.MakeItem("Temperature", calculator.MakeStatistics(data.Select(z => z.Temperature)).ToString()));
            result.Append(maker.MakeItem("Humidity", calculator.MakeStatistics(data.Select(z => z.Humidity)).ToString()));
            result.Append(maker.EndList());
            return result.ToString();
        }
    }
}
