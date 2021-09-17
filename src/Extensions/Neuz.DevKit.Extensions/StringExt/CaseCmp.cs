using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class StringExt
    {
        /// <summary>
        /// 忽略大小写比较
        /// </summary>
        /// <param name="this"></param>
        /// <param name="value">需要进行比较的字符串</param>
        /// <param name="comparison">默认 <see cref="StringComparison.CurrentCultureIgnoreCase"/></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "aaa".CaseCmp("AaA"); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool CaseCmp(this string @this, string value, StringComparison comparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return string.Equals(@this, value, comparison);
        }
    }
}