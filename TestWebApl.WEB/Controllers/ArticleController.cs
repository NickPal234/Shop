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
using TestWebApl.WEB.Models;

namespace TestWebApl.WEB.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        ArticleService db;

        public ArticleController(ArticleService d)
        {
            db = d;
        }
        // GET: Article
        public ActionResult Index(string sortOrder, string searchString, int page = 1, int pagesize = 3)
        {
            ViewData["SortName"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            IEnumerable<ArticleView> articls = db.GetList();
            ViewData["CurrentSearch"] = searchString;
            if (searchString != null)
            {
                articls = articls.Where(t => t.Name.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    articls = articls.OrderByDescending(t => t.Name); break;
                default:
                    articls = articls.OrderBy(s => s.Name);
                    break;
            }


            return View(articls.ToPagedList(page, pagesize));
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            ViewBag.AllWriter = db.GetAllWriter();
            ViewBag.AllMagazine = db.GetAllMagazine();
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(ArticleView art, string[] selectedWriter,  string[] selectedMagazine, HttpPostedFileBase File)
        {

            ExploreData.EditArtilce(art, selectedWriter, selectedMagazine, db, File);

              
                return RedirectToAction("Index");
            
           
        }


        // GET: Article/Edit/5
        public ActionResult Edit(int? id)
        {

            var allWriter = db.GetAllWriter();
            var cc = db.Get(id);
            var bookWriter = new HashSet<int>(cc.Writers.Select(c => c.id));
            var viewModel = new List<Assosiat<WriterView>>();
            foreach (var cour in allWriter)
            {
                Assosiat<WriterView> ass = new Assosiat<WriterView>();
                ass.Assigned = bookWriter.Contains(cour.id);
                ass.Name = cour.Name;
                ass.ID = cour.id;
                viewModel.Add(ass);


            }

            var allMagazine = db.GetAllMagazine();
            var magaz = db.Get(id);
            var bookMag = new HashSet<int>(magaz.Magazines.Select(c => c.id));
            var viewMag = new List<Assosiat<MagazineView>>();
            foreach (var cour in allMagazine)
            {
                Assosiat<MagazineView> ass = new Assosiat<MagazineView>();
                ass.Assigned = bookMag.Contains(cour.id);
                ass.Name = cour.Name;
                ass.ID = cour.id;
                viewMag.Add(ass);


            }



            ViewBag.AllMagazine = viewMag;
            ViewBag.AllWriter = viewModel;

            return View(db.Get(id));
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(ArticleView art, string[] selectedWriter,  string[] selectedMagazine)
        {

            ExploreData.EditArtilce(art, selectedWriter, selectedMagazine, db);

            return RedirectToAction("Index");
        }

        // GET: Article/Delete/5
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

        // POST: Article/Delete/5
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
