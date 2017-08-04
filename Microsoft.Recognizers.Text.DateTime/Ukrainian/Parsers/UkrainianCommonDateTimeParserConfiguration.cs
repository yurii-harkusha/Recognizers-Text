using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.Recognizers.Text.DateTime.Ukrainian.Utilities;
using Microsoft.Recognizers.Text.Number;
using Microsoft.Recognizers.Text.Number.Ukrainian;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianCommonDateTimeParserConfiguration : BaseDateParserConfiguration
    {
        public UkrainianCommonDateTimeParserConfiguration()
        {
            UtilityConfiguration = new UkrainianDatetimeUtilityConfiguration();
            UnitMap = InitUnitMap();
            UnitValueMap = InitUnitValueMap();
            SeasonMap = InitSeasonMap();
            CardinalMap = InitCardinalMap();
            DayOfWeek = InitDayOfWeek();
            MonthOfYear = InitMonthOfYear();
            Numbers = InitNumbers();
            CardinalExtractor = new CardinalExtractor();
            IntegerExtractor = new IntegerExtractor();
            OrdinalExtractor = new OrdinalExtractor();
            NumberParser = new BaseNumberParser(new UkrainianNumberParserConfiguration());
            DateExtractor = new BaseDateExtractor(new UkrainianDateExtractorConfiguration());
            TimeExtractor = new BaseTimeExtractor(new UkrainianTimeExtractorConfiguration());
            DateTimeExtractor = new BaseDateTimeExtractor(new UkrainianDateTimeExtractorConfiguration());
            DurationExtractor = new BaseDurationExtractor(new UkrainianDurationExtractorConfiguration());
            DatePeriodExtractor = new BaseDatePeriodExtractor(new UkrainianDatePeriodExtractorConfiguration());
            TimePeriodExtractor = new BaseTimePeriodExtractor(new UkrainianTimePeriodExtractorConfiguration());
            DateTimePeriodExtractor = new BaseDateTimePeriodExtractor(new UkrainianDateTimePeriodExtractorConfiguration());
            DateParser = new BaseDateParser(new UkrainianDateParserConfiguration(this));
            TimeParser = new TimeParser(new UkrainianTimeParserConfiguration(this));
            DateTimeParser = new BaseDateTimeParser(new UkrainianDateTimeParserConfiguration(this));
            DurationParser = new BaseDurationParser(new UkrainianDurationParserConfiguration(this));
            DatePeriodParser = new BaseDatePeriodParser(new UkrainianDatePeriodParserConfiguration(this));
            TimePeriodParser = new BaseTimePeriodParser(new UkrainianTimePeriodParserConfiguration(this));
            DateTimePeriodParser = new BaseDateTimePeriodParser(new UkrainianDateTimePeriodParserConfiguration(this));
        }
        private static ImmutableDictionary<string, string> InitUnitMap()
        {
            return new Dictionary<string, string>
            {
                {"роки", "Y"},
                {"рік", "Y"},
                {"місяці", "MON"},
                {"місяць", "MON"},
                {"тижні", "W"},
                {"тиждень", "W"},
                {"дні", "D"},
                {"день", "D"},
                {"години", "H"},
                {"година", "H"},
                {"год", "H"},
                {"г", "H"},
                {"хвилини", "M"},
                {"хвилина", "M"},
                {"хв", "M"},
                {"секунди", "S"},
                {"секунда", "S"},
                {"сек", "S"},
                {"с", "S"}
            }.ToImmutableDictionary();
        }
        private static ImmutableDictionary<string, long> InitUnitValueMap()
        {
            return new Dictionary<string, long>
            {
                {"роки", 31536000},
                {"рік", 31536000},
                {"місяці", 2592000},
                {"місяць", 2592000},
                {"тижні", 604800},
                {"тиждень", 604800},
                {"дні", 86400},
                {"день", 86400},
                {"години", 3600},
                {"година", 3600},
                {"год", 3600},
                {"г", 3600},
                {"хвилини", 60},
                {"хвилина", 60},
                {"хв", 60},
                {"х", 60},
                {"секунди", 1},
                {"секунда", 1},
                {"сек", 1},
                {"с", 1}
            }.ToImmutableDictionary();
        }
        private static ImmutableDictionary<string, string> InitSeasonMap()
        {
            return new Dictionary<string, string>
            {
                {"весна", "SP"},
                {"літо", "SU"},
                {"fall", "FA"},
                {"осінь", "FA"},
                {"зима", "WI"}
            }.ToImmutableDictionary();
        }
        private static ImmutableDictionary<string, int> InitSeasonValueMap()
        {
            return new Dictionary<string, int>
            {
                {"SP", 3},
                {"SU", 6},
                {"FA", 9},
                {"WI", 12}
            }.ToImmutableDictionary();
        }
        private static ImmutableDictionary<string, int> InitCardinalMap()
        {
            return new Dictionary<string, int>
            {
                {"перший", 1},
                {"1ий", 1},
                {"другий", 2},
                {"2", 2},
                {"третій", 3},
                {"3ій", 3},
                {"четвертий", 4},
                {"4ий", 4},
                {"п'ятий", 5},
                {"5ий", 5}
            }.ToImmutableDictionary();
        }

        private static ImmutableDictionary<string, int> InitDayOfWeek()
        {
            return new Dictionary<string, int>
            {
                {"понеділок", 1},
                {"вівторок", 2},
                {"середа", 3},
                {"четвер", 4},
                {"п'ятниця", 5},
                {"субота", 6},
                {"неділя", 0},
                {"пн", 1},
                {"вт", 2},
                {"ср", 3},
                {"чт", 4},
                {"пт", 5},
                {"сб", 6},
                {"нд", 0}
            }.ToImmutableDictionary();
        }
        private static ImmutableDictionary<string, int> InitMonthOfYear()
        {
            return new Dictionary<string, int>
            {
                {"січень", 1},
                {"лютий", 2},
                {"березень", 3},
                {"квітень", 4},
                {"травень", 5},
                {"червень", 6},
                {"липень", 7},
                {"серпень", 8},
                {"вересень", 9},
                {"жовтень", 10},
                {"листопад", 11},
                {"грудень", 12},
                {"січ", 1},
                {"лют", 2},
                {"бер", 3},
                {"кві", 4},
                {"тра", 5},
                {"чер", 6},
                {"лип", 7},
                {"сер", 8},
                {"вер", 9},
                {"жов", 10},
                {"лис", 11},
                {"гру", 12},
                {"1", 1},
                {"2", 2},
                {"3", 3},
                {"4", 4},
                {"5", 5},
                {"6", 6},
                {"7", 7},
                {"8", 8},
                {"9", 9},
                {"10", 10},
                {"11", 11},
                {"12", 12},
                {"01", 1},
                {"02", 2},
                {"03", 3},
                {"04", 4},
                {"05", 5},
                {"06", 6},
                {"07", 7},
                {"08", 8},
                {"09", 9}
            }.ToImmutableDictionary();
        }
        private static ImmutableDictionary<string, int> InitNumbers()
        {
            return new Dictionary<string, int>
            {
                {"zero", 0},
                {"one", 1},
                {"a", 1},
                {"an", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9},
                {"ten", 10},
                {"eleven", 11},
                {"twelve", 12},
                {"thirteen", 13},
                {"fourteen", 14},
                {"fifteen", 15},
                {"sixteen", 16},
                {"seventeen", 17},
                {"eighteen", 18},
                {"nineteen", 19},
                {"twenty", 20},
                {"twenty one", 21},
                {"twenty two", 22},
                {"twenty three", 23},
                {"twenty four", 24},
                {"twenty five", 25},
                {"twenty six", 26},
                {"twenty seven", 27},
                {"twenty eight", 28},
                {"twenty nine", 29},
                {"thirty", 30},
                {"thirty one", 31},
                {"thirty two", 32},
                {"thirty three", 33},
                {"thirty four", 34},
                {"thirty five", 35},
                {"thirty six", 36},
                {"thirty seven", 37},
                {"thirty eight", 38},
                {"thirty nine", 39},
                {"forty", 40},
                {"forty one", 41},
                {"forty two", 42},
                {"forty three", 43},
                {"forty four", 44},
                {"forty five", 45},
                {"forty six", 46},
                {"forty seven", 47},
                {"forty eight", 48},
                {"forty nine", 49},
                {"fifty", 50},
                {"fifty one", 51},
                {"fifty two", 52},
                {"fifty three", 53},
                {"fifty four", 54},
                {"fifty five", 55},
                {"fifty six", 56},
                {"fifty seven", 57},
                {"fifty eight", 58},
                {"fifty nine", 59},
                {"sixty", 60},
                {"sixty one", 61},
                {"sixty two", 62},
                {"sixty three", 63},
                {"sixty four", 64},
                {"sixty five", 65},
                {"sixty six", 66},
                {"sixty seven", 67},
                {"sixty eight", 68},
                {"sixty nine", 69},
                {"seventy", 70},
                {"seventy one", 71},
                {"seventy two", 72},
                {"seventy three", 73},
                {"seventy four", 74},
                {"seventy five", 75},
                {"seventy six", 76},
                {"seventy seven", 77},
                {"seventy eight", 78},
                {"seventy nine", 79},
                {"eighty", 80},
                {"eighty one", 81},
                {"eighty two", 82},
                {"eighty three", 83},
                {"eighty four", 84},
                {"eighty five", 85},
                {"eighty six", 86},
                {"eighty seven", 87},
                {"eighty eight", 88},
                {"eighty nine", 89},
                {"ninety", 90},
                {"ninety one", 91},
                {"ninety two", 92},
                {"ninety three", 93},
                {"ninety four", 94},
                {"ninety five", 95},
                {"ninety six", 96},
                {"ninety seven", 97},
                {"ninety eight", 98},
                {"ninety nine", 99},
                {"one hundred", 100}
            }.ToImmutableDictionary();
        }

        public override IImmutableDictionary<string, int> DayOfMonth
        {
            get
            {
                return base.DayOfMonth.AddRange(new Dictionary<string, int>
                {
                    { "1е", 1},
                    { "2е", 2},
                    { "3є", 3},
                    { "4те", 4},
                    { "5те", 5},
                    { "6те", 6},
                    { "7е", 7},
                    { "8е", 8},
                    { "9те", 9},
                    { "10те", 10},
                    { "11те", 11},
                    { "11те", 11},
                    { "12те", 12},
                    { "12те", 12},
                    { "13те", 13},
                    { "13те", 13},
                    { "14те", 14},
                    { "15те", 15},
                    { "16те", 16},
                    { "17те", 17},
                    { "18те", 18},
                    { "19те", 19},
                    { "20те", 20},
                    { "21е", 21},
                    { "22е", 22},
                    { "23є", 23},
                    { "24те", 24},
                    { "25те", 25},
                    { "26е", 26},
                    { "27е", 27},
                    { "28е", 28},
                    { "29е", 29},
                    { "30е", 30},
                    { "31е", 31}
                });
            }
        }
    }
}