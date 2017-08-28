using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.BLL.DTO;

namespace TestWebApl.BLL.Interfaces
{
    public interface IService <T>
    {
        IEnumerable<T> GetList();
        T Get(int? id);
        void Create(T item);
        void Update(T item);
        void Delete(int? id);
    }
}
