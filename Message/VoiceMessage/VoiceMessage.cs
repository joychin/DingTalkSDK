using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.VoiceMessage
{
    /// <summary>
    /// 语音类消息
    /// </summary>
    public class VoiceMessage : IMessage
    {
        public string msgtype { get => "voice"; }
        public VoiceMessageContent voice { get; set; }
    }
}
