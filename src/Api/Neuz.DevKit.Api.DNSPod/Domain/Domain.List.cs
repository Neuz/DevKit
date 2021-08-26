#nullable enable
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
        /// 获取域名列表
        /// <para>
        /// https://www.dnspod.cn/docs/domains.html#domain-list
        /// </para>
        /// <para>
        /// 如果账户中的域名数量超过了3000, 将会强制分页并且只返回前3000条, 这时需要通过 offset 和 length 参数去获取其它域名.
        /// </para>
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResponse> List(ParamDomainList param)
        {
            var url = Settings.BaseUrl.AppendPathSegment("Domain.List");

            var postData = Settings.GetCommonParameters();

            if (param.Type != null) postData["type"]        = param.Type;
            if (param.GroupId != null) postData["group_id"] = param.GroupId;
            if (param.Keyword != null) postData["keyword"]  = param.Keyword;
            if (param.Offset.HasValue) postData["offset"]   = param.Offset;
            if (param.Length.HasValue) postData["length"]   = param.Length;

            var response = await url.WithHeaders(Settings.HttpHeaders)
                                    .PostUrlEncodedAsync(postData);

            var responseString = await response.GetStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDomainList>(responseString);
            result.Original = response.ResponseMessage;
            result.Json     = JObject.Parse(responseString);
            return result;
        }

        /// <summary>
        /// Domain.List 接口参数
        /// </summary>
        public class ParamDomainList
        {
            /// <summary>
            /// 域名分组类型, 默认为 all.
            /// <list type="bullet|number|table">
            ///     <item><term>"all"</term><description>所有域名</description></item>
            ///     <item><term>"mine"</term><description>我的域名</description></item>
            ///     <item><term>"share"</term><description>共享给我的域名</description></item>
            ///     <item><term>"ismark"</term><description>星标域名</description></item>
            ///     <item><term>"pause"</term><description>暂停域名</description></item>
            ///     <item><term>"vip"</term><description>VIP域名</description></item>
            ///     <item><term>"recent"</term><description>最近操作过的域名</description></item>
            ///     <item><term>"share_out"</term><description>我共享出去的域名</description></item>
            /// </list>
            /// </summary>
            public string? Type { get; set; } = "all";

            /// <summary>
            /// 记录开始的偏移, 第一条记录为 0, 依次类推
            /// </summary>
            public int? Offset { get; set; } = null;

            /// <summary>
            /// 要获取的域名数量, 比如获取20个, 则为20
            /// </summary>
            public int? Length { get; set; } = null;

            /// <summary>
            /// 分组ID, 获取指定分组的域名。可以通过 获取域名分组 获取 group_id
            /// </summary>
            public string? GroupId { get; set; } = null;

            /// <summary>
            /// 搜索的关键字, 如果指定则只返回符合该关键字的域名
            /// </summary>
            public string? Keyword { get; set; } = null;
        }

        public class ResponseDomainList : CommonResponse
        {
            [JsonProperty("info")]
            public PartInfo Info { get; set; }

            [JsonProperty("domains")]
            public IList<PartDomain> Domains { get; set; }

            public class PartInfo
            {
                /// <summary>
                /// 域名总数
                /// </summary>
                [JsonProperty("domain_total")]
                public int DomainTotal { get; set; }

                /// <summary>
                /// 域名总数
                /// </summary>
                [JsonProperty("all_total")]
                public int AllTotal { get; set; }

                /// <summary>
                /// 自己创建的域名总数(不包括共享得到的域名)
                /// </summary>
                [JsonProperty("mine_total")]
                public int MineTotal { get; set; }

                /// <summary>
                /// 共享得到的域名总数
                /// </summary>
                [JsonProperty("share_total")]
                public int ShareTotal { get; set; }

                /// <summary>
                /// VIP 域名总数
                /// </summary>
                [JsonProperty("vip_total")]
                public int VipTotal { get; set; }

                /// <summary>
                /// 星标域名的总数
                /// </summary>
                [JsonProperty("ismark_total")]
                public int IsMarkTotal { get; set; }

                /// <summary>
                /// 暂停解析的域名总数
                /// </summary>
                [JsonProperty("pause_total")]
                public int PauseTotal { get; set; }

                /// <summary>
                /// DNS 设置错误的域名总数(包括未注册的和 NS 地址没有改到 DNSPod 的域名)
                /// </summary>
                [JsonProperty("error_total")]
                public int ErrorTotal { get; set; }

                /// <summary>
                /// 已锁定的域名总数
                /// </summary>
                [JsonProperty("lock_total")]
                public int LockTotal { get; set; }

                /// <summary>
                /// 已被封禁的域名总数
                /// </summary>
                [JsonProperty("spam_total")]
                public int SpamTotal { get; set; }

                /// <summary>
                /// VIP 即将到期的域名总数(30天之内)
                /// </summary>
                [JsonProperty("vip_expire")]
                public int VipExpire { get; set; }

                /// <summary>
                /// 共享出去的域名总数
                /// </summary>
                [JsonProperty("share_out_total")]
                public int ShareOutTotal { get; set; }
            }

            public class PartDomain
            {
                /// <summary>
                /// 域名 ID, 即为 domain_id
                /// </summary>
                [JsonProperty("id")]
                public string Id { get; set; }

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
                /// 域名等级对应的ns服务器地址
                /// </summary>
                [JsonProperty("grade_ns")]
                public IList<string> GradeNs { get; set; }

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
                /// 域名备注
                /// </summary>
                [JsonProperty("remark")]
                public string Remark { get; set; }

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
                /// 使用 punycode 转码之后的域名
                /// </summary>
                [JsonProperty("punycode")]
                public string PunyCode { get; set; }

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
                /// 域名
                /// </summary>
                [JsonProperty("name")]
                public string Name { get; set; }

                /// <summary>
                /// 域名等级(中文说明)
                /// </summary>
                [JsonProperty("grade_title")]
                public string GradeTitle { get; set; }

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
                /// 域名所有者
                /// </summary>
                [JsonProperty("owner")]
                public string Owner { get; set; }

                /// <summary>
                /// 域名下记录总条数
                /// </summary>
                [JsonProperty("records")]
                public string Records { get; set; }
            }
        }
    }
}