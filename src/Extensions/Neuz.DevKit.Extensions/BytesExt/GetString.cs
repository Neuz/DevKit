using System;
using System.Text;

namespace Neuz.DevKit.Extensions
{
    public static partial class BytesExt
    {
        /// <summary>
        ///     转换为字符串
        /// </summary>
        /// <param name="this"></param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="encoding" />
        /// </exception>
        /// <exception cref="DecoderFallbackException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// bytes.GetString(Encoding.UTF8);
        ///         ]]>
        ///     </code>
        /// </example>
        public static string GetString(this byte[] @this, Encoding encoding)
        {
            NullCheck.ThrowIfNull(@this,encoding);
            return encoding.GetString(@this);
        }

        /// <summary>
        ///     <para>转换为字符串</para>
        ///     <para>默认Encoding.UTF8</para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="DecoderFallbackException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// bytes.GetString(Encoding.UTF8);
        ///         ]]>
        ///     </code>
        /// </example>
        public static string GetString(this byte[] @this)
        {
            return @this.GetString(Encoding.UTF8);
        }
    }
}