using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.Number.Ukrainian
{
    public class FractionExtractor : BaseNumberExtractor
    {
        internal sealed override ImmutableDictionary<Regex, string> Regexes { get; }
        protected sealed override string ExtractType { get; } = Constants.SYS_NUM_FRACTION; // "Fraction";

        public static string AllFracRegex
            =>
                $@"({IntegerExtractor.AllIntRegex})";

        public FractionExtractor()
        {
            var _regexes = new Dictionary<Regex, string>
            {
                //{
                //    new Regex(
                //        $@"(?<=\b)({AllFracRegex}\s+(і\s+)?)?({IntegerExtractor.AllIntRegex
                //            })(\s+|\s*-\s*)((({OrdinalExtractor.AllOrdinalRegex})|({
                //                OrdinalExtractor.RoundNumberOrdinalRegex}))s|halves|quarters)(?=\b)",
                //        RegexOptions.IgnoreCase | RegexOptions.Singleline)
                //    , "FracUa"
                //},
                {
                    new Regex(@"(((?<=\W|^)-\s*)|(?<=\b))\d+\s+\d+[/]\d+(?=(\b[^/]|$))",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline)
                    , "FracNum"
                },
                {
                    new Regex(@"(((?<=\W|^)-\s*)|(?<=\b))\d+[/]\d+(?=(\b[^/]|$))",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline)
                    , "FracNum"
                },
                {
                    new Regex(
                        $@"(({IntegerExtractor.AllIntRegex}\s+)({OrdinalExtractor.AllOrdinalRegex}))", RegexOptions.IgnoreCase | RegexOptions.Singleline)
                    , "FracUa"
                },
                {
                    new Regex(
                        $@"(({IntegerExtractor.AllIntRegex}(\s+))цілих(\s+)(({IntegerExtractor.AllIntRegex}\s+)({OrdinalExtractor.AllOrdinalRegex})))", RegexOptions.IgnoreCase | RegexOptions.Singleline)
                    , "FracUa"
                },
            };
            Regexes = _regexes.ToImmutableDictionary();
        }
    }
}