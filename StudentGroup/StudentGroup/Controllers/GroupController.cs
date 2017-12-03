using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StudentGroup.Models;

namespace StudentGroup.Controllers
{

    public class GroupController : Controller
    {
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentModel student)
        {
            if (!ModelState.IsValid) return RedirectToAction("AddStudent", "Group");
            foreach (var homeWork in GroupModel.HomeWorks)
            {
                student.DoneHomeWorks.Add(homeWork,0);
            }
            GroupModel.AddStudent(student);
            return RedirectToAction("GetStudents", "Group");
        }
        
        public IActionResult GetStudents()
        {
            return View(GroupModel.GetStudents());
        }
        
        [Route("{cardNum}")]
        public IActionResult GetStudent(int cardNum)
        {
            var student = GroupModel.GetStudentByCardNum(cardNum);
            return View(student);
        }
        
        [Route("{cardNum}/Edit")]
        public IActionResult EditStudent(int cardNum)
        {
            var student = GroupModel.GetStudentByCardNum(cardNum);
            return View(student);
        }

        [HttpPost]
        [Route("{cardNum}/Edit")]
        public IActionResult EditStudent(StudentModel student, int cardNum)
        {
            var currentStudentModel = GroupModel.GetStudentByCardNum(cardNum);
            currentStudentModel.StudentCardNumber = student.StudentCardNumber;
            currentStudentModel.FirstName = student.FirstName;
            currentStudentModel.LastName = student.LastName;
            currentStudentModel.EmailAddress = student.EmailAddress;
            return RedirectToAction("GetStudents", "Group");
        }
        
        [Route("{cardNum}/delete")]
        public IActionResult DeleteStudentByCardNum(int cardNum)
        {
            GroupModel.DeleteStudentByCardNum(cardNum);
            return RedirectToAction("GetStudents", "Group");
        }
        
        [Route("{cardNum}/homeworks")]
        public IActionResult GetDoneHomeWorks(int cardNum)
        {
            var student = GroupModel.GetStudentByCardNum(cardNum);
            return View(student);
        }

        [HttpPost]
        public IActionResult EditHomeWorks(int cardNum,Dictionary<HomeWorkModel,int>homeWorks)
        {
            var student = GroupModel.GetStudentByCardNum(cardNum);
            student.DoneHomeWorks = homeWorks;
            return RedirectToRoute(cardNum + "/homeworks");
        }
    }
    

}
