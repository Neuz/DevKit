using System.Collections.Generic;
using System.Linq;

namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        ///     当前对象是否不存在于<paramref name="items" />集合内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">进行比较的集合</param>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns><paramref name="items" /> 为空  返回 false </returns>
        public static bool NotIn<T>(this T @this, IEnumerable<T> items)
        {
            return !@this.In(items);
        }
    }
}