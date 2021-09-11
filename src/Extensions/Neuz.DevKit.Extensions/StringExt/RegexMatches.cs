using System;
using System.Text.RegularExpressions;

namespace Neuz.DevKit.Extensions
{
    public static partial class StringExt
    {
        /// <summary>
        ///     正则表达式 - 所有匹配对象
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption">正则表达式选项</param>
        /// <returns>所有匹配对象</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var str   = "aaaabaaaabaaaa";
        /// var matches = str.RegexMatches(@"aaaab");  // matches.Count == 2
        ///         ]]>
        ///     </code>
        /// </example>
        public static MatchCollection RegexMatches(this string @this, string pattern, RegexOptions regexOption)
        {
            return Regex.Matches(@this, pattern, regexOption);
        }
    }
}