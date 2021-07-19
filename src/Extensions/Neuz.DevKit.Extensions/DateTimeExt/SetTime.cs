using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     设置DateTime的time部分
        /// </summary>
        /// <param name="this"></param>
        /// <param name="hour">小时 (0-23) 默认0</param>
        /// <param name="minute">分钟 (0-59) 默认0</param>
        /// <param name="second">秒 (0-59) 默认0</param>
        /// <param name="millisecond">毫秒 (0-999) 默认0</param>
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="hour" /> | <paramref name="minute" /> | <paramref name="second" /> | <paramref name="millisecond" /> 参数描述了一个无法表示的日期时间
        /// </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt2 = new DateTime(2019, 4, 1, 1, 2, 3);
        /// var rs2 = dt2.SetTime(23, 11, 11, 999);
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime SetTime(this DateTime @this, int hour = 0, int minute = 0, int second = 0, int millisecond = 0)
        {
            return new DateTime(@this.Year, @this.Month, @this.Day, hour, minute, second, millisecond);
        }
    }
}