using System;
using System.Security.Cryptography;
using System.Text;

// ReSharper disable InconsistentNaming

namespace Neuz.DevKit.Encryption
{
    public partial class Encrypt
    {
        /// <summary>
        /// 格式化类型
        /// </summary>
        public enum MD5Format
        {
            /// <summary>
            /// 16位长度
            /// </summary>
            L16,

            /// <summary>
            /// 32位长度
            /// </summary>
            L32,

            /// <summary>
            /// Base64字符串
            /// </summary>
            Base64
        }

        private static string MD5ToString(byte[] dataBytes, MD5Format format)
        {
            return format switch
            {
                MD5Format.L16 => BitConverter.ToString(dataBytes, 4, 8).Replace("-", ""),
                MD5Format.L32 => BitConverter.ToString(dataBytes).Replace("-", ""),
                MD5Format.Base64 => Convert.ToBase64String(dataBytes),
                _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
            };
        }

        /// <summary>
        /// MD5 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] MD5(string data, Encoding encoding = null)
            => HashInternal.HashCompute<MD5CryptoServiceProvider>(data, encoding);

        /// <summary>
        /// MD5 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="format">默认 <see cref="MD5Format.L32"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        public static string MD5(string data, MD5Format format = MD5Format.L32, Encoding encoding = null)
            => MD5ToString(MD5(data, encoding), format);
    }
}