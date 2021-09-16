using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming

namespace Neuz.DevKit.Encryption.Test
{
    [TestClass]
    public class SHATests
    {
        [TestMethod]
        [DataRow("Neuz", Encrypt.SHAFormat.Hex, "65B36DCEAB019984A21CAFCCC204ABAB4517FF73")]
        [DataRow("Neuz", Encrypt.SHAFormat.Base64, "ZbNtzqsBmYSiHK/MwgSrq0UX/3M=")]
        [DataRow("中国", Encrypt.SHAFormat.Hex, "101806F57C322FB403A9788C4C24B79650D02E77")]
        public void SHA1_Test_1(string source, Encrypt.SHAFormat format, string result)
        {
            Assert.AreEqual(result, Encrypt.SHA1(source, format));
        }

        [TestMethod]
        [DataRow("Neuz", Encrypt.SHAFormat.Hex, "04BB2F8E1EBA55269EDB5726E0F4B6061BA835149B74B83C448A0553B680D02D")]
        [DataRow("中国", Encrypt.SHAFormat.Hex, "F0E9521611BB290D7B09B8CD14A63C3FE7CBF9A2F4E0090D8238D22403D35182")]
        public void SHA256_Test_1(string source, Encrypt.SHAFormat format, string result)
        {
            Assert.AreEqual(result, Encrypt.SHA256(source, format));
        }

        [TestMethod]
        [DataRow("Neuz", Encrypt.SHAFormat.Hex, "EB3DC6CA794A0A591C617580ACD9D6842D452BAD1AE5947B6B730DF7E9B6F0280CE3650AD6C96F38F979B324945F99D7")]
        [DataRow("中国", Encrypt.SHAFormat.Hex, "EBE1C5966F14A75396A6B2B31395FC3BCC01D3D3C43B7D135E72C8E3D9BBE6461D8AEAC37C208E1312E2F278074D7E29")]
        public void SHA384_Test_1(string source, Encrypt.SHAFormat format, string result)
        {
            Assert.AreEqual(result, Encrypt.SHA384(source, format));
        }

        [TestMethod]
        [DataRow("Neuz", Encrypt.SHAFormat.Hex, "84B6E1E0CE09B88268CD6B7966DE7842F110C3A1C7819432078B9C1F63C65944A98EB50EBBEC69782E1FBAB783FA5BFFB9CD22061EFA00376407584A7CF34251")]
        [DataRow("中国", Encrypt.SHAFormat.Hex, "6A169E7D5B7526651086D0D37D6E7686C7E75FF7039D063AD100AEFAB1057A4C1DB1F1E5D088C9585DB1D7531A461AB3F4490CC63809C08CC074574B3FFF759A")]
        public void SHA512_Test_1(string source, Encrypt.SHAFormat format, string result)
        {
            Assert.AreEqual(result, Encrypt.SHA512(source, format));
        }
    }
}