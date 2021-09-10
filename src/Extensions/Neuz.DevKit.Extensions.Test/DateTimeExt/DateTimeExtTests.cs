﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass]
    public class DateTimeExtTests
    {
        [ContractTestCase]
        public void SetTimeTest_1()
        {
            "SetTime() - 1".Test(() =>
            {
                var dt       = new DateTime(2021, 12, 31);
                var expected = new DateTime(2021, 12, 31, 1, 2, 3, 999);
                Assert.AreEqual(expected, dt.SetTime(1, 2, 3, 999));
            });

            "SetTime() - 2".Test(() =>
            {
                var dt       = new DateTime(2021, 12, 31);
                var expected = new DateTime(2021, 12, 31, 0, 0, 0);
                Assert.AreEqual(expected, dt.SetTime());
            });

            "SetTime() 异常 - 1".Test(() =>
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
        public void EndOfDayTest_1()
        {
            "EndOfDay() - 1".Test(() =>
            {
                var dt  = new DateTime(2021, 12, 31);
                var end = dt.EndOfDay();
                Assert.AreEqual(23, end.Hour);
                Assert.AreEqual(59, end.Minute);
                Assert.AreEqual(59, end.Second);
                Assert.AreEqual(999, end.Millisecond);
            });
        }

        [ContractTestCase]
        public void StartOfDayTest_1()
        {
            "StartOfDay() - 1".Test(() =>
            {
                var dt = new DateTime(2021, 12, 31);
                var rs = dt.StartOfDay();
                Assert.AreEqual(0, rs.Hour);
                Assert.AreEqual(0, rs.Minute);
                Assert.AreEqual(0, rs.Second);
                Assert.AreEqual(0, rs.Millisecond);
            });
        }

        [ContractTestCase]
        public void StartOfWeekTest_1()
        {
            "StartOfWeek() - 1".Test(() =>
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
        }

        [ContractTestCase]
        public void EndOfWeekTest_1()
        {
            "EndOfWeek() - 1".Test(() =>
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
        }

        [ContractTestCase]
        public void TimeStampTest_1()
        {
            "TotalDays()".Test(() =>
            {
                var dt = new DateTime(2020, 10, 11, 11, 11, 11);
                Assert.AreEqual(18546.466099537036,dt.TotalDays());
            });
        }
    }
}