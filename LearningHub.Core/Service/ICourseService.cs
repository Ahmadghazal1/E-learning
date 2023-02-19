using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Service
{
    public interface ICourseService
    {
        List<ApiCourse> GetAllCourse();
        void CreateCourse(ApiCourse apiCourse);
        void DeleteCourse(int id);
        public void UpdateCourse(ApiCourse apiCourse);
        ApiCourse GetByCourseId(int id);

        Task<List<ApiCategory>> GetAllCategoryCourse();

    }
}
