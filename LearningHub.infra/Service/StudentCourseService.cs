using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Repository;
using LearningHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.infra.Service
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IStudentCourseRepository studentCourseRepository;

        public StudentCourseService(IStudentCourseRepository studentCourseRepository)
        {
            this.studentCourseRepository = studentCourseRepository;
        }

        public void CreateStudentCourse(ApiStudentCourse apiStudentCourse)
        {
            studentCourseRepository.CreateStudentCourse(apiStudentCourse);
        }

        public void DeleteStudentCourse(int id)
        {
            studentCourseRepository.DeleteStudentCourse(id);
        }

        public List<ApiStudentCourse> GetAllStudentCourse()
        {
            return studentCourseRepository.GetAllStudentCourse();
        }

        public ApiStudentCourse GetStudentCourseById(int id)
        {
            return studentCourseRepository.GetStudentCourseById(id);
        }

        public List<Search> SearcheStudenCourse(Search search)
        {
            return studentCourseRepository.SearcheStudenCourse(search);
        }

        public List<TotalStudents> TotalStudentInEachCourse()
        {
            return studentCourseRepository.TotalStudentInEachCourse();
        }

        public void UpdateStudentCourse(ApiStudentCourse apiStudentCourse)
        {
            studentCourseRepository.UpdateStudentCourse(apiStudentCourse);
        }
    }
}
