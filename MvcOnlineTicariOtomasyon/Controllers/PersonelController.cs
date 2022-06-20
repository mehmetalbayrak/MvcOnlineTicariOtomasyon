using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Controllers;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context _context = new Context();
        public ActionResult Index()
        {
            var degerler = _context.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AddPersonel()
        {

            List<SelectListItem> dropdownlist = (from x in _context.Departmen.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanName,
                                                     Value = x.DepartmanId.ToString()
                                                 }).ToList();
            ViewBag.view = dropdownlist;
            return View();
        }
        [HttpPost]
        public ActionResult AddPersonel(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/_images/" + filename + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelImage = "/_images/" + filename + uzanti;
            }
            _context.Personels.Add(personel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //public ActionResult DeleteDepartman(int id)
        //{
        //    var deger = _context.Departmen.Find(id);
        //    deger.Status = false;
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult UpdatePersonel(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/_images/" + filename + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelImage = "/_images/" + filename + uzanti;
            }
            var cat = _context.Personels.Find(personel.PersonelId);
            cat.PersonelName = personel.PersonelName;
            cat.PersonelSurname = personel.PersonelSurname;
            cat.PersonelImage = personel.PersonelImage;
            cat.DepartmanId = personel.DepartmanId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetPersonel(int id)
        {
            List<SelectListItem> dropdownlist = (from x in _context.Departmen.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanName,
                                                     Value = x.DepartmanId.ToString()
                                                 }).ToList();
            ViewBag.prs = dropdownlist;
            var personel = _context.Personels.Find(id);
            return View("GetPersonel", personel);
        }

        //public ActionResult PersonelDetail(int id)
        //{
        //    var degerler = _context.Personels.Where(x => x.DepartmanId == id).ToList();
        //    var dest = _context.Departmen.Where(x => x.DepartmanId == id).Select(y => y.DepartmanName).FirstOrDefault();
        //    ViewBag.san = dest;
        //    return View(degerler);
        //}

        public ActionResult PersonelList()
        {
            var deger = _context.Personels.ToList();
            return View(deger);
        }
    }
}