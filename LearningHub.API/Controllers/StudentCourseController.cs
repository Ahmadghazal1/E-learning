using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Service;
using LearningHub.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IStudentCourseService studentCourseService;


        public StudentCourseController(IStudentCourseService studentCourseService)
        {
            this.studentCourseService = studentCourseService;
        }
        [HttpGet]
        [Route("GetAllStudentCourse")]
       public List<ApiStudentCourse> GetAllStudentCourse()
        {
            return studentCourseService.GetAllStudentCourse();
        }
        [HttpPost]
        [Route("CreateStudentCourse")]
       public void CreateStudentCourse(ApiStudentCourse apiStudentCourse)
        {
            studentCourseService.CreateStudentCourse(apiStudentCourse);
        }

        [HttpDelete]
        [Route("DeleteStudentCourse")]
        public void DeleteStudentCourse(int id)
        {
            studentCourseService.DeleteStudentCourse(id);
        }
        [HttpPut]
       public void UpdateStudentCourse(ApiStudentCourse apiStudentCourse)
        {
            studentCourseService.UpdateStudentCourse(apiStudentCourse);
        }
        [HttpGet]
        [Route("GetStudentCourseById")]
       public ApiStudentCourse GetStudentCourseById(int id)
        {
          return  studentCourseService.GetStudentCourseById(id);
        }
        [HttpPost]
        [Route("SearcheStudenCourse")]
        public List<Search> SearcheStudenCourse(Search search)
        {
            return studentCourseService.SearcheStudenCourse(search);
        }
        [HttpGet]
        [Route("TotalStudentInEachCourse")]
        public List<TotalStudents> TotalStudentInEachCourse()
        {
            return
            studentCourseService.TotalStudentInEachCourse();
        }


    }
}
