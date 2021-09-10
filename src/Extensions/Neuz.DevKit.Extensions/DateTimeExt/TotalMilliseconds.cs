using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
        /// <summary>
        ///     获取时间戳的毫秒表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 11, 11, 11);
        /// dt.TotalMilliseconds(); // 1554117071000
        ///         ]]>
        ///     </code>
        /// </example>
        public static double TotalMilliseconds(this DateTime @this)
        {
            return (@this - UtcOrigin).TotalMilliseconds;
        }
    }
}