using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        // call function from ICourseService 

        [HttpGet]
        public List<ApiCourse> GetAllCourse()
        {
            return courseService.GetAllCourse();
        }

        [HttpGet]
        [Route("getCourseById/{id}")]
         public  ApiCourse GetByCourseId(int id)
        {
            return courseService.GetByCourseId(id);
        }
        [HttpPost]
     
        public void CreateCourse(ApiCourse apiCourse)
        {
            courseService.CreateCourse(apiCourse);
        }
        [HttpPut]
        
        public void UpdateCourse([FromBody] ApiCourse apiCourse)
        {
            courseService.UpdateCourse(apiCourse);
        }
        [HttpDelete]
        [Route("DeleteCourse/{id}")]
       public void DeleteCourse(int id)
        {
            courseService.DeleteCourse(id);

        }

        [Route("uploadImage")]
        [HttpPost]
        public ApiCourse UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            ApiCourse item = new ApiCourse();
            item.Imagename = fileName;
            return item;
        }

        [HttpGet]
        [Route("GetAllCategoryCourse")]
        public Task<List<ApiCategory>> GetAllCategoryCourse()
        {
            return courseService.GetAllCategoryCourse();
        }

    }
}
