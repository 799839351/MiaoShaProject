using Beyondbit.Framework.Biz;
using DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class OrderInfoBO:BOBase<OrderInfo, OrderInfoDAO>
    {
        /// <summary>
        /// 秒杀功能
        /// </summary>
        /// <param name="miaoShaUser"></param>
        /// <param name="good"></param>
        /// <returns></returns>
        public virtual OrderInfo MiaoSha(MiaoShaUser miaoShaUser, Good good)
        {
            return this.GetResult(() => DataAccess.MiaoSha(miaoShaUser, good));

        }

    }
}
