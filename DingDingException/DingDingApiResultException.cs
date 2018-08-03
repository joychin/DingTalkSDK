using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSDK.DingDingException
{
    public class DingDingApiResultException : DingDingApiException
    {
        public static readonly int ERR_RESULT_RESOLUTION = -2;

        public DingDingApiResultException(String field) : base(ERR_RESULT_RESOLUTION, "Cannot resolve field " + field + " from oapi resonpse")
        {
        }
        public DingDingApiResultException(int errCode,string errMsg):base(errCode,errMsg)
        {

        }
    }
}
