﻿using System;

namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        ///     当前对象是否 Class
        /// </summary>
        /// <param name="this"></param>
        /// <returns><paramref name="this" /> 为 null ，返回 false</returns>
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
            return @this != null && @this.GetType().IsClass;
        }
    }
}