using System;
using System.Collections.Generic;
using System.Text;

namespace DingTalkSDK.Message.ActionCardMessage
{
    public class ActionCardMessageContent_btn_json_list
    {
        /// <summary>
        /// 使用独立跳转ActionCard样式时的按钮的标题，最长20个字符
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 消息点击链接地址，当发送消息为小程序时支持小程序跳转链接，最长500个字符
        /// </summary>
        public string action_url { get; set; }
    }
    /// <summary>
    /// 卡片消息内容
    /// 卡片消息支持整体跳转ActionCard样式和独立跳转ActionCard样式：
    ///（1）整体跳转ActionCard样式，支持一个点击Action，需要传入参数 single_title和 single_url；
    ///（2）独立跳转ActionCard样式，支持多个点击Action，需要传入参数 btn_orientation 和 btn_json_list；
    /// </summary>
    public class ActionCardMessageContent
    {
        /// <summary>
        /// 透出到会话列表和通知的文案，最长64个字符
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 消息内容，支持markdown，语法参考标准markdown语法。建议1000个字符以内
        /// </summary>
        public string markdown { get; set; }
        /// <summary>
        /// 使用整体跳转ActionCard样式时的标题，必须与single_url同时设置，最长20个字符
        /// </summary>
        public string single_title { get; set; }
        /// <summary>
        /// 消息点击链接地址，当发送消息为小程序时支持小程序跳转链接，最长500个字符
        /// </summary>
        public string single_url { get; set; }
        /// <summary>
        /// 使用独立跳转ActionCard样式时的按钮排列方式，竖直排列(0)，横向排列(1)；必须与btn_json_list同时设置
        /// </summary>
        public string btn_orientation { get; set; }
        /// <summary>
        /// 使用独立跳转ActionCard样式时的按钮列表；必须与btn_orientation同时设置
        /// </summary>
        public ActionCardMessageContent_btn_json_list btn_json_list { get; set; }
    }
}
