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
        public const String OAPI_HOST = "https://oapi.dingtalk.com";

        /// <summary>
        /// 企业Id
        /// </summary>
        public static String CorpId { get; set; }

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
                if (Access_token == null)
                {
                    return AuthHelper.getAccessToken();
                }
                else
                {
                    return Access_token;
                }
            }
            set => Access_token = value;

        }
    }
}
