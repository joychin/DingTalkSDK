using DingTalkSDK.DingDingException;
using DingTalkSDK.Util;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson;
using System;

namespace DingTalkSDK.Auth
{
    public class AuthHelper
    {
        public static String getAccessToken()
        {
            string accessonToken;
            if (String.IsNullOrWhiteSpace(Env.CorpId))
            {
                throw new ArgumentException("请先初始化Env中的CorpId");
            }
            if (String.IsNullOrWhiteSpace(Env.CorpSecret))
            {
                throw new ArgumentException("请先初始化Env中的CorpSecret");
            }

            String url = Env.OAPI_HOST + "/gettoken?" +
                "corpid=" + Env.CorpId + "&corpsecret=" + Env.CorpSecret;
            BsonDocument response = HttpHelper.httpGet(url);
            if (response.Contains("access_token"))
            {
                accessonToken = response["access_token"].ToString();
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }

            return accessonToken;
        }
    }
}
