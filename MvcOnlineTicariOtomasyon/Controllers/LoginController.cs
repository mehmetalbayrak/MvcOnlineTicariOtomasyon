using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context _context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Current current)
        {
            _context.Currents.Add(current);
            _context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrentLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentLogin1(Current c)
        {
            var deger = _context.Currents.FirstOrDefault(x => x.CurrentMail == c.CurrentMail && x.CurrentPassword == c.CurrentPassword);
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.CurrentMail, false);
                Session["CurrentMail"] = deger.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var deger = _context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.UserName, false);
                Session["UserName"] = deger.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}