using System;
using System.Text.RegularExpressions;

namespace Neuz.DevKit.Extensions
{
    public static partial class StringExt
    {
        /// <summary>
        ///     正则表达式 - 单个匹配对象
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption">正则表达式选项</param>
        /// <returns>单个匹配对象</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var str = "aaaabaaaabaaaa";
        /// var match = str.RegexMatch("b"); // match.Success == true;
        ///         ]]>
        ///     </code>
        /// </example>
        public static Match RegexMatch(this string @this, string pattern, RegexOptions regexOption)
        {
            return Regex.Match(@this, pattern, regexOption);
        }
    }
}