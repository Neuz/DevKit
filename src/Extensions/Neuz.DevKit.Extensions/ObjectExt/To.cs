using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        /// 对象转换
        /// </summary>
        /// <typeparam name="T"><see cref="IConvertible" /></typeparam>
        /// <param name="this"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>若转换失败，返回 默认值 <see cref="defaultValue"/></returns>
        public static T To<T>(this object @this, T defaultValue) where T : IConvertible
        {
            if (@this == null || @this == DBNull.Value) return defaultValue;
            if (typeof(T).IsEnum)
            {
                if (@this is int) return (T) @this;
                return (T) Enum.Parse(typeof(T), @this.ToString()!, true);
            }

            try { return (T) Convert.ChangeType(@this, typeof(T)); }
            catch { return defaultValue; }
        }

        /// <summary>
        /// 对象转换
        /// </summary>
        /// <typeparam name="T"><see cref="IConvertible" /></typeparam>
        /// <param name="this"></param>
        /// <param name="func">
        /// 返回默认值的方法
        /// <para>
        /// <see cref="object"/> - @this
        /// <see cref="T"/> - 默认值
        /// </para>
        /// </param>
        /// <returns>若转换失败，返回 默认值 <paramref name="func"/></returns>
        public static T To<T>(this object @this, Func<object, T> func) where T : IConvertible
        {
            return @this.To<T>(func.Invoke(@this));
        }

        /// <summary>
        /// 对象转换
        /// </summary>
        /// <typeparam name="T"><see cref="IConvertible" /></typeparam>
        /// <param name="this"></param>
        /// <returns>转换失败则返回 <c>default(<typeparamref name="T" />)</c></returns>
        public static T To<T>(this object @this) where T : IConvertible
        {
            return @this.To<T>(default(T));
        }
    }
}