using System.Collections;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

namespace Neuz.DevKit.Extensions.Test
{
    [TestClass]
    public class StringExtTests
    {
        [ContractTestCase]
        public void String_Is_Test_1()
        {
            "String.IsUpper() - 1".Test(() =>
            {
                Assert.IsTrue("ABC".IsUpper());
                Assert.IsFalse("AbC".IsUpper());
            });

            "String.IsLower() - 1".Test(() =>
            {
                Assert.IsFalse("ABC".IsLower());
                Assert.IsTrue("abc".IsLower());
            });

            "String.IsNullOrEmpty() - 1".Test(() =>
            {
                Assert.IsFalse(" ".IsNullOrEmpty());
                Assert.IsTrue("".IsNullOrEmpty());
            });

            "String.IsNullOrWhiteSpace() - 1".Test(() =>
            {
                Assert.IsTrue(" ".IsNullOrWhiteSpace());
                Assert.IsTrue("".IsNullOrWhiteSpace());
                Assert.IsTrue("\r".IsNullOrWhiteSpace());
            });
        }

        [ContractTestCase]
        public void String_To_Test_1()
        {
            "String.ToBytes()".Test(() =>
            {
                var cc      = "abcd".ToBytes();
                var aa      = new byte[] {97, 98, 99, 100};
                var isEqual = StructuralComparisons.StructuralEqualityComparer.Equals(cc, aa);
                Assert.IsTrue(isEqual);
            });
        }

        [ContractTestCase]
        public void String_Encrypt_Test_1()
        {
            "String.EncodeBase64()".Test(() =>
            {
                Assert.AreEqual("QUJDRA==", "ABCD".EncodeBase64());
                Assert.AreEqual("YWJjZA==", "abcd".EncodeBase64());
            });

            "String.DecodeBase64()".Test(() =>
            {
                Assert.AreEqual("ABCD", "QUJDRA==".DecodeBase64());
                Assert.AreEqual("abcd", "YWJjZA==".DecodeBase64());
            });
        }

        [ContractTestCase]
        public void String_Regex_Test_1()
        {
            "String.RegexIsMatch()".Test(() =>
            {
                var pattern = @"^abc.*\r$";
                Assert.IsTrue("abcdefg\r\nabcdefghijk".RegexIsMatch(pattern, RegexOptions.Multiline));
            });


            "String.RegexMatch()".Test(() =>
            {
                var str     = "aaaabaaaabaaaa";
                var pattern = @"aaaab";
                var match = str.RegexMatch(pattern, RegexOptions.Multiline);
                Assert.IsTrue(match.Success);
            });

            "String.RegexMatches()".Test(() =>
            {
                var str     = "aaaabaaaabaaaa";
                var pattern = @"aaaab";
                var matches   = str.RegexMatches(pattern, RegexOptions.None);
                Assert.AreEqual(2, matches.Count);
            });
        }
    }
}