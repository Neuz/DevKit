using System;
using System.Text;

namespace Neuz.DevKit.Extensions
{
    public static partial class StringExt
    {
        /// <summary>
        ///     <para>进行 BASE64 编码</para>
        ///     <para>使用 <see cref="Encoding.UTF8" /></para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns>转换失败返回 <c>null</c></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var str1   = "ABCD";
        /// str1.EncodeBase64(); // "QUJDRA=="
        ///         ]]>
        ///     </code>
        /// </example>
        public static string EncodeBase64(this string @this)
        {
            try
            {
                var encoding = Encoding.UTF8;
                var bytes    = encoding.GetBytes(@this);
                return Convert.ToBase64String(bytes);
            }
            catch { return null; }
        }
    }
}