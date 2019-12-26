using DingTalkSDK.DingDingException;
using DingTalkSDK.Util;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message
{
    /// <summary>
    /// 消息通知
    /// </summary>
    public class MessageHelper
    {
        /// <summary>
        /// 发送工作通知消息
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="agent_id">应用agentId</param>
        /// <param name="to_all_user">是否发送给企业全部用户</param>
        /// <param name="msg">消息内容，消息类型和样例参考“消息类型与数据格式”。最长不超过2048个字节</param>
        /// <param name="userid_list">接收者的用户userid列表，最大列表长度：100</param>
        /// <param name="dept_id_list">接收者的部门id列表，最大列表长度：20,  接收者是部门id下(包括子部门下)的所有用户</param>
        /// <returns>消息task_id</returns>
        public static string SendCorpconversation(String accessToken, string agent_id,Boolean to_all_user, IMessage msg,string userid_list,string dept_id_list)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(agent_id))
            {
                throw new ArgumentException("应用agentId 不能为空");
            }

            String url = Env.OAPI_HOST + "/topapi/message/corpconversation/asyncsend_v2?" +
                "access_token=" + accessToken;
            #region 创建参数
            BsonDocument args = new BsonDocument();
            args["agent_id"] = agent_id;
            args["userid_list"] = userid_list;
            args["dept_id_list"] = dept_id_list;
            args["to_all_user"] = to_all_user;
            args["msg"] = msg;
            #endregion
            BsonDocument response = HttpHelper.httpPost(url, args);
            if (HttpHelper.CheckResponseOk(response))
            {
                return response["task_id"].ToString();
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
    }
}
