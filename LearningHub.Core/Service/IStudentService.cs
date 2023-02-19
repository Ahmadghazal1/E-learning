using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.Core.Service
{
    public interface IStudentService
    {
        List<ApiStudent> GetAllStudent();
        void CreateStudent(ApiStudent apiStudent);
        void UpdateStudent(ApiStudent apiStudent);
        void DeleteStudent(int id);
        ApiStudent GetStudentById(int id);
        List<ApiStudent> GetStudentWithFullName();
        List< ApiStudent> GetStudentByFirstName(string firstName);
        List<ApiStudent> GetStudentByBirthDay(DateTime birth_date);
    }
}
