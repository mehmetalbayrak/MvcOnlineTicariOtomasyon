using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context _context = new Context();
        public ActionResult Index()
        {
            var degerler = _context.Currents.Where(x => x.Status == true).ToList();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult AddCurrent()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddCurrent(Current current)
        {
            current.Status = true;
            _context.Currents.Add(current);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrent(int id)
        {
            var deger = _context.Currents.Find(id);
            deger.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateCurrent(Current current)
        {
            if (!ModelState.IsValid)
            {
                return View("GetCurrent");
            }
            var cat = _context.Currents.Find(current.CurrentId);
            cat.CurrentName = current.CurrentName;
            cat.CurrentSurname = current.CurrentSurname;
            cat.CurrentProvince = current.CurrentProvince;
            cat.CurrentMail = current.CurrentMail;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrent(int id)
        {
            var current = _context.Currents.Find(id);
            return View("GetCurrent", current);
        }
        public ActionResult ClientSale(int id)
        {
            var degerler = _context.SaleSituations.Where(x=>x.CurrentId==id).ToList();
            var car = _context.Currents.Where(t=>t.CurrentId==id).Select(y=>y.CurrentName +" "+ y.CurrentSurname).FirstOrDefault();
            ViewBag.cari = car;
            return View(degerler);
        }

        //public ActionResult CurrentDetail(int id)
        //{
        //    var degerler = _context.Personels.Where(x => x.DepartmanId == id).ToList();
        //    var dest = _context.Departmen.Where(x => x.DepartmanId == id).Select(y => y.DepartmanName).FirstOrDefault();
        //    ViewBag.san = dest;
        //    return View(degerler);
        //}
        //public ActionResult DepartmanPersonelSale(int id)
        //{
        //    var deger = _context.SaleSituations.Where(x => x.PersonelId == id).ToList();
        //    var dest = _context.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelName + " " + y.PersonelSurname).FirstOrDefault();
        //    ViewBag.dpers = dest;
        //    var cur = _context.Currents.Where(p => p.CurrentId == id).Select(t => t.CurrentName + " " + t.CurrentSurname).FirstOrDefault();
        //    ViewBag.acur = cur;
        //    var pro = _context.Products.Where(a => a.ProductId == id).Select(s => s.ProductName).FirstOrDefault();
        //    ViewBag.apro = pro;
        //    return View(deger);
        //}
    }
}