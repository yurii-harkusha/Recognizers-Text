using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianMergedParserConfiguration : UkrainianCommonDateTimeParserConfiguration, IMergedParserConfiguration
    {
        public Regex BeforeRegex { get; }

        public Regex AfterRegex { get; }

        public IDateTimeParser DatePeriodParser { get; }

        public IDateTimeParser TimePeriodParser { get; }

        public IDateTimeParser DateTimePeriodParser { get; }

        public IDateTimeParser SetParser { get; }

        public IDateTimeParser HolidayParser { get; }

        public UkrainianMergedParserConfiguration() : base()
        {
            BeforeRegex = new Regex(@"^\s*before\s+",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
            AfterRegex = new Regex(@"^\s*after\s+",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
            DatePeriodParser = new BaseDatePeriodParser(new UkrainianDatePeriodParserConfiguration(this));
            TimePeriodParser = new BaseTimePeriodParser(new UkrainianTimePeriodParserConfiguration(this));
            DateTimePeriodParser = new BaseDateTimePeriodParser(new UkrainianDateTimePeriodParserConfiguration(this));
            SetParser = new BaseSetParser(new UkrainianSetParserConfiguration(this));
            HolidayParser = new BaseHolidayParser(new UkrainianHolidayParserConfiguration());
        }
    }
}
