﻿using System.Collections.Immutable;
using Microsoft.Recognizers.Text.DateTime.Utilities;

namespace Microsoft.Recognizers.Text.DateTime
{
    public interface ICommonDateTimeParserConfiguration
    {
        IExtractor CardinalExtractor { get; }
        IExtractor IntegerExtractor { get; }
        IExtractor OrdinalExtractor { get; }
        IParser NumberParser { get; }

        IExtractor DateExtractor { get; }
        IExtractor TimeExtractor { get; }
        IExtractor DateTimeExtractor { get; }
        IExtractor DurationExtractor { get; }
        IExtractor DatePeriodExtractor { get; }
        IExtractor TimePeriodExtractor { get; }
        IExtractor DateTimePeriodExtractor { get; }

        IDateTimeParser DateParser { get; }
        IDateTimeParser TimeParser { get; }
        IDateTimeParser DateTimeParser { get; }
        IDateTimeParser DurationParser { get; }
        IDateTimeParser DatePeriodParser { get; }
        IDateTimeParser TimePeriodParser { get; }
        IDateTimeParser DateTimePeriodParser { get; }


        IImmutableDictionary<string, int> MonthOfYear { get; }
        IImmutableDictionary<string, int> Numbers { get; }
        IImmutableDictionary<string, long> UnitValueMap { get; }
        IImmutableDictionary<string, string> SeasonMap { get; }
        IImmutableDictionary<string, string> UnitMap { get; }
        IImmutableDictionary<string, int> CardinalMap { get; }
        IImmutableDictionary<string, int> DayOfMonth { get; }
        IImmutableDictionary<string, int> DayOfWeek { get; }

        IDateTimeUtilityConfiguration UtilityConfiguration { get; }
    }
}
