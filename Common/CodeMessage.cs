using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CodeMessage
    {
        public String Code { get; set; }
        public String Message { get; set; }
        private CodeMessage(String code, String message)
        {
            this.Code = code;
            this.Message = message;
        }

        //订单异常
        public static CodeMessage Suceess = new CodeMessage("1", "suceess");


        //登陆异常
        public static CodeMessage LoginError = new CodeMessage("2", "用户名或者密码不正确");

        /// <summary>
        /// 商品秒杀完毕
        /// </summary>
        public static CodeMessage MiaoShaOverError = new CodeMessage("500520", "商品已经秒杀完毕");

        /// <summary>
        /// 重复秒杀
        /// </summary>
        public static CodeMessage MiaoShaRepeat = new CodeMessage("500521", "商品不能重复秒杀");

    }
}
