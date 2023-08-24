using Microsoft.AspNetCore.Mvc;
using StudentWebFormApp.DAL;
using StudentWebFormApp.Models;

namespace StudentWebFormApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRespository studentRespository;
        public StudentController(IStudentRespository studentRespository) 
        {
            this.studentRespository = studentRespository;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var students = studentRespository.GetStudents();

            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }
       
        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Create(Student student)
        {
            try
            {
                var students = studentRespository.CreateStudent(student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(student);
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                studentRespository.UpdateStudent(id, student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = studentRespository.GetStudent(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                studentRespository.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
