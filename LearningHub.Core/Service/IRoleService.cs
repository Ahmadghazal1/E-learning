using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.Core.Service
{
    public interface IRoleService
    {
        List<ApiRole> GetAllRole();
        ApiRole GetRoleById(int id);
        void CreateRole(ApiRole apiRole);
        void UpdateRole(ApiRole apiRole);
        void DeleteRole(int id);
    }
}
