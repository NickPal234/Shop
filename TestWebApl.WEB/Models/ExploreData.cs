using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Services;
using TestWebApl.BLL.Interfaces;

namespace TestWebApl.WEB.Models
{
    public static class ExploreData
    {
        public static void EditBook(BookView book, string[] selectedCourses, BookService db, HttpPostedFileBase Image=null)
        {

            if (selectedCourses == null)
            {
                selectedCourses = new string[] { };

            }
             if (Image != null)
                {
                    book.ImageMimeType = Image.ContentType;
                    book.ImageData = new byte[Image.ContentLength];
                    Image.InputStream.Read(book.ImageData, 0, Image.ContentLength);
                }

            WriterService ws = new WriterService();
            var selectedCoursesHS = new HashSet<string>(selectedCourses);


            var allwriter = db.GetAllWriter();
            var newwriter = new List<WriterView>();

            book.Writers = new List<WriterView>();

            foreach (var t in allwriter)
            {

                if (selectedCoursesHS.Contains(t.id.ToString()))
                {

                    book.Writers.Add(t);


                }

            }



            db.Update(book);
        }



        public static void EditMagazine(MagazineView mag, string[] selectedCourses, MagazineService db, HttpPostedFileBase File = null)
        {
            if (selectedCourses == null)
            {
                selectedCourses = new string[] { };

            }
            if (File != null)
            {
                mag.ImageMimeType = File.ContentType;
                mag.ImageData = new byte[File.ContentLength];
                File.InputStream.Read(mag.ImageData, 0, File.ContentLength);
            }
            WriterService ws = new WriterService();
            var selectedCoursesHS = new HashSet<string>(selectedCourses);
          

            var allwriter = db.GetAllArticle();
            var newwriter = new List<ArticleView>();

            mag.Articles = new List<ArticleView>();

            foreach (var t in allwriter)
            {

                if (selectedCoursesHS.Contains(t.id.ToString()))
                {

                    mag.Articles.Add(t);


                }

            }



            db.Update(mag);

        }


        public static void EditArtilce(ArticleView art, string[] selectedWriter, string[] selectedMagazine, ArticleService db, HttpPostedFileBase File=null)
        {
            if (selectedWriter == null)
            {
                selectedWriter = new string[] { };

            }

            if (File != null)
            {
                art.ImageMimeType = File.ContentType;
                art.ImageData = new byte[File.ContentLength];
                File.InputStream.Read(art.ImageData, 0, File.ContentLength);
            }

            WriterService ws = new WriterService();
            var selectedCoursesHS = new HashSet<string>(selectedWriter);
            

            var allwriter = db.GetAllWriter();
            var newwriter = new List<WriterView>();

            art.Writers = new List<WriterView>();

            foreach (var t in allwriter)
            {

                if (selectedCoursesHS.Contains(t.id.ToString()))
                {

                    art.Writers.Add(t);


                }

            }


            db.Update(art);

            //db.Update(art);
            if (selectedMagazine == null)
            {
                selectedMagazine = new string[] { };

            }

            

            MagazineService ms = new MagazineService();
            var selectedHS = new HashSet<string>(selectedMagazine);
          

            var allmag = db.GetAllMagazine();
            var newmag = new List<MagazineView>();

            art.Magazines = new List<MagazineView>();

            foreach (var t in allmag)
            {

                if (selectedHS.Contains(t.id.ToString()))
                {

                    art.Magazines.Add(t);


                }

            }








            db.Update(art);
        }

        //public static void EditBook()
        //{

        //}
    }
}