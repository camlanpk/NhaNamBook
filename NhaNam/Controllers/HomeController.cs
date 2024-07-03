using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NhaNam.Models;


namespace NhaNam.Controllers
{
    public class HomeController : Controller
    {
        private DBNhaNamEntities db = new DBNhaNamEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MasterLayout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }
            return View(proDetail);

        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult ProDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }

            return View(proDetail);
        }
        public ActionResult MenuTop()
        {
            var items = db.Categories.OrderBy(x => x.NameCate).ToList();
            return PartialView("_MenuTop", items);
        }
        public ActionResult MenuProduct()
        {
            var items = db.ProDetails.OrderBy(x => x.ProID).ToList();
            return PartialView("_MenuProduct", items);
        }
        public ActionResult MenuProductCategory(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProDetail proDetail = db.ProDetails.Find(id);
            if (proDetail == null)
            {
                return HttpNotFound();
            }

            return PartialView("_MenuProductCategory", proDetail);
        }

        public ActionResult ProDet()
        {
            var item = db.ProDetails.OrderBy(x => x.ProID).ToList();
            return PartialView("_ProDet", item);
        }
        public ActionResult Test(int id)
        {
            var item = db.Products.Find(id);
            return View(item);
        }
        public ActionResult TransactionHistory()
        {
            return View();
        }

    }
}