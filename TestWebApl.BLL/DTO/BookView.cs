using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl;
using TestWebApl.BLL.Services;

namespace TestWebApl.BLL.DTO
{
  public  class BookView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountPage { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
      
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WriterView> Writers { get; set; }

         
    }
}
