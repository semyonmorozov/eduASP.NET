using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentGroup.Models;

namespace StudentGroup.Controllers
{
    [Route("[controller]")]
    public class GroupController : Controller
    {
        [HttpPost]
        [Route("[Action]")]
        public IActionResult AddStudent([FromBody]StudentModel student)
        {
            if (!ModelState.IsValid) return BadRequest(student);
            GroupModel.AddStudent(student);
            return Json(student);
        }

        [HttpPut]
        [Route("[Action]")]
        public IActionResult UpdateStudent([FromQuery]int cardNum, [FromBody]StudentModel student)
        {
            var currentStudentModel = GroupModel.GetStudentByCardNum(cardNum);

            if (student.FirstName != null)
                currentStudentModel.FirstName = student.FirstName;

            if (student.LastName != null)
                currentStudentModel.LastName = student.LastName;

            if (student.DoneHomeWorks.Count != 0)
                currentStudentModel.DoneHomeWorks = student.DoneHomeWorks;

            if (student.EmailAddress != null)
                currentStudentModel.EmailAddress = student.EmailAddress;

            if (student.StudentCardNumber != 0)
                currentStudentModel.StudentCardNumber = student.StudentCardNumber;

            if (student.Age != 0)
                currentStudentModel.Age = student.Age;

            return Json(currentStudentModel);
        }

        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetStudents()
        {
            return Json(GroupModel.GetStudents());
        }

        [HttpDelete]
        [Route("{cardNum}/delete")]
        public void DeleteStudentByCardNum(int cardNum)
        {
            GroupModel.DeleteStudentByCardNum(cardNum);
        }

        [HttpPost]
        [Route("{cardNum}/did/{homeWork}")]
        public IActionResult AddDoneHomeWork(int cardNum, string homeWork)
        {
            var student = GroupModel.GetStudentByCardNum(cardNum);
            return Json(student.AddDoneHomeWork(homeWork));
        }
    }
    

}
