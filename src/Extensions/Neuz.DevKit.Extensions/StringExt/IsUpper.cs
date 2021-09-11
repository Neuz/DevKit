using System.Linq;

namespace Neuz.DevKit.Extensions
{
    public static partial class StringExt
    {
        /// <summary>
        ///     是否全部大写
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "ABC".IsUpper(); // true
        /// "ABd".IsUpper(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsUpper(this string @this)
        {
            return @this.All(char.IsUpper);
        }
    }
}