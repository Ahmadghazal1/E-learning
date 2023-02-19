using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.infra.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void CreateCategory(ApiCategory apiCategory)
        {
            categoryRepository.CreateCategory(apiCategory);
        }

        public void DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
        }

        public List<ApiCategory> GetAllCategory()
        {
                return    categoryRepository.GetAllCategory();
        }

        public ApiCategory GetCategoryById(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        public void UpdateCategory(ApiCategory apiCategory)
        {
            categoryRepository.UpdateCategory(apiCategory);
        }
    }
}
