using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.TextMessage
{
    /// <summary>
    /// 文字类消息
    /// </summary>
    public class TextMessage : IMessage
    {
        public string msgtype { get => "text"; }
        public TextMessageContent text { get; set; }
    }
}
