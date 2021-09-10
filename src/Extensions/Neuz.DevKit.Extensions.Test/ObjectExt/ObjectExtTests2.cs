using System;
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
        public void Is_Test_1()
        {
            "Object.IsClass()".Test(() =>
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

            "Object.IsArray()".Test(() =>
            {
                var obj1 = new[] {"1", "2"};
                Assert.IsTrue(obj1.IsArray());

                var obj2 = new List<string> {"1", "2"};
                Assert.IsFalse(obj2.IsArray());

                object obj3 = null;
                Assert.IsFalse(obj3.IsArray());
            });

            "Object.IsNull()".Test(() =>
            {
                var obj1 = new[] {"1", "2"};
                Assert.IsFalse(obj1.IsNull());

                var obj2 = new List<string> {"1", "2"};
                Assert.IsFalse(obj2.IsNull());

                object obj3 = null;
                Assert.IsTrue(obj3.IsNull());
            });

            "Object.IsDBNull()".Test(() =>
            {
                object obj1 = null;
                Assert.IsFalse(obj1.IsDBNull());

                object obj2 = DBNull.Value;
                Assert.IsTrue(obj2.IsDBNull());
            });

            "Object.IsNullOrDbNull()".Test(() =>
            {
                object obj1 = null;
                Assert.IsTrue(obj1.IsNullOrDbNull());

                object obj2 = DBNull.Value;
                Assert.IsTrue(obj2.IsNullOrDbNull());
            });

            "Object.IsSerializable()".Test(() =>
            {
                var obj1 = new[] {"1", "2"};
                Assert.IsTrue(obj1.IsSerializable());

                object obj2 = null;
                Assert.IsFalse(obj2.IsSerializable());

                object obj3 = new MyClass();
                Assert.IsFalse(obj3.IsSerializable());

                object obj4 = new MyClass2();
                Assert.IsTrue(obj4.IsSerializable());
            });

            "Object.IsEnum()".Test(() =>
            {
                var obj1 = new[] {"1", "2"};
                Assert.IsFalse(obj1.IsEnum());

                object obj2 = null;
                Assert.IsFalse(obj2.IsEnum());

                object obj3 = new MyClass();
                Assert.IsFalse(obj3.IsEnum());

                object obj4 = MyEnum.First;
                Assert.IsTrue(obj4.IsEnum());
            });
        }


        public enum MyEnum
        {
            First
        }

        public class MyClass
        {
        }

        [Serializable]
        public class MyClass2
        {
        }
    }
}