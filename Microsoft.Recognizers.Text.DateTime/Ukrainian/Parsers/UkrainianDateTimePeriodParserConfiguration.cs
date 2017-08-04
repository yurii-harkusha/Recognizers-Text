using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianDateTimePeriodParserConfiguration : IDateTimePeriodParserConfiguration
    {
        public IExtractor DateExtractor { get; }

        public IExtractor TimeExtractor { get; }

        public IExtractor DateTimeExtractor { get; }

        public IExtractor CardinalExtractor { get; }

        public IParser NumberParser { get; }

        public IDateTimeParser DateParser { get; }

        public IDateTimeParser TimeParser { get; }

        public IDateTimeParser DateTimeParser { get; }

        public Regex PureNumberFromToRegex { get; }

        public Regex PureNumberBetweenAndRegex { get; }

        public Regex SpecificNightRegex { get; }

        public Regex NightRegex { get; }

        public Regex PastRegex { get; }

        public Regex FutureRegex { get; }

        public Regex NumberCombinedWithUnitRegex { get; }

        public Regex UnitRegex { get; }

        public IImmutableDictionary<string, string> UnitMap { get; }

        public IImmutableDictionary<string, int> Numbers { get; }

        public UkrainianDateTimePeriodParserConfiguration(ICommonDateTimeParserConfiguration config)
        {
            DateExtractor = config.DateExtractor;
            TimeExtractor = config.TimeExtractor;
            DateTimeExtractor = config.DateTimeExtractor;
            CardinalExtractor = config.CardinalExtractor;
            NumberParser = config.NumberParser;
            DateParser = config.DateParser;
            TimeParser = config.TimeParser;
            DateTimeParser = config.DateTimeParser;
            PureNumberFromToRegex = UkrainianTimePeriodExtractorConfiguration.PureNumFromTo;
            PureNumberBetweenAndRegex = UkrainianTimePeriodExtractorConfiguration.PureNumBetweenAnd;
            SpecificNightRegex = UkrainianDateTimeExtractorConfiguration.SpecificNightRegex;
            NightRegex = UkrainianDateTimeExtractorConfiguration.NightRegex;
            PastRegex = UkrainianDatePeriodExtractorConfiguration.PastRegex;
            FutureRegex = UkrainianDatePeriodExtractorConfiguration.FutureRegex;
            NumberCombinedWithUnitRegex = UkrainianDateTimePeriodExtractorConfiguration.NumberCombinedWithUnit;
            UnitRegex = UkrainianTimePeriodExtractorConfiguration.UnitRegex;
            UnitMap = config.UnitMap;
            Numbers = config.Numbers;
        }

        public bool GetMatchedTimeRange(string text, out string timeStr, out int beginHour, out int endHour, out int endMin)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            beginHour = 0;
            endHour = 0;
            endMin = 0;
            if (trimedText.EndsWith("ранку"))
            {
                timeStr = "TMO";
                beginHour = 8;
                endHour = 12;
            }
            else if (trimedText.EndsWith("дня"))
            {
                timeStr = "TAF";
                beginHour = 12;
                endHour = 16;
            }
            else if (trimedText.EndsWith("вечора"))
            {
                timeStr = "TEV";
                beginHour = 16;
                endHour = 20;
            }
            else if (trimedText.EndsWith("ночі"))
            {
                timeStr = "TNI";
                beginHour = 20;
                endHour = 23;
                endMin = 59;
            }
            else
            {
                timeStr = null;
                return false;
            }
            return true;
        }

        public int GetSwiftPrefix(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            var swift = 0;
            if (trimedText.StartsWith("наступного"))
            {
                swift = 1;
            }
            else if (trimedText.StartsWith("минулого"))
            {
                swift = -1;
            }
            return swift;
        }
    }
}
