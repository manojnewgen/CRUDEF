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
            return View();
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
    }
}
