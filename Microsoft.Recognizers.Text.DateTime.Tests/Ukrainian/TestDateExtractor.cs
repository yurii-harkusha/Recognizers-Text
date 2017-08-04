using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian.Tests
{
    [TestClass]
    public class TestDateExtractor
    {
        private readonly BaseDateExtractor extractor = new BaseDateExtractor(new UkrainianDateExtractorConfiguration());

        public void BasicTest(string text, int start, int length)
        {
            var results = extractor.Extract(text);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(start, results[0].Start);
            Assert.AreEqual(length, results[0].Length);
            Assert.AreEqual(Constants.SYS_DATETIME_DATE, results[0].Type);
        }

        [TestMethod]
        public void TestDateExtract()
        {
            BasicTest("Я повернусь 15", 12, 2);

            BasicTest("Я повернусь 22 квітня", 12, 9);
            BasicTest("Я повернусь  2 жовтня", 13, 8);
            BasicTest("Я повернусь 12 січня, 2016", 12, 14);
            BasicTest("Я повернусь в понеділок 12 січня, 2016", 14, 24);
            BasicTest("Я повернусь 21/04/2016", 12, 10);
            BasicTest("Я повернусь 21/04/16", 12, 8);
        }
    }
}
