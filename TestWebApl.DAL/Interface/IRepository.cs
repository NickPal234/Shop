﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApl.DAL.Interface
{
   public interface IRepository<T>  
    {
        IEnumerable<T> GetList();
        T Get(int? id);
        void Create(T item);
        void Update(T item);
        void Delete(int? id);
        
    }
}
