using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neuz.DevKit.Result.Test
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var rs = Result.Ok();

            Assert.AreEqual(0, rs.Errors.Count);
            Assert.IsTrue(rs.Succeed);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var msg = "success message";
            var metadata = new Dictionary<string, object>
            {
                {"metaKey", "metaValue"}
            };
            var rs = Result.Ok()
                           .WithSuccess(success =>
                           {
                               success.Message = msg;
                               success.WithMetadata(metadata);
                           });

            Assert.IsTrue(rs.Succeed);
            Assert.AreEqual(0, rs.Errors.Count);
            Assert.AreEqual(1, rs.Successes.Count);
            Assert.AreEqual(msg, rs.Successes[0].Message);
            Assert.AreEqual(metadata["metaKey"], rs.Successes[0].Metadata["metaKey"]);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var metadata = new Dictionary<string, object>
            {
                {"metaKey", "metaValue"}
            };
            var rs = Result.Ok()
                           .WithSuccess(success => success.WithMetadata("metaKey", metadata["metaKey"]));

            Assert.IsTrue(rs.Succeed);
            Assert.AreEqual(0, rs.Errors.Count);
            Assert.AreEqual(1, rs.Successes.Count);
            Assert.AreEqual(string.Empty, rs.Successes[0].Message);
            Assert.AreEqual(metadata["metaKey"], rs.Successes[0].Metadata["metaKey"]);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var metadata = new Dictionary<string, object>
            {
                {"metaKey", "metaValue"}
            };

            var sList = new List<Success>()
            {
                new("msg 1"),
                new("msg 2"),
            };
            var rs = Result.Ok()
                           .WithSuccess(success => success.WithMetadata("metaKey", metadata["metaKey"]))
                           .WithSuccesses(sList);

            Assert.IsTrue(rs.Succeed);
            Assert.AreEqual(0, rs.Errors.Count);
            Assert.AreEqual(3, rs.Successes.Count);
            Assert.AreEqual(string.Empty, rs.Successes[0].Message);
            Assert.AreEqual("msg 1", rs.Successes[1].Message);
            Assert.AreEqual(0, rs.Successes[1].Metadata.Count);
            Assert.AreEqual(metadata["metaKey"], rs.Successes[0].Metadata["metaKey"]);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var metadata = new Dictionary<string, object>
            {
                {"metaKey", "metaValue"}
            };

            var errorMsg = "1233333";
            var rs       = Result.Fail("1233333");

            Assert.IsFalse(rs.Succeed);
            Assert.AreEqual(1, rs.Errors.Count);
            Assert.AreEqual(0, rs.Successes.Count);
            Assert.AreEqual(errorMsg, rs.Errors[0].Message);
        }
    }
}