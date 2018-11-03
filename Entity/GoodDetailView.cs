using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class GoodDetailView
    {

        public Int32 MiaoShaStatus { set; get; }
        public Double RemainSeconds { set; get; }
        public Good Good { set; get; }
        public MiaoShaUser User { set; get; }

    }
}
