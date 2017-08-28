using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApl.BLL.DTO
{
  public  class WriterView
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

        public ICollection<ArticleView> Articles { get; set; }
        public virtual ICollection<BookView> Books { get; set; }
    }
}
