using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable UnusedParameter.Local

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass]
    public class EnumerableExtTests
    {
        [ContractTestCase]
        public void ForEach_Test_1()
        {
            "Array.ForEach() - 1".Test(() =>
            {
                var arr = new[] {"aa", "bb"};
                arr.ForEach((i, item) =>
                {
                    Console.WriteLine(item.ToString());
                    Assert.AreEqual(arr[i], item);
                });
            });

            "Array.ForEach() - 2".Test(() =>
            {
                var arr = new[] {1, 2};
                arr.ForEach((i, item) =>
                {
                    Console.WriteLine(item.ToString());
                    Assert.AreEqual(arr[i], item);
                });
            });


            "Array.ForEach() 异常 - 1".Test(() =>
            {
                int[] arr = null;
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    arr.ForEach((index, item) => { });
                });
            });
        }

        [ContractTestCase]
        public void ForEach_Test_2()
        {
            "List|Array.ForEach() - 1".Test(() =>
            {
                var arr = new[] {"aa", "bb"};
                var rs = new List<string>();
                arr.ForEach(item => { rs.Add(item); });
                Assert.AreEqual(arr[0], rs[0]);
                Assert.AreEqual(arr[1], rs[1]);
            });

            "List|Array.ForEach() - 2".Test(() =>
            {
                var arr = new[] {1, 2};
                var rs = new List<int>();
                arr.ForEach(i => rs.Add(i * 10));
                Assert.AreEqual(rs[0], arr[0] * 10);
                Assert.AreEqual(rs[1], arr[1] * 10);
            });


            "Array.ForEach() 异常 - 1".Test(() =>
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