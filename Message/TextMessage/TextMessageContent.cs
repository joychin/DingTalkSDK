using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.TextMessage
{
    /// <summary>
    /// 文字消息的内容
    /// </summary>
    public class TextMessageContent
    {
        /// <summary>
        /// 消息内容，建议500字符以内
        /// </summary>
        public string content { get; set; }
    }
}
