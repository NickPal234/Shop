using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApl.BLL.Services;

namespace TestWebApl.WEB.Models
{
    public class CartIndex
    {
        public CartServices Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}