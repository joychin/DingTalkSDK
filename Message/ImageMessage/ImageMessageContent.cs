using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.ImageMessage
{
    /// <summary>
    /// 图片类消息的内容
    /// </summary>
    public class ImageMessageContent
    {
        /// <summary>
        /// 媒体文件id，可以通过媒体文件接口上传图片获取。建议宽600像素 x 400像素，宽高比3 : 2
        /// </summary>
        public string media_id { get; set; }
    }
}
