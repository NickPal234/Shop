using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Infrastructure;
using TestWebApl.BLL.Interfaces;
using AutoMapper;
using TestWebApl.BLL.map;
using TestWebApl.DAL.Repository;
using TestWebApl.DAL.Entites;


namespace TestWebApl.BLL.Services
{
  public class ArticleService 
    {
      UnitOfWork repo = new UnitOfWork();
        public IEnumerable<ArticleView> GetList()
        {
            
            return CustomMap.GetListArticle(repo.Articles
                .GetList());
        }

        public ArticleView Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id ", "");

            var art = CustomMap.GetArticle(repo.Articles.Get(id));
            if (art == null)
                throw new ValidationException(" Не найден", "");
            return art;
        }

        public void Create(ArticleView item)
        {
            if (item != null)
            {

                Article newart = CustomMap.ReverseArticle(item);
                repo.Articles.Create(newart);
                repo.Save();
                return;
            }
            throw new ValidationException("Объект не создан", "");
        }
        public void Update(ArticleView item)
        {
            Article newart = CustomMap.ReverseArticle(item);
            repo.Articles.Update(newart);
            repo.Save();
        }

     

        public void Delete(int? id)
        {
            repo.Articles.Delete(id);
            repo.Save();
        }

        public IEnumerable<MagazineView> GetAllMagazine()
        {
            return CustomMap.GetListMagazine(repo.Magazines.GetList());

        }
        public IEnumerable<WriterView> GetAllWriter()
        {
            return CustomMap.GetListWriter(repo.Writers.GetList());

        }
    }
}
