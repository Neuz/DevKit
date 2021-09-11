using System;
using System.Data;

namespace Neuz.DevKit.Extensions
{
    public static partial class DataRowExt
    {
        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <typeparam name="T">目标类型，约束为 <see cref="IConvertible" /></typeparam>
        /// <returns><paramref name="columnName" />不存在 或 转换失败，返回 default(<typeparamref name="T" />)</returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = dataRow.Cell<string>("columnName"); // if fail return default(string)
        ///         ]]>
        ///     </code>
        /// </example>
        public static T Cell<T>(this DataRow @this, string columnName) where T : IConvertible
        {
            return @this.Cell(columnName, default(T));
        }

        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <param name="func"></param>
        /// <typeparam name="T">目标类型，约束为 <see cref="IConvertible" /></typeparam>
        /// <returns><paramref name="columnName" />不存在 或 转换失败，返回 <paramref name="func" /></returns>
        public static T Cell<T>(this DataRow @this, string columnName, Func<DataRow,T> func) where T : IConvertible
        {
            return @this.Cell(columnName, func.Invoke(@this));
        }

        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <param name="defaultValue">默认值</param>
        /// <typeparam name="T">
        ///     目标类型，约束为 <see cref="IConvertible" />
        /// </typeparam>
        /// <returns><paramref name="columnName" />不存在 或 转换失败，返回 <paramref name="defaultValue" /></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = dataRow.Cell("columnName", "abc"); // if fail return "abc"
        ///         ]]>
        ///     </code>
        /// </example>
        public static T Cell<T>(this DataRow @this, string columnName, T defaultValue) where T : IConvertible
        {
            return @this.Table.Columns.Contains(columnName)
                ? @this[columnName].To(defaultValue)
                : defaultValue;
        }
    }
}