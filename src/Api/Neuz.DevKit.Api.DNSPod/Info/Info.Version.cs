using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Neuz.DevKit.Api.DNSPod
{
    public partial class Info
    {
        /// <summary>
        /// 获取API版本号
        /// <para>https://www.dnspod.cn/docs/info.html#info-version</para>
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResponse> Version()
        {
            var url = Settings.BaseUrl.AppendPathSegment("Info.Version");

            var postData = Settings.GetCommonParameters();

            var response = await url.WithHeaders(Settings.HttpHeaders)
                                    .PostUrlEncodedAsync(postData);

            var responseString = await response.GetStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseInfoVersion>(responseString);
            result.Original = response.ResponseMessage;
            result.Json     = JObject.Parse(responseString);
            return result;
        }


        public class ResponseInfoVersion : CommonResponse
        {
        }
    }
}