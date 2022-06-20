 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context _context = new Context();
        public ActionResult Index(int page = 1)
        {
            var degerler = _context.Categories.ToList().ToPagedList(page,5);

            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var cat = _context.Categories.Find(id);
            _context.Categories.Remove(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id )
        {
            var gid = _context.Categories.Find(id);
            return View("GetCategory",gid);
        }
        public ActionResult UpdateCategory(Category category)
        {
            var cat = _context.Categories.Find(category.CategoryId);
            cat.CategoryName = category.CategoryName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NewPage()
        {
            Cascading cascading = new Cascading();
            cascading.Categories = new SelectList(_context.Categories,"CategoryId","CategoryName");
            cascading.Products = new SelectList(_context.Products,"ProductId","ProductName");
            return View(cascading);
        }
        // GetProduct code sayfası scriptten dolayı çalışmıyor geri dönüp bakılacak
        public JsonResult GetProduct(int id)
        {
            var urunlistesi = (from x in _context.Products
                               join y in _context.Categories
                               on x.CategoryId equals y.CategoryId
                               where x.Category.CategoryId == id
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductId.ToString()
                               }).ToList();
            return Json(urunlistesi,JsonRequestBehavior.AllowGet);
        }
    }
}