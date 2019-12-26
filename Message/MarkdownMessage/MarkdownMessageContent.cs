using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.MarkdownMessage
{
    /// <summary>
    /// markdown消息内容
    /// </summary>
    public class MarkdownMessageContent
    {
        /// <summary>
        /// 首屏会话透出的展示内容
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// markdown格式的消息，建议500字符以内
        /// </summary>
        public string text { get; set; }
    }
}
