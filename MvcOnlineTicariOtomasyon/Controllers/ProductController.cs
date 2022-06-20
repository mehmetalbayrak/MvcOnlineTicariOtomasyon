using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
   
    public class ProductController : Controller
    {
        // GET: Product
        Context _context = new Context();
        public ActionResult Index(string pro)
        {
            var urunler = from x in _context.Products select x;
            if (!string.IsNullOrEmpty(pro))
            {
                urunler = urunler.Where(y => y.ProductName.Contains(pro));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> dropdownlist = (from x in _context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.view = dropdownlist;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var deger = _context.Products.Find(id);
            deger.Status = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateProduct(Product product)
        {
            var cat = _context.Products.Find(product.ProductId);
            cat.ProductName = product.ProductName;
            cat.Brand = product.Brand;
            cat.Stock = product.Stock;
            cat.BuyPrice = product.BuyPrice;
            cat.SellPrice = product.SellPrice;
            cat.Status = product.Status;
            cat.ProductImage = product.ProductImage;
            cat.CategoryId = product.CategoryId;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> dropdownlist = (from x in _context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.view = dropdownlist;
            var urun = _context.Products.Find(id);
            return View("GetProduct", urun);
        }
        public ActionResult DepartmanPersonelSale(int id)
        {
            return View();
        }

        public ActionResult PrintProducts()
        {
            var deger = _context.Products.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult SellProduct(int id)
        {
            List<SelectListItem> deger1 = (from x in _context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelName + " " + x.PersonelSurname,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var deger2 = _context.Products.Find(id);
            ViewBag.dgr2 = deger2.ProductId;
            ViewBag.dgr3 = deger2.SellPrice;
            return View();
        }
        [HttpPost]
        public ActionResult SellProduct(SaleSituation salesituation)
        {
            salesituation.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.SaleSituations.Add(salesituation);
            _context.SaveChanges();
            return RedirectToAction("Index","Sale");
        }
      
    }
}