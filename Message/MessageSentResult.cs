using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message
{
    /// <summary>
    /// 消息发送后的返回结果
    /// </summary>
    public class MessageSentResult
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public string errcode { get; set; }
        /// <summary>
        /// 对返回码的文本描述内容
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// 创建的发送任务id
        /// </summary>
        public string task_id { get; set; }
    }
}
