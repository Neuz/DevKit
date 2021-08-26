using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace Neuz.DevKit.Api.DNSPod
{
    public partial class User : BaseApi
    {
        /// <summary>
        /// 获取帐户信息
        /// <para>https://www.dnspod.cn/docs/accounts.html#user-detail</para>
        /// </summary>
        /// <returns></returns>
        public async Task<CommonResponse> Detail()
        {
            var url = _settings.BaseUrl.AppendPathSegment("User.Detail");

            var postData = _settings.GetCommonParameters();

            var rr = await url.WithHeaders(_settings.HttpHeaders)
                              .PostUrlEncodedAsync(postData);

            var result = await rr.GetJsonAsync<UserDetailResponse>();
            result.Original = rr.ResponseMessage;
            return result;
        }
        
        public class UserDetailResponse : CommonResponse
        {
            [JsonProperty("info")]
            public PartInfo Info { get; set; }

            public class PartInfo
            {
                [JsonProperty("user")]
                public PartUser User { get; set; }

                public class PartUser
                {
                    /// <summary>
                    /// 用户名称, 企业用户对应为公司名称
                    /// </summary>
                    [JsonProperty("real_name")]
                    public string RealName { get; set; }

                    /// <summary>
                    /// 账号类型：[“personal”,”enterprise”]，分别对应个人用户和企业用户
                    /// </summary>
                    [JsonProperty("user_type")]
                    public string UserType { get; set; }

                    /// <summary>
                    /// 电话号码
                    /// </summary>
                    [JsonProperty("telephone")]
                    public string Telephone { get; set; }

                    /// <summary>
                    /// 用户 IM (已废弃)
                    /// </summary>
                    [JsonProperty("im")]
                    public string Im { get; set; }

                    /// <summary>
                    /// 用户昵称
                    /// </summary>
                    [JsonProperty("nick")]
                    public string Nick { get; set; }

                    /// <summary>
                    /// 用户 ID, 即为 user_id
                    /// </summary>
                    [JsonProperty("id")]
                    public string Id { get; set; }

                    /// <summary>
                    /// 用户账号, 邮箱格式
                    /// </summary>
                    [JsonProperty("email")]
                    public string EMail { get; set; }

                    /// <summary>
                    /// 账号状态
                    /// <para>enabled: 正常；disabled: 被封禁</para>
                    /// </summary>
                    [JsonProperty("status")]
                    public string Status { get; set; }

                    /// <summary>
                    /// 邮箱是否通过验证
                    /// <para>yes: 通过；no: 未通过</para>
                    /// </summary>
                    [JsonProperty("email_verified")]
                    public string EmailVerified { get; set; }

                    /// <summary>
                    /// 手机是否通过验证
                    /// <para>yes: 通过；no: 未通过</para>
                    /// </summary>
                    [JsonProperty("telephone_verified")]
                    public string TelephoneVerified { get; set; }
                }
            }
        }
    }
}