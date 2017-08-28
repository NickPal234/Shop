using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApl.BLL.Interfaces;
using TestWebApl.BLL.Services;
using Ninject;

namespace TestWebApl.WEB.Util
{
    public class NinjectWeb : IDependencyResolver
    {
        IKernel kernal;
        public NinjectWeb(IKernel k)
        {
            kernal = k;
            AddBindgs();
        }
        public object GetService(Type serviceType)
        {
            return kernal.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernal.GetAll(serviceType);
        }

        public void AddBindgs()
        {
            //kernal.Bind<IService>().To<Service>();
        }
    }
}