using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        Context _context = new Context();
        public ActionResult Index()
        {
            var deger = _context.Products.ToList();
            return View(deger);
        }
    }
}