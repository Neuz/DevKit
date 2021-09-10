using System.Collections.Generic;
using System.Linq;

namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        ///     当前对象是否存在于<paramref name="items" />集合内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">进行比较的集合</param>
        /// <param name="comparer">比较器</param>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns><paramref name="items" /> 为空  返回 false </returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var    stringItems = new[] {"a", "b", null};
        /// var    s           = "a";
        /// string s2          = null;
        /// s.In(stringItems); // true
        /// s2.In(stringItems); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var strItems = new[] {"a", "A", "b"};
        /// var s        = "B";
        /// s.In(strItems, StringComparer.CurrentCultureIgnoreCase); // true
        /// s.In(strItems, StringComparer.CurrentCulture);  // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// public class MyComparer : IEqualityComparer<DateTime>
        /// {
        ///     public bool Equals(DateTime x, DateTime y)
        ///     {
        ///         return x.Year.Equals(y.Year);
        ///     }
        /// 
        ///     public int GetHashCode(DateTime obj)
        ///     {
        ///         return obj.GetHashCode();
        ///     }
        /// }
        /// 
        /// var dtItems = new[]
        /// {
        ///     new DateTime(2018, 1, 1),
        ///     new DateTime(2019, 1, 1, 9, 10, 1),
        ///     DateTime.Today
        /// };
        /// var dt = new DateTime(2019, 5, 25, 1, 1, 1);
        /// 
        /// dt.In(dtItems, new MyComparer());  // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool In<T>(this T @this, IEnumerable<T> items, IEqualityComparer<T> comparer = null)
        {
            return items != null && (comparer == null
                    ? items.Contains(@this)
                    : items.Contains(@this, comparer)
                );
        }
    }
}