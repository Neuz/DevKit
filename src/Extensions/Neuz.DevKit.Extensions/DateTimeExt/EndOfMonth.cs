using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     获取月的结束 DateTime (year-month-day 23:59:59.999)
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 12, 1, 2, 3);
        /// var rs = dt.EndOfMonth(); // 2019-04-30 23:59:59.999
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime EndOfMonth(this DateTime @this)
        {
            return @this.StartOfMonth().AddMonths(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }
    }
}