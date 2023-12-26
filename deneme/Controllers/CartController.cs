using deneme.Entity;
using deneme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace deneme.Controllers
{
    public class CartController : Controller
    {
        private VeriBaglam db = new VeriBaglam();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }


        public ActionResult AddToCart(int Id)
        {
            var urun=db.uruns.FirstOrDefault(i=>i.Id==Id);

            if (urun != null)
            {
                GetCart().AddProduct(urun, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var urun = db.uruns.FirstOrDefault(i => i.Id == Id);

            if (urun != null)
            {
                GetCart().DeleteProduct(urun);
            }

            return RedirectToAction("Index");
        }


        public Cart GetCart()
        {
            var cart =(Cart) Session["Cart"];

            if(cart == null) 
            {
                cart = new Cart();
                Session["Cart"]=cart;

            }
            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

    }
}