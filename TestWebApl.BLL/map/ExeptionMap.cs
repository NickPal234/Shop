using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.BLL.DTO;
using TestWebApl.DAL.Entites;

namespace TestWebApl.BLL.map
{
  static public  class ExeptionMap
    {
        public static List<ExceptionDetailView> GetListExeption(IEnumerable<ExceptionDetail> data)
        {
            Mapper.Initialize(p =>
            {
                p.CreateMap<ExceptionDetail, ExceptionDetailView>();
               
            });
            return Mapper.Map<IEnumerable<ExceptionDetail>, List<ExceptionDetailView>>(data);
        }
        public static ExceptionDetailView GetException(ExceptionDetail exeption)
        {

            Mapper.Initialize(p =>
            {
                p.CreateMap<ExceptionDetail, ExceptionDetailView>();
                
            });



            return Mapper.Map<ExceptionDetail, ExceptionDetailView>(exeption);
        }

        public static ExceptionDetail ReverseExep(ExceptionDetailView item)
        {

            Mapper.Initialize(p =>
            {
                p.CreateMap<ExceptionDetailView, ExceptionDetail>();
               
            });

            return Mapper.Map<ExceptionDetailView, ExceptionDetail>(item); ;

        }
    }
}
