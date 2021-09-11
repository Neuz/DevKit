using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass]
    public class DataTableExtTests
    {
        [ContractTestCase]
        public void DataTable_Test_1()
        {
            "DataTable.HasRow() - 1".Test(() =>
            {
                var dataTable = new DataTable();
                Assert.IsFalse(dataTable.HasRows());

                dataTable = null;
                Assert.ThrowsException<ArgumentNullException>(() => dataTable.HasRows());
            });

            "DataTable.FirstRow() - 1".Test(() =>
            {
                var dataTable = new DataTable();
                Assert.AreEqual(null, dataTable.FirstRow());

                dataTable = null;
                Assert.ThrowsException<ArgumentNullException>(() => dataTable.FirstRow());
            });

            "DataTable.LastRow() - 1".Test(() =>
            {
                var dataTable = new DataTable();
                Assert.AreEqual(null, dataTable.LastRow());

                dataTable = null;
                Assert.ThrowsException<ArgumentNullException>(() => dataTable.LastRow());
            });
        }
    }
}