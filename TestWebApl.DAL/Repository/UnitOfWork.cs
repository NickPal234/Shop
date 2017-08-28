using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.DAL.EF;
using TestWebApl.DAL.Entites;
using TestWebApl.DAL.Interface;

namespace TestWebApl.DAL.Repository
{
    public class UnitOfWork 
    {
        private DataContext db=new DataContext();
        private ArticleRepository ar;
        private BookRepository br;
        private MagazineRepository mr;
        private WriterRepository wr;
        private ExceptionDetailRepository exr;
       


        public IRepository<Book> Books
        {
            get
            {
                if (br == null)
                    br = new BookRepository(db);
                return br;
            }
        }


        public IRepository<Writer> Writers
        {
            get
            {
                if (wr == null)
                    wr = new WriterRepository(db);
                return wr;
            }
        }

        public IRepository<Magazine> Magazines
        {
            get
            {
                if (mr == null)
                    mr = new MagazineRepository(db);
                return mr;
            }
        }

        public IRepository<Article> Articles
        {
            get
            {
                if (ar == null)
                    ar = new ArticleRepository(db);
                return ar;
            }
        }

        public IRepository<ExceptionDetail> ExceptionDetails
        {
            get
            {
                if (exr == null)
                    exr = new ExceptionDetailRepository(db);
                return exr;
            }
        }

       


        public void Save()
        {
            db.SaveChanges();
        }



        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
