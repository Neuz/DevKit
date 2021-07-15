using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable UnusedParameter.Local
// ReSharper disable CheckNamespace

namespace Neuz.DevKit.Extensions.IEnumerableExt.Tests
{
    [TestClass]
    public class ForEachExtTests
    {
        [ContractTestCase]
        public void ForEachTest1()
        {
            "正常使用".Test(() =>
            {
                var arr = new[] {"aa", "bb"};
                arr.ForEach((i, item) =>
                {
                    Console.WriteLine(item.ToString());
                    Assert.AreEqual(arr[i], item);
                });
            });

            "正常使用2".Test(() =>
            {
                var arr = new[] {1, 2};
                arr.ForEach((i, item) =>
                {
                    Console.WriteLine(item.ToString());
                    Assert.AreEqual(arr[i], item);
                });
            });


            "抛出异常 - this".Test(() =>
            {
                int[] arr = null;
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    arr.ForEach((index, item) => { });
                });
            });
        }

        [ContractTestCase]
        public void ForEachTest2()
        {
            "正常使用".Test(() =>
            {
                var arr = new[] {"aa", "bb"};
                var rs = new List<string>();
                arr.ForEach(item => { rs.Add(item); });
                Assert.AreEqual(arr[0], rs[0]);
                Assert.AreEqual(arr[1], rs[1]);
            });

            "正常使用2".Test(() =>
            {
                var arr = new[] {1, 2};
                var rs = new List<int>();
                arr.ForEach(i => rs.Add(i * 10));
                Assert.AreEqual(rs[0], arr[0] * 10);
                Assert.AreEqual(rs[1], arr[1] * 10);
            });


            "抛出异常 - this".Test(() =>
            {
                int[] arr = null;
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    arr.ForEach(item => { });
                });
            });
        }
    }
}