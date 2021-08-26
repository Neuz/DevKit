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
        /// 添加域名共享
        /// <para>
        /// https://www.dnspod.cn/docs/domains.html#domainshare-create
        /// </para>
        /// </summary>
        /// <param name="domain">域名</param>
        /// <param name="domainId">域名ID</param>
        /// <param name="email">要共享到的邮箱</param>
        /// <param name="mode">共享模式, 默认为 r
        /// <list type="bullet|number|table">
        ///     <item><term>"r"</term><description>只读</description></item>
        ///     <item><term>"rw"</term><description>读取、修改</description></item>
        /// </list>
        /// </param>
        /// <param name="subDomain">子域名共享, 如：www、bbs等. 如果要共享整个域名, 则无需提交此参数</param>
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
        public async Task<CommonResponse> Create(string domain = null, string domainId = null, string email = null, string mode = "r", string subDomain = null)
        {
            var url = Settings.BaseUrl.AppendPathSegment("Domainshare.Create");

            var postData = Settings.GetCommonParameters();

            postData["domain"]     = domain;
            postData["domain_id"]  = domainId;
            postData["email"]      = email;
            postData["mode"]       = mode;
            postData["sub_domain"] = subDomain;

            var response = await url.WithHeaders(Settings.HttpHeaders)
                                    .PostUrlEncodedAsync(postData);

            var responseString = await response.GetStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDomainShareCreate>(responseString);
            result.Original = response.ResponseMessage;
            result.Json     = JObject.Parse(responseString);
            return result;
        }

        public class ResponseDomainShareCreate : CommonResponse
        {
        }
    }
}