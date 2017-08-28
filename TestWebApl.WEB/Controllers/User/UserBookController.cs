using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Services;
using PagedList;
using PagedList.Mvc;
using System.Threading;
using TestWebApl.BLL.Infrastructure;

namespace TestWebApl.WEB.Controllers
{
    public class UserBookController : Controller
    {
       BookService db;
       public UserBookController(BookService s)
        {
            db = s;
        }
       public ActionResult Index(string sortOrder, string searchString, int page = 1, int pagesize = 3)
        {
            ViewData["SortName"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentSearch"] = searchString;     
            

             IEnumerable<BookView> books = db.GetList(sortOrder, searchString);

             return View(books.ToPagedList(page, pagesize));
          
        }
       public PartialViewResult Menu()
       {
           IEnumerable<string> categories = db.GetList()
               .Select(book => book.Name)
               .Distinct()
               .OrderBy(x => x);
           return PartialView(categories);
       }
       
       
        public FileResult GetImage(int? id)
        {

            BookView book = db.Get(id);
            if (book != null)
            {

                return File(book.ImageData, book.ImageMimeType);
            }
            else
            {
                return null;
            }

        }
        public ActionResult Details(int id)
        {
            try
            {
                return View(db.Get(id));
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
    }
}