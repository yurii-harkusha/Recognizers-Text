using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianDatePeriodParserConfiguration : IDatePeriodParserConfiguration
    {
        public string TokenBeforeDate { get; }

        #region internalsParsers

        public IExtractor DateExtractor { get; }

        public IExtractor CardinalExtractor { get; }

        public IParser NumberParser { get; }

        public IDateTimeParser DateParser { get; }

        #endregion

        #region Regexes

        public Regex MonthFrontBetweenRegex { get; }
        public Regex BetweenRegex { get; }
        public Regex MonthFrontSimpleCasesRegex { get; }
        public Regex SimpleCasesRegex { get; }
        public Regex OneWordPeriodRegex { get; }
        public Regex MonthWithYear { get; }
        public Regex MonthNumWithYear { get; }
        public Regex YearRegex { get; }
        public Regex PastRegex { get; }
        public Regex FutureRegex { get; }
        public Regex NumberCombinedWithUnit { get; }
        public Regex WeekOfMonthRegex { get; }
        public Regex WeekOfYearRegex { get; }
        public Regex QuarterRegex { get; }
        public Regex QuarterRegexYearFront { get; }
        public Regex SeasonRegex { get; }
        public Regex WhichWeekRegex { get; }
        public Regex WeekOfRegex { get; }
        public Regex MonthOfRegex { get; }

        #endregion

        #region Dictionaries

        public IImmutableDictionary<string, string> UnitMap { get; }

        public IImmutableDictionary<string, int> CardinalMap { get; }

        public IImmutableDictionary<string, int> DayOfMonth { get; }

        public IImmutableDictionary<string, int> MonthOfYear { get; }

        public IImmutableDictionary<string, string> SeasonMap { get; }

        #endregion

        public IImmutableList<string> InStringList { get; }

        public UkrainianDatePeriodParserConfiguration(ICommonDateTimeParserConfiguration config)
        {
            TokenBeforeDate = "on ";
            CardinalExtractor = config.CardinalExtractor;
            NumberParser = config.NumberParser;
            DateExtractor = config.DateExtractor;
            DateParser = config.DateParser;
            MonthFrontBetweenRegex = UkrainianDatePeriodExtractorConfiguration.MonthFrontBetweenRegex;
            BetweenRegex = UkrainianDatePeriodExtractorConfiguration.BetweenRegex;
            MonthFrontSimpleCasesRegex = UkrainianDatePeriodExtractorConfiguration.MonthFrontSimpleCasesRegex;
            SimpleCasesRegex = UkrainianDatePeriodExtractorConfiguration.SimpleCasesRegex;
            OneWordPeriodRegex = UkrainianDatePeriodExtractorConfiguration.OneWordPeriodRegex;
            MonthWithYear = UkrainianDatePeriodExtractorConfiguration.MonthWithYear;
            MonthNumWithYear = UkrainianDatePeriodExtractorConfiguration.MonthNumWithYear;
            YearRegex = UkrainianDatePeriodExtractorConfiguration.YearRegex;
            PastRegex = UkrainianDatePeriodExtractorConfiguration.PastRegex;
            FutureRegex = UkrainianDatePeriodExtractorConfiguration.FutureRegex;
            NumberCombinedWithUnit = UkrainianDurationExtractorConfiguration.NumberCombinedWithUnit;
            WeekOfMonthRegex = UkrainianDatePeriodExtractorConfiguration.WeekOfMonthRegex;
            WeekOfYearRegex = UkrainianDatePeriodExtractorConfiguration.WeekOfYearRegex;
            QuarterRegex = UkrainianDatePeriodExtractorConfiguration.QuarterRegex;
            QuarterRegexYearFront = UkrainianDatePeriodExtractorConfiguration.QuarterRegexYearFront;
            SeasonRegex = UkrainianDatePeriodExtractorConfiguration.SeasonRegex;
            WhichWeekRegex = UkrainianDatePeriodExtractorConfiguration.WhichWeekRegex;
            WeekOfRegex = UkrainianDatePeriodExtractorConfiguration.WeekOfRegex;
            MonthOfRegex = UkrainianDatePeriodExtractorConfiguration.MonthOfRegex;
            UnitMap = config.UnitMap;
            CardinalMap = config.CardinalMap;
            DayOfMonth = config.DayOfMonth;
            MonthOfYear = config.MonthOfYear;
            SeasonMap = config.SeasonMap;
            InStringList = config.UtilityConfiguration.InStringList.ToImmutableList();
        }

        public int GetSwiftDay(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            var swift = 0;
            if (trimedText.StartsWith("наступний"))
            {
                swift = 1;
            }
            else if (trimedText.StartsWith("минулий"))
            {
                swift = -1;
            }
            return swift;
        }

        public int GetSwiftMonth(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            var swift = 0;
            if (trimedText.StartsWith("наступний"))
            {
                swift = 1;
            }
            if (trimedText.StartsWith("минулий"))
            {
                swift = -1;
            }
            return swift;
        }

        public int GetSwiftYear(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            var swift = -10;
            if (trimedText.StartsWith("наступний"))
            {
                swift = 1;
            }
            else if (trimedText.StartsWith("минулий"))
            {
                swift = -1;
            }
            else if (trimedText.StartsWith("цього"))
            {
                swift = 0;
            }
            return swift;
        }

        public bool IsFuture(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            return (trimedText.StartsWith("цього") || trimedText.StartsWith("наступного"));
        }

        public bool IsLastCardinal(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            return trimedText.Equals("минулий");
        }

        public bool IsMonthOnly(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            return trimedText.EndsWith("місяць");
        }

        public bool IsMonthToDate(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            return trimedText.Equals("місяць до дати");
        }

        public bool IsWeekend(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            return trimedText.EndsWith("вихідні");
        }

        public bool IsWeekOnly(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            return trimedText.EndsWith("тиждень");
        }

        public bool IsYearOnly(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            return trimedText.EndsWith("рік");
        }

        public bool IsYearToDate(string text)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            return trimedText.Equals("рік до дати");
        }
    }
}
