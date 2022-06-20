using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Context _context = new Context();
        public ActionResult Index()
        {
            var degerler = _context.SaleSituations.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddSale()
        {
            List<SelectListItem> deger1 = (from x in _context.Products.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProductName,
                                              Value = x.ProductId.ToString()
                                          }).ToList();
           

            List<SelectListItem> deger2 = (from x in _context.Currents.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CurrentName+" "+ x.CurrentSurname ,
                                              Value = x.CurrentId.ToString()
                                          }).ToList();
            List<SelectListItem> deger3 = (from x in _context.Personels.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PersonelName+" "+ x.PersonelSurname,
                                              Value = x.PersonelId.ToString()
                                          }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult AddSale(SaleSituation salesituation)
        {
            salesituation.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.SaleSituations.Add(salesituation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetSale(int id)
        {
            List<SelectListItem> deger1 = (from x in _context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();


            List<SelectListItem> deger2 = (from x in _context.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName + " " + x.CurrentSurname,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in _context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelName + " " + x.PersonelSurname,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            var sale = _context.SaleSituations.Find(id);
            return View("GetSale",sale);
        }
        public ActionResult UpdateSale(SaleSituation salesituation)
        {
            var cat = _context.SaleSituations.Find(salesituation.SaleId);
            cat.Date = salesituation.Date;
            cat.Piece = salesituation.Piece;
            cat.Price = salesituation.Price;
            cat.TotalPrice = salesituation.TotalPrice;
            cat.CurrentId = salesituation.CurrentId;
            cat.PersonelId = salesituation.PersonelId;
            cat.ProductId = salesituation.ProductId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaleDetail(int id)
        {
            var degerler = _context.SaleSituations.Where(x => x.SaleId == id).ToList();
            return View(degerler);
        }
    }
}