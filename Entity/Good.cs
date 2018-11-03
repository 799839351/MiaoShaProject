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
    [Table("Good", SorMappingType.PublicProperty)]
    public class Good : EntityBase
    {
        [Column("Id", ColumnType.IdentityAndPrimaryKey)]
        /// <summary>
        /// Id
        /// </summary>		
        public Int64 Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// Title
        /// </summary>		
        public string Title { get; set; }
        /// <summary>
        /// Img
        /// </summary>		
        public string Img { get; set; }
        /// <summary>
        /// Detail
        /// </summary>		
        public string Detail { get; set; }
        /// <summary>
        /// Price
        /// </summary>		
        public decimal Price { get; set; }
        /// <summary>
        /// Stock
        /// </summary>		
        public Int64 Stock { get; set; }

        #region 秒杀商品表的信息
        /// <summary>
        /// MiaoShaPrice
        /// </summary>		
        [Column("MiaoShaPrice", ColumnType.ReadOnly)]
        public decimal MiaoShaPrice { get; set; }
        /// <summary>
        /// StockCount
        /// </summary>		
        [Column("StockCount", ColumnType.ReadOnly)]
        public int StockCount { get; set; }
        /// <summary>
        /// StartDate
        /// </summary>		
        [Column("StartDate", ColumnType.ReadOnly)]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// EndDate
        /// </summary>		
        [Column("EndDate", ColumnType.ReadOnly)]
        public DateTime? EndDate { get; set; }
        #endregion


    }
}
