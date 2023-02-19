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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;
        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCategory(ApiCategory apiCategory)
        {
            var p = new DynamicParameters();
            p.Add("CAT_NAME", apiCategory.Category_Name, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CATEGORY_PACKAGE.InsertCategory",p, commandType:CommandType.StoredProcedure);
                
                
         }

        public void DeleteCategory(int id)
        {
            var p = new DynamicParameters();
            p.Add("IDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("CATEGORY_PACKAGE.DELETE_CATEGORY", p, commandType: CommandType.StoredProcedure);
        }

        public List<ApiCategory> GetAllCategory()
        {
            IEnumerable<ApiCategory> result = _dbContext.Connection.Query<ApiCategory>("CATEGORY_PACKAGE.GetAllCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public ApiCategory GetCategoryById(int id)
        {
            var p = new DynamicParameters();

            p.Add("IDD", id, dbType: DbType.Int32,direction: ParameterDirection.Input);

            IEnumerable<ApiCategory> result = _dbContext.Connection.Query<ApiCategory>("CATEGORY_PACKAGE.GetCategoryById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateCategory(ApiCategory apiCategory)
        {
            var p = new DynamicParameters();
            p.Add("IDD", apiCategory.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NAMEE", apiCategory.Category_Name, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("CATEGORY_PACKAGE.UPDATE_CATEGORY", p, commandType: CommandType.StoredProcedure);
        }
    }
}
