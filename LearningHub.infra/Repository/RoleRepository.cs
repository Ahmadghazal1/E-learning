using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace LearningHub.infra.Repository
{
    
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext dbContext;
        public RoleRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreateRole(ApiRole apiRole)
        {
            var p = new DynamicParameters();
            p.Add("NAMEE", apiRole.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("ROLE_PACKAGE.InsertRole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("IDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Execute("ROLE_PACKAGE.DELETE_ROLE", p, commandType: CommandType.StoredProcedure);
        }

        public List<ApiRole> GetAllRole()
        {
            IEnumerable<ApiRole> result = dbContext.Connection.Query<ApiRole>("ROLE_PACKAGE.GetAllRole", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ApiRole GetRoleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("IDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<ApiRole> result = dbContext.Connection.Query<ApiRole>("ROLE_PACKAGE.GetRoleById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void UpdateRole(ApiRole apiRole)
        {

            var p = new DynamicParameters();
            p.Add("IDD", apiRole.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NAMEE", apiRole.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("ROLE_PACKAGE.UPDATE_ROLE", p, commandType: CommandType.StoredProcedure);


        }
    }
}
