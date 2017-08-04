﻿using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianSetParserConfiguration : ISetParserConfiguration
    {
        public IExtractor DurationExtractor { get; }

        public IDateTimeParser DurationParser { get; }

        public IExtractor TimeExtractor { get; }

        public IDateTimeParser TimeParser { get; }

        public IExtractor DateExtractor { get; }

        public IDateTimeParser DateParser { get; }

        public IExtractor DateTimeExtractor { get; }

        public IDateTimeParser DateTimeParser { get; }

        public IExtractor DatePeriodExtractor { get; }

        public IDateTimeParser DatePeriodParser { get; }

        public IExtractor TimePeriodExtractor { get; }

        public IDateTimeParser TimePeriodParser { get; }

        public IExtractor DateTimePeriodExtractor { get; }

        public IDateTimeParser DateTimePeriodParser { get; }

        public IImmutableDictionary<string, string> UnitMap { get; }

        public Regex EachPrefixRegex { get; }

        public Regex PeriodicRegex { get; }

        public Regex EachUnitRegex { get; }

        public Regex EachDayRegex { get; }

        public UkrainianSetParserConfiguration(ICommonDateTimeParserConfiguration config)
        {
            DurationExtractor = config.DurationExtractor;
            TimeExtractor = config.TimeExtractor;
            DateExtractor = config.DateExtractor;
            DateTimeExtractor = config.DateTimeExtractor;
            DatePeriodExtractor = config.DatePeriodExtractor;
            TimePeriodExtractor = config.TimePeriodExtractor;
            DateTimePeriodExtractor = config.DateTimePeriodExtractor;

            DurationParser = config.DurationParser;
            TimeParser = config.TimeParser;
            DateParser = config.DateParser;
            DateTimeParser = config.DateTimeParser;
            DatePeriodParser = config.DatePeriodParser;
            TimePeriodParser = config.TimePeriodParser;
            DateTimePeriodParser = config.DateTimePeriodParser;
            UnitMap = config.UnitMap;

            EachPrefixRegex = UkrainianSetExtractorConfiguration.EachPrefixRegex;
            PeriodicRegex = UkrainianSetExtractorConfiguration.PeriodicRegex;
            EachUnitRegex = UkrainianSetExtractorConfiguration.EachUnitRegex;
            EachDayRegex = UkrainianSetExtractorConfiguration.EachDayRegex;
        }

        public bool GetMatchedDailyTimex(string text, out string timex)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            if (trimedText.Equals("daily"))
            {
                timex = "P1D";
            }
            else if (trimedText.Equals("weekly"))
            {
                timex = "P1W";
            }
            else if (trimedText.Equals("biweekly"))
            {
                timex = "P2W";
            }
            else if (trimedText.Equals("monthly"))
            {
                timex = "P1M";
            }
            else if (trimedText.Equals("yearly") || trimedText.Equals("annually") || trimedText.Equals("annual"))
            {
                timex = "P1Y";
            }
            else
            {
                timex = null;
                return false;
            }
            return true;
        }

        public bool GetMatchedUnitTimex(string text, out string timex)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            if (trimedText.Equals("day"))
            {
                timex = "P1D";
            }
            else if (trimedText.Equals("week"))
            {
                timex = "P1W";
            }
            else if (trimedText.Equals("month"))
            {
                timex = "P1M";
            }
            else if (trimedText.Equals("year"))
            {
                timex = "P1Y";
            }
            else
            {
                timex = null;
                return false;
            }
            return true;
        }
    }
}