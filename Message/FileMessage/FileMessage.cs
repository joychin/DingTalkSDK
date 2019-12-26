using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.FileMessage
{
    /// <summary>
    /// 附件类消息
    /// </summary>
    public class FileMessage : IMessage
    {
        public string msgtype { get => "file"; }
        public FileMessageContent file { get; set; }
    }
}
