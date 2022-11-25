using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crudapp.Models;

namespace crudapp.Controllers
{
    public class HomeController : Controller
    {
        UsersContext db = new UsersContext();
        public ActionResult Index()
        {
            var user = db.User.ToList();
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Users user)
        {
            db.User.Add(user);
            int chk = db.SaveChanges();
            if (chk > 0)
            {
                ModelState.Clear();
                ViewBag.InsertMessage = "<script>alert('data inserted')</script>";
            }
            else
            {
                ViewBag.InsertMessage = "<script>alert('OOp's something went wrong')</script>";
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.User.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Users user)
        {

            if (ModelState.IsValid)
            {

                db.Entry(user).State = EntityState.Modified;
                int check = db.SaveChanges();
                if (check > 0)
                {
                    return RedirectToAction("Index");

                }

            }
            return View("index");
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Object model = db.User.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Users user)
        {
            db.Entry(user).State = EntityState.Deleted;
            int check = db.SaveChanges();
            if (check > 0)
            {
                ViewBag.DeleteMessage = "<script>alert('record deleted')</script>";
            }
            else
            {
                ViewBag.DeleteMessage = "<script>alert('something went wrong.')</script>";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Object user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
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
    }
}