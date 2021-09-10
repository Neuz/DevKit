using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        ///     当前对象是否 Array
        /// </summary>
        /// <param name="this"></param>
        /// <returns><paramref name="this" /> 为 null ，返回 false</returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj1 = new[] {"1", "2"};
        /// obj1.IsArray(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj2 = new List<string> {"1", "2"};
        /// obj2.IsArray(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// object obj3 = null;
        /// obj3.IsArray(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj4 = new MyClass();
        /// obj4.IsArray(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsArray(this object @this)
        {
            return @this != null && @this.GetType().IsArray;
        }
    }
}