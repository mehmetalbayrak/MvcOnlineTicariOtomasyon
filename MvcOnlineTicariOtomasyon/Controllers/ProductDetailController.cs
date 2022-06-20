using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context _context = new Context();
        GeneralClass _generalClass = new GeneralClass();
        public ActionResult Index()
        {
            //var degerler = _context.Products.Where(x=>x.ProductId==1).ToList();
            _generalClass.products = _context.Products.Where(x=>x.ProductId==1).ToList();
            _generalClass.details = _context.Details.Where(y=>y.DetailId==1).ToList();
            return View(_generalClass);
        }
    }
}