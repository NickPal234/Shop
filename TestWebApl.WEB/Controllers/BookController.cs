using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Interfaces;
using TestWebApl.BLL.Services;
using TestWebApl.WEB.Models;
using PagedList;
using PagedList.Mvc;

namespace TestWebApl.WEB.Controllers
{
    
    public class BookController : Controller
    {
       BookService db;
       public BookController(BookService s)
        {
            db = s;
        }
        public ActionResult Index(string sortOrder , string searchString, int page=1, int pagesize=3)
        {
             ViewData["SortName"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
             ViewData["CurrentSearch"] = searchString;           
             IEnumerable<BookView> books = db.GetList( sortOrder, searchString);
                   
             return View(books.ToPagedList(page, pagesize));
          
        }

       

        
        public ActionResult Create()
        {
            var allWriter = db.GetAllWriter();
            var viewModel = new List<Assosiat<WriterView>>();
            foreach (var cour in allWriter)

            {

                viewModel.Add(new Assosiat<WriterView>
                {

                    ID = cour.id,
                    Name = cour.Name,
                    Assigned = false

                });
                
            }
            ViewBag.AllWriter = viewModel;
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BookView book, string[] selected, HttpPostedFileBase Image)
        {

            ExploreData.EditBook(book, selected, db, Image);
          
           
                return RedirectToAction("Index");
            }
           

        // GET: Book/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {

            var allWriter = db.GetAllWriter();
            var cc = db.Get(id);
            var bookWriter = new HashSet<int>(cc.Writers.Select(c=>c.id));
            var viewModel = new List<Assosiat<WriterView>>();
            foreach (var cour in allWriter)
            {
                Assosiat<WriterView> ass = new Assosiat<WriterView>();
                ass.Assigned = bookWriter.Contains(cour.id);
                ass.Name = cour.Name;
                ass.ID = cour.id;
                viewModel.Add(ass);

                 
            }



            ViewBag.AllWriter = viewModel;
            
            return View(db.Get(id));
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(BookView book, string[] selectedCourses)
        {
            ExploreData.EditBook(book, selectedCourses, db);              
            return RedirectToAction("Index");
          
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Get(id));
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id )
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
