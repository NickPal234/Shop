using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using TestWebApl.DAL.Entites;

namespace TestWebApl.DAL.EF
{
  public  class DataContext :DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<ExceptionDetail> ExceptionDetails { get; set; }
    

        public DataContext(string connectionString = @"Data Source=(LocalDb)\v11.0;Initial Catalog=67;Integrated Security=True")
            : base(connectionString)
        {
        }
    }
}
