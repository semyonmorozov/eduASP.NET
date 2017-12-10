using System.Collections.Generic;

namespace StudentGroup.Models
{
    public interface IStudentsDatabase
    {
        List<HomeWorkModel> HomeWorks { get; }
        StudentModel GetStudentByCardNum(int cardNum);
        void DeleteStudentByCardNum(int cardNum);
        List<StudentModel> GetStudents();
        void AddStudent(StudentModel student);
    }
}