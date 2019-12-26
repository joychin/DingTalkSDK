using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.VoiceMessage
{
    /// <summary>
    /// 语音消息的内容
    /// </summary>
    public class VoiceMessageContent
    {
        /// <summary>
        /// 媒体文件id。2MB，播放长度不超过60s，AMR格式
        /// </summary>
        public string media_id { get; set; }
        /// <summary>
        /// 正整数，小于60，表示音频时长
        /// </summary>
        public int duration { get; set; }
    }
}
