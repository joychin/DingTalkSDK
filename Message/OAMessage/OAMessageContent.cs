using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.OAMessage
{
    public class OAMessageContent_head
    {
        /// <summary>
        /// 消息头部的背景颜色。长度限制为8个英文字符，其中前2为表示透明度，后6位表示颜色值。不要添加0x
        /// </summary>
        public string bgcolor { get;set;}
        /// <summary>
        /// 消息的头部标题 (向普通会话发送时有效，向企业会话发送时会被替换为微应用的名字)，长度限制为最多10个字符
        /// </summary>
        public string text { get; set; }
    }
    public class OAMessageContent_body_form
    {
        /// <summary>
        /// 消息体的关键字
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 消息体的关键字对应的值
        /// </summary>
        public string value { get; set; }
    }
    public class OAMessageContent_body_rich
    {
        /// <summary>
        /// 单行富文本信息的数目
        /// </summary>
        public string num { get; set; }
        /// <summary>
        /// 单行富文本信息的单位
        /// </summary>
        public string unit { get; set; }
    }
    public class OAMessageContent_body
    {
        /// <summary>
        /// 消息体的标题，建议50个字符以内
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 消息体的表单，最多显示6个，超过会被隐藏
        /// </summary>
        public List<OAMessageContent_body_form> form { get; set; }
        /// <summary>
        /// 单行富文本信息
        /// </summary>
        public OAMessageContent_body_rich rich { get; set; }
        /// <summary>
        /// 消息体的内容，最多显示3行
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 消息体中的图片，支持图片资源@mediaId
        /// </summary>
        public string image { get; set; }
        /// <summary>
        /// 自定义的附件数目。此数字仅供显示，钉钉不作验证
        /// </summary>
        public string file_count { get; set; }
        /// <summary>
        /// 自定义的作者名字
        /// </summary>
        public string author { get; set; }
    }
    /// <summary>
    /// OA类消息的内容
    /// </summary>
    public class OAMessageContent
    {
        /// <summary>
        /// 消息点击链接地址，当发送消息为小程序时支持小程序跳转链接
        /// </summary>
        public string message_url { get;set;}
        /// <summary>
        /// PC端点击消息时跳转到的地址
        /// </summary>
        public string pc_message_url { get; set; }
        /// <summary>
        /// 消息头部内容
        /// </summary>
        public OAMessageContent_head head { get; set; }
        /// <summary>
        /// 消息体
        /// </summary>
        public OAMessageContent_body body { get; set; }

    }
}
