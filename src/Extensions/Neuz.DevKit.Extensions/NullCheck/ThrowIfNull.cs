using System;

namespace Neuz.DevKit.Extensions
{
    public static class NullCheck
    {
        /// <summary>
        /// 如果为空抛出 <see cref="ArgumentNullException"/>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="message"></param>
        public static void ThrowIfNull(object @this, string message=null)
        {
            message ??= nameof(@this);
            if (@this == null) throw new ArgumentNullException(message);
        }

        /// <summary>
        /// 如果为空抛出 <see cref="ArgumentNullException"/>
        /// </summary>
        /// <param name="objects"></param>
        public static void ThrowIfNull(params object[] objects)
        {
            foreach (var o in objects)
            {
                ThrowIfNull(o);
            }
        }
    }
}