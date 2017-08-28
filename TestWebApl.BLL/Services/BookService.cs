
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Infrastructure;
using TestWebApl.BLL.Interfaces;
using TestWebApl.BLL.map;
using TestWebApl.DAL.EF;
using TestWebApl.DAL.Entites;
using TestWebApl.DAL.Interface;
using TestWebApl.DAL.Repository;


namespace TestWebApl.BLL.Services
{
    public class BookService 
    {
        UnitOfWork repo = new UnitOfWork();
        public IEnumerable<BookView> GetList(string sortOrder=null, string searchString=null )
        {
            var books = CustomMap.GetListBook(repo.Books.GetList());
            if (searchString != null  )
            {
                books = books.Where(t => t.Name.Contains(searchString));
            }
            if (sortOrder=="name_desc")
            {
                
                books = books.OrderByDescending(t => t.Name);
            }
            books = books.OrderBy(s => s.Name);

            return books;
        }

        public BookView Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id ", "");

            var book = CustomMap.GetBook(repo.Books.Get(id));
                 if (book == null)
                throw new ValidationException(" Не найден", "");
                 return book;
        }

        public void Create(BookView item)
        {
            if (item != null)
            {
              

                Book newbok = CustomMap.ReverseBook(item);
                repo.Books.Create(newbok);
                repo.Save();
                return;
            }
            throw new ValidationException("Объект не создан", "");

        }

        public void Update(BookView item)
        {

            Book newbok = CustomMap.ReverseBook(item);
            repo.Books.Delete(item.Id);


            List<Writer> writer = new List<Writer>();
           
            foreach (Writer w in newbok.Writers)
            {
               
                writer.Add(repo.Writers.Get(w.id));
             
            }
            
           newbok.Writers = writer;
           foreach (Writer w in newbok.Writers)
            {

                w.Books.Add(newbok);

            }
           repo.Books.Create(newbok);
           repo.Save();
        }

        public void Delete(int? id)
        {
            repo.Books.Delete(id);
            repo.Save();
        }
        public IEnumerable<WriterView> GetAllWriter()
        {
            return CustomMap.GetListWriter(repo.Writers.GetList());
      
        }
    }
}
