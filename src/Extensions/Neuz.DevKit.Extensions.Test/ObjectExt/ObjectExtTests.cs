using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

// ReSharper disable ArrangeDefaultValueWhenTypeNotEvident
// ReSharper disable RedundantTypeArgumentsOfMethod

// ReSharper disable ExpressionIsAlwaysNull

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass()]
    public class ObjectExtTests
    {
        #region To

        [ContractTestCase]
        public void To_Test_1()
        {
            "string to numeric".Test(() =>
            {
                // null
                string input = null;
                Assert.AreEqual(-99, input.To(-99)); // will be fail

                // int
                Assert.AreEqual(1123, "1123".To(-99));

                Assert.AreEqual(-99, "1123x".To(-99)); // will be fail

                // long
                Assert.AreEqual(1123L, "1123".To<long>(-99L));

                Assert.AreEqual(-99L, "1123x".To<long>(-99L)); // will be fail

                // double
                Assert.AreEqual(12.3d, "12.3".To<double>(-99d));

                Assert.AreEqual(-99d, "12.3x".To<double>(-99d));

                // decimal
                Assert.AreEqual(-12.3m, "-12.3".To<decimal>(-99m));

                Assert.AreEqual(-99m, "12.3x".To<decimal>(-99m));
            });


            "numeric to string".Test(() =>
            {
                Assert.AreEqual("123", 123L.To("default"));

                Assert.AreEqual("123", 123m.To("default"));
            });

            "string to datetime".Test(() =>
            {
                Assert.AreEqual(new DateTime(2018, 1, 1, 23, 59, 59), "2018-01-01 23:59:59".To(DateTime.MinValue));

                Assert.AreEqual(DateTime.MinValue, "2018-01-01 23:59:59xxxxxx".To(DateTime.MinValue)); // will be fail
            });
        }

        [ContractTestCase]
        public void To_Test_2()
        {
            "string to numeric".Test(() =>
            {
                // null
                string input = null;
                Assert.AreEqual(default(int), input.To<int>()); // will be fail

                // int
                Assert.AreEqual(1123, "1123".To(-99));

                Assert.AreEqual(default(int), "1123x".To<int>()); // will be fail

                // long
                Assert.AreEqual(1123L, "1123".To<long>(-99L));

                Assert.AreEqual(default(long), "1123x".To<long>()); // will be fail

                // double
                Assert.AreEqual(12.3d, "12.3".To<double>(-99d));

                Assert.AreEqual(default(double), "12.3x".To<double>());

                // decimal
                Assert.AreEqual(-12.3m, "-12.3".To<decimal>(-99m));

                Assert.AreEqual(default(decimal), "12.3x".To<decimal>());
            });
        }


        [ContractTestCase]
        public void To_Test_3()
        {
            "object convert".Test(() =>
            {
                // string to int
                Assert.AreEqual(123, "123".To<int>(o => -99));

                // object
                var obj = new {Name = "Aoi", Age = 10};
                Assert.AreEqual(null, obj.To<string>());                             // will be fail
                Assert.AreEqual(obj.Name, obj.To<string>(o => (o as dynamic).Name)); // will be fail, return default func
            });
        }

        #endregion


        #region As

        class MyClass
        {
            public string Name { get; set; }
        }

        class MyClass2 : MyClass
        {
            public string Title { get; set; }
        }

        [ContractTestCase]
        public void As_Test_1()
        {
            "object as".Test(() =>
            {
                var myClass2 = new MyClass2 {Name = "Aio", Title = "xxx"};
                Assert.AreEqual("Aio", myClass2.As<MyClass>().Name);

                var myClass = new MyClass {Name = "Bio"};
                Assert.AreEqual(default(MyClass2), myClass.As<MyClass2>());

                var defaultMyClass2 = new MyClass2 {Name = "C", Title = "C"};
                Assert.AreEqual(defaultMyClass2, myClass.As<MyClass2>(defaultMyClass2));
            });
        }

        #endregion
    }
}