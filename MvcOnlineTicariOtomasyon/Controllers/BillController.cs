using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        Context _context = new Context();
        public ActionResult Index()
        {
            var deger = _context.Bills.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult AddBill()
        {
            //List<SelectListItem> dropdownlist = (from x in _context.Personels.ToList()
            //                                     select new SelectListItem
            //                                     {
            //                                         Text = x.PersonelName +" "+ x.PersonelSurname,
            //                                         Value = x.PersonelId.ToString()
            //                                     }).ToList();
            //ViewBag.vew = dropdownlist;
            return View();
        }
        [HttpPost]
        public ActionResult AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetBill(int id)
        {
            var bill = _context.Bills.Find(id);
            return View("GetBill", bill);
        }
        public ActionResult UpdateBill(Bill bill)
        {
            var cat = _context.Bills.Find(bill.BillId);
            cat.BillSerialNo = bill.BillSerialNo;
            cat.BillQueueNo = bill.BillQueueNo;
            cat.Tax = bill.Tax;
            cat.Date = bill.Date;
            cat.Delivery = bill.Delivery;
            cat.Receiver = bill.Receiver;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BillDetail(int id)
        {
            var degerler = _context.BillDetails.Where(x => x.BillId == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult AddBillDetail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBillDetail(BillDetail billDetail)
        {
            _context.BillDetails.Add(billDetail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dynamic()
        {
            BillDynamic billDynamic = new BillDynamic();
            billDynamic.Bills = _context.Bills.ToList();
            billDynamic.BillDetails = _context.BillDetails.ToList();
            return View(billDynamic);
        }

        public ActionResult SaveBill(string BillSerialNo, string BillQueueNo, DateTime Date, string Tax, string Time, string Delivery, string Receiver, string TotalPrice, BillDetail[] billDetails)
        {
            Bill bill = new Bill();
            bill.BillSerialNo = BillSerialNo;
            bill.BillQueueNo = BillQueueNo;
            bill.Date = Date;
            bill.Time = Time;
            bill.Tax = Tax;
            bill.Delivery = Delivery;
            bill.Receiver = Receiver;
            bill.TotalPrice = decimal.Parse(TotalPrice);
            _context.Bills.Add(bill);

            foreach (var item in billDetails)
            {
                BillDetail billDetails1 = new BillDetail();
                billDetails1.BillContext = item.BillContext;
                billDetails1.Amount = item.Amount;
                billDetails1.BillId = item.BillDetailId;
                billDetails1.Price = item.Price;
                billDetails1.UnitPrice = item.UnitPrice;
                _context.BillDetails.Add(billDetails1);
            }
            _context.SaveChanges();

            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet); 
        }
    }
}