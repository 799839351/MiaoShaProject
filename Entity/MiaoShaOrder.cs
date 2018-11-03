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
    [Table("MiaoShaOrder", SorMappingType.PublicProperty)]
    public class MiaoShaOrder : EntityBase
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
        /// OrderId
        /// </summary>		
        public long OrderId { get; set; }
        /// <summary>
        /// GoodId
        /// </summary>		
        public long GoodId { get; set; }
    }
}
