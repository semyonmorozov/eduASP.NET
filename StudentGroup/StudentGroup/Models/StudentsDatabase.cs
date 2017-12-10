using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGroup.Models
{
    public class StudentsDatabase : IStudentsDatabase
    {
        public List<HomeWorkModel> HomeWorks => new List<HomeWorkModel>
        {
            new HomeWorkModel{DeadLine = new DateTime(2017,10,30), Title = "Introdution"},
            new HomeWorkModel{DeadLine = new DateTime(2017,11,06), Title = "Middleware"},
            new HomeWorkModel{DeadLine = new DateTime(2017,11,13), Title = "MVC p1"},
            new HomeWorkModel{DeadLine = new DateTime(2017,11,20), Title = "MVC p2"},
            new HomeWorkModel{DeadLine = new DateTime(2017,12,04), Title = "Razor"},
            new HomeWorkModel{DeadLine = new DateTime(2017,12,11), Title = "Dependency Injection"},
            new HomeWorkModel{DeadLine = new DateTime(2017,12,18), Title = "EF.Part1"},
            new HomeWorkModel{DeadLine = new DateTime(2017,12,25), Title = "EF.Part2"}
        };

        private readonly List<StudentModel> students = new List<StudentModel>();

        public void AddStudent(StudentModel student)
        {
            students.Add(student);
        }

        public List<StudentModel> GetStudents()
        {
            return students;
        }

        public void DeleteStudentByCardNum(int cardNum)
        {
            students.Remove(students.Find(x => x.StudentCardNumber == cardNum));
        }

        public List<StudentModel> GetStudentsByName(string name)
        {
            return students.Where(x => x.FirstName == name).ToList();
        }

        public StudentModel GetStudentByCardNum(int cardNum)
        {
            return students.Find(x => x.StudentCardNumber == cardNum);
        }
    }
}
