using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        ///     当前对象类型是否 Class
        /// </summary>
        /// <param name="this"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj1 = new MyClass();
        /// obj1.IsClass(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj2 = 12;
        /// obj2.IsClass(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// object obj3 = null;
        /// obj3.IsClass(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsClass(this object @this)
        {
            NullCheck.ThrowIfNull(@this);
            return @this.GetType().IsClass;
        }
    }
}