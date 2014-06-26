using System;

namespace Acute
{
    internal static class StringUtilities
    {
        public static string FirstCharToLower(this string s)
        {
           if (s == null) 
               throw new ArgumentException("s");

            if (s.Length == 0)
                return s;

            var firstChar = s[0].ToString().ToLower();

            if (s.Length == 1)
                return firstChar;

            return firstChar + s.Substring(1);
        } 
    }
}