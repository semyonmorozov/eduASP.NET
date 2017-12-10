using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using StudentGroup.Models;

namespace StudentGroup.Controllers
{

    public class GroupController : Controller
    {
        private readonly IStudentsDatabase studentsDatabase;

        //Получение сервиса в качестве параметра конструктора
        public GroupController(IStudentsDatabase studentsDatabase)
        {
            this.studentsDatabase = studentsDatabase;
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        //Получение сервиса в качестве параметра метода
        [HttpPost]
        public IActionResult AddStudent([FromServices]IStudentsDatabase studentsDatabase, StudentModel student)
        {
            if (!ModelState.IsValid) return RedirectToAction("AddStudent", "Group");
            foreach (var homeWork in studentsDatabase.HomeWorks)
            {
                student.DoneHomeWorks.Add(homeWork,0);
            }
            studentsDatabase.AddStudent(student);
            return RedirectToAction("GetStudents", "Group");
        }

        //Получение из HttpContexta
        public IActionResult GetStudents()
        {
            var studentsDatabase = HttpContext.RequestServices.GetService<IStudentsDatabase>();
            return View(studentsDatabase.GetStudents());
        }

        
        [Route("{cardNum}")]
        public IActionResult GetStudent(int cardNum)
        {
            var student = studentsDatabase.GetStudentByCardNum(cardNum);
            return View(student);
        }
        
        [Route("{cardNum}/Edit")]
        public IActionResult EditStudent(int cardNum)
        {
            var student = studentsDatabase.GetStudentByCardNum(cardNum);
            return View(student);
        }

        [HttpPost]
        [Route("{cardNum}/Edit")]
        public IActionResult EditStudent(StudentModel student, int cardNum)
        {
            var currentStudentModel = studentsDatabase.GetStudentByCardNum(cardNum);
            currentStudentModel.StudentCardNumber = student.StudentCardNumber;
            currentStudentModel.FirstName = student.FirstName;
            currentStudentModel.LastName = student.LastName;
            currentStudentModel.EmailAddress = student.EmailAddress;
            return RedirectToAction("GetStudents", "Group");
        }

        
        [Route("{cardNum}/delete")]
        public IActionResult DeleteStudentByCardNum(int cardNum)
        {
            studentsDatabase.DeleteStudentByCardNum(cardNum);
            return RedirectToAction("GetStudents", "Group");
        }

        //С помощью ActivatorUtilities
        [Route("{cardNum}/fakedelete")]
        public IActionResult FakeDeleteStudentByCardNum(int cardNum)
        {
            var studentsDatabase = ActivatorUtilities.CreateInstance<StudentsDatabase>(HttpContext.RequestServices);
            studentsDatabase.DeleteStudentByCardNum(cardNum);
            return RedirectToAction("GetStudents", "Group");
        }

        [Route("{cardNum}/homeworks")]
        public IActionResult GetDoneHomeWorks(int cardNum)
        {
            var student = studentsDatabase.GetStudentByCardNum(cardNum);
            return View(student);
        }

        [HttpPost]
        public IActionResult EditHomeWorks(int cardNum,Dictionary<HomeWorkModel,int>homeWorks)
        {
            var student = studentsDatabase.GetStudentByCardNum(cardNum);
            student.DoneHomeWorks = homeWorks;
            return RedirectToRoute(cardNum + "/homeworks");
        }
    }
    

}
