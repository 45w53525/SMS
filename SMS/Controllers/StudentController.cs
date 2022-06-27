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
    public class StudentController : Controller
    {
        StudentDBContext db=new StudentDBContext();
        // GET: Student
        public ActionResult Index()
        {
           var students =db.Students.ToList();
            return View(students);
        }
        public ActionResult Create()
        {
            ViewBag.courseId = getCourses();
            ViewBag.teacherId = getTeachers();
            return View();
        }
        private List<SelectListItem> getCourses()
        {
            List<SelectListItem> courses = (from c in db.Courses.AsEnumerable()
                                            select new SelectListItem
                                            {
                                                Text = c.CourseName,
                                                Value = c.CourseId.ToString()
                                            }).ToList();
            courses.Insert(0, new SelectListItem { Text = "--Select Courses--", Value = "" });
            return courses;
        }
        private List<SelectListItem> getTeachers()
        {
            List<SelectListItem> teachers = (from t in db.Teachers.AsEnumerable()
                                            select new SelectListItem
                                            {
                                                Text = t.TeacherFirstName,
                                                Value =t.TeacherId.ToString()
                                            }).ToList();
            teachers.Insert(0, new SelectListItem { Text = "--Select Teachers--", Value = "" });
            return teachers;
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Students.Add(s);
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
            ViewBag.courseId = getCourses();
            ViewBag.teacherId = getTeachers();
            var row = db.Students.Where(model => model.StudentId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            ViewBag.courseId = getCourses();
            ViewBag.teacherId = getTeachers();
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
            var row = db.Students.Where(model => model.StudentId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
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
            var detailsid = db.Students.Where(model => model.StudentId == id).FirstOrDefault();
            return View(detailsid);
        }
    }
}