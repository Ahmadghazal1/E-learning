using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.Core.Repository
{
     public interface IStudentCourseRepository
    {
        List<ApiStudentCourse> GetAllStudentCourse();
        void CreateStudentCourse(ApiStudentCourse apiStudentCourse);
        void DeleteStudentCourse(int id);
        void UpdateStudentCourse(ApiStudentCourse apiStudentCourse);
        ApiStudentCourse GetStudentCourseById(int id);
        List<Search> SearcheStudenCourse(Search search);
         List<TotalStudents> TotalStudentInEachCourse();


    }
}
