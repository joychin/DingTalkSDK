using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.LinkMessage
{
    /// <summary>
    /// 链接消息
    /// </summary>
    public class LinkMessage : IMessage
    {
        public string msgtype { get => "link"; }
        public LinkMessageContent link { get; set; }
    }
}
