using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;
using Microsoft.Recognizers.Text.DateTime.Utilities;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianDateTimeParserConfiguration : IDateTimeParserConfiguration
    {
        public string TokenBeforeDate { get; }

        public string TokenBeforeTime { get; }

        public IExtractor DateExtractor { get; }

        public IExtractor TimeExtractor { get; }

        public IDateTimeParser DateParser { get; }

        public IDateTimeParser TimeParser { get; }

        public IExtractor CardinalExtractor { get; }

        public IParser NumberParser { get; }

        public IExtractor DurationExtractor { get; }

        public IParser DurationParser { get; }

        public IImmutableDictionary<string, string> UnitMap { get; }

        public Regex NowRegex { get; }

        public Regex AMTimeRegex { get; }

        public Regex PMTimeRegex { get; }

        public Regex SimpleTimeOfTodayAfterRegex { get; }

        public Regex SimpleTimeOfTodayBeforeRegex { get; }

        public Regex SpecificNightRegex { get; }

        public Regex TheEndOfRegex { get; }

        public Regex UnitRegex { get; }

        public IImmutableDictionary<string, int> Numbers { get; }

        public IDateTimeUtilityConfiguration UtilityConfiguration { get; }

        public UkrainianDateTimeParserConfiguration(ICommonDateTimeParserConfiguration config)
        {
            TokenBeforeDate = "on ";
            TokenBeforeTime = "at ";
            DateExtractor = config.DateExtractor;
            TimeExtractor = config.TimeExtractor;
            DateParser = config.DateParser;
            TimeParser = config.TimeParser;
            NowRegex = UkrainianDateTimeExtractorConfiguration.NowRegex;
            AMTimeRegex = new Regex(@"(?<am>morning)",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
            PMTimeRegex = new Regex(@"(?<pm>afternoon|evening|night)",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);
            SimpleTimeOfTodayAfterRegex = UkrainianDateTimeExtractorConfiguration.SimpleTimeOfTodayAfterRegex;
            SimpleTimeOfTodayBeforeRegex = UkrainianDateTimeExtractorConfiguration.SimpleTimeOfTodayBeforeRegex;
            SpecificNightRegex = UkrainianDateTimeExtractorConfiguration.SpecificNightRegex;
            TheEndOfRegex = UkrainianDateTimeExtractorConfiguration.TheEndOfRegex;
            UnitRegex = UkrainianTimeExtractorConfiguration.UnitRegex;
            Numbers = config.Numbers;
            CardinalExtractor = config.CardinalExtractor;
            NumberParser = config.NumberParser;
            DurationExtractor = config.DurationExtractor;
            DurationParser = config.DurationParser;
            UnitMap = config.UnitMap;
            UtilityConfiguration = config.UtilityConfiguration;
        }

        public int GetHour(string text, int hour)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            int result = hour;
            if (trimedText.EndsWith("ранок") && hour >= 12)
            {
                result -= 12;
            }
            else if (!trimedText.EndsWith("ранок") && hour < 12)
            {
                result += 12;
            }
            return result;
        }

        public bool GetMatchedNowTimex(string text, out string timex)
        {
            var trimedText = text.Trim().ToLowerInvariant();
            if (trimedText.EndsWith("now"))
            {
                timex = "PRESENT_REF";
            }
            else if (trimedText.Equals("нещодавно") || trimedText.Equals("минулого"))
            {
                timex = "PAST_REF";
            }
            else if (trimedText.Equals("якнайшвидше"))
            {
                timex = "FUTURE_REF";
            }
            else
            {
                timex = null;
                return false;
            }
            return true;
        }

        public int GetSwiftDay(string text)
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

        public bool HaveAmbiguousToken(string text, string matchedText) => false;
    }
}