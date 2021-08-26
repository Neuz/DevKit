using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest.Extensions.Contracts;

namespace Neuz.DevKit.Api.DNSPod.Test
{
    [TestClass]
    public class DnsPodApiTest
    {
        DnsPodApi _api = new DnsPodApi(new DnsPodSettings
        {
            LoginToken = "254344,9b8314a8f77181517ccccbeb09550ef0",
            Language   = DnsPodSettings.ApiLanguage.Cn
        });

        [ContractTestCase]
        public void Info()
        {
            "Info.Version".Test(() =>
            {
                var result = _api.Info.Version().Result;

                Assert.IsNotNull(result.Json);
                Assert.IsNotNull(result.Original);
                Assert.AreEqual(HttpStatusCode.OK, result.Original.StatusCode);

                Assert.AreEqual("1", result.Status.Code);
            });
        }

        [ContractTestCase]
        public void User()
        {
            "User.Detail".Test(() =>
            {
                var result = _api.User.Detail().Result;

                Assert.IsNotNull(result.Json);
                Assert.IsNotNull(result.Original);
                Assert.AreEqual(HttpStatusCode.OK, result.Original.StatusCode);

                Assert.AreEqual("1", result.Status.Code);
                Assert.IsNotNull(((User.ResponseUserDetail) result).Info);
            });

            "User.Log".Test(() =>
            {
                var result = _api.User.Log().Result;

                Assert.IsNotNull(result.Json);
                Assert.IsNotNull(result.Original);
                Assert.AreEqual(HttpStatusCode.OK, result.Original.StatusCode);

                Assert.AreEqual("1", result.Status.Code);
                Assert.IsNotNull(((User.ResponseUserLog) result).Log);
            });
        }


        [ContractTestCase]
        public void Domain_List()
        {
            "Domain.List".Test(() =>
            {
                var param = new Domain.ParamDomainList
                {
                    Keyword = "neuz"
                };
                var result = _api.Domain.List(param).Result;

                Assert.IsNotNull(result.Json);
                Assert.IsNotNull(result.Original);
                Assert.AreEqual(HttpStatusCode.OK, result.Original.StatusCode);

                Assert.AreEqual("1", result.Status.Code);
                Assert.IsNotNull(((Domain.ResponseDomainList) result).Info);
                Assert.IsNotNull(((Domain.ResponseDomainList) result).Domains);
            });
        }

        [ContractTestCase]
        public void Domain_Create()
        {
            "Domain.Create".Test(() =>
            {
                var param = new Domain.ParamDomainCreate
                {
                    Domain = "aaa.com"
                };
                var result = _api.Domain.Create(param).Result;

                Assert.IsNotNull(result.Json);
                Assert.IsNotNull(result.Original);
                Assert.AreEqual(HttpStatusCode.OK, result.Original.StatusCode);

                Assert.AreEqual("12", result.Status.Code);
            });
        }

        [ContractTestCase]
        public void Domain_Remove()
        {
            "Domain.Remove.1".Test(() =>
            {
                var result = _api.Domain.Remove(null, "abc.com").Result;

                Assert.IsNotNull(result.Json);
                Assert.IsNotNull(result.Original);
                Assert.AreEqual(HttpStatusCode.OK, result.Original.StatusCode);

                Assert.AreEqual("6", result.Status.Code);
            });

            "Domain.Remove.2".Test(() =>
            {
                var result = _api.Domain.Remove().Result;

                Assert.IsNotNull(result.Json);
                Assert.IsNotNull(result.Original);
                Assert.AreEqual(HttpStatusCode.OK, result.Original.StatusCode);

                Assert.AreEqual("6", result.Status.Code);
            });

            "Domain.Remove.3".Test(() =>
            {
                var result = _api.Domain.Remove("abc.com").Result;

                Assert.IsNotNull(result.Json);
                Assert.IsNotNull(result.Original);
                Assert.AreEqual(HttpStatusCode.OK, result.Original.StatusCode);

                Assert.AreEqual("7", result.Status.Code);
            });

            "Domain.Remove.4".Test(() =>
            {
                var result = _api.Domain.Remove("abc.com,de2").Result;

                Assert.IsNotNull(result.Json);
                Assert.IsNotNull(result.Original);
                Assert.AreEqual(HttpStatusCode.OK, result.Original.StatusCode);

                Assert.AreEqual("8", result.Status.Code);
            });
        }
    }
}