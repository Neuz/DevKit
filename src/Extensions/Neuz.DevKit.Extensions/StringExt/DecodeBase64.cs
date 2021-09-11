using System;
using System.Text;

namespace Neuz.DevKit.Extensions
{
    public static partial class StringExt
    {
        /// <summary>
        ///     <para>进行 BASE6 4解码</para>
        ///     <para>使用 <see cref="Encoding.UTF8" /></para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns>转换失败返回 <c>null</c></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var base64 = "QUJDRA==";
        /// base64.DecodeBase64(); // "ABCD"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string DecodeBase64(this string @this)
        {
            try
            {
                var encoding = Encoding.UTF8;
                var bytes    = Convert.FromBase64String(@this);
                return encoding.GetString(bytes);
            }
            catch { return null; }
        }
    }
}