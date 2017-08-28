using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Services;
using PagedList;
using PagedList.Mvc;
using TestWebApl.BLL.Infrastructure;

namespace TestWebApl.WEB.Controllers.User
{
    public class UserWriterController : Controller
    {
        WriterService db;
        public UserWriterController(WriterService wr)
        {
            db = wr;
        }

        public ActionResult Index(string sortOrder, string searchString, int page = 1, int pagesize = 3)
        {
            ViewData["SortName"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CurrentSearch"] = searchString;


            IEnumerable<WriterView> writers = db.GetList();

            return View(writers.ToPagedList(page, pagesize));
        }
        public FileResult GetImage(int? id)
        {

            WriterView witer = db.Get(id);
            if (witer != null)
            {

                return File(witer.ImageData, witer.ImageMimeType);
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