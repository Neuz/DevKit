using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     获取本周开始 DateTime (year-month-day 00:00:00.000)
        /// </summary>
        /// <param name="this"></param>
        /// <param name="startOfWeek">设置每周的起始</param>
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 1, 2, 3);
        /// var rs = dt.StartOfWeek(DayOfWeek.Sunday); // 2019-03-31 00:00:00
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime StartOfWeek(this DateTime @this, DayOfWeek startOfWeek)
        {
            var diff = @this.DayOfWeek - startOfWeek;
            return @this.AddDays(Convert.ToDouble(-1 * (diff < 0 ? diff + 7 : diff))).Date.StartOfDay();
        }
    }
}