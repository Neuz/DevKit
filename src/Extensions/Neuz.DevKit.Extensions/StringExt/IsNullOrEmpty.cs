using System.Linq;

namespace Neuz.DevKit.Extensions
{
    public static partial class StringExt
    {
        /// <summary>
        ///     是否 null 或 string.Empty
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// " ".IsNullOrEmpty(); // false
        /// "".IsNullOrEmpty();  // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }
    }
}