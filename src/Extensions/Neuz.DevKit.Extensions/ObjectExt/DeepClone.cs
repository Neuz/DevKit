using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        ///     <para>深复制</para>
        ///     <remarks>需要支持序列化 Serializable</remarks>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="SerializationException">目标类型 <typeparamref name="T"/> 需要支持序列化</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// [Serializable]
        /// private class MyClass
        /// {
        ///     public string Name { get; set; }
        /// }
        /// var obj = new MyClass{Name = "aa"};
        /// var rs = obj.DeepClone();
        /// // obj.Name == rs.Name
        /// // obj != rs
        ///         ]]>
        ///     </code>
        /// </example>
        public static T DeepClone<T>(this T @this)
        {
            if (!typeof(T).IsSerializable) throw new SerializationException("目标类型需要支持序列化");

            if (ReferenceEquals(@this, null)) return default;

            using var stream    = new MemoryStream();
            var       formatter = new BinaryFormatter();
            formatter.Serialize(stream, @this);
            stream.Seek(0, SeekOrigin.Begin);
            return (T) formatter.Deserialize(stream);
        }
    }
}