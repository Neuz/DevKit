using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     获取月的开始 DateTime (year-month-day 00:00:00.000)
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 12, 1, 2, 3);
        /// var rs = dt.StartOfMonth(); // 2019-04-01 00:00:00.000
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime StartOfMonth(this DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, 1);
        }
    }
}