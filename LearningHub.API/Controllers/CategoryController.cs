using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAllCategory")]
       public List<ApiCategory> GetAllCategory()
        {
            return categoryService.GetAllCategory();
        }
        [HttpGet]
        [Route("GetCategory/{id}")]
        public ApiCategory GetCategoryById(int id)
        {
            return categoryService.GetCategoryById(id);
        }
        [HttpPost]
        [Route("CreateCategory")]
       public void CreateCategory(ApiCategory apiCategory)
        {
            categoryService.CreateCategory(apiCategory);
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public  void UpdateCategory(ApiCategory apiCategory)
        {
            categoryService.UpdateCategory(apiCategory);
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public  void DeleteCategory(int id)
        {
            categoryService.DeleteCategory(id);
        }

    }
}
