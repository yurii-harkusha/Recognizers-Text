﻿using System;
using System.Collections.Generic;
using Microsoft.Recognizers.Text.Number.Chinese;
using Microsoft.Recognizers.Text.Number.English;
using Microsoft.Recognizers.Text.Number.French;
using Microsoft.Recognizers.Text.Number.Portuguese;
using Microsoft.Recognizers.Text.Number.Spanish;
using Microsoft.Recognizers.Text.Number.Ukrainian;

namespace Microsoft.Recognizers.Text.Number
{
    public class NumberRecognizer : BaseNumberRecognizer
    {
        static NumberRecognizer()
        {
            ModelInstances = new Dictionary<string, Dictionary<Type, IModel>>(StringComparer.InvariantCultureIgnoreCase)
            {
                {
                    Culture.English, new Dictionary<Type, IModel>
                    {
                        [typeof (NumberModel)] = new NumberModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Number, new EnglishNumberParserConfiguration()),
                            new English.NumberExtractor(NumberMode.PureNumber)),
                        [typeof (OrdinalModel)] = new OrdinalModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Ordinal, new EnglishNumberParserConfiguration()),
                            new English.OrdinalExtractor()),
                        [typeof (PercentModel)] = new PercentModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Percentage, new EnglishNumberParserConfiguration()),
                            new English.PercentageExtractor())
                    }
                },
                {
                    Culture.Chinese, new Dictionary<Type, IModel>
                    {
                        [typeof (NumberModel)] = new NumberModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Number, new ChineseNumberParserConfiguration()),
                            new Chinese.NumberExtractor()),
                        [typeof (OrdinalModel)] = new OrdinalModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Ordinal, new ChineseNumberParserConfiguration()),
                            new Chinese.OrdinalExtractor()),
                        [typeof (PercentModel)] = new PercentModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Percentage, new ChineseNumberParserConfiguration()),
                            new Chinese.PercentageExtractor())
                    }
                },
                {
                    Culture.Spanish, new Dictionary<Type, IModel>
                    {
                        [typeof (NumberModel)] = new NumberModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Number, new SpanishNumberParserConfiguration()),
                            new Spanish.NumberExtractor(NumberMode.PureNumber)),
                        [typeof (OrdinalModel)] = new OrdinalModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Ordinal, new SpanishNumberParserConfiguration()),
                            new Spanish.OrdinalExtractor()),
                        [typeof (PercentModel)] = new PercentModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Percentage, new SpanishNumberParserConfiguration()),
                            new Spanish.PercentageExtractor())
                    }
                },
                {
                    Culture.Portuguese, new Dictionary<Type, IModel>
                    {
                        [typeof(NumberModel)] = new NumberModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Number, new PortugueseNumberParserConfiguration()),
                            new Portuguese.NumberExtractor(NumberMode.PureNumber)),
                        [typeof(OrdinalModel)] = new OrdinalModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Ordinal, new PortugueseNumberParserConfiguration()),
                            new Portuguese.OrdinalExtractor()),
                        [typeof(PercentModel)] = new PercentModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Percentage, new PortugueseNumberParserConfiguration()),
                            new Portuguese.PercentageExtractor())
                    }
                },
                {
                    Culture.French, new Dictionary<Type, IModel>
                    {
                        [typeof(NumberModel)] = new NumberModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Number, new FrenchNumberParserConfiguration()),
                            new French.NumberExtractor(NumberMode.PureNumber)),
                        [typeof(OrdinalModel)] = new OrdinalModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Ordinal, new FrenchNumberParserConfiguration()),
                            new French.OrdinalExtractor()),
                        [typeof(PercentModel)] = new PercentModel(
                            AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Percentage, new FrenchNumberParserConfiguration()),
                            new French.PercentageExtractor())
                    }
                },
             {
                 Culture.Ukrainian, new Dictionary<Type, IModel>
                 {
                     [typeof (NumberModel)] = new NumberModel(
                         AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Number, new UkrainianNumberParserConfiguration()),
                         new Ukrainian.NumberExtractor(NumberMode.PureNumber)),
                     [typeof (OrdinalModel)] = new OrdinalModel(
                         AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Ordinal, new UkrainianNumberParserConfiguration()),
                         new Ukrainian.OrdinalExtractor()),
                     [typeof (PercentModel)] = new PercentModel(
                         AgnosticNumberParserFactory.GetParser(AgnosticNumberParserType.Percentage, new UkrainianNumberParserConfiguration()),
                         new Ukrainian.PercentageExtractor())
                 }
             },
            };
        }

        public static IModel GetNumberModel(string culture, bool fallbackToDefaultCulture = true)
        {
            return GetModel<NumberModel>(culture, fallbackToDefaultCulture);
        }

        public static IModel GetOrdinalModel(string culture, bool fallbackToDefaultCulture = true)
        {
            return GetModel<OrdinalModel>(culture, fallbackToDefaultCulture);
        }

        public static IModel GetPercentageModel(string culture, bool fallbackToDefaultCulture = true)
        {
            return GetModel<PercentModel>(culture, fallbackToDefaultCulture);
        }
    }
}
