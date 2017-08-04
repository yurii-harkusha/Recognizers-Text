using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Recognizers.Text.DateTime.Ukrainian;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian.Extractors
{
    public class UkrainianMergedExtractorConfiguration : IMergedExtractorConfiguration
    {
        public IExtractor DateExtractor { get; }

        public IExtractor TimeExtractor { get; }

        public IExtractor DateTimeExtractor { get; }

        public IExtractor DatePeriodExtractor { get; }

        public IExtractor TimePeriodExtractor { get; }

        public IExtractor DateTimePeriodExtractor { get; }

        public IExtractor DurationExtractor { get; }

        public IExtractor SetExtractor { get; }

        public IExtractor HolidayExtractor { get; }

        public UkrainianMergedExtractorConfiguration()
        {
            DateExtractor = new BaseDateExtractor(new UkrainianDateExtractorConfiguration());
            TimeExtractor = new BaseTimeExtractor(new UkrainianTimeExtractorConfiguration());
            DateTimeExtractor = new BaseDateTimeExtractor(new UkrainianDateTimeExtractorConfiguration());
            DatePeriodExtractor = new BaseDatePeriodExtractor(new UkrainianDatePeriodExtractorConfiguration());
            TimePeriodExtractor = new BaseTimePeriodExtractor(new UkrainianTimePeriodExtractorConfiguration());
            DateTimePeriodExtractor = new BaseDateTimePeriodExtractor(new UkrainianDateTimePeriodExtractorConfiguration());
            DurationExtractor = new BaseDurationExtractor(new UkrainianDurationExtractorConfiguration());
            SetExtractor = new BaseSetExtractor(new UkrainianSetExtractorConfiguration());
            HolidayExtractor = new BaseHolidayExtractor(new UkrainianHolidayExtractorConfiguration());
        }

        public bool HasAfterTokenIndex(string text, out int index)
        {
            index = -1;
            if (text.EndsWith("after"))
            {
                index = text.LastIndexOf("after");
                return true;
            }
            return false;
        }

        public bool HasBeforeTokenIndex(string text, out int index)
        {
            index = -1;
            if (text.EndsWith("before"))
            {
                index = text.LastIndexOf("before");
                return true;
            }
            return false;
        }
    }
}
