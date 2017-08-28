using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Services;
using PagedList.Mvc;
using PagedList;

namespace TestWebApl.WEB.Controllers.User
{
    public class UserArticleController : Controller
    {
        ArticleService db;
      public  UserArticleController(ArticleService art)
        {
            db = art;
        }
        // GET: UserArticle
      public ActionResult Index(string sortOrder, string searchString, int page = 1, int pagesize = 3)
      {
          ViewData["SortName"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
          ViewData["CurrentSearch"] = searchString;


          IEnumerable<ArticleView> art = db.GetList();

          return View(art.ToPagedList(page, pagesize));

      }
      public ActionResult Details(int id)
      {
          return View();
      }
      public FileResult GetImage(int? id)
      {

          ArticleView art = db.Get(id);
          if (art != null)
          {

              return File(art.ImageData, art.ImageMimeType);
          }
          else
          {
              return null;
          }

      }
    }
}