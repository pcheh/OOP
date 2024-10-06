using Report;

namespace ReportUnitTestProject
{
    [TestFixture]
    public class ReportUnitTests
    {
        [Test]
		public void MeanAndStdHtml()
		{
			var expected = @"<h1>Mean and Std</h1><ul><li><b>Temperature</b>: 9±17.08800749063506<li><b>Humidity</b>: 2±0.816496580927726</ul>";
			var actual = ReportMakerHelper.MeanAndStdHtmlReport(data);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void MedianMarkdown()
		{
			var expected = "## Median\n\n * **Temperature**: 8\n\n * **Humidity**: 2\n\n";
			var actual = ReportMakerHelper.MedianMarkdownReport(data);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void MeanAndStdMarkdown()
		{
			var expected = "## Mean and Std\n\n * **Temperature**: 9±17.08800749063506\n\n * **Humidity**: 2±0.816496580927726\n\n";
			var actual = ReportMakerHelper.MeanAndStdMarkdownReport(data);
			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void MedianHtml()
		{
			var expected = "<h1>Median</h1><ul><li><b>Temperature</b>: 8<li><b>Humidity</b>: 2</ul>";
			var actual = ReportMakerHelper.MedianHtmlReport(data);
			Assert.That(actual, Is.EqualTo(expected));
		}

		private readonly List<Measurement> data = new List<Measurement>
		{
			new Measurement
			{
				Humidity=1,
				Temperature=-10,
			},
			new  Measurement
			{
				Humidity=2,
				Temperature=2,
			},
			new Measurement
			{
				Humidity=3,
				Temperature=14
			},
			new Measurement
			{
				Humidity=2,
				Temperature=30
			}
		};
	}
}
