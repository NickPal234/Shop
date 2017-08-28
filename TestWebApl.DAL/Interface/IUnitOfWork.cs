using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.DAL.Entites;

namespace TestWebApl.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Writer> Writers { get; }
        IRepository<Magazine> Magazines { get; }
        IRepository<Article> Articles { get; }
        IRepository<ExceptionDetail> ExceptionDetails { get; }
        void Save();
    }
}
