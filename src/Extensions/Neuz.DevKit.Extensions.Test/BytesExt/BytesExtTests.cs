using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass()]
    public class BytesExtTests
    {
        [ContractTestCase]
        public void GetStringTest_1()
        {
            "正常使用_1".Test(() =>
            {
                var str = "abcd";
                var b = Encoding.UTF8.GetBytes(str);
                Assert.AreEqual(str, b.GetString());
            });


            "正常使用_2".Test(() =>
            {
                var str = "abcd";
                var encoding = Encoding.ASCII;
                var b = encoding.GetBytes(str);
                Assert.AreEqual(str, b.GetString(encoding));
            });

            "异常检查_1".Test(() =>
            {
                var str = "abcd";
                var b = Encoding.UTF8.GetBytes(str);
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    b = null;
                    Assert.AreEqual(str, b.GetString());
                });
            });

            "异常检查_2".Test(() =>
            {
                var str = "abcd";
                var encoding = Encoding.ASCII;
                var b = encoding.GetBytes(str);
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    Assert.AreEqual(str, b.GetString(null));
                });
            });

            "异常检查_3".Test(() =>
            {
                var str = "abcd";
                var b = Encoding.UTF8.GetBytes(str);
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    Assert.AreEqual(str, b.GetString(null));
                });
            });
        }
    }
}