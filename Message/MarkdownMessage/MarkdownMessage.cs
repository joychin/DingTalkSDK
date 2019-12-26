using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.MarkdownMessage
{
    /// <summary>
    /// Markdown消息
    /// </summary>
    public class MarkdownMessage : IMessage
    {
        public string msgtype { get => "markdown"; }
        public MarkdownMessageContent markdown { get; set; }
    }
}
