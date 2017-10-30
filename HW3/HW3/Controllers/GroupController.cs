using System.Collections.Generic;
using HW3.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW3.Controllers
{
    [Route("[controller]")]
    public class GroupController : Controller
    {
        [Route("[Action]")]
        public StudentModel AddStudent(string name)
        {
            StudentModel student = new StudentModel { Name = name, DoneHomeWorks = new List<string>()}; 
            GroupModel.AddStudent(student);
            return student;
        }

        [Route("[Action]")]
        public List<StudentModel> GetStudents()
        {
            return GroupModel.GetStudents();
        }

        [Route("{name}/delete")]
        public void DeleteStudentByName(string name)
        {
            GroupModel.DeleteStudentByName(name);
        }

        [Route("{name}/did/{homeWork}")]
        public void AddDoneHW(string name, string homeWork)
        {
            GroupModel.AddDoneHW(name,homeWork);
        }
    }
}
