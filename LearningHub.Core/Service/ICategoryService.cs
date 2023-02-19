using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.Core.Service
{
    public interface ICategoryService
    {
        List<ApiCategory> GetAllCategory();
        ApiCategory GetCategoryById(int id);
        void CreateCategory(ApiCategory apiCategory);
        void UpdateCategory(ApiCategory apiCategory);
        void DeleteCategory(int id);
    }
}
