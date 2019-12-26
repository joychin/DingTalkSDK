using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.ImageMessage
{
    /// <summary>
    /// 图片类消息
    /// </summary>
    public class ImageMessage : IMessage
    {
        public string msgtype { get => "image"; }
        public ImageMessageContent image { get; set; }
    }
}
