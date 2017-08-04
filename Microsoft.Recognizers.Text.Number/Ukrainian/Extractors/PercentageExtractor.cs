using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.Number.Ukrainian
{
    public sealed class PercentageExtractor : BasePercentageExtractor
    {
        public PercentageExtractor() : base(new NumberExtractor()) { }

        protected override ImmutableHashSet<Regex> InitRegexes()
        {
            HashSet<string> regexStrs = new HashSet<string>
            {
                $@"(@{IntegerExtractor.AllIntRegex})(\s)(процент|відсоток|відсотків|процентів|проценти|відсотки)"
            };

            return BuildRegexes(regexStrs);
        }
    }
}