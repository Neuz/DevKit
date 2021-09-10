namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        ///     当前对象类型是否枚举
        /// </summary>
        /// <param name="this"></param>
        /// <returns><paramref name="this" /> 为 null ，返回 false</returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// private enum MyEnum
        /// {
        ///     None
        /// }
        /// 
        /// var obj1 = MyEnum.None;
        /// obj1.IsEnum(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsEnum(this object @this)
        {
            return @this != null && @this.GetType().IsEnum;
        }
    }
}