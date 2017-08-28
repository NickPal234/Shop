using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApl.DAL.Entites
{
  public  class Magazine
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int NumberIssue { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

      
        public virtual ICollection<Article> Articles { get; set; }
    }
}
