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
    public class MagazineController : Controller
    {
        MagazineService db;
        public MagazineController(MagazineService d)
        {
            db = d;
        }
        public ActionResult Index(string sortOrder, string searchString, int page = 1, int pagesize = 3)
        {
            ViewData["SortName"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            IEnumerable<MagazineView> magazines = db.GetList();
            ViewData["CurrentSearch"] = searchString;
            if (searchString != null)
            {
                magazines = magazines.Where(t => t.Name.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    magazines = magazines.OrderByDescending(t => t.Name); break;
                default:
                    magazines = magazines.OrderBy(s => s.Name);
                    break;
            }


            return View(magazines.ToPagedList(page, pagesize));
        }

        // GET: Magazine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Magazine/Create
        public ActionResult Create()
        {
            var allArticle = db.GetAllArticle();
            var viewModel = new List<Assosiat<ArticleView>>();
            foreach (var cour in allArticle)
            {

                viewModel.Add(new Assosiat<ArticleView>
                {

                    ID = cour.id,
                    Name = cour.Name,
                    Assigned = false

                });
                
            }
            ViewBag.AllArticle = viewModel;
            return View();
        }

        // POST: Magazine/Create
        [HttpPost]
        public ActionResult Create(MagazineView mag, string[] selected, HttpPostedFileBase File)
        {
          
            ExploreData.EditMagazine(mag, selected, db, File);
            return RedirectToAction("Index");
        }

        // GET: Magazine/Edit/5
        public ActionResult Edit(int? id)
        {

            var allArticle = db.GetAllArticle();
            var cc = db.Get(id);
            var art = new HashSet<int>(cc.Articles.Select(c => c.id));
            var viewModel = new List<Assosiat<ArticleView>>();
            foreach (var cour in allArticle)
            {
                Assosiat<ArticleView> ass = new Assosiat<ArticleView>();
                ass.Assigned = art.Contains(cour.id);
                ass.Name = cour.Name;
                ass.ID = cour.id;
                viewModel.Add(ass);


            }

            ViewBag.AllArticle = viewModel;

            return View(db.Get(id));



           
        }

        // POST: Magazine/Edit/5
        [HttpPost]
        public ActionResult Edit(MagazineView mag, string[] selectedCourses)
        {
          

            ExploreData.EditMagazine(mag, selectedCourses, db);

            return RedirectToAction("Index");
        }

        // GET: Magazine/Delete/5
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

        // POST: Magazine/Delete/5
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
