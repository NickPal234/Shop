using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Services;
using TestWebApl.WEB.Filter;
using TestWebApl.WEB.Models;

namespace TestWebApl.WEB.Controllers
{
    public class ExceptionDetailViewsController : Controller
    {
        private ExceptionDetailService db = new ExceptionDetailService();

        // GET: ExceptionDetailViews
        public ActionResult Index()
        {
            return View(db.GetList());
        }

      


        [ExceptionLogger]
        public ActionResult Test(int id=4)
        {
            if (id > 3)
            {
                int[] mas = new int[2];
                mas[6] = 4;
            }
            else if (id < 3)
            {
                throw new Exception("id не может быть меньше 3");
            }
            else
            {
                throw new Exception("Некорректное значение для параметра id");
            }
            return View("Index");
        }

        

       

       
    }
}
