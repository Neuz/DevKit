using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

// ReSharper disable ArrangeDefaultValueWhenTypeNotEvident
// ReSharper disable RedundantTypeArgumentsOfMethod

// ReSharper disable ExpressionIsAlwaysNull

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass()]
    public class ObjectExtTests2
    {
        [ContractTestCase]
        public void To_Test_1()
        {
            "Object.IsClass".Test(() =>
            {
                var obj1 = new MyClass();
                Assert.IsTrue(obj1.IsClass());

                var obj2 = 1233;
                Assert.IsFalse(obj2.IsClass());

                var obj3 = typeof(string);
                Assert.IsTrue(obj3.IsClass());

                object obj4 = null;
                Assert.IsFalse(obj4.IsClass());
            });

            "Object.IsArray".Test(() =>
            {
                var obj1 = new[] {"1", "2"};
                Assert.IsTrue(obj1.IsArray());

                var obj2 = new List<string> {"1", "2"};
                Assert.IsFalse(obj2.IsArray());

                object obj3 = null;
                Assert.IsFalse(obj3.IsArray());
            });
        }

        public class MyClass
        {
        }
    }
}