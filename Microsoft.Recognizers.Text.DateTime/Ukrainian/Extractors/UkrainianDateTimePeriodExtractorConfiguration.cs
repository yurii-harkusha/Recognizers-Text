﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Recognizers.Text.Number.Ukrainian;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianDateTimePeriodExtractorConfiguration : IDateTimePeriodExtractorConfiguration
    {
        public UkrainianDateTimePeriodExtractorConfiguration()
        {
            CardinalExtractor = new CardinalExtractor();
            SingleDateExtractor = new BaseDateExtractor(new UkrainianDateExtractorConfiguration());
            SingleTimeExtractor = new BaseTimeExtractor(new UkrainianTimeExtractorConfiguration());
            SingleDateTimeExtractor = new BaseDateTimeExtractor(new UkrainianDateTimeExtractorConfiguration());
        }

        private static readonly Regex[] simpleCasesRegex = new Regex[]
        {
            UkrainianTimePeriodExtractorConfiguration.PureNumFromTo,
            UkrainianTimePeriodExtractorConfiguration.PureNumBetweenAnd
        };

        public IEnumerable<Regex> SimpleCasesRegex => simpleCasesRegex;

        public Regex PrepositionRegex => UkrainianTimePeriodExtractorConfiguration.PrepositionRegex;

        public Regex TillRegex => UkrainianTimePeriodExtractorConfiguration.TillRegex;

        private static readonly Regex nightRegex = new Regex(@"\b(?<night>morning|afternoon|(late\s+)?night|evening)\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private static readonly Regex specificNightRegex = new Regex($@"\b(((this|next|last)\s+{nightRegex})\b|\btonight)\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public Regex NightRegex => nightRegex;

        public Regex SpecificNightRegex => specificNightRegex;

        private static readonly Regex unitRegex =
            new Regex(@"(?<unit>hours|hour|hrs|hr|h|minutes|minute|mins|min|seconds|second|secs|sec)\b",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private static readonly Regex followedUnit = new Regex($@"^\s*{unitRegex}",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex NumberCombinedWithUnit = new Regex($@"\b(?<num>\d+(\.\d*)?){unitRegex}",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public Regex FollowedUnit => followedUnit;

        Regex IDateTimePeriodExtractorConfiguration.NumberCombinedWithUnit => NumberCombinedWithUnit;

        public Regex UnitRegex => unitRegex;

        public Regex PastRegex => UkrainianDatePeriodExtractorConfiguration.PastRegex;

        public Regex FutureRegex => UkrainianDatePeriodExtractorConfiguration.FutureRegex;

        public IExtractor CardinalExtractor { get; }

        public IExtractor SingleDateExtractor { get; }

        public IExtractor SingleTimeExtractor { get; }

        public IExtractor SingleDateTimeExtractor { get; }

        public bool GetFromTokenIndex(string text, out int index)
        {
            index = -1;
            if (text.EndsWith("from"))
            {
                index = text.LastIndexOf("from");
                return true;
            }
            return false;
        }

        public bool GetBetweenTokenIndex(string text, out int index)
        {
            index = -1;
            if (text.EndsWith("between"))
            {
                index = text.LastIndexOf("between");
                return true;
            }
            return false;
        }

        public bool HasConnectorToken(string text)
        {
            return text.Equals("and");
        }
    }
}
