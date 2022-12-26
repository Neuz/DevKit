using System.Collections.Generic;
using System.Linq;

namespace Neuz.DevKit.Extensions
{
    public static partial class EnumerableExt
    {
        /// <summary>
        ///     是否null或Empty
        /// </summary>
        /// <param name="this"></param>
        /// <typeparam name="T">元素类型</typeparam>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var arr = new[] {"aa", "bb"};
        /// arr.IsNullOrEmpty(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this) => @this == null || !@this.Any();
    }
}