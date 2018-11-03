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
    public class MiaoShaUserDAO:ObjectDAO<MiaoShaUser>
    {
        public MiaoShaUser Login(MiaoShaUser miaoShaUser)
        {
            if (miaoShaUser == null)
            {
                return miaoShaUser;
            }
            if (string.IsNullOrEmpty(miaoShaUser.Mobile))
            {
                return null;
            }
            if (string.IsNullOrEmpty(miaoShaUser.Password))
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(@" SELECT * FROM MiaoShaUser WHERE Mobile=@Mobile AND Password=@Password");
            IDictionary param = new Hashtable();
            param.Add("Mobile", miaoShaUser.Mobile);
            param.Add("Password", miaoShaUser.Password);

           var list= this.Query(sb.ToString(), param);
            if (list!=null&& list.Count>0)
            {
                miaoShaUser = list[0];
            }
            else
            {
                miaoShaUser = null;
            }
            return miaoShaUser;
        }

    }
}
