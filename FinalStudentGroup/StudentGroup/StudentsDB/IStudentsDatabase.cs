using System.Collections.Generic;
using StudentGroup.Models;

namespace StudentGroup.StudentsDB
{
    public interface IStudentsDatabase
    {
        StudentModel GetStudentByCardNum(int cardNum);
        void DeleteStudentByCardNum(int cardNum);
        List<StudentModel> GetStudents();
        void AddStudent(StudentModel student);
        void UpdateStudent(int cardNum, StudentModel student);
    }
}