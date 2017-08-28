
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Infrastructure;
using TestWebApl.BLL.Interfaces;
using TestWebApl.DAL.Entites;
using TestWebApl.DAL.Interface;
using TestWebApl.DAL.Repository;
using TestWebApl.BLL.map;

namespace TestWebApl.BLL.Services
{
   public class WriterService  
    {
       UnitOfWork repo = new UnitOfWork();
        public IEnumerable<WriterView> GetList()
        {

            return CustomMap.GetListWriter(repo.Writers.GetList());
        }

        public WriterView Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id ", "");

            var writer = CustomMap.GetWriter(repo.Writers.Get(id));
            if (writer == null)
                throw new ValidationException(" Не найден", "");
            return writer;
        }

        public void Create(WriterView item)
        {
            if (item != null)
            {
                
                Writer newart = CustomMap.ReverseWriter(item);
                repo.Writers.Create(newart);
                repo.Save();
                return;
            }
            throw new ValidationException("Объект не создан", "");
        }

        public void Update(WriterView item)
        {

            Writer writer = CustomMap.ReverseWriter(item);
            repo.Writers.Update(writer);
            repo.Save();
        }

        public void Delete(int? id)
        {
            repo.Writers.Delete(id);
            repo.Save();
        }

        public IEnumerable<ArticleView> GetAllArticle()
        {
            return CustomMap.GetListArticle(repo.Articles.GetList());

        }
        public IEnumerable<BookView> GetAllBook()
        {
            return CustomMap.GetListBook(repo.Books.GetList());

        }
    }
}
