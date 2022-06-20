using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context _context = new Context();
       
        public ActionResult Index()
        {
            var curmail = (string)Session["CurrentMail"];
            ViewBag.mail = curmail;

            var degerler = _context.Messages.Where(x => x.Receiver == curmail).ToList();

            var mailId = _context.Currents.Where(y => y.CurrentMail == curmail).Select(z => z.CurrentId).FirstOrDefault();
            ViewBag.mid = mailId;

            var toplamtutar = _context.SaleSituations.Where(w => w.CurrentId == mailId).Sum(e => e.TotalPrice);
            ViewBag.toplamtutar = toplamtutar;

            var toplamsatis = _context.SaleSituations.Where(q => q.CurrentId == mailId).Count();
            ViewBag.toplamsatis = toplamsatis;

            var toplamurunsayisi = _context.SaleSituations.Where(r => r.CurrentId == mailId).Sum(t => t.Piece);
            ViewBag.toplamurunsayisi = toplamurunsayisi;

            var adsoyad = _context.Currents.Where(u => u.CurrentMail == curmail).Select(o => o.CurrentName + " " + o.CurrentSurname).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;

            return View(degerler);
        }
       
        public ActionResult Orders()
        {
            var curmail = (string)Session["CurrentMail"];
            var id = _context.Currents.Where(x => x.CurrentMail == curmail.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var degerler = _context.SaleSituations.Where(z => z.CurrentId == id).ToList();
            return View(degerler);
        }
        
        public ActionResult IncomingMessage()
        {
            var curmail = (string)Session["CurrentMail"];
            var degerler = _context.Messages.Where(x => x.Receiver == curmail).OrderByDescending(y => y.MessageId).ToList();

            var gelensayisi = _context.Messages.Count(x => x.Receiver == curmail).ToString();
            ViewBag.d1 = gelensayisi;

            var gidensayisi = _context.Messages.Count(x => x.Sender == curmail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }
       
        public ActionResult SentMessage()
        {
            var curmail = (string)Session["CurrentMail"];
            var degerler = _context.Messages.Where(x => x.Sender == curmail).OrderByDescending(z => z.MessageId).ToList();

            var gelensayisi = _context.Messages.Count(x => x.Receiver == curmail).ToString();
            ViewBag.d1 = gelensayisi;

            var gidensayisi = _context.Messages.Count(x => x.Sender == curmail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(degerler);
        }
      
        public ActionResult MessageDetail(int id)
        {
            var degerler = _context.Messages.Where(x => x.MessageId == id).ToList();
            var curmail = (string)Session["CurrentMail"];
            var gelensayisi = _context.Messages.Count(x => x.Receiver == curmail).ToString();
            ViewBag.d1 = gelensayisi;

            var gidensayisi = _context.Messages.Count(x => x.Sender == curmail).ToString();
            ViewBag.d2 = gidensayisi;

            return View(degerler);
        }
       
        [HttpGet]
        public ActionResult NewMessage()
        {
            var curmail = (string)Session["CurrentMail"];

            var gelensayisi = _context.Messages.Count(x => x.Receiver == curmail).ToString();
            ViewBag.d1 = gelensayisi;

            var gidensayisi = _context.Messages.Count(x => x.Sender == curmail).ToString();
            ViewBag.d2 = gidensayisi;

            return View();
        }
        
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            var curmail = (string)Session["CurrentMail"];
            message.Sender = curmail;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return View();
        }
        
        public ActionResult CargoTrack(string pro)
        {
            var kargolar = from x in _context.CargoDetails select x;
            kargolar = kargolar.Where(y => y.TrackingCode.Contains(pro));
            return View(kargolar.ToList());
        }
        
        public ActionResult CurrentCargoTrack(string id)
        {
            var degerler = _context.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(degerler);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Partial1()
        {
            var curmail = (string)Session["CurrentMail"];

            var id = _context.Currents.Where(x => x.CurrentMail == curmail).Select(y => y.CurrentId).FirstOrDefault();

            var caribul = _context.Currents.Find(id);

            return PartialView("Partial1", caribul);
        }

        public PartialViewResult Partial2()
        {
            var veriler = _context.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(veriler);
        }

        public ActionResult UpdateCurrent(Current current)
        {
            var curr = _context.Currents.Find(current.CurrentId);
            curr.CurrentName = current.CurrentName;
            curr.CurrentSurname = current.CurrentSurname;
            curr.CurrentProvince = current.CurrentProvince;
            curr.CurrentPassword = current.CurrentPassword;
            curr.CurrentMail = current.CurrentMail;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}