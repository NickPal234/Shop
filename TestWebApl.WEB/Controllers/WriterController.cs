using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Infrastructure;
using TestWebApl.BLL.Services;
using PagedList;
using PagedList.Mvc;

namespace TestWebApl.WEB.Controllers
{
    public class WriterController : Controller
    {
        WriterService db;
        public WriterController(WriterService w)
        {
            db = w;
        }
        public ActionResult Index(string sortOrder, string searchString, int page = 1, int pagesize = 3)

        {


            ViewData["SortName"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            IEnumerable<WriterView> writers = db.GetList();
            ViewData["CurrentSearch"] = searchString;
            if (searchString != null)
            {
                writers = writers.Where(t => t.Name.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    writers = writers.OrderByDescending(t => t.Name); break;
                default:
                    writers = writers.OrderBy(s => s.Name);
                    break;
            }

            return View(writers.ToPagedList(page, pagesize));
          
        }

        // GET: Writer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Writer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Writer/Create
        [HttpPost]
        public ActionResult Create(WriterView writer, HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                writer.ImageMimeType = Image.ContentType;
                writer.ImageData = new byte[Image.ContentLength];
                Image.InputStream.Read(writer.ImageData, 0, Image.ContentLength);
            }

            try
            {
                db.Create(writer);

                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: Writer/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Writer/Edit/5
        [HttpPost]
        public ActionResult Edit(WriterView writer)
        {
            try
            {
                db.Update(writer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Writer/Delete/5
        public ActionResult Delete(int id)
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

        // POST: Writer/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {
                db.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
