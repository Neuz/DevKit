using System;
using System.Text;

namespace Neuz.DevKit.Extensions
{
    public static partial class DecimalExt
    {
        /// <summary>
        /// 绝对值
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var d = -123m;
        /// d.Abs();
        ///         ]]>
        ///     </code>
        /// </example>
        public static decimal Abs(this decimal @this)
        {
            return Math.Abs(@this);
        }
    }
}