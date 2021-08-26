using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Neuz.DevKit.Api.DNSPod.DomainShare
{
    /// <summary>
    /// 域名共享相关
    /// </summary>
    public partial class DomainShare
    {
        /// <summary>
        /// 域名共享列表
        /// <para>
        /// https://www.dnspod.cn/docs/domains.html#domainshare-list
        /// </para>
        /// </summary>
        /// <param name="domain">域名</param>
        /// <param name="domainId">域名ID</param>
        /// <returns>
        /// status.code
        /// <list type="bullet|number|table">
        ///     <item><term>-15</term><description>域名已被封禁</description></item>
        ///     <item><term>6</term><description>域名ID错误</description></item>
        ///     <item><term>7</term><description>非域名所有者</description></item>
        ///     <item><term>8</term><description>域名无效</description></item>
        ///     <item><term>10</term><description>已达到该域名的最大共享限制</description></item>
        ///     <item><term>13</term><description>当前域名有误，请返回重新操作</description></item>
        ///     <item><term>21</term><description>域名被锁定</description></item>
        ///     <item><term>23</term><description>子域名级数超出限制</description></item>
        ///     <item><term>24</term><description>泛解析级数超出限制</description></item>
        ///     <item><term>75</term><description>子域名共享数量超出了限制</description></item>
        /// </list>
        /// </returns>
        public async Task<CommonResponse> List(string domain = null, string domainId = null)
        {
            var url = Settings.BaseUrl.AppendPathSegment("Domainshare.List");

            var postData = Settings.GetCommonParameters();

            postData["domain"]    = domain;
            postData["domain_id"] = domainId;

            var response = await url.WithHeaders(Settings.HttpHeaders)
                                    .PostUrlEncodedAsync(postData);

            var responseString = await response.GetStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDomainShareList>(responseString);
            result.Original = response.ResponseMessage;
            result.Json     = JObject.Parse(responseString);
            return result;
        }

        public class ResponseDomainShareList : CommonResponse
        {
            /// <summary>
            /// 域名的共享信息
            /// </summary>
            [JsonProperty("share")]
            public PartShare Share { get; set; }

            /// <summary>
            /// 域名所有者的账号
            /// </summary>
            [JsonProperty("owner")]
            public string Owner { get; set; }

            public class PartShare
            {
                /// <summary>
                /// 共享给其他 DNSPod 的账号
                /// </summary>
                [JsonProperty("share_to")]
                public string ShareTo { get; set; }

                /// <summary>
                /// 域名共享模式
                /// <list type="bullet|number|table">
                ///     <item><term>"r"</term><description>只读</description></item>
                ///     <item><term>"rw"</term><description>可读写</description></item>
                /// </list>
                /// </summary>
                [JsonProperty("mode")]
                public string Mode { get; set; }

                /// <summary>
                /// 域名的共享状态
                /// <list type="bullet|number|table">
                ///     <item><term>"enable"</term><description>共享成功</description></item>
                ///     <item><term>"pending"</term><description>共享到的账号不存在, 等待注册</description></item>
                /// </list>
                /// </summary>
                [JsonProperty("status")]
                public string Status { get; set; }
            }
        }
    }
}