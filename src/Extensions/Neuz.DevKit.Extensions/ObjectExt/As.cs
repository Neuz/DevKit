using System;
using System.Diagnostics.CodeAnalysis;

namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        /// 对象强转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>若转换失败，返回 默认值 <see cref="defaultValue"/></returns>
        public static T As<T>([NotNull] this object @this, [NotNull] T defaultValue)
        {
            try { return (T) @this; }
            catch { return defaultValue; }
        }

        /// <summary>
        /// 对象强转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="func">
        /// 返回默认值的方法
        /// <para>
        /// <see cref="object"/> - @this
        /// <see cref="T"/> - 默认值
        /// </para>
        /// </param>
        /// <returns>若转换失败，返回 默认值 <paramref name="func"/></returns>
        public static T As<T>([NotNull] this object @this, [NotNull] Func<object, T> func)
        {
            return @this.As<T>(func.Invoke(@this));
        }

        /// <summary>
        /// 对象强转换
        /// </summary>
        /// <typeparam name="T"><see cref="IConvertible" /></typeparam>
        /// <param name="this"></param>
        /// <returns>转换失败则返回 <c>default(<typeparamref name="T" />)</c></returns>
        public static T As<T>([NotNull] this object @this)
        {
            return @this.As<T>(default(T));
        }
    }
}