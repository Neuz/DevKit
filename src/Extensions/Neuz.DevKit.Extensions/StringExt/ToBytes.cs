using System;
using System.Text;

namespace Neuz.DevKit.Extensions
{
    public static partial class StringExt
    {
        /// <summary>
        ///     转换为 byte 数组
        /// </summary>
        /// <param name="this"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="EncoderFallbackException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var source = "abcd";
        /// var rs = source.ToBytes(Encoding.Unicode);
        /// var rs2 = source.ToBytes();    // use Encoding.UTF8
        ///         ]]>
        ///     </code>
        /// </example>
        public static byte[] ToBytes(this string @this, Encoding encoding)
        {
            NullCheck.ThrowIfNull(@this, encoding);
            return encoding.GetBytes(@this);
        }

        /// <summary>
        ///     <para>转换为 byte 数组</para>
        ///     <para>编码格式 默认为 <see cref="Encoding.UTF8" /></para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="EncoderFallbackException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var source = "abcd";
        /// var rs = source.ToBytes(Encoding.Unicode);
        /// var rs2 = source.ToBytes();    // use Encoding.UTF8
        ///         ]]>
        ///     </code>
        /// </example>
        public static byte[] ToBytes(this string @this)
        {
            return @this.ToBytes(Encoding.UTF8);
        }
    }
}