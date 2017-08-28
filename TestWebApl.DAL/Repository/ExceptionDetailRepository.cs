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
    public class ExceptionDetailRepository : IRepository<ExceptionDetail>
    {
        DataContext db;
        public ExceptionDetailRepository(DataContext d)
        {
            db = d;
        }

        public IEnumerable<ExceptionDetail> GetList()
        {
            return db.ExceptionDetails;
        }

        public ExceptionDetail Get(int? id)
        {
            return db.ExceptionDetails.Find(id);
        }

        public void Create(ExceptionDetail item)
        {
            db.ExceptionDetails.Add(item);
        }

        public void Update(ExceptionDetail item)
        {
          
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int? id)
        {
            ExceptionDetail m = db.ExceptionDetails.Find(id);
            if (m != null)
                db.ExceptionDetails.Remove(m);
        }
    }
}
