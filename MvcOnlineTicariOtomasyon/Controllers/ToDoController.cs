using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Context _context = new Context();
        public ActionResult Index()
        {
            var deger1 = _context.Currents.Count().ToString();
            ViewBag.dgr1 = deger1;

            var deger2 = _context.Products.Count().ToString();
            ViewBag.dgr2 = deger2;

            var deger3 = _context.Categories.Count().ToString();
            ViewBag.dgr3 = deger3;

            var deger4 = (from x in _context.Currents select x.CurrentProvince).Distinct().Count().ToString();
            ViewBag.dgr4 = deger4;

            var doing = _context.ToDos.ToList();
            return View(doing);

            
        }
    }
}