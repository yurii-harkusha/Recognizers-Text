using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianSetExtractorConfiguration : ISetExtractorConfiguration
    {
        public static readonly Regex UnitRegex =
            new Regex(
                @"(?<unit>years|year|months|month|weeks|week|days|day|hours|hour|hrs|hr|h|minutes|minute|mins|min|seconds|second|secs|sec)\b",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex PeriodicRegex = new Regex(
            @"\b(?<periodic>daily|monthly|weekly|biweekly|yearly|annually|annual)\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EachUnitRegex = new Regex(
            $@"(?<each>(each|every)\s*{UnitRegex})", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EachPrefixRegex = new Regex(@"(?<each>(each|every)\s*$)",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex LastRegex = new Regex(@"(?<last>last|this|next)",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex EachDayRegex = new Regex(@"^\s*(each|every)\s*day\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public UkrainianSetExtractorConfiguration()
        {
            DurationExtractor = new BaseDurationExtractor(new UkrainianDurationExtractorConfiguration());
            TimeExtractor = new BaseTimeExtractor(new UkrainianTimeExtractorConfiguration());
            DateExtractor = new BaseDateExtractor(new UkrainianDateExtractorConfiguration());
            DateTimeExtractor = new BaseDateTimeExtractor(new UkrainianDateTimeExtractorConfiguration());
            DatePeriodExtractor = new BaseDatePeriodExtractor(new UkrainianDatePeriodExtractorConfiguration());
            TimePeriodExtractor = new BaseTimePeriodExtractor(new UkrainianTimePeriodExtractorConfiguration());
            DateTimePeriodExtractor = new BaseDateTimePeriodExtractor(new UkrainianDateTimePeriodExtractorConfiguration());
        }

        public IExtractor DurationExtractor { get; }

        public IExtractor TimeExtractor { get; }

        public IExtractor DateExtractor { get; }

        public IExtractor DateTimeExtractor { get; }

        public IExtractor DatePeriodExtractor { get; }

        public IExtractor TimePeriodExtractor { get; }

        public IExtractor DateTimePeriodExtractor { get; }

        Regex ISetExtractorConfiguration.LastRegex => LastRegex;

        Regex ISetExtractorConfiguration.EachPrefixRegex => EachPrefixRegex;

        Regex ISetExtractorConfiguration.PeriodicRegex => PeriodicRegex;

        Regex ISetExtractorConfiguration.EachUnitRegex => EachUnitRegex;

        Regex ISetExtractorConfiguration.EachDayRegex => EachDayRegex;

        Regex ISetExtractorConfiguration.BeforeEachDayRegex => null;
    }
}