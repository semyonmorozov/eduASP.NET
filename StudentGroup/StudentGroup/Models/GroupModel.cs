using System.Collections.Generic;
using System.Linq;

namespace StudentGroup.Models
{
    public static class GroupModel
    {
        private static List<StudentModel> students
            = new List<StudentModel>{
                new StudentModel
                {
                    FirstName = "Anna",
                    LastName = "Egorova",
                    Age = 22,
                    StudentCardNumber = 65034584,
                    EmailAddress = "annaegorova@mail.com"
                }
            };

        public static void AddStudent(StudentModel student)
        {
            students.Add(student);
        }

        public static List<StudentModel> GetStudents()
        {
            return students;
        }

        public static void DeleteStudentByCardNum(int cardNum)
        {
            students.Remove(students.Find(x => x.StudentCardNumber == cardNum));
        }

        public static List<StudentModel> GetStudentsByName(string name)
        {
            return students.Where(x => x.FirstName == name).ToList();
        }

        public static StudentModel GetStudentByCardNum(int cardNum)
        {
            return students.Find(x => x.StudentCardNumber == cardNum);
        }
    }
}
