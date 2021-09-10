using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     获取时间戳的分钟表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 11, 11, 11);
        /// dt.TotalDays(); // 25901951.183333334
        ///         ]]>
        ///     </code>
        /// </example>
        public static double TotalMinutes(this DateTime @this)
        {
            return (@this - UtcOrigin).TotalMinutes;
        }
    }
}