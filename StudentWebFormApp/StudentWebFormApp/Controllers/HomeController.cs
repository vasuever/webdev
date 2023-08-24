using Microsoft.AspNetCore.Mvc;
using StudentWebFormApp.DAL;
using StudentWebFormApp.Models;
using System.Diagnostics;

namespace StudentWebFormApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //private readonly IStudentRespository studentRespository;

        public HomeController(/*ILogger<HomeController> logger, IStudentRespository studentRespository*/)
        {
            //this._logger = logger;
            //this.studentRespository = studentRespository;
        }

        public IActionResult Index()
        {
            //var students = studentRespository.GetStudents();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}