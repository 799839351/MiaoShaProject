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
    [Table("MiaoShaGood", SorMappingType.PublicProperty)]
    public class MiaoShaGood : EntityBase
    {
        [Column("Id", ColumnType.IdentityAndPrimaryKey)]
        /// <summary>
        /// Id
        /// </summary>		
        public long Id { get; set; }
        /// <summary>
        /// GoodId
        /// </summary>		
        public long GoodId { get; set; }
        /// <summary>
        /// MiaoShaPrice
        /// </summary>		
        public decimal MiaoShaPrice { get; set; }
        /// <summary>
        /// StockCount
        /// </summary>		
        public int StockCount { get; set; }
        /// <summary>
        /// StartDate
        /// </summary>		
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// EndDate
        /// </summary>		
        public DateTime? EndDate { get; set; }

    }
}
