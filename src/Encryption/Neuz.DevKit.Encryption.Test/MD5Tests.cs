using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace Neuz.DevKit.Encryption.Test
{
    [TestClass]
    public class MD5Tests
    {
        [TestMethod]
        [DataRow("Neuz", Encrypt.MD5Format.L32, "BD5982CE07D871D3D76F4AE998FEFB64")]
        [DataRow("Neuz", Encrypt.MD5Format.L16, "07D871D3D76F4AE9")]
        [DataRow("ÖÐ¹ú", Encrypt.MD5Format.L32, "C13DCEABCB143ACD6C9298265D618A9F")]
        public void MD5_Test_1(string source, Encrypt.MD5Format format, string result)
        {
            Assert.AreEqual(result, Encrypt.MD5(source, format));
        }
    }
}