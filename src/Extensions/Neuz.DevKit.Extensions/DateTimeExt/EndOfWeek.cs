using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     获取本周结束的 DateTime (year-month-day 23:59:59.999)
        /// </summary>
        /// <param name="this"></param>
        /// <param name="startOfWeek">设置每周的起始</param>
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt2 = new DateTime(2019, 4, 1, 1, 2, 3);
        /// var rs2 = dt.EndOfWeek(DayOfWeek.Friday); // 2019-04-04 23:59:59.999
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime EndOfWeek(this DateTime @this, DayOfWeek startOfWeek)
        {
            return @this.StartOfWeek(startOfWeek).AddDays(6).EndOfDay();
        }
    }
}