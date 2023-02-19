using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;

        }
        [HttpGet]
        public List<ApiRole> GetAllRole()
        {
           return roleService.GetAllRole();
        }
        [HttpGet]
        [Route("GetRoleById/{id}")]
       public ApiRole GetRoleById(int id)
        {
            return roleService.GetRoleById(id);
        }
        [HttpPost]
        [Route("CreateRole")]
        public void CreateRole(ApiRole apiRole)
        {
            roleService.CreateRole(apiRole);
        }
        [HttpPut]
       public void UpdateRole(ApiRole apiRole)
        {
            roleService.UpdateRole(apiRole);
        }
        [HttpDelete]
        [Route("DeleteRole/{id}")]
       public void DeleteRole(int id)
        {
            roleService.DeleteRole(id);
        }
    }
}
