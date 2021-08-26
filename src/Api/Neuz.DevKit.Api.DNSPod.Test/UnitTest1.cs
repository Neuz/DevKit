using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Neuz.DevKit.Api.DNSPod.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var api = new DnsPodApi(new DnsPodSettings
            {
                LoginToken   = "251492,805e3859330772e95839c1092d85a5dc",
            });
            var r = api.Info.Version().Result;

            var r2 = api.User.Detail().Result;
        }
    }
}
