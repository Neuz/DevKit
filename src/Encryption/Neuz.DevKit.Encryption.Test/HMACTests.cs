using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Neuz.DevKit.Encryption.Test
{
    [TestClass]
    public class HMACTests
    {
        [TestMethod]
        [DataRow("Neuz", "123", Encrypt.HMACFormat.Hex, "BBBA92BD89DF8CA7720554FC8D95D822")]
        [DataRow("中国", "123", Encrypt.HMACFormat.Hex, "37C7FEDFAAEC42115440383F76788D87")]
        [DataRow("中国", null, Encrypt.HMACFormat.Hex, "67BC859CC909B38BB9510D004E0541A5")]
        public void HMACMD5_Test_1(string source, string key, Encrypt.HMACFormat format, string result)
        {
            Assert.AreEqual(result, Encrypt.HMACMD5(source, key, format));
        }


        [TestMethod]
        [DataRow("Neuz", "123", Encrypt.HMACFormat.Hex, "D5821EE9F061CF97EDCC4697BCD52D8E3434BD4B")]
        [DataRow("中国", "123", Encrypt.HMACFormat.Hex, "D619CE90D5C1BD4CA5DB28D1FED2B6C51168A23D")]
        [DataRow("中国", null, Encrypt.HMACFormat.Hex, "AB2E01F074F61F555C846F89FB3DB0873C1F3361")]
        public void HMACSHA1_Test_1(string source, string key, Encrypt.HMACFormat format, string result)
        {
            Assert.AreEqual(result, Encrypt.HMACSHA1(source, key, format));
        }

        [TestMethod]
        [DataRow("Neuz", "123", Encrypt.HMACFormat.Hex, "4B47C5B9AA603CDAA31A90BEFB920D4719A83A1C5527A971E7BA141D8F5835CA")]
        [DataRow("中国", "123", Encrypt.HMACFormat.Hex, "CA013D907B3D8D3E317EE683D14BDA18512106276D25C0942255225824318622")]
        [DataRow("中国", null, Encrypt.HMACFormat.Hex, "C77CA147029925B73A17B35AF5A5EC9B2C3813B3960C9A6CA18806791F37D238")]
        public void HMACSHA256_Test_1(string source, string key, Encrypt.HMACFormat format, string result)
        {
            Assert.AreEqual(result, Encrypt.HMACSHA256(source, key, format));
        }

        [TestMethod]
        [DataRow("Neuz", "123", Encrypt.HMACFormat.Hex, "177B9C7D84D6AA6800672C715EB28877CAC25B131F7CA594C93B3AD082D561CB5A25F33B39F10260BF4F247E968CC982")]
        [DataRow("中国", "123", Encrypt.HMACFormat.Hex, "5AD9877CE085C45EDE50A0FC9136A09A643420D5FF9B78C37504D0379881A68B5F7BF8F7E65D9FAC5DFA47BA518FC20A")]
        [DataRow("中国", null, Encrypt.HMACFormat.Hex, "4D1B3F85416808D33B990DA38E14FCA154F03731DB31DD77013B7E371C31F3C2A6ACF5652CA7837FCEF758766089B0CA")]
        public void HMACSHA384_Test_1(string source, string key, Encrypt.HMACFormat format, string result)
        {
            Assert.AreEqual(result, Encrypt.HMACSHA384(source, key, format));
        }

        [TestMethod]
        [DataRow("Neuz", "123", Encrypt.HMACFormat.Hex, "71934B7FEA193C86BA6F4132D1F328601F01A1822DDE8B37D27AAF887B00E991D6CE1AA78C43C7C040D1D8EA3893A6AD38602FEF8BD6E5D0655BDFFC739A0665")]
        [DataRow("中国", "123", Encrypt.HMACFormat.Hex, "C9F9D943AF6B6E189CDBAE8FF9F40455B205CF45512C56B19BA7B134CF5273B22FEBF8F719AEDF4B4FA2120D931F87AD1580F74299B2601A54E0D151AF55045A")]
        [DataRow("中国", null, Encrypt.HMACFormat.Hex, "F9188C06D95978BDF35EBAF162ABBF76E2CD880C403DFAA1414579FC2A98A75C3586C9BA398AE3147836102C22891944225765ED5DD7B343B9A0CDE862E573FC")]
        public void HMACSHA512_Test_1(string source, string key, Encrypt.HMACFormat format, string result)
        {
            Assert.AreEqual(result, Encrypt.HMACSHA512(source, key, format));
        }
    }
}