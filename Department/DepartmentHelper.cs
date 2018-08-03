using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DingTalkSDK.DingDingException;
using DingTalkSDK.Util;
using MongoDB.Bson;

namespace DingTalkSDK.Department
{
    public class DepartmentHelper
    {
        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="accessToken">token</param>
        /// <param name="name">部门名称</param>
        /// <param name="parentId">父部门名称</param>
        /// <param name="order"></param>
        /// <returns>创建成功的部门ID</returns>
        public static long CreateDepartment(String accessToken, Department department)
        {

            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(department.name))
            {
                throw new ArgumentException("部门名称不能为空");
            }
            if (String.IsNullOrWhiteSpace(department.parentid))
            {
                throw new ArgumentException("父部门id不能为空");
            }

            String url = Env.OAPI_HOST + "/department/create?" +
                "access_token=" + accessToken;

            #region 创建参数
            BsonDocument args = new BsonDocument();
            args["name"] = department.name;
            args["parentid"] = department.parentid;
            if (!string.IsNullOrWhiteSpace(department.order))
            {
                args["order"] = department.order;
            }
            args["createDeptGroup"] = department.createDeptGroup;
            args["deptHiding"] = department.deptHiding;
            if (!string.IsNullOrWhiteSpace(department.deptPerimits))
            {
                args["deptPerimits"] = department.deptPerimits;
            }
            if (!string.IsNullOrWhiteSpace(department.userPerimits))
            {
                args["userPerimits"] = department.userPerimits;
            }
            args["outerDept"] = department.outerDept;
            if (!string.IsNullOrWhiteSpace(department.outerPermitDepts))
            {
                args["outerPermitDepts"] = department.outerPermitDepts;
            }
            if (!string.IsNullOrWhiteSpace(department.outerPermitUsers))
            {
                args["outerPermitUsers"] = department.outerPermitUsers;
            }
            if (!string.IsNullOrWhiteSpace(department.sourceIdentifier))
            {
                args["sourceIdentifier"] = department.sourceIdentifier;
            }
            #endregion

            BsonDocument response = HttpHelper.httpPost(url, args);
            if (response.Contains("id"))
            {
                return response["id"].ToInt64();
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="accessToken">token</param>
        /// <param name="name">部门名称</param>
        /// <param name="parentId">父部门名称</param>
        /// <param name="order"></param>
        /// <returns>创建成功的部门ID</returns>
        public static async Task<long> CreateDepartmentAsync(String accessToken, Department department)
        {

            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(department.name))
            {
                throw new ArgumentException("部门名称不能为空");
            }
            if (String.IsNullOrWhiteSpace(department.parentid))
            {
                throw new ArgumentException("父部门id不能为空");
            }

            String url = Env.OAPI_HOST + "/department/create?" +
                "access_token=" + accessToken;

            #region 创建参数
            BsonDocument args = new BsonDocument();
            args["name"] = department.name;
            args["parentid"] = department.parentid;
            if (!string.IsNullOrWhiteSpace(department.order))
            {
                args["order"] = department.order;
            }
            args["createDeptGroup"] = department.createDeptGroup;
            args["deptHiding"] = department.deptHiding;
            if (!string.IsNullOrWhiteSpace(department.deptPerimits))
            {
                args["deptPerimits"] = department.deptPerimits;
            }
            if (!string.IsNullOrWhiteSpace(department.userPerimits))
            {
                args["userPerimits"] = department.userPerimits;
            }
            args["outerDept"] = department.outerDept;
            if (!string.IsNullOrWhiteSpace(department.outerPermitDepts))
            {
                args["outerPermitDepts"] = department.outerPermitDepts;
            }
            if (!string.IsNullOrWhiteSpace(department.outerPermitUsers))
            {
                args["outerPermitUsers"] = department.outerPermitUsers;
            }
            if (!string.IsNullOrWhiteSpace(department.sourceIdentifier))
            {
                args["sourceIdentifier"] = department.sourceIdentifier;
            }
            #endregion

            BsonDocument response = await HttpHelper.httpPostAsync(url, args);
            if (response.Contains("id"))
            {
                return response["id"].ToInt64();
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
        /// <summary>
        /// 列出所有的部门
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <returns>部门列表</returns>
        public static List<Department> ListDepartments(String accessToken)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            String url = Env.OAPI_HOST + "/department/list?" +
                "access_token=" + accessToken;
            BsonDocument response = HttpHelper.httpGet(url);
            if (response.Contains("department"))
            {
                BsonArray arr = response["department"].AsBsonArray;
                List<Department> list = new List<Department>();
                for (int i = 0; i < arr.Count; i++)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<Department>(arr[i].ToString()));
                }
                return list;
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }

        /// <summary>
        /// 列出所有的部门
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <returns>部门列表</returns>
        public static async Task<List<Department>> ListDepartmentsAsync(String accessToken)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            String url = Env.OAPI_HOST + "/department/list?" +
                "access_token=" + accessToken;
            BsonDocument response = await HttpHelper.httpGetAsync(url);
            if (response.Contains("department"))
            {
                BsonArray arr = response["department"].AsBsonArray;
                List<Department> list = new List<Department>();
                for (int i = 0; i < arr.Count; i++)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<Department>(arr[i].ToString()));
                }
                return list;
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="accessToken">accessontoken</param>
        /// <param name="id">部门id</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteDepartment(String accessToken, long id)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            String url = Env.OAPI_HOST + "/department/delete?" +
                        "access_token=" + accessToken + "&id=" + id;
            BsonDocument response = HttpHelper.httpGet(url);
            if (response.Contains("errcode") && response["errcode"].AsInt32 != 0)
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
            return true;
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="accessToken">accessontoken</param>
        /// <param name="id">部门id</param>
        /// <returns>是否删除成功</returns>
        public static async Task<bool> DeleteDepartmentAsync(String accessToken, long id)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            String url = Env.OAPI_HOST + "/department/delete?" +
                        "access_token=" + accessToken + "&id=" + id;
            BsonDocument response = await HttpHelper.httpGetAsync(url);
            if (response.Contains("errcode") && response["errcode"].AsInt32 != 0)
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
            return true;
        }
        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="department">部门实体</param>
        /// <returns>更新的部门id</returns>
        public static long UpdateDepartment(String accessToken, Department department)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            String url = Env.OAPI_HOST + "/department/update?" +
                        "access_token=" + accessToken;
            #region 创建参数
            BsonDocument args = new BsonDocument();
            args["name"] = department.name;
            args["parentid"] = department.parentid;
            if (!string.IsNullOrWhiteSpace(department.order))
            {
                args["order"] = department.order;
            }
            args["createDeptGroup"] = department.createDeptGroup;
            args["deptHiding"] = department.deptHiding;
            if (!string.IsNullOrWhiteSpace(department.deptPerimits))
            {
                args["deptPerimits"] = department.deptPerimits;
            }
            if (!string.IsNullOrWhiteSpace(department.userPerimits))
            {
                args["userPerimits"] = department.userPerimits;
            }
            args["outerDept"] = department.outerDept;
            if (!string.IsNullOrWhiteSpace(department.outerPermitDepts))
            {
                args["outerPermitDepts"] = department.outerPermitDepts;
            }
            if (!string.IsNullOrWhiteSpace(department.outerPermitUsers))
            {
                args["outerPermitUsers"] = department.outerPermitUsers;
            }
            if (!string.IsNullOrWhiteSpace(department.sourceIdentifier))
            {
                args["sourceIdentifier"] = department.sourceIdentifier;
            }
            #endregion
            BsonDocument response = HttpHelper.httpPost(url, args);
            if (response.Contains("id"))
            {
                return response["id"].ToInt64();
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="department">部门实体</param>
        /// <returns>更新的部门id</returns>
        public static async Task<long> UpdateDepartmentAsync(String accessToken, Department department)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            String url = Env.OAPI_HOST + "/department/update?" +
                        "access_token=" + accessToken;
            #region 创建参数
            BsonDocument args = new BsonDocument();
            args["name"] = department.name;
            args["parentid"] = department.parentid;
            if (!string.IsNullOrWhiteSpace(department.order))
            {
                args["order"] = department.order;
            }
            args["createDeptGroup"] = department.createDeptGroup;
            args["deptHiding"] = department.deptHiding;
            if (!string.IsNullOrWhiteSpace(department.deptPerimits))
            {
                args["deptPerimits"] = department.deptPerimits;
            }
            if (!string.IsNullOrWhiteSpace(department.userPerimits))
            {
                args["userPerimits"] = department.userPerimits;
            }
            args["outerDept"] = department.outerDept;
            if (!string.IsNullOrWhiteSpace(department.outerPermitDepts))
            {
                args["outerPermitDepts"] = department.outerPermitDepts;
            }
            if (!string.IsNullOrWhiteSpace(department.outerPermitUsers))
            {
                args["outerPermitUsers"] = department.outerPermitUsers;
            }
            if (!string.IsNullOrWhiteSpace(department.sourceIdentifier))
            {
                args["sourceIdentifier"] = department.sourceIdentifier;
            }
            #endregion
            BsonDocument response = await HttpHelper.httpPostAsync(url, args);
            if (response.Contains("id"))
            {
                return response["id"].ToInt64();
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
        /// <summary>
        /// 获取钉钉上某个企业/组织内的人数。
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="onlyActive">0：包含未激活钉钉的人员数量,1：不包含未激活钉钉的人员数量</param>
        /// <returns></returns>
        public static long GetOrgUserCount(String accessToken, int onlyActive)
        {
            String url = Env.OAPI_HOST + "/department/get_org_user_count";
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }

            if (onlyActive != 0 && onlyActive != 1)
            {
                throw new ArgumentException("onlyActive,只能是1或者是0。0：包含未激活钉钉的人员数量,1：不包含未激活钉钉的人员数量");
            }
            BsonDocument args = new BsonDocument();
            args["access_token"] = "accessToken";
            args["onlyActive"] = onlyActive;
            var response = HttpHelper.httpGet(url, args);
            if (response.Contains("count"))
            {
                return response["count"].ToInt64();
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
        /// <summary>
        /// 获取钉钉上某个企业/组织内的人数。
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <param name="onlyActive">0：包含未激活钉钉的人员数量,1：不包含未激活钉钉的人员数量</param>
        /// <returns></returns>
        public static async Task<long> GetOrgUserCountAsync(String accessToken, int onlyActive)
        {
            String url = Env.OAPI_HOST + "/department/get_org_user_count";
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }

            if (onlyActive != 0 && onlyActive != 1)
            {
                throw new ArgumentException("onlyActive,只能是1或者是0。0：包含未激活钉钉的人员数量,1：不包含未激活钉钉的人员数量");
            }
            BsonDocument args = new BsonDocument();
            args["access_token"] = "accessToken";
            args["onlyActive"] = onlyActive;
            var response = await HttpHelper.httpGetAsync(url, args);
            if (response.Contains("count"))
            {
                return response["count"].ToInt64();
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
    }
}
