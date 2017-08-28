using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApl.BLL.DTO
{
   public class CartView
    {
        public BookView book { get; set; }
        public int count { get; set; }
    }
}
