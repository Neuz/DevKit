using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace Neuz.DevKit.Api.DNSPod
{
    public partial class User
    {
        /// <summary>
        /// 获取用户日志
        /// <para>
        /// https://www.dnspod.cn/docs/accounts.html#user-log
        /// </para>
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResponse> Log()
        {
            var url = _settings.BaseUrl.AppendPathSegment("User.Log");

            var postData = _settings.GetCommonParameters();

            var rr = await url.WithHeaders(_settings.HttpHeaders)
                              .PostUrlEncodedAsync(postData);

            var result = await rr.GetJsonAsync<ResponseUserLog>();
            result.Original = rr.ResponseMessage;
            return result;
        }
        
        public class ResponseUserLog : CommonResponse
        {
            [JsonProperty("log")]
            public IList<string> Log { get; set; }
        }
    }
}