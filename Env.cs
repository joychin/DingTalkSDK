using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DingTalkSDK.Auth;

namespace DingTalkSDK
{
    /// <summary>
    /// 钉钉的环境配置
    /// </summary>
    public class Env
    {
        public const string OAPI_HOST = "https://oapi.dingtalk.com";

        /// <summary>
        /// 企业Id
        /// </summary>
        public static string CorpId { get; set; }

        /// <summary>
        /// 企业应用的凭证密钥
        /// </summary>
        public static string CorpSecret { get; set; }

        /// <summary>
        /// Access_Token
        /// </summary>
        public static string Access_token
        {
            get
            {
               return AuthHelper.getAccessToken();
            }
            set => Access_token = value;
        }
    }
}
