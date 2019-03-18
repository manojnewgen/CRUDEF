using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDEF.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDEF.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private SchoolContext schoolContext;
        public HomeController(SchoolContext sc)
        {
            schoolContext = sc;
        }

        public IActionResult Index()
        {
            return View(schoolContext.Teacher);
        }
        [HttpDelete]
        public IActionResult Delete(int id) => View();
       

        public IActionResult Update(int id)=> View(schoolContext.Teacher.Where(a => a.Id == id).FirstOrDefault());

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Teacher teacher)
        {
            schoolContext.Teacher.Update(teacher);
            schoolContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Teacher tch)
        {
            if (ModelState.IsValid)
            {
                schoolContext.Teacher.Add(tch);
                schoolContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        [ActionName("RegisterView")]
        public IActionResult Register()
        {          
                return View(schoolContext.Employee);
        }
        [ActionName("Register")]
        public IActionResult Register(Eemployee emp)
        {
            if (ModelState.IsValid)
            {
                schoolContext.Employee.Add(emp);
                schoolContext.SaveChanges();
                return RedirectToAction("RegisterView");
            }
            else
                return View();
        }
        [ActionName("Login")]
        public IActionResult Login()
        {
            return View();
        }
       
    }
}
