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
  public  class WriterRepository : IRepository<Writer>
    {
        DataContext db;

        public WriterRepository(DataContext dc)
        {
            db = dc;
        }
        
        public IEnumerable<Writer> GetList()
        {
            return db.Writers;
        }

        public Writer Get(int? id)
        {
            return db.Writers.Find(id);
        }

        public void Create(Writer item)
        {
            db.Writers.Add(item);
        }

        public void Update(Writer item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int? id)
        {
            Writer w = db.Writers.Find(id);
            if (w != null)
                db.Writers.Remove(w);
        }
       
    }
}
