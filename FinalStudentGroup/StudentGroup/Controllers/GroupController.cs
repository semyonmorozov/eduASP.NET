using Microsoft.AspNetCore.Mvc;
using StudentGroup.Models;
using StudentGroup.StudentsDB;

namespace StudentGroup.Controllers{

    public class GroupController : Controller
    {
        private readonly IStudentsDatabase studentsDatabase;

        public GroupController(IStudentsDatabase studentsDatabase)
        {
            this.studentsDatabase = studentsDatabase;
        }

        public IActionResult AddStudent()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddStudent( StudentModel student)
        {
            if (!ModelState.IsValid) return RedirectToAction("AddStudent", "Group");
            studentsDatabase.AddStudent(student);
            return RedirectToAction("GetStudents", "Group");
        }
        
        public IActionResult GetStudents()
        {
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
            studentsDatabase.UpdateStudent(cardNum,student);
            return RedirectToAction("GetStudents", "Group");
        }
        
        [Route("{cardNum}/delete")]
        public IActionResult DeleteStudentByCardNum(int cardNum)
        {
            studentsDatabase.DeleteStudentByCardNum(cardNum);
            return RedirectToAction("GetStudents", "Group");
        }
    }
    

}
