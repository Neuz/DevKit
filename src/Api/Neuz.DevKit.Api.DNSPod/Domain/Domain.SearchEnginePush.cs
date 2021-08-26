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
        /// 设置搜索引擎推送
        /// <para>
        /// 参数中域名ID和域名, 提交其中一个即可
        /// </para>
        /// <para>
        /// https://www.dnspod.cn/docs/domains.html#domain-searchenginepush
        /// </para>
        /// </summary>
        /// <param name="status">
        /// 是否推送
        /// <list type="bullet|number|table">
        ///     <item><term>"yes"</term><description>启用</description></item>
        ///     <item><term>"no"</term><description>关闭</description></item>
        /// </list>
        /// </param>
        /// <param name="domain">域名</param>
        /// <param name="domainId">域名ID</param>
        /// <returns>
        /// status.code
        /// <list type="bullet|number|table">
        ///     <item><term>-15</term><description>域名已被封禁</description></item>
        ///     <item><term>6</term><description>域名ID错误</description></item>
        ///     <item><term>7</term><description>非域名所有者</description></item>
        ///     <item><term>8</term><description>域名无效</description></item>
        ///     <item><term>13</term><description>当前域名有误，请返回重新操作</description></item>
        ///     <item><term>21</term><description>域名被锁定</description></item>
        /// </list>
        /// </returns>
        public async Task<CommonResponse> SearchEnginePush(string status, string domain = null, string domainId = null)
        {
            var url = Settings.BaseUrl.AppendPathSegment("Domain.Searchenginepush");

            var postData = Settings.GetCommonParameters();

            postData["status"]    = status;
            postData["domain"]    = domain;
            postData["domain_id"] = domainId;

            var response = await url.WithHeaders(Settings.HttpHeaders)
                                    .PostUrlEncodedAsync(postData);

            var responseString = await response.GetStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDomainSearchEnginePush>(responseString);
            result.Original = response.ResponseMessage;
            result.Json     = JObject.Parse(responseString);
            return result;
        }

        public class ResponseDomainSearchEnginePush : CommonResponse
        {
        }
    }
}