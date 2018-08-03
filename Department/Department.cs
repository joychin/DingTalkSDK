using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSDK.Department
{
    public class Department
    {
        public String lang = "zh_CN";
        /// <summary>
        /// 部门id,创建部门的时候不用填写
        /// </summary>
        public long id;
        /// <summary>
        /// 部门名称。长度限制为1~64个字符。不允许包含字符‘-’‘，’以及‘,’。
        /// </summary>
        public String name;
        /// <summary>
        /// 父部门id。根部门id为1，如果创建的是根部门，则不传这个参数
        /// </summary>
        public String parentid;
        /// <summary>
        /// 在父部门中的次序值，order值小的排序靠前
        /// </summary>
        public string order;
        /// <summary>
        /// 是否创建一个关联此部门的企业群，默认为false
        /// </summary>
        public bool createDeptGroup = false;

        /// <summary>
        /// 是否隐藏部门,true表示隐藏,false表示显示,默认为false
        /// </summary>
        public bool deptHiding = false;

        /// <summary>
        /// 可以查看指定隐藏部门的其他部门列表，如果部门隐藏，则此值生效，取值为其他的部门id组成的字符串，使用“|”符号进行分割。总数不能超过200
        /// </summary>
        public string deptPerimits;
        /// <summary>
        /// 可以查看指定隐藏部门的其他人员列表，如果部门隐藏，则此值生效，取值为其他的人员userid组成的的字符串，使用“|”符号进行分割。总数不能超过200
        /// </summary>
        public string userPerimits;

        /// <summary>
        /// 是否本部门的员工仅可见员工自己，为true时，本部门员工默认只能看到员工自己,默认为false
        /// </summary>
        public bool outerDept = false;
        /// <summary>
        /// 本部门的员工仅可见员工自己为true时，可以配置额外可见部门，值为部门id组成的的字符串，使用“|”符号进行分割。总数不能超过200
        /// </summary>
        public string outerPermitDepts;
        /// <summary>
        /// 本部门的员工仅可见员工自己为true时，可以配置额外可见人员，值为userid组成的的字符串，使用“|”符号进行分割。总数不能超过200
        /// </summary>
        public string outerPermitUsers;
        /// <summary>
        /// 部门标识字段，开发者可用该字段来唯一标识一个部门，并与钉钉外部通讯录里的部门做映射
        /// </summary>
        public string sourceIdentifier;
        public override string ToString()
        {
            return "Department[id:" + id + " Name:" + name + " Parentid:" + parentid + "]";
        }

    }
}
