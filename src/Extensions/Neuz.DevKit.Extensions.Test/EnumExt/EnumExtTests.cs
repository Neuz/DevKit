using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass]
    public class EnumExtTests
    {
        [ContractTestCase]
        public void DataTable_Test_1()
        {
            "Enum.GetDescription() - 1".Test(() =>
            {
                Assert.AreEqual("First Description", MyEnum.First.GetDescription());
            });
        }

        public enum MyEnum
        {
            [System.ComponentModel.Description("First Description")]
            First = 0
        }
    }
}