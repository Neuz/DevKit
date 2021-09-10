namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        ///     是否值类型
        /// </summary>
        /// <param name="this"></param>
        /// <returns><paramref name="this" /> 为 null ，返回 false</returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj1 = 12;
        /// obj1.IsValueType(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj2 = "";
        /// obj2.IsValueType(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj4 = new MyStruct();
        /// obj4.IsValueType(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj5 = new DateTime();
        /// obj5.IsValueType(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsValueType(this object @this)
        {
            return @this.GetType().IsValueType;
        }
    }
}