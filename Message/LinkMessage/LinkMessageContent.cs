using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.LinkMessage
{
    /// <summary>
    /// 链接消息的内容
    /// </summary>
    public class LinkMessageContent
    {
        /// <summary>
        /// 消息点击链接地址，当发送消息为小程序时支持小程序跳转链接
        /// </summary>
        public string messageUrl { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string picUrl { get; set; }
        /// <summary>
        /// 消息标题，建议100字符以内
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 消息描述，建议500字符以内
        /// </summary>
        public string text { get; set; }
    }
}
