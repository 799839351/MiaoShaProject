using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ResponseResult
    {
        /// <summary>
        /// 返回代码. 0-失败，1-成功，其他-具体见方法返回值说明
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public dynamic Data { get; set; }

        private ResponseResult(dynamic data)
        {
            this.Code = "1";
            this.Message = "success";
            this.Data = data;
        }

        private ResponseResult(CodeMessage data)
        {
            if (data==null)
            {
                return ;
            }
            this.Code = data.Code;
            this.Message = data.Message;
        }

        public static ResponseResult Succeed(dynamic data)
        {
            return new ResponseResult(data);
        }

        public static ResponseResult Error(CodeMessage msg)
        {
            return new ResponseResult(msg);
        }

       
    }
}
