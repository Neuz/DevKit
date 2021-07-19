using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Neuz.DevKit.Extensions.IEnumerable
{
    public static partial class EnumerableExt
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
        /// <exception cref="ArgumentNullException"> <paramref name="this" /> </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="action" /> </exception>
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
        public static void ForEach<T>([NotNull] this IEnumerable<T> @this, [NotNull] Action<int, T> action)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));
            if (action == null) throw new ArgumentNullException(nameof(action));
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
        /// <exception cref="ArgumentNullException"> <paramref name="this" /> </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="action" /> </exception>
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
        public static void ForEach<T>([NotNull] this IEnumerable<T> @this, [NotNull] Action<T> action)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));
            if (action == null) throw new ArgumentNullException(nameof(action));
            foreach (var item in @this) action(item);
        }
    }
}