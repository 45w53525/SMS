using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        // GET: Teacher
        StudentDBContext db = new StudentDBContext();
        public ActionResult Index()
        {
            var data = db.Courses.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course c)
        {
            if (ModelState.IsValid == true)
            {
                db.Courses.Add(c);
                int n = db.SaveChanges();
                if (n != 0)
                {
                    TempData["Insert"] = "<script>alert('Data Inserted!!')</script>";
                    return RedirectToAction("Index");
                    
                }
                else
                {
                    TempData["Insert"] = "<script>alert('Data Inserted Fail!!')</script>";

                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.Courses.Where(model => model.CourseId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Course s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int n = db.SaveChanges();
                if (n != 0)
                {
                    TempData["Update"] = "<script>alert('Update SuccessFully!!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Update"] = "<script>alert('Update Fail!!')</script>";

                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var row = db.Courses.Where(model => model.CourseId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(Course s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int n = db.SaveChanges();
                if (n != 0)
                {
                    
                    TempData["Delete"] = "<script>alert('Deleted SuccessFully!!')</script>";
                }
                else
                {
                    TempData["Delete"] = "<script>alert('Deleted Fail!!')</script>";

                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var detailsid = db.Courses.Where(model => model.CourseId == id).FirstOrDefault();
            return View(detailsid);
        }
    }
}