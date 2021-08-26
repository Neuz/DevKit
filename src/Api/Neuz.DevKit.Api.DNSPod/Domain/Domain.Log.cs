using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Neuz.DevKit.Api.DNSPod
{
    /// <summary>
    /// Api相关
    /// </summary>
    public partial class Domain
    {
        /// <summary>
        /// 获取域名日志
        /// <para>
        /// 参数中域名ID和域名, 提交其中一个即可
        /// </para>
        /// <para>
        /// https://www.dnspod.cn/docs/domains.html#domain-info
        /// </para>
        /// </summary>
        /// <param name="domain">域名</param>
        /// <param name="domainId">域名ID</param>
        /// <param name="offset">记录开始的偏移，第一条记录为 0，依次类推，默认为0</param>
        /// <param name="length">共要获取的日志条数，比如获取20条，则为20，默认为500条，单次最多获取500条</param>
        /// <returns>
        /// status.code
        /// <list type="bullet|number|table">
        ///     <item><term>-15</term><description>域名已被封禁</description></item>
        ///     <item><term>6</term><description>域名ID错误</description></item>
        ///     <item><term>7</term><description>非域名所有者</description></item>
        ///     <item><term>8</term><description>域名无效、VIP域名不可以删除</description></item>
        /// </list>
        /// </returns>
        public async Task<CommonResponse> Log(string domain = null, string domainId = null, int offset = 0, int? length = 500)
        {
            var url = Settings.BaseUrl.AppendPathSegment("Domain.Log");

            var postData = Settings.GetCommonParameters();

            postData["domain"]    = domain;
            postData["domain_id"] = domainId;
            postData["offset"]    = offset;
            postData["length"]    = length;

            var response = await url.WithHeaders(Settings.HttpHeaders)
                                    .PostUrlEncodedAsync(postData);

            var responseString = await response.GetStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDomainLog>(responseString);
            result.Original = response.ResponseMessage;
            result.Json     = JObject.Parse(responseString);
            return result;
        }

        public class ResponseDomainLog : CommonResponse
        {
            [JsonProperty("log")]
            public IList<string> Log { get; set; }
        }
    }
}