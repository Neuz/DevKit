using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     获取时间戳的小时表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 11, 11, 11);
        /// dt.TotalDays(); // 431699.18638888886
        ///         ]]>
        ///     </code>
        /// </example>
        public static double TotalHours(this DateTime @this)
        {
            return (@this - UtcOrigin).TotalHours;
        }
    }
}