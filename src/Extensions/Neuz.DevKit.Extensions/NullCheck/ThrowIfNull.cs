using System;
using System.Linq;

namespace Neuz.DevKit.Extensions
{
    public static class NullCheck
    {
        /// <summary>
        /// 如果为空抛出 <see cref="ArgumentNullException"/>
        /// </summary>
        /// <param name="objects"></param>
        public static void ThrowIfNull(params object[] objects)
        {
            if (objects.Any(obj => obj == null)) throw new ArgumentNullException(null, "参数不能为空");
        }
    }
}