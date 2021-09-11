using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable UnusedParameter.Local

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass]
    public class DataRowExtTests
    {
        [ContractTestCase]
        public void Cell_Test_1()
        {
            "DataRow.Cell<T>() - 1".Test(() =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("id");
                dataTable.Columns.Add("name");
                dataTable.Rows.Add("aaa", "123");

                Assert.AreEqual(default, dataTable.Rows[0].Cell<string>("columnName"));
                Assert.AreEqual(123, dataTable.Rows[0].Cell<int>("name"));
            });

            "DataRow.Cell<T>() - 2".Test(() =>
            {
                var dataTable = new DataTable();
                dataTable.Columns.Add("id");
                dataTable.Columns.Add("name");
                dataTable.Rows.Add("aaa", "123");

                Assert.AreEqual("aaa", dataTable.Rows[0].Cell("columnName", "aaa"));

                Assert.AreEqual("aaa - 1", dataTable.Rows[0].Cell("columnName", row => $"{row["id"]} - 1"));
            });
        }
    }
}