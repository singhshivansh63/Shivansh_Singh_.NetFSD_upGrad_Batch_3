using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
         
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost("register")]
        public IActionResult Register(string name, int age, string course)
        {
             
            ViewBag.StudentName = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

           
            return RedirectToAction("Details", new { name = name, age = age, course = course });
        }

        
        [HttpGet("details")]
        public IActionResult Details(string name, int age, string course)
        {
            ViewBag.StudentName = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}