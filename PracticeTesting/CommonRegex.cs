using System.Text.RegularExpressions;

namespace RocketClubs.Study.PracticeTesting
{
    internal static class CommonRegex
    {
        private static readonly Regex ReduceWhitespaceRegex = new Regex(@"[\s]+", RegexOptions.Compiled);

        internal static string ReduceWhitespace(string original)
        {
            var result = ReduceWhitespaceRegex.Replace(original, " ").Trim();
            return result;
        }
    }
}
