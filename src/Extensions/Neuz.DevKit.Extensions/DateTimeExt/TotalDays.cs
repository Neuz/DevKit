using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class DateTimeExt
    {
#if NETSTANDARD2_1
        private static readonly DateTime UtcOrigin = DateTime.UnixEpoch;
#else
        private static readonly DateTime UtcOrigin = new DateTime(1970, 1, 1, 0, 0, 0);
#endif
        /// <summary>
        ///     获取时间戳的日表示
        /// <para>
        /// ([CurrentDateTime] - DateTime.UtcNow).TotalDays
        /// </para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 11, 11, 11);
        /// dt.TotalDays(); // 17987.466099537036
        ///         ]]>
        ///     </code>
        /// </example>
        public static double TotalDays(this DateTime @this)
        {
            return (@this - UtcOrigin).TotalDays;
        }
    }
}