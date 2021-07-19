using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     获取 DateTime 当天的开始 (year-month-day 00:00:00.000)
        /// </summary>
        /// <param name="this"></param>
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// var rs = dt.StartOfDay(); // rs == new DateTime(2019, 4, 1, 0, 0, 0, 000)
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime StartOfDay(this DateTime @this)
        {
            return @this.SetTime(0, 0, 0);
        }
    }
}