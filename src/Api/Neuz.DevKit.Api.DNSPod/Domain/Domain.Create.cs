#nullable enable
using System;
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
        /// 添加新域名
        /// <para>
        /// https://www.dnspod.cn/docs/domains.html#domain-create
        /// </para>
        /// </summary>
        /// <param name="param"></param>
        /// <returns>
        /// status.code
        /// <list type="bullet|number|table">
        ///     <item><term>6</term><description>域名无效</description></item>
        ///     <item><term>7</term><description>域名已存在</description></item>
        ///     <item><term>11</term><description>域名已经存在并且是其它域名的别名</description></item>
        ///     <item><term>12</term><description>域名已经存在并且您没有权限管理</description></item>
        /// </list>
        /// </returns>
        public async Task<CommonResponse> Create(ParamDomainCreate param)
        {
            var url = Settings.BaseUrl.AppendPathSegment("Domain.Create");

            var postData = Settings.GetCommonParameters();

            postData["domain"] = param.Domain ??
                                 throw new ArgumentNullException(nameof(ParamDomainCreate.Domain), "不允许为空");

            if (param.GroupId != null) postData["group_id"] = param.GroupId;
            if (param.IsMark != null) postData["is_mark"]   = param.IsMark;

            var response = await url.WithHeaders(Settings.HttpHeaders)
                                    .PostUrlEncodedAsync(postData);


            var responseString = await response.GetStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDomainCreate>(responseString);
            result.Original = response.ResponseMessage;
            result.Json     = JObject.Parse(responseString);
            return result;
        }

        public class ParamDomainCreate
        {
            /// <summary>
            /// 域名, 没有 www, 如 dnspod.com
            /// </summary>
            public string Domain { get; set; }

            /// <summary>
            /// 域名分组ID, 可选参数
            /// </summary>
            public string? GroupId { get; set; } = null;

            /// <summary>
            /// 是否星标域名
            /// <list type="bullet|number|table">
            ///     <item><term>"yes"</term><description>是</description></item>
            ///     <item><term>"no"</term><description>否</description></item>
            /// </list>
            /// </summary>
            public string? IsMark { get; set; }
        }

        public class ResponseDomainCreate : CommonResponse
        {
            [JsonProperty("domain")]
            public PartDomain Domain { get; set; }

            public class PartDomain
            {
                /// <summary>
                /// 域名 ID, 即为 domain_id
                /// </summary>
                [JsonProperty("id")]
                public string Id { get; set; }

                /// <summary>
                /// 使用 punycode 转码之后的域名
                /// </summary>
                [JsonProperty("punycode")]
                public string PunyCode { get; set; }

                /// <summary>
                /// 添加的域名
                /// </summary>
                [JsonProperty("domain")]
                public string Domain { get; set; }
            }
        }
    }
}