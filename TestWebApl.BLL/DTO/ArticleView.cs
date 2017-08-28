using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApl.BLL.DTO
{
  public  class ArticleView
    {
        public int id { get; set; }
        public string Name { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public ICollection<WriterView> Writers { get; set; }
        public ICollection<MagazineView> Magazines { get; set; }
    }
}
