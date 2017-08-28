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
  public  class MagazineRepository : IRepository<Magazine>
    {
        DataContext db;
        public MagazineRepository(DataContext d)
        {
            db = d;
        }
       
        public IEnumerable<Magazine> GetList()
        {
            return db.Magazines;
        }

        public Magazine Get(int? id)
        {
            return db.Magazines.Find(id);
        }

        public void Create(Magazine item)
        {
            db.Magazines.Add(item);
        }

        public void Update(Magazine item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int? id)
        {
            Magazine m = db.Magazines.Find(id);
            if (m != null)
                db.Magazines.Remove(m);
        }
      
    }
}
