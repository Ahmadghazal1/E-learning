using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.Core.Repository
{
   public interface IStudentRepository
    {
        List<ApiStudent> GetAllStudent();
        ApiStudent GetStudentById(int id);
        void UpdateStudent(ApiStudent apiStudent);
        void CreateStudent(ApiStudent apiStudent);
        void DeleteStudent(int id);

        List<ApiStudent> GetStudentWithFullName();

       List< ApiStudent> GetStudentByFirstName(string firstName);

        List<ApiStudent> GetStudentByBirthDay(DateTime birth_date);
        

        List<ApiStudent> GetStudentByInterval(DateTime start_date , DateTime end_date);

    }
}
