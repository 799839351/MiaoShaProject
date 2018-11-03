using Beyondbit.Framework.Biz;
using Beyondbit.Framework.Sor.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Serializable]
    [Table("OrderInfo", SorMappingType.PublicProperty)]
    public class OrderInfo : EntityBase
    {
        [Column("Id", ColumnType.IdentityAndPrimaryKey)]
        /// <summary>
        /// Id
        /// </summary>		
        public long Id { get; set; }
        /// <summary>
        /// UserId
        /// </summary>		
        public long UserId { get; set; }
        /// <summary>
        /// GoodId
        /// </summary>		
        public long GoodId { get; set; }
        /// <summary>
        /// DeliveryAddrId
        /// </summary>		
        public long DeliveryAddrId { get; set; }
        /// <summary>
        /// GoodName
        /// </summary>		
        public string GoodName { get; set; }
        /// <summary>
        /// GoodCount
        /// </summary>		
        public int GoodCount { get; set; }
        /// <summary>
        /// GoodPrice
        /// </summary>		
        public decimal GoodPrice { get; set; }
        /// <summary>
        /// OrderChannel
        /// </summary>		
        public int OrderChannel { get; set; }
        /// <summary>
        /// Status
        /// </summary>		
        public int Status { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>		
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// PayTime
        /// </summary>		
        public DateTime PayTime { get; set; }
    }
}
