using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass]
    public class HasRowsTests
    {
        [ContractTestCase]
        public void SetTime_Test_1()
        {
            "DateTime.SetTime() - 1".Test(() =>
            {
                var dt       = new DateTime(2021, 12, 31);
                var expected = new DateTime(2021, 12, 31, 1, 2, 3, 999);
                Assert.AreEqual(expected, dt.SetTime(1, 2, 3, 999));
            });

            "DateTime.SetTime() - 2".Test(() =>
            {
                var dt       = new DateTime(2021, 12, 31);
                var expected = new DateTime(2021, 12, 31, 0, 0, 0);
                Assert.AreEqual(expected, dt.SetTime());
            });

            "DateTime.SetTime() 异常 - 1".Test(() =>
            {
                var dt = new DateTime(2021, 12, 31);
                Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                {
                    dt.SetTime(25);
                });
                Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                {
                    dt.SetTime(-1);
                });
            });
        }

        [ContractTestCase]
        public void StartOf_EndOf_Test_1()
        {
            "DateTime.StartOfDay() - 1".Test(() =>
            {
                var dt = new DateTime(2021, 12, 31);
                var rs = dt.StartOfDay();
                Assert.AreEqual(0, rs.Hour);
                Assert.AreEqual(0, rs.Minute);
                Assert.AreEqual(0, rs.Second);
                Assert.AreEqual(0, rs.Millisecond);
            });

            "DateTime.EndOfDay() - 1".Test(() =>
            {
                var dt  = new DateTime(2021, 12, 31);
                var end = dt.EndOfDay();
                Assert.AreEqual(23, end.Hour);
                Assert.AreEqual(59, end.Minute);
                Assert.AreEqual(59, end.Second);
                Assert.AreEqual(999, end.Millisecond);
            });

            "DateTime.StartOfWeek() - 1".Test(() =>
            {
                var dt = new DateTime(2019, 4, 1, 1, 2, 3);
                var rs = dt.StartOfWeek(DayOfWeek.Sunday);
                Assert.AreEqual(2019, rs.Year);
                Assert.AreEqual(3, rs.Month);
                Assert.AreEqual(31, rs.Day);
                Assert.AreEqual(0, rs.Hour);
                Assert.AreEqual(0, rs.Minute);
                Assert.AreEqual(0, rs.Second);
                Assert.AreEqual(0, rs.Millisecond);
            });

            "DateTime.EndOfWeek() - 1".Test(() =>
            {
                var dt = new DateTime(2019, 4, 1, 1, 2, 3);
                var rs = dt.EndOfWeek(DayOfWeek.Friday);
                Assert.AreEqual(2019, rs.Year);
                Assert.AreEqual(4, rs.Month);
                Assert.AreEqual(4, rs.Day);
                Assert.AreEqual(23, rs.Hour);
                Assert.AreEqual(59, rs.Minute);
                Assert.AreEqual(59, rs.Second);
                Assert.AreEqual(999, rs.Millisecond);
            });

            "DateTime.StartOfMonth() - 1".Test(() =>
            {
                var dt = new DateTime(2019, 4, 1, 1, 2, 3);
                var rs = dt.StartOfMonth();
                Assert.AreEqual(2019, rs.Year);
                Assert.AreEqual(4, rs.Month);
                Assert.AreEqual(1, rs.Day);
                Assert.AreEqual(0, rs.Hour);
                Assert.AreEqual(0, rs.Minute);
                Assert.AreEqual(0, rs.Second);
                Assert.AreEqual(0, rs.Millisecond);
            });

            "DateTime.EndOfMonth() - 1".Test(() =>
            {
                var dt = new DateTime(2019, 4, 12, 1, 2, 3);
                var rs = dt.EndOfMonth();
                Assert.AreEqual(2019, rs.Year);
                Assert.AreEqual(4, rs.Month);
                Assert.AreEqual(30, rs.Day);
                Assert.AreEqual(23, rs.Hour);
                Assert.AreEqual(59, rs.Minute);
                Assert.AreEqual(59, rs.Second);
                Assert.AreEqual(999, rs.Millisecond);
            });

            "DateTime.StartOfYear() - 1".Test(() =>
            {
                var dt = new DateTime(2019, 4, 12, 1, 2, 3);
                var rs = dt.StartOfYear();
                Assert.AreEqual(2019, rs.Year);
                Assert.AreEqual(1, rs.Month);
                Assert.AreEqual(1, rs.Day);
                Assert.AreEqual(0, rs.Hour);
                Assert.AreEqual(0, rs.Minute);
                Assert.AreEqual(0, rs.Second);
                Assert.AreEqual(0, rs.Millisecond);
            });

            "DateTime.EndOfYear() - 1".Test(() =>
            {
                var dt = new DateTime(2019, 4, 12, 1, 2, 3);
                var rs = dt.EndOfYear();
                Assert.AreEqual(2019, rs.Year);
                Assert.AreEqual(12, rs.Month);
                Assert.AreEqual(31, rs.Day);
                Assert.AreEqual(23, rs.Hour);
                Assert.AreEqual(59, rs.Minute);
                Assert.AreEqual(59, rs.Second);
                Assert.AreEqual(999, rs.Millisecond);
            });
        }


        [ContractTestCase]
        public void ToString_Test_1()
        {
            "DateTime.ToString_Common() - 1".Test(() =>
            {
                var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
                Assert.AreEqual("2019-04-01 21:11:11", dt.ToString_Common());
            });

            "DateTime.ToString_Full() - 1".Test(() =>
            {
                var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
                Assert.AreEqual("2019-04-01 21:11:11.1230000", dt.ToString_Full());
            });
        }

        [ContractTestCase]
        public void TimeStamp_Test_1()
        {
            "DateTime.TotalDays()".Test(() =>
            {
                var dt = new DateTime(2020, 10, 11, 11, 11, 11);
                Assert.AreEqual(18546.466099537036, dt.TotalDays());
            });

            "DateTime.TotalHours()".Test(() =>
            {
                var dt = new DateTime(2019, 4, 1, 11, 11, 11);
                Assert.AreEqual(431699.18638888886, dt.TotalHours());
            });

            "DateTime.TotalMinutes()".Test(() =>
            {
                var dt = new DateTime(2019, 4, 1, 11, 11, 11);
                Assert.AreEqual(25901951.183333334, dt.TotalMinutes());
            });

            "DateTime.TotalSeconds()".Test(() =>
            {
                var dt = new DateTime(2019, 4, 1, 11, 11, 11);
                Assert.AreEqual(1554117071, dt.TotalSeconds());
            });

            "DateTime.TotalMilliseconds()".Test(() =>
            {
                var dt = new DateTime(2019, 4, 1, 11, 11, 11);
                Assert.AreEqual(1554117071000, dt.TotalMilliseconds());
            });
        }
    }
}