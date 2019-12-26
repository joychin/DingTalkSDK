using System;
using System.Net;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json.Bson;

namespace DingTalkSDK.Util
{
    internal class HttpHelper
    {
        private static CookieContainer cookie = new CookieContainer();

        /// <summary>
        /// 使用GET从url获取数据
        /// </summary>
        /// <param name="url">获取数据的url</param>
        /// <param name="data">附带的data,可以不传，直接在url里面拼接参数，如果传了，url里面的参数就会被忽略</param>
        /// <returns>格式化的BsonDocument</returns>
        public static BsonDocument httpGet(String url, BsonDocument data = null)
        {
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            if (data != null)
            {
                foreach (var item in data)
                {
                    client.QueryString.Add(item.Name, item.Value.ToString());
                }
            }
            var respostData = client.DownloadData(url);
            return BsonDocument.Parse(System.Text.UTF8Encoding.UTF8.GetString(respostData));
        }

        /// <summary>
        /// 使用GET从url获取数据
        /// </summary>
        /// <param name="url">获取数据的url</param>
        /// <param name="data">附带的data,可以不传，直接在url里面拼接参数，如果传了，url里面的参数就会被忽略</param>
        /// <returns>格式化的BsonDocument</returns>
        public static async Task<BsonDocument> httpGetAsync(String url, BsonDocument data = null)
        {
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            if (data != null)
            {
                foreach (var item in data)
                {
                    client.QueryString.Add(item.Name, item.Value.ToString());
                }
            }

            var respostData = await client.DownloadDataTaskAsync(url);
            return BsonDocument.Parse(System.Text.UTF8Encoding.UTF8.GetString(respostData));
        }

        /// <summary>
        /// 使用POST从url获取数据
        /// </summary>
        /// <param name="url">获取数据的url</param>
        /// <param name="data">附带的data</param>
        /// <returns>格式化的BsonDocument</returns>
        public static BsonDocument httpPost(String url, BsonDocument data)
        {
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var postdata = System.Text.UTF8Encoding.UTF8.GetBytes((data.ToString()));
            var respostData = client.UploadData(url, postdata);
            return BsonDocument.Parse(System.Text.UTF8Encoding.UTF8.GetString(respostData));
        }

        /// <summary>
        /// 使用POST从url获取数据
        /// </summary>
        /// <param name="url">获取数据的url</param>
        /// <param name="data">附带的data</param>
        /// <returns>格式化的BsonDocument</returns>
        public static async Task<BsonDocument> httpPostAsync(String url, BsonDocument data)
        {
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            var postdata = System.Text.UTF8Encoding.UTF8.GetBytes((data.ToString()));
            var respostData = await client.UploadDataTaskAsync(url, postdata);
            return BsonDocument.Parse(System.Text.UTF8Encoding.UTF8.GetString(respostData));
        }
        /// <summary>
        /// 检查请求是否执行成功
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static bool CheckResponseOk(BsonDocument response)
        {
            if (response.Contains("errcode") && response["errcode"].ToInt64() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}