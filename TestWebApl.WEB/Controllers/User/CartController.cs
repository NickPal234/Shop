using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWebApl.BLL.DTO;
using TestWebApl.BLL.Services;
using TestWebApl.WEB.Models;

namespace TestWebApl.WEB.Controllers.User
{
    public class CartController : Controller
    {
        private BookService repository;
        public CartController(BookService repo)
        {
            repository = repo;
        }

        public ViewResult Index(CartServices cart, string returnUrl)
        {
            return View(new CartIndex
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(CartServices cart, int bookId, string returnUrl)
        {
            BookView book = repository.GetList()
                .FirstOrDefault(g => g.Id == bookId);

            if (book != null)
            {
                cart.AddItem(book, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(CartServices cart, int bookId, string returnUrl)
        {
            BookView book = repository.GetList()
                .FirstOrDefault(g => g.Id == bookId);

            if (book != null)
            {
                cart.RemoveLine(book);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        public PartialViewResult Summary(CartServices cart)
        {
          


            return PartialView(cart);
        }

     
    }
}