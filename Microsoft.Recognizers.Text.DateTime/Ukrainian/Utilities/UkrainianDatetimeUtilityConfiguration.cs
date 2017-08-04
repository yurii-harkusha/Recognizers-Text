using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Recognizers.Text.DateTime.Utilities;

namespace Microsoft.Recognizers.Text.DateTime.Ukrainian.Utilities
{
    public class UkrainianDatetimeUtilityConfiguration : IDateTimeUtilityConfiguration
    {
        public static readonly List<string> AgoStringList = new List<string>
        {
            "назад",
        };

        public static readonly List<string> LaterStringList = new List<string>
        {
            "пізніше",
            "від тепер"
        };

        public static readonly List<string> InStringList = new List<string>
        {
            "в",
        };

        List<string> IDateTimeUtilityConfiguration.AgoStringList => AgoStringList;

        List<string> IDateTimeUtilityConfiguration.LaterStringList => LaterStringList;

        List<string> IDateTimeUtilityConfiguration.InStringList => InStringList;
    }
}
