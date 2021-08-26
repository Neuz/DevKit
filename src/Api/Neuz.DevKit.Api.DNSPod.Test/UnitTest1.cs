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
                LoginToken   = "254344,9b8314a8f77181517ccccbeb09550ef0",
            });
            var r = api.Info.Version().Result;

            var r2 = api.User.Detail().Result;
        }
    }
}
