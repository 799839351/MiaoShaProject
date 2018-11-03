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
    [Table("MiaoShaUser", SorMappingType.PublicProperty)]
    public class MiaoShaUser : EntityBase
    {
        [Column("Id", ColumnType.IdentityAndPrimaryKey)]
        public long Id { get; set; }

        public string NickName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Head { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public long LoginCount { get; set; }
        public string Mobile { get; set; }
    }
}
