namespace Neuz.DevKit.Extensions
{
    public static partial class ObjectExt
    {
        /// <summary>
        ///     当前对象类型是否可序列化的
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <returns><paramref name="this" /> 为 null ，返回 false</returns>
        public static bool IsSerializable(this object @this)
        {
            return @this != null && @this.GetType().IsSerializable;
        }
    }
}