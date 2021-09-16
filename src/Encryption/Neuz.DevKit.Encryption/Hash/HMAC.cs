using System;
using System.Security.Cryptography;
using System.Text;

// ReSharper disable CommentTypo

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Neuz.DevKit.Encryption
{
    public partial class Encrypt
    {
        public enum HMACFormat
        {
            /// <summary>
            /// 格式化类型
            /// </summary>
            /// <summary>
            /// 十六进制字符串
            /// </summary>
            Hex,

            /// <summary>
            /// Base64字符串
            /// </summary>
            Base64
        }

        private static string HMACToString(byte[] dataBytes, HMACFormat format)
        {
            return format switch
            {
                HMACFormat.Hex => BitConverter.ToString(dataBytes).Replace("-", ""),
                HMACFormat.Base64 => Convert.ToBase64String(dataBytes),
                _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
            };
        }

        #region HMACMD5

        /// <summary>
        /// HMACMD5 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">默认 <see cref="string.Empty"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] HMACMD5(string data, string key = null, Encoding encoding = null)
            => HashInternal.KeyedHashCompute<HMACMD5>(data, key, encoding);

        /// <summary>
        /// HMACMD5 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">默认 <see cref="string.Empty"/></param>
        /// <param name="format">默认 <see cref="HMACFormat.Hex"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string HMACMD5(string data, string key = null, HMACFormat format = HMACFormat.Hex, Encoding encoding = null)
            => HMACToString(HMACMD5(data, key, encoding), format);

        #endregion

        #region HMACSHA1

        /// <summary>
        /// HMACSHA1 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">默认 <see cref="string.Empty"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] HMACSHA1(string data, string key = null, Encoding encoding = null)
            => HashInternal.KeyedHashCompute<HMACSHA1>(data, key, encoding);

        /// <summary>
        /// HMACSHA1 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">默认 <see cref="string.Empty"/></param>
        /// <param name="format">默认 <see cref="HMACFormat.Hex"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string HMACSHA1(string data, string key = null, HMACFormat format = HMACFormat.Hex, Encoding encoding = null)
            => HMACToString(HMACSHA1(data, key, encoding), format);

        #endregion

        #region HMACSHA256

        /// <summary>
        /// HMACSHA256 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">默认 <see cref="string.Empty"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] HMACSHA256(string data, string key = null, Encoding encoding = null)
            => HashInternal.KeyedHashCompute<HMACSHA256>(data, key, encoding);

        /// <summary>
        /// HMACSHA256 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">默认 <see cref="string.Empty"/></param>
        /// <param name="format">默认 <see cref="HMACFormat.Hex"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string HMACSHA256(string data, string key = null, HMACFormat format = HMACFormat.Hex, Encoding encoding = null)
            => HMACToString(HMACSHA256(data, key, encoding), format);

        #endregion

        #region HMACSHA384

        /// <summary>
        /// HMACSHA384 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">默认 <see cref="string.Empty"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] HMACSHA384(string data, string key = null, Encoding encoding = null)
            => HashInternal.KeyedHashCompute<HMACSHA384>(data, key, encoding);

        /// <summary>
        /// HMACSHA384 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">默认 <see cref="string.Empty"/></param>
        /// <param name="format">默认 <see cref="HMACFormat.Hex"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string HMACSHA384(string data, string key = null, HMACFormat format = HMACFormat.Hex, Encoding encoding = null)
            => HMACToString(HMACSHA384(data, key, encoding), format);

        #endregion

        #region HMACSHA512

        /// <summary>
        /// HMACSHA512 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">默认 <see cref="string.Empty"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static byte[] HMACSHA512(string data, string key = null, Encoding encoding = null)
            => HashInternal.KeyedHashCompute<HMACSHA512>(data, key, encoding);

        /// <summary>
        /// HMACSHA512 算法
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key">默认 <see cref="string.Empty"/></param>
        /// <param name="format">默认 <see cref="HMACFormat.Hex"/></param>
        /// <param name="encoding">默认 <see cref="Encoding.UTF8"/></param>
        /// <returns></returns>
        public static string HMACSHA512(string data, string key = null, HMACFormat format = HMACFormat.Hex, Encoding encoding = null)
            => HMACToString(HMACSHA512(data, key, encoding), format);

        #endregion
    }
}