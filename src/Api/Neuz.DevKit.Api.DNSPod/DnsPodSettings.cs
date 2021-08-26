using System;
using System.Collections.Generic;

namespace Neuz.DevKit.Api.DNSPod
{
    public class DnsPodSettings
    {
        /// <summary>
        /// DNSPod API Url
        /// </summary>
        public readonly string BaseUrl = "https://dnsapi.cn";

        public readonly object HttpHeaders = new
        {
            UserAgent = "Neuz.DevKit.Api.DNSPod/1.0.0 (i@neuz.net)"
        };

        /// <summary>
        /// 用于鉴权的 API Token
        /// <para>
        /// 完整的 API Token 是由 ID,Token 组合而成的，用英文的逗号分割 <br/>
        /// API Token 生成方法详见：https://support.dnspod.cn/Kb/showarticle/tsid/227/
        /// </para>
        /// </summary>
        public string LoginToken { get; set; }

        /// <summary>
        /// 返回的错误语言，可选，默认为en，建议用cn
        /// </summary>
        public ApiLanguage Language { get; set; } = ApiLanguage.En;

        /// <summary>
        /// 没有数据时是否返回错误，可选，默认为yes，建议用no
        /// </summary>
        public ApiErrorOnEmpty ErrorOnEmpty { get; set; } = ApiErrorOnEmpty.Yes;

        /// <summary>
        /// 可选，仅代理接口需要， 用户接口不需要提交此参数
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public enum ApiLanguage
        {
            En,
            Cn
        }

        /// <summary>
        /// 没有数据时是否返回错误
        /// </summary>
        public enum ApiErrorOnEmpty
        {
            Yes,
            No
        }

        /// <summary>
        /// 获取公共参数
        /// <para>https://www.dnspod.cn/docs/info.html#common-parameters</para>
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetCommonParameters()
        {
            return new Dictionary<string, object>
            {
                {"login_token", LoginToken},
                {"format", "json"},
                {"lang", Enum.GetName(typeof(ApiLanguage), Language)?.ToLower()},
                {"error_on_empty", Enum.GetName(typeof(ApiErrorOnEmpty), ErrorOnEmpty)?.ToLower()},
                {"user_id", UserId},
            };
        }
    }
}