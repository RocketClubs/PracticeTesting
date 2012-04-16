using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PracticeTesting
{
    internal static class CommonRegex
    {
        private static Regex regex = new Regex(@"[\s]+");

        internal static string ReduceWhitespace(string original)
        {
            string result = regex.Replace(original, " ").Trim();
            return result;
        }
    }
}
