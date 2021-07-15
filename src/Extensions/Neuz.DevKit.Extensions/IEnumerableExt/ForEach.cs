using System;
using System.Collections.Generic;

namespace Neuz.DevKit.Extensions.IEnumerableExt
{
    public static partial class ForEachExt
    {
        /// <summary>
        ///     对指定可计数的每个元素执行指定操作
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action">
        ///     <para>指定操作</para>
        ///     <para>int: 数组元素的索引</para>
        ///     <para>T: 元素</para>
        /// </param>
        /// <typeparam name="T">元素类型</typeparam>
        /// <exception cref="ArgumentNullException"> <paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="action" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var arr = new[] {"aa", "bb"};
        /// var rs  = new Dictionary<int, string>();
        /// arr.ForEach((index, str) => rs.Add(index, str));
        /// // rs[0] = "aa"
        /// // rs[1] = "bb"
        ///         ]]>
        ///     </code>
        /// </example>
        public static void ForEach<T>(this IEnumerable<T> @this, Action<int, T> action)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (action == null) throw new ArgumentNullException(nameof(action), $"{nameof(action)} is null");
            var i = 0;
            foreach (var item in @this) action(i++, item);
        }

        /// <summary>
        ///     对指定可计数的每个元素执行指定操作
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action">
        ///     <para>指定操作</para>
        ///     <para>T: 元素</para>
        /// </param>
        /// <typeparam name="T">元素类型</typeparam>
        /// <exception cref="ArgumentNullException"> <paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="action" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var arr = new[] {"aa", "bb"};
        /// var rs  = new List<string>();
        /// arr.ForEach(str => rs.Add(str));
        /// // rs[0] = "aa"
        /// // rs[1] = "bb"
        ///         ]]>
        ///     </code>
        /// </example>
        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (action == null) throw new ArgumentNullException(nameof(action), $"{nameof(action)} is null");
            foreach (var item in @this) action(item);
        }
    }
}