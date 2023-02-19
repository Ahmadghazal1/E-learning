using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LearningHub.infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext dbContext;

        public LoginRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreateLogin(ApiLogin apiLogin)
        {
            var p = new DynamicParameters();
            p.Add("USERNAME", apiLogin.User_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASSWORDD_USER", apiLogin.Passwordd, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLEID", apiLogin.Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STUDENT_ID", apiLogin.Std_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("LOGIN_PACKAGE.InsertLogin", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("IDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("LOGIN_PACKAGE.DELETE_LOGIN", p, commandType: CommandType.StoredProcedure);
        }

        public List<ApiLogin> GetAllLogin()
        {
            IEnumerable<ApiLogin> result = dbContext.Connection.Query<ApiLogin>("LOGIN_PACKAGE.GetAllLogin", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ApiLogin GetLoginById(int id)
        {
            var p = new DynamicParameters();
            p.Add("IDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<ApiLogin> result = dbContext.Connection.Query<ApiLogin>("LOGIN_PACKAGE.GetLoginById",p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void UpdateLogin(ApiLogin apiLogin)
        {
            var p = new DynamicParameters();
            p.Add("IDD", apiLogin.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USERNAME", apiLogin.User_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASSWORDD_USER", apiLogin.Passwordd, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLEID", apiLogin.Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STUDENT_ID", apiLogin.Std_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.Execute("LOGIN_PACKAGE.UPDATE_LOGIN", commandType: CommandType.StoredProcedure);
        }
    }
}
