using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentOrganiser.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace StudentOrganiser.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (StudentOrganiserDbContext ctx = new StudentOrganiserDbContext())
            {
                var students = ctx.Students.ToList();
                return View(students);
            }
               
        }

        public ActionResult Create()
        {
            using (StudentOrganiserDbContext ctx = new StudentOrganiserDbContext())
            {
                List<Academy> academies = ctx.Academies.ToList();
                ViewBag.Academies = academies;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentCreate model)
        {

            if (ModelState.IsValid)
            {
                
                Student entity = new Student
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Birthday = model.Birthday,
                    Faculty = model.Faculty,
                    FacultyStart = model.FacultyStart,
                    Gender = model.Gender

                };
                StudentOrganiserDbContext ctxx = new StudentOrganiserDbContext();

                
                    ctxx.Students.Add(entity);
                ctxx.SaveChanges();

                save(model.academy, entity.StudentId);
               
                return RedirectToAction("Index");
            }
            return View();
           
        }
        public void save(int ida, int ids)
        {
            StudentAcademy e = new StudentAcademy
            {
                AcademyId =ida,
                StudentId =ids

            };
            StudentOrganiserDbContext ctxx = new StudentOrganiserDbContext();



            ctxx.StudentAcademies.Add(e);
            // ctxx.SaveChanges();     
            try
            {
                ctxx.SaveChanges();
            }
            
            
            catch (DbUpdateException dbu)
            {
                var exception = HandleDbUpdateException(dbu);
                throw exception;
            }


        }
        private Exception HandleDbUpdateException(DbUpdateException dbu)
        {
            var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

            try
            {
                foreach (var result in dbu.Entries)
                {
                    builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateException: " + e.ToString());
            }

            string message = builder.ToString();
            return new Exception(message, dbu);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using(StudentOrganiserDbContext ctx =  new StudentOrganiserDbContext())
            {
                var student = ctx.Students.Where(s => s.StudentId == id).ToList();
                Student st = student[0];
                return View(st);
            }
            //return RedirectToAction("Index");
            
        }
        [HttpPost]
        public ActionResult Edit (Student model)
        {
            StudentOrganiserDbContext ctx = new StudentOrganiserDbContext();
            Student s = ctx.Students.Single(x => x.StudentId == model.StudentId);
            s.FirstName = model.FirstName;
            s.LastName = model.LastName;
            s.Birthday = model.Birthday;
            s.Email = model.Email;
            s.Faculty = model.Faculty;
            s.FacultyStart = model.FacultyStart;
            s.PhoneNumber = model.PhoneNumber;
            s.Gender = model.Gender;
           
            if (ModelState.IsValid)
            {
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_g(int id)
        {
            using(StudentOrganiserDbContext ctx = new StudentOrganiserDbContext())
            {
                Student st = ctx.Students.Single(s => s.StudentId == id);
                return View(st);

            }
        }
        [ActionName("Delete")]
        public ActionResult DeleteS(int id)
        {
            using (StudentOrganiserDbContext ctx = new StudentOrganiserDbContext())
            {
                Student st = ctx.Students.Single(a => a.StudentId == id);
                ctx.Students.Remove(st);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Details(int id)
        {
            using (StudentOrganiserDbContext ctx = new StudentOrganiserDbContext())
            {
                Student st = ctx.Students.Single(a => a.StudentId == id);
                return View(st);
            }

        }
        public ActionResult Add(int id)
        {
            using (StudentOrganiserDbContext ctx = new StudentOrganiserDbContext())
            {
                List<Academy> academies = ctx.Academies.ToList();
                return View(academies);
            }
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