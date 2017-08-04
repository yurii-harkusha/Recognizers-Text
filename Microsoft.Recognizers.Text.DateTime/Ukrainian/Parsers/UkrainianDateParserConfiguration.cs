using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;
using Microsoft.Recognizers.Text.DateTime.Ukrainian.Utilities;
using Microsoft.Recognizers.Text.DateTime.Utilities;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianDateParserConfiguration : IDateParserConfiguration
    {
        public string DateTokenPrefix { get; }

        public IExtractor IntegerExtractor { get; }

        public IExtractor OrdinalExtractor { get; }

        public IExtractor CardinalExtractor { get; }

        public IParser NumberParser { get; }

        public IExtractor DurationExtractor { get; }

        public IParser DurationParser { get; }

        public IEnumerable<Regex> DateRegexes { get; }

        public IImmutableDictionary<string, string> UnitMap { get; }

        public Regex OnRegex { get; }

        public Regex SpecialDayRegex { get; }

        public Regex NextRegex { get; }

        public Regex ThisRegex { get; }

        public Regex LastRegex { get; }

        public Regex UnitRegex { get; }

        public Regex StrictWeekDay { get; }

        public Regex MonthRegex { get; }

        public Regex WeekDayOfMonthRegex { get; }

        public IImmutableDictionary<string, int> DayOfMonth { get; }

        public IImmutableDictionary<string, int> DayOfWeek { get; }

        public IImmutableDictionary<string, int> MonthOfYear { get; }

        public IImmutableDictionary<string, int> CardinalMap { get; }

        public IDateTimeUtilityConfiguration UtilityConfiguration { get; }

        public UkrainianDateParserConfiguration(ICommonDateTimeParserConfiguration config)
        {
            DateTokenPrefix = "on ";
            IntegerExtractor = config.IntegerExtractor;
            OrdinalExtractor = config.OrdinalExtractor;
            CardinalExtractor = config.CardinalExtractor;
            NumberParser = config.NumberParser;
            DurationExtractor = config.DurationExtractor;
            DurationParser = config.DurationParser;
            DateRegexes = UkrainianDateExtractorConfiguration.DateRegexList;
            OnRegex = UkrainianDateExtractorConfiguration.OnRegex;
            SpecialDayRegex = UkrainianDateExtractorConfiguration.SpecialDayRegex;
            NextRegex = UkrainianDateExtractorConfiguration.NextRegex;
            ThisRegex = UkrainianDateExtractorConfiguration.ThisRegex;
            LastRegex = UkrainianDateExtractorConfiguration.LastRegex;
            UnitRegex = UkrainianDateExtractorConfiguration.UnitRegex;
            StrictWeekDay = UkrainianDateExtractorConfiguration.StrictWeekDay;
            MonthRegex = UkrainianDateExtractorConfiguration.MonthRegex;
            WeekDayOfMonthRegex = UkrainianDateExtractorConfiguration.WeekDayOfMonthRegex;
            DayOfMonth = config.DayOfMonth;
            DayOfWeek = config.DayOfWeek;
            MonthOfYear = config.MonthOfYear;
            CardinalMap = config.CardinalMap;
            UnitMap = config.UnitMap;
            UtilityConfiguration = config.UtilityConfiguration;
        }

        public int GetSwiftDay(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            var swift = 0;
            if (trimedText.Equals("сьогодні"))
            {
                swift = 0;
            }
            else if (trimedText.Equals("завтра") || trimedText.Equals("наступного дня"))
            {
                swift = 1;
            }
            else if (trimedText.Equals("вчора"))
            {
                swift = -1;
            }
            else if (trimedText.EndsWith("післязавтра"))
            {
                swift = 2;
            }
            else if (trimedText.EndsWith("позавчора"))
            {
                swift = -2;
            }
            else if (trimedText.EndsWith("минулого дня"))
            {
                swift = -1;
            }
            return swift;
        }

        public int GetSwiftMonth(string text)
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

        public bool IsCardinalLast(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            return trimedText.Equals("минулого");
        }
    }
}
