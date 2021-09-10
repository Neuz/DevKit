using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

// ReSharper disable ArrangeDefaultValueWhenTypeNotEvident
// ReSharper disable RedundantTypeArgumentsOfMethod

// ReSharper disable ExpressionIsAlwaysNull

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass]
    public class ObjectExtTests3
    {
        [ContractTestCase]
        public void In_Test_1()
        {
            "Object.In<T>()".Test(() =>
            {
                var strItems = new[] {"a", "A", "b"};
                var s        = "B";
                Assert.IsTrue(s.In(strItems, StringComparer.CurrentCultureIgnoreCase));
                Assert.IsFalse(s.In(strItems, StringComparer.CurrentCulture));

                var    stringItems = new[] {"a", "b", null};
                var    s1          = "a";
                string s2          = null;
                Assert.IsTrue(s1.In(stringItems));
                Assert.IsTrue(s2.In(stringItems));
            });
        }

        [ContractTestCase]
        public void NotIn_Test_1()
        {
            "Object.NotIn<T>()".Test(() =>
            {
                var strItems = new[] {"a", "A", "b"};
                var s        = "B";
                Assert.IsTrue(s.In(strItems, StringComparer.CurrentCultureIgnoreCase));
                Assert.IsFalse(s.In(strItems, StringComparer.CurrentCulture));

                var    stringItems = new[] {"a", "b", null};
                var    s1          = "a";
                string s2          = null;
                Assert.IsFalse(s1.NotIn(stringItems));
                Assert.IsFalse(s2.NotIn(stringItems));
            });
        }
    }
}