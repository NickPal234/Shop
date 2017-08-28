using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using TestWebApl.DAL.Interface;
using TestWebApl.DAL.Repository;

namespace TestWebApl.BLL.Util
{
    //public class NinjectModClass : NinjectModule
    //{
    //    private string connectionString;
    //    public NinjectModClass(string connection)
    //    {
    //        connectionString = connection;
    //    }

    //    public override void Load()
    //    {
    //        Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
    //    }
    //}
}
