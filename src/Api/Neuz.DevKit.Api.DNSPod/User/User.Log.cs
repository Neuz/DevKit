using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            var url = Settings.BaseUrl.AppendPathSegment("User.Log");

            var postData = Settings.GetCommonParameters();

            var response = await url.WithHeaders(Settings.HttpHeaders)
                                    .PostUrlEncodedAsync(postData);

            var responseString = await response.GetStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseUserLog>(responseString);
            result.Original = response.ResponseMessage;
            result.Json     = JObject.Parse(responseString);
            return result;
        }

        public class ResponseUserLog : CommonResponse
        {
            [JsonProperty("log")]
            public IList<string> Log { get; set; }
        }
    }
}