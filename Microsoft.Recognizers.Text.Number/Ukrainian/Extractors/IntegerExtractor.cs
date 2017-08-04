using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace Microsoft.Recognizers.Text.Number.Ukrainian
{
    public class IntegerExtractor : BaseNumberExtractor
    {
        internal sealed override ImmutableDictionary<Regex, string> Regexes { get; }
        protected sealed override string ExtractType { get; } = Constants.SYS_NUM_INTEGER; // "Integer";

        public const string RoundNumberIntegerRegex = @"(тисяча|тисяч|тисячі|тисячами|тисячу|тисячею|мільйон|мільйона|мільйону|мільйоном|мільйоні|мільйони|мільйонів|мільйонам|мільйонах|мільярд|мільярда|мільярду|мільярдом|мільярді|мільярди|мільярдів|мільярдам|мільярдах|трильйон|трильйона|трильйону|трильйоном|трильйоні|трильйони|трильйонів|трильйонам|трильйонах)";
        public const string HundredsNumberIntegerRegex = @"(сто|ста|двісті|двохсот|двомстам|двомстами|двомстам|двохстах|триста|трьохсот|трьомстам|трьомастами|трьохстах|чотириста|чотирьохсот|чотирьохстам|чотирьохстами|чотирьохстах|п'ятсот|п'ятисот|п'ятистам|п'ятистами|п'ятистах|п'ятьомастами|шістсот|шестисот|шестистам|шестистами|шестистах|шістьомастами|сімсот|семисот|семистам|семистами|семистах|сімомастами|вісімсот|восьмисот|восьмистам|восьмистами|восьмистах|вісьмомастами|дев'ятсот|дев'ятисот|дев'ятистам|дев'ятистами|дев'ятистах|дев'ятистами)";
        public const string TensNumberIntegerRegex = @"(двадцять|двадцятьти|двадцятьма|двадцятьох|двадцятьом|тридцять|тридцяти|тридцятьма|тридцятьох|тридцятьом|сорок|сорока|п'ятдесят|п'ятдесяти|п'ятдесятьма|п'ятдесятьох|п'ятдесятьом|шістдесят|шістдесяти|шістдесятьма|шістдесятьох|шістдесятьом|сімдесят|сімдесяти|сімдесятьма|сімдесятьох|сімдесятьом|вісімдесят|восьмидесяти|вісімдесятьма|вісімдесятьох|вісімдесятьом|дев'яносто|дев'яноса)";
        public const string TenToNineteenIntegerRegex = @"(десять|десяти|десятьми|десятьох|десятьом|десятьма|одинадцять|одинадцяти|одинадцятьма|одинадцятьох|одинадцятьом|дванадцять|дванадцяти|дванадцятьма|дванадцятьох|дванадцятьом|дюжина|дюжини|дюжен|тринадцять|тринадцяти|тринадцятьма|тринадцятьох|тринадцятьом|чотирнадцять|чотирнадцяти|чотирнадцятьма|чотирнадцятьох|чотирнадцятьом|п'ятнадцять|п'ятнадцяти|п'ятнадцятьма|п'ятнадцятьох|п'ятнадцятьом|шістнадцять|шістнадцяти|шістнадцятьма|шістнадцятьох|шістнадцятьом|сімнадцять|сімнадцяти|сімнадцятьма|сімнадцятьох|сімнадцятьом|вісімнадцять|вісімнадцяти|вісімнадцятьма|вісімнадцятьох|вісімнадцятьом|дев'ятнадцять|дев'ятнадцяти|дев'ятнадцятьма|дев'ятнадцятьох|дев'ятнадцятьом)";
        public const string ZeroToNineIntegerRegex = @"(нуль|нуля|нулю|нулеві|нулем|один|одна|одні|одного|однієї|одної|одних|одному|одній|одним|одну|однією|одною|одними|два|дві|двох|двом|двома|три|трьох|трьом|трьома|чотири|чотирьох|чотирьом|чотирма|п'ять|п'яти|п'ятьох|п'ятьом|п'ятьма|п'ятьома|шість|шести|шістьох|шістьом|шістьма|шістьома|сім|семи|сімох|сімом|сімома|вісім|восьми|вісьмох|вісьмом|вісьмома|дев'ять|дев'яти|дев'ятьми|дев'ятьох|дев'ятьом|дев'ятьма)";


        public const string ThousandNumberIntegerRegex = @"(тисяча|тисяч|тисячі)";
        public const string MillionNumberIntegerRegex = @"(мільйон|мільйонів|мільйони)";
        public const string BillionNumberIntegerRegex = @"(мільярд|мільярди|мільярдів)";
        public const string TrillionNumberIntegerRegex = @"(трильйон|трильйони|трильйонів)";

        public static string BelowHundredsRegex => $@"((({TensNumberIntegerRegex})(\s+)?({ZeroToNineIntegerRegex})?)|({ZeroToNineIntegerRegex})|({TenToNineteenIntegerRegex}))";
        public static string BelowThousandsRegex => $@"((({HundredsNumberIntegerRegex})?(\s+)?({BelowHundredsRegex}))|({HundredsNumberIntegerRegex})|({BelowHundredsRegex}))";
        public static string BelowMlnRegex => $@"((({BelowThousandsRegex})?(\s+)?({RoundNumberIntegerRegex})(\s+)?({BelowThousandsRegex})?)|({BelowThousandsRegex}))";
        public static string BelowBlnRegex => $@"((({BelowThousandsRegex})?(\s+)?({RoundNumberIntegerRegex})(\s+)?({BelowMlnRegex})?)|({BelowMlnRegex}))";
        public static string BelowTrlnRegex => $@"((({BelowThousandsRegex})?(\s+)?({RoundNumberIntegerRegex})(\s+)?({BelowBlnRegex})?)|({BelowBlnRegex}))";
        public static string AllIntRegex => $@"((({BelowThousandsRegex})?(\s+)?({RoundNumberIntegerRegex})(\s+)?({BelowTrlnRegex})?)|({BelowTrlnRegex}))";


        public IntegerExtractor(string placeholder = @"\D|\b")
        {
            var _regexes = new Dictionary<Regex, string>
            {
                {
                    new Regex($@"(((?<!\d+\s*)-\s*)|(?<=\b))\d+(?!(\.\d+[a-zA-Z]))(?={placeholder})",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline)
                    , "IntegerNum"
                },
                {
                    new Regex(@"(((?<!\d+\s*)-\s*)|(?<=\b))\d+\s*(тис|млн|млрд|трлн)(?=\b)", RegexOptions.Singleline)
                    , "IntegerNum"
                },
                {
                    new Regex(@"(((?<!\d+\s*)-\s*)|(?<=\b))\d{1,3}(,\d{3})+" + $@"(?={placeholder})",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "IntegerNum"
                },
                {
                    new Regex($@"(?<=\b)\d+\s+{RoundNumberIntegerRegex}(?=\b)",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "IntegerNum"
                },
                {
                    new Regex(
                        @"(((?<!\d+\s*)-\s*)|(?<=\b))\d+\s+дюжина(s)?(?=\b)",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "IntegerNum"
                },
                {
                    new Regex(
                        $@"((?<=\b){AllIntRegex}(?=\b))",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "IntegerUa"
                },
                {
                    new Regex(
                        $@"(?<=\b)(((half\s+)?a\s+дюжина)|({AllIntRegex}\s+дюжина(s)?))(?=\b)",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    "IntegerUa"
                }
            };
            Regexes = _regexes.ToImmutableDictionary();
        }
    }
}