using Microsoft.Recognizers.Text.Number.Ukrainian;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Recognizers.Text.Number.Tests
{
    [TestClass]
    public class TestNumberUkrainian
    {
        private void BasicTest(IModel model, string source, string value)
        {
            var resultStr = model.Parse(source);
            var resultJson = resultStr;
            Assert.AreEqual(1, resultJson.Count);
            Assert.AreEqual(source.Trim(), resultJson[0].Text);
            Assert.AreEqual(value, resultJson[0].Resolution["value"]);
        }

        private void WrappedTest(IModel model, string source, string extractSrc, string value)
        {
            var resultStr = model.Parse(source);
            var resultJson = resultStr;
            Assert.AreEqual(1, resultJson.Count);
            Assert.AreEqual(extractSrc, resultJson[0].Text);
            Assert.AreEqual(value, resultJson[0].Resolution["value"]);
        }


        private void MultiTest(IModel model, string source, int count)
        {
            var resultStr = model.Parse(source);
            var resultJson = resultStr;
            Assert.AreEqual(count, resultJson.Count);
        }

        [TestMethod]
        public void TestOrdinalModel()
        {
            var model = NumberRecognizer.GetOrdinalModel(Culture.Ukrainian);

            BasicTest(model,
                "11ий", "11");

            BasicTest(model,
                "21ий", "21");

            BasicTest(model,
                "30ий", "30");

            BasicTest(model,
                "2ий", "2");

            BasicTest(model,
                "одинадцятий", "11");

            BasicTest(model,
                "двадцятий", "20");

            BasicTest(model,
                "двадцять п'ятий", "25");

            BasicTest(model,
                "двадцять перший", "21");

            BasicTest(model,
                "сто двадцять п'ятий", "125");

            BasicTest(model,
                "трильйонний", "1000000000000");

            BasicTest(model,
                "двадцять один трильйон триста двадцять другий", "21000000000322");

            BasicTest(model,
                "трьох трильйонний", "3000000000000");

            BasicTest(model,
                "десять тисяч триста дванадцятий", "10312");

            //TODO: It is problem for round numbers in Ukrainian
            //BasicTest(model,
            //    "десяти трильйонний", "10000000000000");
        }

        [TestMethod]
        public void TestNumberModel()
        {
            var model = NumberRecognizer.GetNumberModel(Culture.Ukrainian);
  
            BasicTest(model,
                "чотири", "4");
              
            BasicTest(model,
                "чотирнадцять", "14");
            
            BasicTest(model,
                "двадцять шість", "26");
            
            BasicTest(model,
                "двадцять", "20");
            
            BasicTest(model,
                "сто три", "103");
            
            BasicTest(model,
                "сто тридцятьма вісьмома", "138");
            
            BasicTest(model,
                "сто дванадцять", "112");
            
            BasicTest(model,
                "сто шістдесят три", "163");
            
            BasicTest(model,
                "сто", "100");
            
            BasicTest(model,
                "сто дванадцять", "112");
            
            BasicTest(model,
                "тисяча", "1000");
            
            BasicTest(model,
                "тисяча один", "1001");
            
            BasicTest(model,
                "тисяча одинадцять", "1011");
            
            BasicTest(model,
                "тисяча дев'ятсот шістдесят три", "1963");
            
            BasicTest(model,
                "дев'ять тисяч триста двадцять чотири", "9324");
            
            BasicTest(model,
                "дев'ять тисяч двадцять чотири", "9024");
            
            BasicTest(model,
                "дев'ять тисяч один", "9001");
            
            BasicTest(model,
                "десять тисяч", "10000");
            
            BasicTest(model,
                "двадцять дві тисячі", "22000");
            
            BasicTest(model,
                "двадцять дві тисячі два", "22002");
            
            BasicTest(model,
                "двадцять дві тисячі двадцять два", "22022");
            
            BasicTest(model,
                "двадцять дві тисячі чотириста вісімдесят шість", "22486");
            
            BasicTest(model,
                "двадцять дві тисячі чотириста вісімдесят шістьма", "22486");
            
            BasicTest(model,
                "сто вісімдесят тисяч", "180000");
            
            BasicTest(model,
                "сто вісімдесят тисяч п'ятсот", "180500");
            
            BasicTest(model,
                "сто дванадцять тисяч", "112000");
            
            BasicTest(model,
                "сто дванадцять тисяч триста", "112300");
            
            BasicTest(model,
                "сто вісімдесят тисяч п'ятсот сорок шість", "180546");
            
            BasicTest(model,
                "сто вісімдесят дві тисячі п'ятсот сорок шість", "182546");
            
            BasicTest(model,
               "мільйон", "1000000");
            
            BasicTest(model,
                "один мільйон", "1000000");
            
            BasicTest(model,
                "два мільйони", "2000000");
            
            BasicTest(model,
                "чотириста тридцять п'ять тисяч", "435000");
            
            BasicTest(model,
                "два мільйони одна тисяча", "2001000");
            
            BasicTest(model,
                "два мільйони чотириста тридцять п'ять тисяч", "2435000");
            
            BasicTest(model,
                "два мільйони чотириста тридцять п'ять тисяч сімсот дев'яносто два", "2435792");
            
            BasicTest(model,
                "два мільйони сто дві тисячі", "2102000");
            
            BasicTest(model,
                "два мільйони сто дванадцять тисяч двісті", "2112200");
            
            BasicTest(model,
                "два мільйони сто дванадцять тисяч триста двадцять один", "2112321");
            
            BasicTest(model,
                "двадцять два мільйони сто дванадцять тисяч триста двадцять один", "22112321");
            
            BasicTest(model,
                "два мільйони три", "2000003");
            
            BasicTest(model,
                "сто мільйонів", "100000000");
            
            BasicTest(model,
                "сто мільйонів дванадцять", "100000012");
            
            BasicTest(model,
                "чотириста вісімдесят дев'ять мільйонів дванадцять тисяч триста вісім", "489012308");
            
            BasicTest(model,
                "мільярд", "1000000000");
            
            BasicTest(model,
                "мільярд один", "1000000001");
            
            BasicTest(model,
                "два мільярди одинадцять тисяч три", "2000011003");
            
            BasicTest(model,
                "вісімсот чотири мільярди сто одинадцять мільйонів сімсот тридцять дві тисячі вісімсот тридцять три", "804111732833");
            
            //BasicTest(model,
            //    "дев'ятсот сорок дев'ять трильйонів вісімсот чотири мільярди сто одинадцять мільйонів сімсот тридцять дві тисячі вісімсот тридцять три", "949804111732833");


            WrappedTest(model,
                "192.", "192", "192");
            
            MultiTest(model,
                "192.168.1.2", 4);

            MultiTest(model,
                "180мл", 0);

            MultiTest(model,
                " 29км ", 0);
            
            MultiTest(model,
                "4те травня", 0);
            
            MultiTest(model,
                ".25мл", 0);
            
            BasicTest(model,
                ".08", "0.08");
            
            BasicTest(model,
                ".23456000", "0.23456");
            
            BasicTest(model,
                "4.800", "4.8");

            BasicTest(model,
                "шістнадцять", "16");

            //BasicTest(model,
            //    "дві третіх", ((double)2 / 3).ToString());
            //
            //TODO: Problem for numbers like 1 1/3
            //BasicTest(model,
            //    "двісті цілих одна третя", (double)200 + (1 / 3).ToString());
            //
            //BasicTest(model,
            //    "двісті крапка три", "200.3");
            BasicTest(model,
                "чотири сьомих", ((double)4 / 7).ToString());

            //BasicTest(model,
            //    "трильйонна", "1E-12");
            
           //BasicTest(model,
           //    "сто трильйонних", "1E-10");
            
            //BasicTest(model,
            //    "половина дюжини", "6");
            
            //BasicTest(model,
            //    " 3 дюжини", "36");
            //
            //BasicTest(model,
            //    "дюжина", "12");
    
            BasicTest(model,
                "1,234,567", "1234567");

            MultiTest(model,
                "1, 234, 567", 3);

            BasicTest(model,
                "9.2321312", "9.2321312");

            BasicTest(model,
                " -9.2321312", "-9.2321312");

            BasicTest(model,
                " -1", "-1");

            BasicTest(model,
                "-4/5", "-0.8");

            BasicTest(model,
                "- 1 4/5", "-1.8");

            BasicTest(model,
                " 123456789101231", "123456789101231");

            BasicTest(model,
                "-123456789101231", "-123456789101231");

            BasicTest(model,
                " -123456789101231", "-123456789101231");

            BasicTest(model,
                "1", "1");

            //BasicTest(model,
            //    "10тис", "10000");

            //BasicTest(model,
            //    "10млрд", "10000000000");

            //BasicTest(model,
            //    "- 10  тис", "-10000");

            //BasicTest(model,
            //    "2 мільйони", "2000000");
            //
            //BasicTest(model,
            //    "1 трильйон", "1000000000000");

            BasicTest(model,
                "1e10", "10000000000");

            BasicTest(model,
                "1.1^23", "8.95430243255239");

            BasicTest(model,
                "2  1/4", "2.25");

            BasicTest(model,
                "3/4", "0.75");
        }

        [TestMethod]
        public void TestFractionModel()
        {
            var model = NumberRecognizer.GetNumberModel(Culture.Ukrainian);

            BasicTest(model,
                "сто цілих дві п'ятих", (100 + (double)2 / 5).ToString());

            BasicTest(model,
                "сто цілих дві п'ятих", (100 + (double)2 / 5).ToString());
        }

        [TestMethod]
        public void TestPercentageModel()
        {
            var model = NumberRecognizer.GetPercentageModel(Culture.English);

            BasicTest(model,
                "100%", "100%");

            BasicTest(model,
                " 100% ", "100%");

            //BasicTest(model,
            //    " 100 відсотків", "100%");
            //
            //BasicTest(model,
            //    " 100 процентів", "100%");
            //
            //BasicTest(model,
            //    "240 відсотків", "240%");
            //
            //BasicTest(model,
            //    "двадцять відсотків", "20%");
            //
            //BasicTest(model,
            //    "тридцять відсотків", "30%");
            //
            //BasicTest(model,
            //    "сто відсотків", "100%");
            //
            //BasicTest(model,
            //    "двадцять відсотків", "20%");
            //
            //BasicTest(model,
            //    "10 відсотків", "10%");
            //
            //BasicTest(model,
            //    "двадцять два відсотки", "22%");
            //
            //BasicTest(model,
            //    "210 відсотків", "210%");
            //
            //BasicTest(model,
            //    "10 відсотків", "10%");
        }
    }
}