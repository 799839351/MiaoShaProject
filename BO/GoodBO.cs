using Beyondbit.Framework.Biz;
using DAO;
using Entity;
using System;
using System.Collections.Generic;

namespace BO
{
   public class GoodBO:BOBase<Good,GoodDAO>
    {

        /// <summary>
        /// 获取秒杀商品列表
        /// </summary>
        /// <returns></returns>
        public virtual IList<Good> GetGood()
        {
            return this.GetResult(() => DataAccess.GetGood());
        }

        /// <summary>
        /// 根据id获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Good GetGoodById(Int64 id)
        {
            return this.GetResult(() => DataAccess.GetGoodById(id));

        }

      
    }
}
