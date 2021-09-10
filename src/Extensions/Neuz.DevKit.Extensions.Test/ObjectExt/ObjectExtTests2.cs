using System;
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
            });
        }

        public class MyClass
        {
            
        }
    }
}