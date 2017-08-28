using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApl.DAL.Entites
{
  public  class Writer
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BornYear { get; set; }

        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
        public string Biografy { get; set; }
       
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
