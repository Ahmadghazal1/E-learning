using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.infra.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public void CreateRole(ApiRole apiRole)
        {
            roleRepository.CreateRole(apiRole);
        }

        public void DeleteRole(int id)
        {
            roleRepository.DeleteRole(id);
        }

        public List<ApiRole> GetAllRole()
        {
           return roleRepository.GetAllRole();
        }

        public ApiRole GetRoleById(int id)
        {
            return roleRepository.GetRoleById(id);
        }

        public void UpdateRole(ApiRole apiRole)
        {
            roleRepository.UpdateRole(apiRole);
        }
    }
}
