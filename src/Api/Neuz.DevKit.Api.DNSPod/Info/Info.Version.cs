using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

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
            var url = _settings.BaseUrl.AppendPathSegment("Info.Version");

            var postData = _settings.GetCommonParameters();

            var rr = await url.WithHeaders(_settings.HttpHeaders)
                              .PostUrlEncodedAsync(postData);

            var result = await rr.GetJsonAsync<VersionResponse>();
            result.Original = rr.ResponseMessage;
            return result;
        }


        public class VersionResponse : CommonResponse
        {
        }
    }
}