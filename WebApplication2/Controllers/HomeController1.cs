using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController1 : Controller
    {
        public ActionResult helloWrold()
        {
            Student stu1 = new Student()
            {
                Name = "jahir",
                Age = 30
            };
            ViewBag.students = stu1;
            return View();
        }


    }

}
