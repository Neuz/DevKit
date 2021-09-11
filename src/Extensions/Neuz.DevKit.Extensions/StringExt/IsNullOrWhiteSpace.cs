using System.Linq;

namespace Neuz.DevKit.Extensions
{
    public static partial class StringExt
    {
        /// <summary>
        ///     是否null或空白
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "   ".IsNullOrWhiteSpace(); // true
        /// "\r".IsNullOrWhiteSpace();  // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsNullOrWhiteSpace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this);
        }
    }
}