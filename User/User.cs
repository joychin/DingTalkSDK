using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSDK.User
{
    public class User
    {
        /// <summary>
        /// 员工唯一标识ID（不可修改），企业内必须唯一。长度为1~64个字符，如果不传，服务器将自动生成一个userid
        /// </summary>
        public String userid;
        /// <summary>
        /// 成员名称。长度为1~64个字符
        /// </summary>
        public String name;
        /// <summary>
        /// 在对应的部门中的排序, Map结构的json字符串, key是部门的Id, value是人员在这个部门的排序值
        /// </summary>
        public BsonDocument orderInDepts;
        /// <summary>
        /// 数组类型，数组里面值为整型，成员所属部门id列表
        /// </summary>
        public List<long> department;
        /// <summary>
        /// 职位信息。长度为0~64个字符
        /// </summary>
        public String position;
        /// <summary>
        /// 手机号码，企业内必须唯一，不可重复
        /// </summary>
        public String mobile;
        /// <summary>
        /// 电话号码
        /// </summary>
        public String tel;
        /// <summary>
        /// 邮箱
        /// </summary>
        public String email;
        /// <summary>
        /// 工作地
        /// </summary>
        public String workPlace;
        /// <summary>
        /// 员工工号。对应显示到OA后台和客户端个人资料的工号栏目。长度为0~64个字符
        /// </summary>
        public String jobnumber;
        /// <summary>
        /// 企业邮箱
        /// </summary>
        public String orgEmail;
        /// <summary>
        /// 是否号码隐藏, true表示隐藏, false表示不隐藏。隐藏手机号后，手机号在个人资料页隐藏，但仍可对其发DING、发起钉钉免费商务电话。
        /// </summary>
        public bool isHide;
        /// <summary>
        /// 是否高管模式，true表示是，false表示不是。开启后，手机号码对所有员工隐藏。普通员工无法对其发DING、发起钉钉免费商务电话。高管之间不受影响。
        /// </summary>
        public bool isSenior;
        /// <summary>
        /// 扩展属性，可以设置多种属性(但手机上最多只能显示10个扩展属性，具体显示哪些属性，请到OA管理后台->设置->通讯录信息设置和OA管理后台->设置->手机端显示信息设置)
        /// </summary>
        public BsonDocument extattr;

        public User()
        {
        }

        public User(String userid, String name)
        {
            this.userid = userid;
            this.name = name;
        }
        public override string ToString()
        {
            //List<User> users;
            return "User[userid:" + userid + ", name:" + name + ", department:" + department +
                    ", position:" + position + ", mobile:" + mobile + ", email:" + email +
                     ", extattr:" + extattr + "]";
        }
    }
}
