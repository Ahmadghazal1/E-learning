using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
 
        public List<ApiStudent> GetAllStudent()
        {
            return _studentService.GetAllStudent();
        }

        [HttpPost]
       public void CreateStudent(ApiStudent apiStudent)
        {
            _studentService.CreateStudent(apiStudent);
        }
        [HttpPut]
        public void UpdateStudent(ApiStudent apiStudent)
        {
            _studentService.UpdateStudent(apiStudent);
        }
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public void DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }
        [HttpGet]
        [Route("GetStudentById/{id}")]
       public ApiStudent GetStudentById(int id)
        {
            return _studentService.GetStudentById(id);
        }
        [HttpGet]
        [Route("GetStudentWithFullName")]
       public List<ApiStudent> GetStudentWithFullName()
        {
            return _studentService.GetStudentWithFullName();
        }
        [HttpGet]
        [Route("GetStudentByFirstName")]
        public List<ApiStudent> GetStudentByFirstName(string firstName)
        {
            return _studentService.GetStudentByFirstName(firstName);
        }
        [HttpGet]
        [Route("GetStudentByBirthDay(")]
        public List<ApiStudent> GetStudentByBirthDay(DateTime birth_date)
        {
            return _studentService.GetStudentByBirthDay(birth_date);
        }

    }
}
