using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Interfaces;
using TestWebApl.DAL.Interface;

using TestWebApl.DAL.Entites;
using TestWebApl.BLL.Infrastructure;
using TestWebApl.DAL.Repository;
using TestWebApl.BLL.map;

namespace TestWebApl.BLL.Services
{
  public  class MagazineService  
    {
      UnitOfWork repo = new UnitOfWork();
        public IEnumerable<MagazineView> GetList()
        {
            
            return CustomMap.GetListMagazine(repo.Magazines.GetList()) ;
        }

        public MagazineView Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id ", "");

            var mag = CustomMap.GetMagazine(repo.Magazines.Get(id));
            if (mag == null)
                throw new ValidationException(" Не найден", "");
            return mag;
        }

        public void Create(MagazineView item)
        {
            if (item != null)
            {

                Magazine r = CustomMap.ReverseMagazine(item);
                repo.Magazines.Create(r);
                repo.Save();
            }
            return;
        }

        public void Update(MagazineView item)
        {

            Magazine r = CustomMap.ReverseMagazine(item);
            repo.Magazines.Delete(item.id);


            List<Article> article = new List<Article>();

            foreach (Article w in r.Articles)
            {

                article.Add(repo.Articles.Get(w.id));

            }

            r.Articles = article;
            foreach (Article w in r.Articles)
            {

                w.Magazines.Add(r);

            }
            repo.Magazines.Create(r);
            repo.Save();
        }

        public void Delete(int? id)
        {
            repo.Magazines.Delete(id);
            repo.Save();
        }

        public IEnumerable<ArticleView> GetAllArticle()
        {
            return CustomMap.GetListArticle(repo.Articles.GetList());

        }
    }
}
