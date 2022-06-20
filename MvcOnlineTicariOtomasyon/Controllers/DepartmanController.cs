using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Controllers;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{

    public class DepartmanController : Controller
    {
        // GET: Departman
        Context _context = new Context();
        public ActionResult Index()
        {
            var degerler = _context.Departmen.Where(x => x.Status == true).ToList();
            return View(degerler);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult AddDepartman()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddDepartman(Departman departman)
        {
            _context.Departmen.Add(departman);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDepartman(int id)
        {
            var deger = _context.Departmen.Find(id);
            deger.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateDepartman(Departman departman)
        {
            var cat = _context.Departmen.Find(departman.DepartmanId);
            cat.DepartmanName = departman.DepartmanName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDepartman(int id)
        {
            var departman = _context.Departmen.Find(id);
            return View("GetDepartman", departman);
        }

        public ActionResult DepartmanDetail(int id)
        {
            var degerler = _context.Personels.Where(x => x.DepartmanId == id).ToList();
            var dest = _context.Departmen.Where(x => x.DepartmanId == id).Select(y => y.DepartmanName).FirstOrDefault();
            ViewBag.san = dest;
            return View(degerler);
        }
        public ActionResult DepartmanPersonelSale(int id)
        {
            var deger = _context.SaleSituations.Where(x => x.PersonelId == id).ToList();
            var dest = _context.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelName + " " + y.PersonelSurname).FirstOrDefault();
            ViewBag.dpers = dest;
            var cur = _context.Currents.Where(p => p.CurrentId == id).Select(t => t.CurrentName + " " + t.CurrentSurname).FirstOrDefault();
            ViewBag.acur = cur;
            var pro = _context.Products.Where(a => a.ProductId == id).Select(s => s.ProductName).FirstOrDefault();
            ViewBag.apro = pro;
            return View(deger);
        }
    }
}