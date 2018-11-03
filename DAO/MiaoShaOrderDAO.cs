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
    public class MiaoShaOrderDAO : ObjectDAO<MiaoShaOrder>
    {
        public MiaoShaOrder GetMiaoshaOrderByUserIdGoodsId(Int64 userId, Int64 goodId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM MiaoShaOrder WHERE UserId=@UserId AND GoodId=@GoodId");
            IDictionary param = new Hashtable();
            param.Add("UserId", userId);
            param.Add("GoodId", goodId);
            var list = Query(sb.ToString(), param);
            if (list != null && list.Count > 0)
                return list[0];
            else
                return null;
        }
    }
}
