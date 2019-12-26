using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.FileMessage
{
    /// <summary>
    /// 附件消息的内容
    /// </summary>
    public class FileMessageContent
    {
        /// <summary>
        /// 媒体文件id，引用的媒体文件最大10MB
        /// </summary>
        public string media_id { get; set; }
    }
}
