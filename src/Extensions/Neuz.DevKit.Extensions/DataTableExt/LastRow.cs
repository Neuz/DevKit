using System;
using System.Data;

namespace Neuz.DevKit.Extensions
{
    public static partial class DataTableExt
    {
        /// <summary>
        ///     获取末行
        /// <para>
        /// 当前DataTable没有行时，返回null
        /// </para>
        /// </summary>
        /// <param name="this"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// dataTable.LastRow();
        ///         ]]>
        ///     </code>
        /// </example>
        public static DataRow LastRow(this DataTable @this)
        {
            return !@this.HasRows() ? null : @this.Rows[^1];
        }
    }
}