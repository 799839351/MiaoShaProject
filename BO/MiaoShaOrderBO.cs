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
    public class MiaoShaOrderBO : BOBase<MiaoShaOrder, MiaoShaOrderDAO>
    {
        public virtual MiaoShaOrder GetMiaoshaOrderByUserIdGoodsId(Int64 userId, Int64 goodId)
        {
            return this.GetResult(() => DataAccess.GetMiaoshaOrderByUserIdGoodsId(userId, goodId));
        }
    }
}
