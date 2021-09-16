using System;
using System.Security.Cryptography;
using System.Text;

namespace Neuz.DevKit.Encryption
{
    internal class HashInternal
    {
        public static byte[] HashCompute<T>(string data, Encoding encoding = null) where T : HashAlgorithm, new()
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            encoding ??= Encoding.UTF8;
            var provider = new T();
            return provider.ComputeHash(encoding.GetBytes(data));
        }

        public static byte[] KeyedHashCompute<T>(string data, string key, Encoding encoding = null) where T : KeyedHashAlgorithm, new()
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            key      ??= string.Empty;
            encoding ??= Encoding.UTF8;
            var provider = new T {Key = encoding.GetBytes(key)};
            return provider.ComputeHash(encoding.GetBytes(data));
        }
    }
}