using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     获取 DateTime 当天的结束 (year-month-day 23:59:59.999)
        /// </summary>
        /// <param name="this"></param>
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 1, 2, 3);
        /// var rs = dt.EndOfDay(); // rs == new DateTime(2019, 4, 1, 23, 59, 59, 999);
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime EndOfDay(this DateTime @this)
        {
            return @this.SetTime(23, 59, 59, 999);
        }
    }
}