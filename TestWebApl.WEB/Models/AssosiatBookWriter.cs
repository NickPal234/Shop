using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApl.WEB.Models
{
    public class Assosiat<T>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; } 
    }
}