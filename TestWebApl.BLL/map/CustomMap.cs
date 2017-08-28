using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApl.BLL.DTO;
using TestWebApl.DAL.Entites;

namespace TestWebApl.BLL.map
{
   
        public static class CustomMap
        {
            //Article
            public static List<ArticleView> GetListArticle(IEnumerable<Article> data)
            {
                Mapper.Initialize(p =>
                {
                    p.CreateMap<Article, ArticleView>();
                    p.CreateMap<Writer, WriterView>().ForMember(c => c.Books, d => d.Ignore());
                    p.CreateMap<Magazine, MagazineView>();


                });
                return Mapper.Map<IEnumerable<Article>, List<ArticleView>>(data);
            }
            public static ArticleView GetArticle(Article article)
            {

                Mapper.Initialize(p =>
                {
                    p.CreateMap<Article, ArticleView>();
                    p.CreateMap<Writer, WriterView>().ForMember(c => c.Books, d => d.Ignore());
                    p.CreateMap<Magazine, MagazineView>();
                });



                return Mapper.Map<Article, ArticleView>(article);
            }

            public static Article ReverseArticle(ArticleView item)
            {

                Mapper.Initialize(p =>
                {
                    p.CreateMap<ArticleView, Article>();
                    p.CreateMap<WriterView, Writer>().ForMember(c => c.Articles, d => d.Ignore()).ForMember(c=>c.Books, d=>d.Ignore());
                    p.CreateMap<MagazineView, Magazine>().ForMember(c => c.Articles, d => d.Ignore());
                });

                return Mapper.Map<ArticleView, Article>(item); ;

            }

            //Book
            public static IEnumerable<BookView> GetListBook(IEnumerable<Book> book)
            {

                Mapper.Initialize(p =>
                {
                    p.CreateMap<Book, BookView>();
                    p.CreateMap<Writer, WriterView>().ForMember(c => c.Articles, d => d.Ignore());
                });
                return Mapper.Map<IEnumerable<Book>, List<BookView>>(book);
            }

            public static BookView GetBook(Book book)
            {
                

               
                            Mapper.Initialize(p =>
                            {
                                p.CreateMap<Book, BookView>();
                                p.CreateMap<Writer, WriterView>().ForMember(c => c.Articles, d => d.Ignore());
                            });

               
                return Mapper.Map<Book, BookView>(book);
            }

            public static Book ReverseBook(BookView book)
            {

                Mapper.Initialize(p =>
                {
                    p.CreateMap<BookView, Book>();
                    p.CreateMap<WriterView, Writer>().ForMember(c => c.Articles, d => d.Ignore());
                    
                });


                return Mapper.Map<BookView, Book>(book);

            }

            //Magazine
            public static IEnumerable<MagazineView> GetListMagazine(IEnumerable<Magazine> magazine)
            {
                Mapper.Initialize(p =>
                {
                    p.CreateMap<Magazine, MagazineView>();
                    p.CreateMap<Article, ArticleView>().ForMember(c => c.Writers, d => d.Ignore());
                });
            

                return Mapper.Map<IEnumerable<Magazine>, List<MagazineView>>(magazine);
            }

            public static MagazineView GetMagazine(Magazine magazine)
            {

                Mapper.Initialize(p =>
                {
                    p.CreateMap<Magazine, MagazineView>();
                    p.CreateMap<Article, ArticleView>().ForMember(c => c.Writers, d => d.Ignore());
                });
                return Mapper.Map<Magazine, MagazineView>(magazine);
            }

            public static Magazine ReverseMagazine(MagazineView item)
            {

                Mapper.Initialize(p =>
                {
                    p.CreateMap<MagazineView, Magazine >();
                    p.CreateMap<ArticleView, Article >().ForMember(c => c.Writers, d => d.Ignore());
                });



                return Mapper.Map<MagazineView, Magazine>(item);
            }



            //Writer
            public static IEnumerable<WriterView> GetListWriter(IEnumerable<Writer> writer)
            {
                Mapper.Initialize(p =>
                {
                    p.CreateMap<Writer, WriterView>();
                    p.CreateMap<Article, ArticleView>();
                    p.CreateMap<Book, BookView>();
                });
                return Mapper.Map<IEnumerable<Writer>, List<WriterView>>(writer);
            }

            public static WriterView GetWriter(Writer writer)
            {

                Mapper.Initialize(p =>
                {
                    p.CreateMap<Writer, WriterView>();
                    p.CreateMap<Article, ArticleView>();
                    p.CreateMap<Book, BookView>();
                });
                return Mapper.Map<Writer, WriterView>(writer);
            }

            public static Writer ReverseWriter(WriterView writer)
            {

                Mapper.Initialize(p =>
                {
                    p.CreateMap<WriterView, Writer>();
                    p.CreateMap<ArticleView, Article>();
                    p.CreateMap<BookView, Book>();
                });

                return Mapper.Map<WriterView, Writer>(writer); ;
            }

        }

      

      
    }
