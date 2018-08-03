using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingTalkSDK.DingDingException
{
    public class DingDingApiException:Exception
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public DingDingApiException(int errCode, String errMsg) : base("error code: " + errCode + ", error message: " + errMsg)
        {
            ErrCode = errCode;
            ErrMsg = errMsg;
        }

        public void printStackTrace()
        {
            Console.WriteLine(string.Format("errCode={0} errMsg={1}", ErrCode, ErrMsg));
        }
    }
}

