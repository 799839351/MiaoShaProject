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
   public class MiaoShaUserBO:BOBase<MiaoShaUser, MiaoShaUserDAO>
    {

        public virtual MiaoShaUser Login(MiaoShaUser miaoShaUser)
        {
           return this.GetResult(() => DataAccess.Login(miaoShaUser));
        }
    }
}
