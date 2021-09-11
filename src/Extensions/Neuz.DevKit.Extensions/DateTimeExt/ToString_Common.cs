using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     格式化为 yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_Common(); // "2019-04-01 21:11:11"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_Common(this DateTime @this)
        {
            return @this.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}