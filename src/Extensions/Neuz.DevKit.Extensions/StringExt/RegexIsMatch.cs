using System;
using System.Text.RegularExpressions;

namespace Neuz.DevKit.Extensions
{
    public static partial class StringExt
    {
        /// <summary>
        ///     正则表达式 - 是否匹配
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption">正则表达式选项</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var source = "abcdefg\r\nabcdefghijk";
        /// source.RegexIsMatch(@"^abc.*\r$", RegexOptions.Multiline); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool RegexIsMatch(this string @this, string pattern, RegexOptions regexOption)
        {
            return Regex.IsMatch(@this, pattern, regexOption);
        }
    }
}