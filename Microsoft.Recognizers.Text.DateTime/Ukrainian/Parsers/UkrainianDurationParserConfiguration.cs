using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianDurationParserConfiguration : IDurationParserConfiguration
    {
        public IExtractor CardinalExtractor { get; }

        public IParser NumberParser { get; }

        public Regex NumberCombinedWithUnit { get; }

        public Regex AnUnitRegex { get; }

        public Regex AllDateUnitRegex { get; }

        public Regex HalfDateUnitRegex { get; }

        public IImmutableDictionary<string, string> UnitMap { get; }

        public IImmutableDictionary<string, long> UnitValueMap { get; }

        public UkrainianDurationParserConfiguration(ICommonDateTimeParserConfiguration config)
        {
            CardinalExtractor = config.CardinalExtractor;
            NumberParser = config.NumberParser;
            NumberCombinedWithUnit = UkrainianDurationExtractorConfiguration.NumberCombinedWithUnit;
            AnUnitRegex = UkrainianDurationExtractorConfiguration.AnUnitRegex;
            AllDateUnitRegex = UkrainianDurationExtractorConfiguration.AllRegex;
            HalfDateUnitRegex = UkrainianDurationExtractorConfiguration.HalfRegex;
            UnitMap = config.UnitMap;
            UnitValueMap = config.UnitValueMap;
        }
    }
}
