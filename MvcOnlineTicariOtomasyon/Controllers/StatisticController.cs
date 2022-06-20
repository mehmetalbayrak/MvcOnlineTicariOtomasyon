using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        Context _context = new Context();
        public ActionResult Index()
        {
            var deger1 = _context.Currents.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = _context.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = _context.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = _context.Categories.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = _context.Products.Sum(x => x.Stock).ToString();
            ViewBag.d5 = deger5;

            var deger6 = (from x in _context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = deger6;

            var deger7 = _context.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in _context.Products orderby x.SellPrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = (from x in _context.Products orderby x.SellPrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = _context.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d10 = deger10;
            var deger11 = _context.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d11 = deger11;
            var deger12 = _context.Products.Count(x => x.ProductName == "Bilgisayar").ToString();
            ViewBag.d12 = deger12;

            var deger13 = _context.Products.Where(p => p.ProductId == (_context.SaleSituations.GroupBy(x => x.ProductId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = _context.SaleSituations.Sum(x => x.TotalPrice).ToString();
            ViewBag.d14 = deger14;

            DateTime today = DateTime.Today;
            var deger15 = _context.SaleSituations.Count(x => x.Date == today).ToString();
            ViewBag.d15 = deger15;
            var deger16 = _context.SaleSituations.Where(x => x.Date == today).Sum(y => (decimal?)y.TotalPrice).ToString();
            ViewBag.d16 = deger16;

            return View();
        }
        public ActionResult SimpleTables()
        {
            var query = from x in _context.Currents group x by x.CurrentProvince into g select new GroupClass
            {
                Province = g.Key,
                Number = g.Count()
        };
            return View(query.ToList());
        }
        public PartialViewResult Partial1()
        {
            var que = from x in _context.Personels
                      group x by x.Departmen.DepartmanName into g
                      select new GroupClass2
                      {
                          Departman = g.Key,
                          Number = g.Count()
                      };
            return PartialView(que.ToList());
        }

        public PartialViewResult Partial2()
        {
            var que = _context.Currents.ToList();
            return PartialView(que);
        }

        public PartialViewResult Partial3()
        {
            var que = _context.Products.ToList();
            return PartialView(que);
        }
        public PartialViewResult Partial4()
        {
            var que = from x in _context.Products
                      group x by x.Brand into g
                      select new GroupClass3
                      {
                          Brand = g.Key,
                          Number = g.Count()
                      };
            return PartialView(que.ToList());
        }
    }
}