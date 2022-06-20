using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        Context _context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok")
                .AddSeries("Değerler",
                xValue:
                new[] { "Beyaz Eşya", "Bilgisayar", "Televizyon", "Küçük Ev Aletleri", "Telefon", "Mouse" },
                yValues: new[] { 118, 67, 27, 36, 69, 81 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = _context.Products.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.ProductName));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stock));
            var grafik = new Chart(500, 500);
            grafik.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok")
                .AddSeries(chartType: "pie",
                name: "Stok",
                xValue: xvalue,
                yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        // Index4'ten sonrası ve VisualizeProductResult kısmı çalışmıyor, dönüp bakılacak, ders 190

        //Index4 ve sonrası için , google chartların gelmesi için script kodu değiştilecek

        // <script src="~/Scripts/jquery-3.4.1.min.js"></script>
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<GraphicClass> ProductList()
        {
            List<GraphicClass> chartClasses = new List<GraphicClass>();
            chartClasses.Add(new GraphicClass()
            {
                ProductName = "Bilgisayar",
                Stock = 50
            });
            chartClasses.Add(new GraphicClass()
            {
                ProductName = "Mobilya",
                Stock = 120
            });
            chartClasses.Add(new GraphicClass()
            {
                ProductName = "Beyaz Eşya",
                Stock = 90
            });
            return chartClasses;
        }
        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeProductResult2()
        {
            return Json(ProductList2(),JsonRequestBehavior.AllowGet);
        }
        public List<GoogleChart> ProductList2()
        {
            List<GoogleChart> googleCharts = new List<GoogleChart>();
            using (var context = new Context())
            {
                googleCharts = context.Products.Select(x => new GoogleChart
                {
                    ProductName = x.ProductName,
                    Stock = x.Stock

                }).ToList();
            }
            return googleCharts;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}