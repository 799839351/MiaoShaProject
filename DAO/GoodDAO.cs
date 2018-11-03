using Beyondbit.Framework.DataAccess.ObjectDAO;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class GoodDAO : ObjectDAO<Good>
    {
        /// <summary>
        /// 获取秒杀商品列表
        /// </summary>
        /// <returns></returns>
        public IList<Good> GetGood()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT  g.*,mg.MiaoShaPrice,
                       mg.StockCount,mg.StartDate,mg.EndDate
                      FROM MiaoShaGood mg LEFT JOIN Good g
                      ON mg.GoodId=g.Id");
          return  base.Query(sb.ToString());
        }

        /// <summary>
        /// 根据id获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Good GetGoodById(Int64 id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT  g.*,mg.MiaoShaPrice,
                       mg.StockCount,mg.StartDate,mg.EndDate
                      FROM MiaoShaGood mg LEFT JOIN Good g
                      ON mg.GoodId=g.Id");
            sb.Append(@" where g.Id=@Id");
            IDictionary param = new Hashtable();
            param.Add("Id",id);
            return base.Query(sb.ToString(),param)[0];
        }

        
    }
}
