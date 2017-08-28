using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApl.DAL.Entites
{
   public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountPage { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Writer> Writers { get; set; }
    }
}
