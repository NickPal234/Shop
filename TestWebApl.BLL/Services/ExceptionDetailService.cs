using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Interfaces;
using TestWebApl.DAL.Repository;
using TestWebApl.BLL.map;

namespace TestWebApl.BLL.Services
{
  public  class ExceptionDetailService : IService<ExceptionDetailView>
    {
        UnitOfWork repo = new UnitOfWork();
        public IEnumerable<ExceptionDetailView> GetList()
        {

            return ExeptionMap.GetListExeption (repo.ExceptionDetails.GetList());
        }

        public ExceptionDetailView Get(int? id)
        {
            return ExeptionMap.GetException(repo.ExceptionDetails.Get(id));
        }

        public void Create(ExceptionDetailView item)
        {
            var t = ExeptionMap.ReverseExep(item);
            repo.ExceptionDetails.Create(t);
            repo.Save();
        }

        public void Update(ExceptionDetailView item)
        {
            repo.ExceptionDetails.Delete(item.Id);
            repo.Save();
            var t = ExeptionMap.ReverseExep(item);
            repo.ExceptionDetails.Create(t);
            repo.Save();
        }

        public void Delete(int? id)
        {
            repo.ExceptionDetails.Delete(id);
        }
    }
}
