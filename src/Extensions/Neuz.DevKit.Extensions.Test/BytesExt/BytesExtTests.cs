using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass]
    public class BytesExtTests
    {
        [ContractTestCase]
        public void GetStringTest_1()
        {
            "byte[].GetString() - 1".Test(() =>
            {
                var str = "abcd";
                var b = Encoding.UTF8.GetBytes(str);
                Assert.AreEqual(str, b.GetString());
            });


            "byte[].GetString() - 2".Test(() =>
            {
                var str = "abcd";
                var encoding = Encoding.ASCII;
                var b = encoding.GetBytes(str);
                Assert.AreEqual(str, b.GetString(encoding));
            });

            "byte[].GetString() 异常 - 1".Test(() =>
            {
                var str = "abcd";
                var b = Encoding.UTF8.GetBytes(str);
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    b = null;
                    Assert.AreEqual(str, b.GetString());
                });
            });

            "byte[].GetString() 异常 -2".Test(() =>
            {
                var str = "abcd";
                var encoding = Encoding.ASCII;
                var b = encoding.GetBytes(str);
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    Assert.AreEqual(str, b.GetString(null));
                });
            });

            "byte[].GetString() 异常 - 3".Test(() =>
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