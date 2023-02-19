using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Repository
{
    public interface ICourseRepository
    {
        List<ApiCourse> GetAllCourse();
        ApiCourse GetCourseById(int id);
        void CreateCourse(ApiCourse apiCourse);
        void UpdateCourse(ApiCourse apiCourse);
        void DeleteCourse(int id);
        Task<List<ApiCategory>> GetAllCategoryCourse();
    }
}
