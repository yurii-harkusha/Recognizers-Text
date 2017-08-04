using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Recognizers.Text.DateTime.English.Utilities;
using Microsoft.Recognizers.Text.DateTime.Utilities;
using Microsoft.Recognizers.Text.Number;
using Microsoft.Recognizers.Text.Number.Ukrainian;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian
{
    public class UkrainianDateExtractorConfiguration : IDateExtractorConfiguration
    {
        public const string ThisWords = @"цей|цьому|цього|цим|ця|цій|цієї|цією|цими|ці|цих|цими";
        public const string NextWords = @"наступний|наступного|наступному|наступним|наступна|наступної|наступній|наступною|наступні|наступних|наступним|наступними";
        public const string LastWords = @"минулий|минулого|минулому|минулим|минула|минулої|минулій|минулою|минулі|минулих|минулим|минулими";


        public static readonly Regex MonthRegex =
            new Regex(
                @"(?<month>квітень|квітня|квітню|квітні|квітнем|кві|серпень|серпня|серпню|серпні|серпнем|сер|грудень|грудня|грудню|грудні|груднем|гру|лютий|лютого|лютому|лютому|лют|січень|січня|січню|січні|січнем|січ|липень|липня|липню|липні|липнем|лип|червень|червня|червню|червні|червнем|чер|березень|березня|березню|березні|березнем|бер|травень|травня|травню|травні|травнем|тра|листопад|листопаду|листопаді|листопадом|листопада|лис|жовтень|жовтня|жовтню|жовтні|жовтнем|жов|вересень|вересня|вересню|вересні|вереснем|вер)",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex DayRegex =
            new Regex(
                @"(?<day>01|1|1е|1го|02|2|2е|2го|3|03|3є|3го|04|4|4е|4го|05|5|5е|5го|06|6|6е|6го|07|7|7е|7го|08|8|8е|8го|09|9|9е|9го|10е|10|10го|11е|11|11го|12е|12|12го|13е|13|13го|14е|14|14го|15е|15|15го|16е|16|16го|17е|17|17го|18е|18|18го|19е|19|19го|20|20е|20го|21е|21|21го|22е|22|22го|23є|23|23го|24е|24|24го|25е|25|25го|26е|26|26го|27е|27|27го|28е|28|28го|29е|29|29го|30е|30|30го|31е|31|31го)",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex MonthNumRegex =
            new Regex(@"(?<month>01|02|03|04|05|06|07|08|09|10|11|12|1|2|3|4|5|6|7|8|9)",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex YearRegex = new Regex(@"(?<year>19\d{2}|20\d{2}|9\d|0\d|1\d|2\d)",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex WeekDayRegex =
            new Regex(
                @"(?<weekday>понеділок|понеділка|понеділку|понеділком|вівторок|вівторку|вівторка|вівторком|середа|середи|середу|середі|середою|четвер|четверга|четвергу|четвергом|п'ятниця|п'ятниці|п'ятницею|п'ятницею|субота|суботи|суботою|суботу|неділя|неділю|неділі|неділею|пн|вт|ср|чт|пт|сб|нд)",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex OnRegex = new Regex($@"(?<=\b)({DayRegex}s?)\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex RelaxedOnRegex =
            new Regex(
                $@"(?<=\b(на|в)\s+)((?<day>01|1|1е|1го|02|2|2е|2го|3|03|3є|3го|04|4|4е|4го|05|5|5е|5го|06|6|6е|6го|07|7|7е|7го|08|8|8е|8го|09|9|9е|9го|10е|10|10го|11е|11|11го|12е|12|12го|13е|13|13го|14е|14|14го|15е|15|15го|16е|16|16го|17е|17|17го|18е|18|18го|19е|19|19го|20|20е|20го|21е|21|21го|22е|22|22го|23є|23|23го|24е|24|24го|25е|25|25го|26е|26|26го|27е|27|27го|28е|28|28го|29е|29|29го|30е|30|30го|31е|31|31го)s?)\b",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex ThisRegex = new Regex($@"\b(({ThisWords}\s+){WeekDayRegex})|({WeekDayRegex}(\s+(цей|цьому|цього|цим|ця|цій|цієї|цією|цими|ці|цих|цими)\s*week))\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex LastRegex = new Regex($@"\b({LastWords}\s+{WeekDayRegex})|({WeekDayRegex}(\s+last\s*week))\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex NextRegex = new Regex($@"\b({NextWords}\s+{WeekDayRegex})",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex UnitRegex = new Regex(@"(?<unit>роки|рік|місяці|місяць|тижні|тиждень|дні|день)\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex SpecialDayRegex =
            new Regex(
                @"\b(позавчора|післязавтра|наступний день|минулий день|сьогодні|вчора)\b",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex StrictWeekDay =
            new Regex(
                @"\b(?<weekday>понеділок|вівторок|середа|четвер|п'ятниця|субота|неділя|пн|вт|ср|чт|пт|сб|н)s?\b",
                RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex WeekDayOfMonthRegex =
            new Regex(
                $@"(?<wom>(?<cardinal>перший|1ий|другий|2ий|третій|3ій|четвертий|4ий|п'ятий|5ий|минулий)\s+{WeekDayRegex
                    }\s+{UkrainianDatePeriodExtractorConfiguration.MonthSuffixRegex})", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex SpecialDate = new Regex($@"(?<=\b){DayRegex}\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex[] DateRegexList =
        {
            // (Sunday,)? April 5 // 15 квітня
            new Regex(
                string.Format(@"\b({2}(\s+|\s*,\s*))?{1}\s*[/\\\.\-]?\s*{0}\b", MonthRegex, DayRegex, WeekDayRegex),
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // (Sunday,)? April 5, 2016 // 15 квітня
            new Regex(
                string.Format(@"\b({3}(\s+|\s*,\s*))?{1}\s*[\.\-]?\s*{0}(\s+|\s*,\s*|\s+of\s+){2}\b", MonthRegex,
                    DayRegex,
                    YearRegex, WeekDayRegex), RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // (Sunday,)? 6th of April
            new Regex(
                string.Format(@"\b({2}(\s+|\s*,\s*))?{0}(\s+|\s*,\s*|\s+|\s*-\s*){1}((\s+|\s*,\s*){3})?\b",
                    DayRegex, MonthRegex, WeekDayRegex, YearRegex), RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // 3-23-2017 //23-3-2017
            new Regex($@"\b{DayRegex}\s*[/\\\-]\s*{MonthNumRegex}\s*[/\\\-]\s*{YearRegex}",
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            //// 23-3-2015 //23-3-2015
            //new Regex(string.Format(@"\b{1}\s*[/\\\-]\s*{0}\s*[/\\\-]\s*{2}", MonthNumRegex, DayRegex, YearRegex),
            //    RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // on 1.3
            new Regex($@"(?<=\b(на)\s+){MonthNumRegex}[\-\.]{DayRegex}\b",
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // 7/23
            new Regex($@"\b{MonthNumRegex}\s*/\s*{DayRegex}((\s+|\s*,\s*|\s+){YearRegex})?\b",
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // on 24-12
            new Regex(string.Format(@"(?<=\b(на)\s+){1}[\\\-]{0}\b", MonthNumRegex, DayRegex),
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // 23/7
            new Regex($@"\b{DayRegex}\s*/\s*{MonthNumRegex}((\s+|\s*,\s*|\s+of\s+){YearRegex})?\b",
                RegexOptions.IgnoreCase | RegexOptions.Singleline),

            // 2015-12-23
            new Regex($@"\b{YearRegex}\s*[/\\\-]\s*{MonthNumRegex}\s*[/\\\-]\s*{DayRegex}",
                RegexOptions.IgnoreCase | RegexOptions.Singleline)
        };


        public static readonly Regex[] ImplicitDateList =
        {
            OnRegex, RelaxedOnRegex, SpecialDayRegex, ThisRegex, LastRegex, NextRegex,
            StrictWeekDay, WeekDayOfMonthRegex, SpecialDate
        };

        public static readonly Regex OfMonth = new Regex(@"^\s*of\s*" + MonthRegex,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex MonthEnd = new Regex(MonthRegex + @"\s*\s*$",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public static readonly Regex NonDateUnitRegex = new Regex(@"(?<unit>година|годин|годину|годиною|годині|години|години|годинами|год|секунд|секунда|секундою|секунді|секунди|секунди|секундами|сек|хвилина|хвилини|хвилин|хвилиною|хвилинами|хвилинах|хв)\b",
            RegexOptions.IgnoreCase | RegexOptions.Singleline);

        public UkrainianDateExtractorConfiguration()
        {
            IntegerExtractor = new IntegerExtractor();
            OrdinalExtractor = new OrdinalExtractor();
            NumberParser = new BaseNumberParser(new UkrainianNumberParserConfiguration());
            DurationExtractor = new BaseDurationExtractor(new UkrainianDurationExtractorConfiguration());
            UtilityConfiguration = new EnlighDatetimeUtilityConfiguration();
        }

        public IExtractor IntegerExtractor { get; }

        public IExtractor OrdinalExtractor { get; }

        public IParser NumberParser { get; }

        public IExtractor DurationExtractor { get; }

        public IDateTimeUtilityConfiguration UtilityConfiguration { get; }

        IEnumerable<Regex> IDateExtractorConfiguration.DateRegexList => DateRegexList;

        IEnumerable<Regex> IDateExtractorConfiguration.ImplicitDateList => ImplicitDateList;

        Regex IDateExtractorConfiguration.OfMonth => OfMonth;

        Regex IDateExtractorConfiguration.MonthEnd => MonthEnd;

        Regex IDateExtractorConfiguration.NonDateUnitRegex => NonDateUnitRegex;
    }
}