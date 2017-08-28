using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApl.BLL.DTO
{
  public  class MagazineView
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int NumberIssue { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }


        public ICollection<ArticleView> Articles { get; set; }
    }
}
