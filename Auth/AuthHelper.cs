using DingTalkSDK.DingDingException;
using DingTalkSDK.Util;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson;
using System;

namespace DingTalkSDK.Auth
{
    public class AuthHelper
    {
        /// <summary>
        /// token 缓存
        /// </summary>
        private static MemoryCache accessonTokenCache;
        /// <summary>
        /// token 缓存的名称
        /// </summary>
        private static string accessonTokenCacheName = "AccessonToken";
        static AuthHelper()
        {
            accessonTokenCache = new MemoryCache(new MemoryCacheOptions() { });
            getAccessToken();
        }
        public static String getAccessToken()
        {
            string accessonToken;
            bool isTokenExist = accessonTokenCache.TryGetValue(accessonTokenCacheName, out accessonToken);
            if (!isTokenExist)
            {
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
                    //钉钉规定7200秒过期，这里我们用6900秒过期
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(6900));
                    accessonTokenCache.Set(accessonTokenCacheName, accessonToken, cacheEntryOptions);
                }
                else
                {
                    throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
                }
            }
            return accessonToken;
        }
    }
}
