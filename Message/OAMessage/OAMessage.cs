using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.OAMessage
{
    /// <summary>
    /// OA消息
    /// </summary>
    public class OAMessage : IMessage
    {
        public string msgtype  { get =>"oa";}
        public OAMessageContent oa { get; set; }

    }
}
