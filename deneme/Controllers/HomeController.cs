using deneme.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace deneme.Controllers
{
    public class HomeController : Controller
    {
        VeriBaglam _context=new VeriBaglam();

        // GET: Home
        public ActionResult Index()
        {
            // Veritabanından örnek bir veri getiriliyor (bu kısmı kendi projenize göre uyarlayın)

            var urunler = _context.uruns;
            return View(urunler);
        }
        
        public ActionResult Urundetay(int? id)
        {
           
            
            return View(_context.uruns.Where(i=> i.Id==id).FirstOrDefault());
        }

        public ActionResult Urunlistesi(int? id)
        {
            var urunler = _context.uruns.Where(i=>i.Onay);

            if(id != null)
            {
                urunler=urunler.Where(i=> i.KategoriId==id);
            }

            return View(urunler.ToList());

        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Kategoris.ToList());
        }


        public ActionResult Hakkımızda()
        {           
            return View();
        }


        public ActionResult Iletisim()
        {
            return View();
        }
    }
}