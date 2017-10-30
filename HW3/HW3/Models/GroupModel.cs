using System.Collections.Generic;
using System.Linq;

namespace HW3.Models
{
    public static class GroupModel
    {
        private static List<StudentModel> students = new List<StudentModel>();

        public static void AddStudent(StudentModel student)
        {
            students.Add(student);
        }

        public static List<StudentModel> GetStudents()
        {
            return students;
        }

        public static void DeleteStudentByName(string name)
        {
            students.Remove(students.Find(x => x.Name == name));
        }

        public static StudentModel GetStudentByName(string name)
        {
            return students.Find(x => x.Name == name);
        }

        public static void AddDoneHW(string name, string homeWork)
        {
            students.First(d => d.Name == name).DoneHomeWorks.Add(homeWork);
        }
    }
}
