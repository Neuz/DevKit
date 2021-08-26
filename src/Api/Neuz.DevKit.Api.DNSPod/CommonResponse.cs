using System.Net.Http;
using Newtonsoft.Json;

namespace Neuz.DevKit.Api.DNSPod
{
    /// <summary>
    /// 通用返回 <br/>
    /// 详细文档: https://www.dnspod.cn/docs/info.html#common-response
    /// </summary>
    public class CommonResponse
    {
        /// <summary>
        /// 原始 HttpResponseMessage
        /// </summary>
        [JsonIgnore]
        public HttpResponseMessage Original;

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("status")]
        public PartStatus Status { get; set; }

        public class PartStatus
        {
            /// <summary>
            /// Code
            /// </summary>
            [JsonProperty("code")]
            public string Code { get; set; }

            /// <summary>
            /// 消息
            /// </summary>
            [JsonProperty("message")]
            public string Message { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }
        }
    }
}