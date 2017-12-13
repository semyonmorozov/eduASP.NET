using System.Collections.Generic;
using System.Linq;
using StudentGroup.Models;

namespace StudentGroup.StudentsDB
{
    public class StudentsDatabase :IStudentsDatabase
    {
        private readonly StudentContext context;

        public StudentsDatabase(StudentContext context)
        {
            this.context = context;
        }

        public StudentModel GetStudentByCardNum(int cardNum)
        {
            return context.Students.First(x => x.StudentCardNumber == cardNum);
        }

        public void DeleteStudentByCardNum(int cardNum)
        {
            context.Students.Remove(context.Students.First(x => x.StudentCardNumber == cardNum));
            context.SaveChanges();
        }

        public List<StudentModel> GetStudents()
        {
            return context.Students.ToList();
        }

        public void AddStudent(StudentModel student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void UpdateStudent(int cardNum, StudentModel student)
        {
            if (student.StudentCardNumber == cardNum)
            {
                var oldStudent = context.Students.FirstOrDefault(s => s.StudentCardNumber == cardNum);
                oldStudent.StudentCardNumber = student.StudentCardNumber;
                oldStudent.FirstName = student.FirstName;
                oldStudent.LastName = student.LastName;
                oldStudent.EmailAddress = student.EmailAddress;
                context.SaveChanges();
            }
            else
            {
                DeleteStudentByCardNum(cardNum);
                AddStudent(student);
            }
        }
    }
}
