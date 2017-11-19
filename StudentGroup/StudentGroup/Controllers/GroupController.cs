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
        public StudentModel AddStudent([FromBody]StudentModel student)
        {
            GroupModel.AddStudent(student);
            return student;
        }

        [HttpPut]
        [Route("[Action]")]
        public StudentModel UpdateStudent([FromQuery]int cardNum, [FromBody]StudentModel student)
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

            return currentStudentModel;
        }

        [HttpGet]
        [Route("[Action]")]
        public List<StudentModel> GetStudents()
        {
            return GroupModel.GetStudents();
        }

        [HttpDelete]
        [Route("{cardNum}/delete")]
        public void DeleteStudentByCardNum(int cardNum)
        {
            GroupModel.DeleteStudentByCardNum(cardNum);
        }

        [HttpPost]
        [Route("{cardNum}/did/{homeWork}")]
        public StudentModel AddDoneHomeWork(int cardNum, string homeWork)
        {
            var student = GroupModel.GetStudentByCardNum(cardNum);
            return student.AddDoneHomeWork(homeWork);
        }
    }
    

}
