using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingTalkSDK.DingDingException;
using DingTalkSDK.Util;
using MongoDB.Bson;

namespace DingTalkSDK.User
{
    public class UserHelper
    {
        /// <summary>
        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="user">user</param>
        /// <returns>创建的用户ID</returns>
        public static string CreateUser(String accessToken, User user)
        {

            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(user.name))
            {
                throw new ArgumentException("name 必须不能为空");
            }
            if (String.IsNullOrWhiteSpace(user.mobile))
            {
                throw new ArgumentException("mobile 必须不能为空");
            }
            if (String.IsNullOrWhiteSpace(user.userid))
            {
                throw new ArgumentException("userid 必须不能为空");
            }
            if (user.department.Count == 0)
            {
                throw new ArgumentException("user 的构造参数 department 必须不能为空");
            }

            String url = Env.OAPI_HOST + "/user/create";

            BsonDocument args = new BsonDocument();
            args["access_token"] = accessToken;
            args["name"] = user.name;
            args["mobile"] = user.mobile;
            args["userid"] = user.userid;
            var deptlist = "[";
            foreach (var item in user.department)
            {
                deptlist += item.ToString() + ",";
            }
            deptlist = deptlist.Remove(deptlist.Count() - 1) + "]";
            args["department"] = deptlist;

            BsonDocument response = HttpHelper.httpPost(url, args);

            if (response.Contains("userid"))
            {
                return response["userid"].ToString();
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
        /// <summary>
        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="user">user</param>
        /// <returns>创建的用户ID</returns>
        public static async Task<string> CreateUserAsync(String accessToken, User user)
        {

            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(user.name))
            {
                throw new ArgumentException("name 必须不能为空");
            }
            if (String.IsNullOrWhiteSpace(user.mobile))
            {
                throw new ArgumentException("mobile 必须不能为空");
            }
            if (String.IsNullOrWhiteSpace(user.userid))
            {
                throw new ArgumentException("userid 必须不能为空");
            }
            if (user.department.Count == 0)
            {
                throw new ArgumentException("user 的构造参数 department 必须不能为空");
            }

            String url = Env.OAPI_HOST + "/user/create";

            BsonDocument args = new BsonDocument();
            args["access_token"] = accessToken;
            args["name"] = user.name;
            args["mobile"] = user.mobile;
            args["userid"] = user.userid;
            var deptlist = "[";
            foreach (var item in user.department)
            {
                deptlist += item.ToString() + ",";
            }
            deptlist = deptlist.Remove(deptlist.Count() - 1) + "]";
            args["department"] = deptlist;

            var response = await HttpHelper.httpPostAsync(url, args);
            if (response.Contains("userid"))
            {
                return response["userid"].ToString();
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }

        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="user">user</param>
        /// <returns>是否更新成功</returns>
        public static bool UpdateUser(String accessToken, User user)
        {

            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(user.userid))
            {
                throw new ArgumentException("userid 必须不能为空");
            }

            String url = Env.OAPI_HOST + "/user/update";
            BsonDocument args = new BsonDocument();
            args["access_token"] = accessToken;
            args["name"] = user.name;
            args["mobile"] = user.mobile;
            args["userid"] = user.userid;
            var deptlist = "[";
            foreach (var item in user.department)
            {
                deptlist += item.ToString() + ",";
            }
            deptlist = deptlist.Remove(deptlist.Count() - 1) + "]";
            args["department"] = deptlist;

            BsonDocument response = HttpHelper.httpPost(url, args);

            if (response.Contains("errcode") && response["errcode"].AsInt32 != 0)
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
            return true;
        }

        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="user">user</param>
        /// <returns>是否更新成功</returns>
        public static async Task<bool> UpdateUserAsync(String accessToken, User user)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(user.userid))
            {
                throw new ArgumentException("userid 必须不能为空");
            }

            String url = Env.OAPI_HOST + "/user/update";
            BsonDocument args = new BsonDocument();
            args["access_token"] = accessToken;
            args["name"] = user.name;
            args["mobile"] = user.mobile;
            args["userid"] = user.userid;
            var deptlist = "[";
            foreach (var item in user.department)
            {
                deptlist += item.ToString() + ",";
            }
            deptlist = deptlist.Remove(deptlist.Count() - 1) + "]";
            args["department"] = deptlist;

            BsonDocument response = await HttpHelper.httpPostAsync(url, args);

            if (response.Contains("errcode") && response["errcode"].AsInt32 != 0)
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
            return true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="userid">userid</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteUser(String accessToken, String userid)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(userid))
            {
                throw new ArgumentException("userid 必须不能为空");
            }
            String url = Env.OAPI_HOST + "/user/delete?" +
                "access_token=" + accessToken + "&userid=" + userid;
            BsonDocument response = HttpHelper.httpGet(url);

            if (response.Contains("errcode") && response["errcode"].AsInt32 != 0)
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
            return true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="userid">userid</param>
        /// <returns>是否删除成功</returns>
        public static async Task<bool> DeleteUserAsync(String accessToken, String userid)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(userid))
            {
                throw new ArgumentException("userid 必须不能为空");
            }
            String url = Env.OAPI_HOST + "/user/delete?" +
                "access_token=" + accessToken + "&userid=" + userid;
            BsonDocument response = await HttpHelper.httpGetAsync(url);

            if (response.Contains("errcode") && response["errcode"].AsInt32 != 0)
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
            return true;
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="userid">userid</param>
        public static User GetUser(String accessToken, String userid)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(userid))
            {
                throw new ArgumentException("userid 不能为空");
            }
            String url = Env.OAPI_HOST + "/user/get?" +
                "access_token=" + accessToken + "&userid=" + userid;
            BsonDocument json = HttpHelper.httpGet(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json.ToString());
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="userid">userid</param>
        public static async Task<User> GetUserAsync(String accessToken, String userid)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (String.IsNullOrWhiteSpace(userid))
            {
                throw new ArgumentException("userid 不能为空");
            }
            String url = Env.OAPI_HOST + "/user/get?" +
                "access_token=" + accessToken + "&userid=" + userid;
            BsonDocument json = await HttpHelper.httpGetAsync(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json.ToString());
        }

        /// <summary>
        /// 批量删除成员
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="useridlist">用户列表</param>
        /// <returns>是否删除成功</returns>
        public static bool BatchDeleteUser(String accessToken, List<String> useridlist)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (useridlist.Count == 0)
            {
                throw new ArgumentException("useridlist 不能为空");
            }
            String url = Env.OAPI_HOST + "/user/batchdelete?" +
                    "access_token=" + accessToken;
            BsonDocument args = new BsonDocument();
            args["useridlist"] = new BsonArray(useridlist);
            BsonDocument response = HttpHelper.httpPost(url, args);
            if (response.Contains("errcode") && response["errcode"].AsInt32 != 0)
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
            return true;
        }

        /// <summary>
        /// 批量删除成员
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="useridlist">用户列表</param>
        /// <returns>是否删除成功</returns>
        public static async Task<bool> BatchDeleteUserAsync(String accessToken, List<String> useridlist)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            if (useridlist.Count == 0)
            {
                throw new ArgumentException("useridlist 不能为空");
            }
            String url = Env.OAPI_HOST + "/user/batchdelete?" +
                    "access_token=" + accessToken;
            BsonDocument args = new BsonDocument();
            args["useridlist"] = new BsonArray(useridlist);
            BsonDocument response = await HttpHelper.httpPostAsync(url, args);
            if (response.Contains("errcode") && response["errcode"].AsInt32 != 0)
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
            return true;
        }
        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="department_id">部门id</param>
        /// <returns>部门成员list</returns>
        public static List<User> GetDepartmentUser(String accessToken, long department_id)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            String url = Env.OAPI_HOST + "/user/simplelist?" +
                    "access_token=" + accessToken + "&department_id=" + department_id;
            BsonDocument response = HttpHelper.httpGet(url);
            if (response.Contains("userlist"))
            {
                List<User> list = new List<User>();
                BsonArray arr = response["userlist"].AsBsonArray;
                for (int i = 0; i < arr.Count; i++)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<User>(arr[i].ToString()));
                }
                return list;
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }

        /// <summary>
        /// 获取部门成员的简单信息，此接口只包含userid和name
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="department_id">部门id</param>
        /// <returns>部门成员list</returns>
        public static async Task<List<User>> GetDepartmentUserAsync(String accessToken, long department_id)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            String url = Env.OAPI_HOST + "/user/simplelist?" +
                    "access_token=" + accessToken + "&department_id=" + department_id;
            BsonDocument response = await HttpHelper.httpGetAsync(url);
            if (response.Contains("userlist"))
            {
                List<User> list = new List<User>();
                BsonArray arr = response["userlist"].AsBsonArray;
                for (int i = 0; i < arr.Count; i++)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<User>(arr[i].ToString()));
                }
                return list;
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }

        /// <summary>
        /// 获取部门成员的详细信息
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="department_id">部门id</param>
        /// <returns>部门成员list</returns>
        public static List<User> GettDepartmentUserDetail(String accessToken, long department_id)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            String url = Env.OAPI_HOST + "/user/list?" +
                        "access_token=" + accessToken + "&department_id=" + department_id;
            BsonDocument response = HttpHelper.httpGet(url);
            if (response.Contains("userlist"))
            {
                BsonArray arr = response["userlist"].AsBsonArray;
                List<User> list = new List<User>();
                for (int i = 0; i < arr.Count; i++)
                {
                    var bd = arr[i].ToBsonDocument();
                    if (bd.Contains("order"))
                    {
                        bd.Set("order", bd.GetValue("order").AsInt64.ToString());
                    }
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<User>(arr[i].ToString()));
                }
                return list;
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
        /// <summary>
        /// 获取部门成员的详细信息
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <param name="department_id">部门id</param>
        /// <returns>部门成员list</returns>
        public static async Task<List<User>> GettDepartmentUserDetailAsync(String accessToken, long department_id)
        {
            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("accessToken 不能为空");
            }
            String url = Env.OAPI_HOST + "/user/list?" +
                        "access_token=" + accessToken + "&department_id=" + department_id;
            BsonDocument response = await HttpHelper.httpGetAsync(url);
            if (response.Contains("userlist"))
            {
                BsonArray arr = response["userlist"].AsBsonArray;
                List<User> list = new List<User>();
                for (int i = 0; i < arr.Count; i++)
                {
                    var bd = arr[i].ToBsonDocument();
                    if (bd.Contains("order"))
                    {
                        bd.Set("order", bd.GetValue("order").AsInt64.ToString());
                    }
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<User>(arr[i].ToString()));
                }
                return list;
            }
            else
            {
                throw new DingDingApiResultException(response["errcode"].AsInt32, response["errmsg"].AsString);
            }
        }
    }
}
