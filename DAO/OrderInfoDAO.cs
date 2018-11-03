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
    public class OrderInfoDAO : ObjectDAO<OrderInfo>
    {
        /// <summary>
        /// 秒杀功能
        /// </summary>
        /// <param name="miaoShaUser"></param>
        /// <param name="good"></param>
        /// <returns></returns>
        public OrderInfo MiaoSha(MiaoShaUser miaoShaUser, Good good)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"DECLARE @OrderIdPri bigint
                        SET @OrderIdPri=0
                        BEGIN TRY 
                        BEGIN TRAN 
                        update MiaoShaGood SET StockCount=StockCount-1 WHERE GoodId=@GoodId and StockCount>0
                        IF @@rowcount<=0   BEGIN
                        SELECT * FROM OrderInfo WHERE Id=@OrderIdPri
                        END
                        ELSE BEGIN
                        INSERT INTO [dbo].[OrderInfo]
                                   ([UserId]
                                   ,[GoodId]
                                   ,[DeliveryAddrId]
                                   ,[GoodName]
                                   ,[GoodCount]
                                   ,[GoodPrice]
                                   ,[OrderChannel]
                                   ,[Status]
                                   ,[CreateTime]
                                   ,[PayTime])
                             VALUES
                                   (@UserId
                                   ,@GoodId
                                   ,@DeliveryAddrId
                                   ,@GoodName
                        		   ,@GoodCount
                                   ,@GoodPrice
                                   ,@OrderChannel
                                   ,@Status
                                   ,GETDATE()
                                   ,GETDATE() )select @OrderIdPri=@@identity
                        INSERT INTO [dbo].[MiaoShaOrder]
                                   ([UserId]
                                   ,[OrderId]
                                   ,[GoodId])
                             VALUES
                                   (@UserId,@OrderIdPri,@GoodId)
                    SELECT * FROM OrderInfo WHERE Id=@OrderIdPri
                    END  COMMIT TRAN  END TRY  BEGIN CATCH  ROLLBACK TRAN   SELECT * FROM OrderInfo WHERE Id=0   END CATCH ");
            IDictionary param = new Hashtable();
            param.Add("GoodId", good.Id);
            param.Add("UserId", miaoShaUser.Id);
            param.Add("DeliveryAddrId", 0);
            param.Add("GoodName", good.Name);
            param.Add("GoodCount", 1);
            param.Add("GoodPrice", good.MiaoShaPrice);
            param.Add("OrderChannel", 0);
            param.Add("Status", 0);
           var list= base.Query(sb.ToString(), param);
            if (list!=null&& list.Count>0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

    }
}
