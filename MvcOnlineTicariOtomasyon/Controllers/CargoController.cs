using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context _context = new Context();
        public ActionResult Index(string pro)
        {
            var kargolar = from x in _context.CargoDetails select x;
            if (!string.IsNullOrEmpty(pro))
            {
                kargolar = kargolar.Where(y => y.TrackingCode.Contains(pro));
            }
            return View(kargolar.ToList());
        }
        [HttpGet]
        public ActionResult AddCargo()
        {
            Random rastgele = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int k1, k2, k3, s1, s2, s3;

            k1 = rastgele.Next(0, karakterler.Length);
            k2 = rastgele.Next(0, karakterler.Length);
            k3 = rastgele.Next(0, karakterler.Length);
            s1 = rastgele.Next(100, 1000);
            s2 = rastgele.Next(10, 100);
            s3 = rastgele.Next(10, 100);

            string code = s1 + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkodu = code;

            return View();
        }
        [HttpPost]
        public ActionResult AddCargo(CargoDetail cargoDetail)
        {
            _context.CargoDetails.Add(cargoDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CargoDetail(string id)
        {
            var degerler = _context.CargoTrackings.Where(x => x.TrackingCode == id).ToList();     
            return View(degerler);
        }
    }
}