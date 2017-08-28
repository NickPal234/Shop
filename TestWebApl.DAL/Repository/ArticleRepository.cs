using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.DAL.EF;
using TestWebApl.DAL.Entites;
using TestWebApl.DAL.Interface;
using AutoMapper;


namespace TestWebApl.DAL.Repository
{
   public class ArticleRepository: IRepository<Article>
    {
        private DataContext db;
        public ArticleRepository(DataContext s)
        {
            
            db = s;
        }
       
        public IEnumerable<Article> GetList()
        {

             return   db.Articles.ToList();

           
        }

        public Article Get(int? id)
        {

            return db.Articles.Find(id);
        }

        public void Create(Article item)
        {
            db.Articles.Add(item);
        }

        public void Update(Article item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int? id)
        {
            Article a = db.Articles.Find(id);
            if (a != null)
                db.Articles.Remove(a);

        }
       

    }
}
