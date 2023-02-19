using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        [HttpGet]
        [Route("GetAllLogin")]
         public  List<ApiLogin> GetAllLogin()
        {
            return loginService.GetAllLogin();
        }

        [HttpGet]
        [Route("GetLoginById/{id}")]
       public ApiLogin GetLoginById(int id)
        {
            return loginService.GetLoginById(id);
        }
        [HttpPost]
        [Route("Create")]
        public  void CreateLogin(ApiLogin apiLogin)
        {
            loginService.CreateLogin(apiLogin);
        }
        [HttpPut]
        [Route("Update")]
        public void UpdateLogin(ApiLogin apiLogin)
        {
            loginService.UpdateLogin(apiLogin);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteLogin(int id)
        {
            loginService.DeleteLogin(id);
        }
    }
}
