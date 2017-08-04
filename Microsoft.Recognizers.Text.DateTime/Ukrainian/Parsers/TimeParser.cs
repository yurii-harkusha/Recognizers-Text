﻿using DateObject = System.DateTime;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class TimeParser : BaseTimeParser
    {
        public TimeParser(ITimeParserConfiguration configuration) : base(configuration) { }

        protected override DateTimeResolutionResult InternalParse(string text, DateObject referenceTime)
        {
            var innerResult = base.InternalParse(text, referenceTime);
            if (!innerResult.Success)
            {
                innerResult = ParseIsh(text, referenceTime);
            }
            return innerResult;
        }

        // parse "noonish", "11-ish"
        private DateTimeResolutionResult ParseIsh(string text, DateObject referenceTime)
        {
            var ret = new DateTimeResolutionResult();
            var trimedText = text.ToLowerInvariant().Trim();

            var match = UkrainianTimeExtractorConfiguration.IshRegex.Match(trimedText);
            if (match.Success && match.Length == trimedText.Length)
            {
                var hourStr = match.Groups["hour"].Value;
                var hour = 12;
                if (!string.IsNullOrEmpty(hourStr))
                {
                    hour = int.Parse(hourStr);
                }

                ret.Timex = "T" + hour.ToString("D2");
                ret.FutureValue =
                    ret.PastValue =
                        new DateObject(referenceTime.Year, referenceTime.Month, referenceTime.Day, hour, 0, 0);
                ret.Success = true;
                return ret;
            }

            return ret;
        }
    }
}
