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
        public enum SHAFormat
        {
            /// <summary>
            /// 十六进制字符串
            /// </summary>
            Hex,

            /// <summary>
            /// Base64字符串
            /// </summary>
            Base64
        }

        private static string SHAToString(byte[] dataBytes, SHAFormat format)
        {
            return format switch
            {
                SHAFormat.Hex => BitConverter.ToString(dataBytes).Replace("-", ""),
                SHAFormat.Base64 => Convert.ToBase64String(dataBytes),
                _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
            };
        }

        #region SHA1

        /// <summary>
        /// SHA1 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] SHA1(string data, Encoding encoding = null)
            => HashInternal.HashCompute<SHA1CryptoServiceProvider>(data, encoding);

        /// <summary>
        /// SHA1 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="format">默认 <see cref="SHAFormat.Hex"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string SHA1(string data, SHAFormat format = SHAFormat.Hex, Encoding encoding = null)
            => SHAToString(SHA1(data, encoding), format);

        #endregion

        #region SHA256

        /// <summary>
        /// SHA256 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] SHA256(string data, Encoding encoding = null)
            => HashInternal.HashCompute<SHA256CryptoServiceProvider>(data, encoding);

        /// <summary>
        /// SHA256 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="format">默认 <see cref="SHAFormat.Hex"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string SHA256(string data, SHAFormat format = SHAFormat.Hex, Encoding encoding = null)
            => SHAToString(SHA256(data, encoding), format);

        #endregion

        #region SHA384

        /// <summary>
        /// SHA384 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] SHA384(string data, Encoding encoding = null)
            => HashInternal.HashCompute<SHA384CryptoServiceProvider>(data, encoding);

        /// <summary>
        /// SHA384 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="format">默认 <see cref="SHAFormat.Hex"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string SHA384(string data, SHAFormat format = SHAFormat.Hex, Encoding encoding = null)
            => SHAToString(SHA384(data, encoding), format);

        #endregion

        #region SHA512

        /// <summary>
        /// SHA512 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] SHA512(string data, Encoding encoding = null)
            => HashInternal.HashCompute<SHA512CryptoServiceProvider>(data, encoding);

        /// <summary>
        /// SHA512 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="format">默认 <see cref="SHAFormat.Hex"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string SHA512(string data, SHAFormat format = SHAFormat.Hex, Encoding encoding = null)
            => SHAToString(SHA512(data, encoding), format);

        #endregion
    }
}