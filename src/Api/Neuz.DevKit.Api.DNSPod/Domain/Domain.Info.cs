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
        /// 获取域名信息
        /// <para>
        /// 参数中域名ID和域名, 提交其中一个即可
        /// </para>
        /// <para>
        /// https://www.dnspod.cn/docs/domains.html#domain-info
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
        ///     <item><term>8</term><description>域名无效、VIP域名不可以删除</description></item>
        ///     <item><term>13</term><description>当前域名有误，请返回重新操作</description></item>
        ///     <item><term>21</term><description>域名已锁定</description></item>
        /// </list>
        /// </returns>
        public async Task<CommonResponse> Info(string domain = null, string domainId = null)
        {
            var url = Settings.BaseUrl.AppendPathSegment("Domain.Info");

            var postData = Settings.GetCommonParameters();

            postData["domain"]    = domain;
            postData["domain_id"] = domainId;

            var response = await url.WithHeaders(Settings.HttpHeaders)
                                    .PostUrlEncodedAsync(postData);

            var responseString = await response.GetStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDomainInfo>(responseString);
            result.Original = response.ResponseMessage;
            result.Json     = JObject.Parse(responseString);
            return result;
        }

        public class ResponseDomainInfo : CommonResponse
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
                /// 域名
                /// </summary>
                [JsonProperty("name")]
                public string Name { get; set; }

                /// <summary>
                /// 使用 punycode 转码之后的域名
                /// </summary>
                [JsonProperty("punycode")]
                public string PunyCode { get; set; }

                /// <summary>
                /// 域名等级
                /// <list type="bullet|number|table">
                ///     <item><term>"D_Free"</term><description>旧免费套餐 (旧套餐)</description></item>
                ///     <item><term>"D_Plus"</term><description>个人豪华套餐 (旧套餐)</description></item>
                ///     <item><term>"D_Extra"</term><description>企业Ⅰ (旧套餐)</description></item>
                ///     <item><term>"D_Expert"</term><description>企业Ⅱ (旧套餐)</description></item>
                ///     <item><term>"D_Ultra"</term><description>企业Ⅲ (旧套餐)</description></item>
                ///     <item><term>"DP_Free"</term><description>免费套餐</description></item>
                ///     <item><term>"DP_Plus"</term><description>个人专业版</description></item>
                ///     <item><term>"DP_Extra"</term><description>企业创业版</description></item>
                ///     <item><term>"DP_Expert"</term><description>企业标准版</description></item>
                ///     <item><term>"DP_Ultra"</term><description>企业旗舰版</description></item>
                /// </list>
                /// </summary>
                public string Grade { get; set; }

                /// <summary>
                /// 域名等级(中文说明)
                /// </summary>
                [JsonProperty("grade_title")]
                public string GradeTitle { get; set; }

                /// <summary>
                /// 域名状态
                /// <list type="bullet|number|table">
                ///     <item><term>"enable"</term><description>正常</description></item>
                ///     <item><term>"pause"</term><description>已暂停解析</description></item>
                ///     <item><term>"spam"</term><description>已被封禁</description></item>
                ///     <item><term>"lock"</term><description>已被锁定</description></item>
                /// </list>
                /// </summary>
                [JsonProperty("status")]
                public string Status { get; set; }

                /// <summary>
                /// 域名扩展的状态
                /// <list type="bullet|number|table">
                ///     <item><term>"notexist"</term><description>域名没有注册</description></item>
                ///     <item><term>"dnserror"</term><description>DNS 设置错误</description></item>
                ///     <item><term>""</term><description>正常</description></item>
                /// </list>
                /// </summary>
                [JsonProperty("ext_status")]
                public string ExtStatus { get; set; }

                /// <summary>
                /// 域名下记录总条数
                /// </summary>
                [JsonProperty("records")]
                public string Records { get; set; }

                /// <summary>
                /// 域名分组 ID
                /// </summary>
                [JsonProperty("group_id")]
                public string GroupId { get; set; }


                /// <summary>
                /// 是否开启搜索引擎推送功能
                /// <list type="bullet|number|table">
                ///     <item><term>"yes"</term><description>已开启</description></item>
                ///     <item><term>"no"</term><description>未开启</description></item>
                /// </list>
                /// </summary>
                [JsonProperty("searchengine_push")]
                public string SearchEnginePush { get; set; }


                /// <summary>
                /// 是否设置域名星标
                /// <list type="bullet|number|table">
                ///     <item><term>yes</term><description>已设置</description></item>
                ///     <item><term>no</term><description>未设置</description></item>
                /// </list>
                /// </summary>
                [JsonProperty("is_mark")]
                public string IsMark { get; set; }

                /// <summary>
                /// 域名备注
                /// </summary>
                [JsonProperty("remark")]
                public string Remark { get; set; }


                /// <summary>
                /// 是否VIP
                /// <list type="bullet|number|table">
                ///     <item><term>"yes"</term><description>是 VIP</description></item>
                ///     <item><term>"mo"</term><description>不是 VIP</description></item>
                /// </list>
                /// </summary>
                [JsonProperty("is_vip")]
                public string IsVip { get; set; }

                /// <summary>
                /// 添加域名的时间
                /// </summary>
                [JsonProperty("created_on")]
                public string CreatedOn { get; set; }

                /// <summary>
                /// 域名最后修改时间
                /// </summary>
                [JsonProperty("updated_on")]
                public string UpdatedOn { get; set; }

                /// <summary>
                /// 域名默认的 TTL 值
                /// </summary>
                [JsonProperty("ttl")]
                public string TTL { get; set; }


                /// <summary>
                /// CNAME 加速状态
                /// <list type="bullet|number|table">
                ///     <item><term>"enable"</term><description>已启用</description></item>
                ///     <item><term>"disable"</term><description>已禁用</description></item>
                /// </list>
                /// </summary>
                [JsonProperty("cname_speedup")]
                public string CNameSpeedUp { get; set; }


                /// <summary>
                /// 域名所有者
                /// </summary>
                [JsonProperty("owner")]
                public string Owner { get; set; }

                /// <summary>
                /// 解析套餐的开始时间，格式为 yyyy-mm-dd（该字段仅当 is_vip 为“yes”时才存在）
                /// </summary>
                [JsonProperty("vip_start_at")]
                public string VipStartAt { get; set; }

                /// <summary>
                /// 解析套餐的到期时间，格式为 yyyy-mm-dd（该字段仅当 is_vip 为“yes”时才存在）
                /// </summary>
                [JsonProperty("vip_end_at")]
                public string VipEndAt { get; set; }

                /// <summary>
                /// 解析套餐是否会自动续费，“yes”或“no”（该字段仅当 is_vip 为“yes”时才存在）
                /// <list type="bullet|number|table">
                ///     <item><term>"yes"</term><description>是</description></item>
                ///     <item><term>"no"</term><description>否</description></item>
                /// </list>
                /// </summary>
                [JsonProperty("vip_auto_renew")]
                public string VipAutoRenew { get; set; }

                /// <summary>
                /// 域名等级对应的ns服务器地址
                /// </summary>
                [JsonProperty("dnspod_ns")]
                public IList<string> DnsPodNs { get; set; }

                /// <summary>
                /// 域名是否有备案，“yes”或“no”
                /// <list type="bullet|number|table">
                ///     <item><term>"yes"</term><description>是</description></item>
                ///     <item><term>"no"</term><description>否</description></item>
                /// </list>
                /// </summary>
                [JsonProperty("is_beian")]
                public string IsBeian { get; set; }
            }
        }
    }
}