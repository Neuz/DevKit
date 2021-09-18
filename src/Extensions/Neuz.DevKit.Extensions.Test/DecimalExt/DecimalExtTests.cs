using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass]
    public class DecimalExtTests
    {
        [ContractTestCase]
        public void Abs_Test_1()
        {
            "Decimal.Abs() - 1".Test<decimal, decimal>((source, result) =>
                               {
                                   Assert.AreEqual(result, source.Abs());
                               })
                               .WithArguments(
                                   (-1.32m, 1.32m),
                                   (decimal.MinValue, -decimal.MinValue),
                                   (decimal.MaxValue, decimal.MaxValue)
                               );
        }
    }
}