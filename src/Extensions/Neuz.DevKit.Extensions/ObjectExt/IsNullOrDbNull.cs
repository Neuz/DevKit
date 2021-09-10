namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        /// 是否 <c>Null</c> 或 <c>DBNull</c>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var v = DBNull.Value;
        /// v.IsNullOrDbNull();         // true
        /// var v2 = default(string);   // null
        /// v2.IsNullOrDbNull();        // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsNullOrDbNull(this object @this)
        {
            return @this == null || @this.IsDBNull();
        }
    }
}