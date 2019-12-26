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
        /// Token 更新日期
        /// </summary>
        private static DateTime Accesson_token_UpdateTime
        {
            get;set;
        }

        /// <summary>
        /// Access_Token
        /// </summary>
        public static string Access_token
        {
            get
            {
                //钉钉规定7200秒过期，这里我们用6900秒过期

                if (
                    Accesson_token_UpdateTime == DateTime.MinValue
                    || Accesson_token_UpdateTime == null
                    || (DateTime.Now - Accesson_token_UpdateTime).TotalSeconds > 6900
                    )
                {
                    var accessonToken = AuthHelper.getAccessToken();
                    Env.Accesson_token_UpdateTime = DateTime.Now;
                    return accessonToken;
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
