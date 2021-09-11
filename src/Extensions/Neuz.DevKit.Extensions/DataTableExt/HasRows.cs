using System;
using System.Data;

namespace Neuz.DevKit.Extensions
{
    public static partial class DataTableExt
    {
        /// <summary>
        ///     是否存在数据行
        /// </summary>
        /// <param name="this"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// dataTable.HasRows();
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool HasRows(this DataTable @this)
        {
            NullCheck.ThrowIfNull(@this);
            return @this.Rows.Count > 0;
        }
    }
}