using System.Collections.Generic;
using System.Linq;

namespace Acute.Compiler.Core
{
    internal static class StringExtensions
    {
        public static string SingleQuote(this string s)
        {
            return string.Format("'{0}'", s);
        }

        public static string CommaSeparate(this IEnumerable<string> items)
        {
            return string.Join(",", items);
        }

    }
}