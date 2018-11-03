using Beyondbit.Framework.Biz;
using Beyondbit.Framework.Sor.Attributes;
using Entity.Enum;
using System;

namespace Entity
{
    [Serializable]
    [Table("Users", SorMappingType.PublicProperty)]
    public class User: EntityBase
    {

        /// <summary>
        /// 用户ID 主键
        /// </summary>
        [Column("UserID", ColumnType.IdentityAndPrimaryKey)]
        public Int32 UserID { get; set; }

       
        public String UserUid { get; set; }
        /// <summary>
        /// 获取或设置用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置密码
        /// </summary>
       
        public string Password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
       
        public SexEnum Sex { get; set; }

        /// <summary>
        /// 获取或设置用户邮箱
        /// </summary>
      
        public string Email { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
       
        public int State { set; get; }

       
        public Boolean IsDeleted { set; get; }


       
        public DateTime CreateTime { get; set; }

        public String Remark { get; set; }
    }
}
