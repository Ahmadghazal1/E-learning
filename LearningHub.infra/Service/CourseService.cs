using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.infra.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }
        public void CreateCourse(ApiCourse apiCourse)
        {
            courseRepository.CreateCourse(apiCourse);
        }

        public void DeleteCourse(int id)
        {
            courseRepository.DeleteCourse(id);
        }

        public Task<List<ApiCategory>> GetAllCategoryCourse()
        {
           return courseRepository.GetAllCategoryCourse();
        }

        public List<ApiCourse> GetAllCourse()
        {
            return courseRepository.GetAllCourse();
        }

        public ApiCourse GetByCourseId(int id)
        {
            return courseRepository.GetCourseById(id);
        }

        public void UpdateCourse(ApiCourse apiCourse)
        {
            courseRepository.UpdateCourse(apiCourse);
        }
    }
}
