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
  public  class BookRepository : IRepository<Book>
    {
        private DataContext db;

        public BookRepository(DataContext context)
        {
            db = context;
        }
        

        public IEnumerable<Book> GetList()
        {
            return db.Books.ToList();
        }

        public Book Get(int? id)
        {
            return db.Books.Find(id);
        }

        public void Create(Book item)
        {
            db.Books.Add(item);
        
        }

        public void Update(Book item)
        {
            
           
          
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
         
        }

        public void Delete(int? id)
        {
            Book b = db.Books.Find(id);
            if (b != null)
            {
                db.Books.Remove(b);
             
            }

        }
      


   

    }
}
