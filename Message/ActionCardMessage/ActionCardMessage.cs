using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.ActionCardMessage
{
    /// <summary>
    /// 卡片消息
    /// </summary>
    public class ActionCardMessage : IMessage
    {
        public string msgtype { get => "action_card"; }
        public ActionCardMessageContent action_card { get; set; }
    }
}
