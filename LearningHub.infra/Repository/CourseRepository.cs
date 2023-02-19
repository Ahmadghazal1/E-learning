using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LearningHub.infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public readonly IDbContext _dbContext;
        public CourseRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void CreateCourse(ApiCourse apiCourse)
        {
            var p = new DynamicParameters();
            p.Add("courseName",apiCourse.Course_Name , dbType:DbType.String , direction: ParameterDirection.Input);
            p.Add("price1", apiCourse.Price , dbType:DbType.Int32 , direction: ParameterDirection.Input);
            p.Add("STARTDATE", apiCourse.StartDate , dbType:DbType.DateTime , direction: ParameterDirection.Input);
            p.Add("ENDDATE", apiCourse.EndDate , dbType:DbType.DateTime , direction: ParameterDirection.Input);
            p.Add("IMAGE_NAME", apiCourse.Imagename , dbType:DbType.String , direction: ParameterDirection.Input);
            p.Add("CATEGORYID", apiCourse.Category_Id, dbType:DbType.Int32 , direction: ParameterDirection.Input);

           var result = _dbContext.Connection.Execute("COURSE_PACKAGE.InsertCourse", p, commandType: CommandType.StoredProcedure);

        }

        public void DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("COURSE_PACKAGE.DELETECOURSE", p, commandType: CommandType.StoredProcedure);

        }

        public async Task<List<ApiCategory>> GetAllCategoryCourse()
        {
            var p = new DynamicParameters();
            var result =await _dbContext.Connection.QueryAsync<ApiCategory, ApiCourse, ApiCategory>("COURSE_PACKAGE.GetAllCategoryCourse",

                    (category, course) =>
                    {
                        category.ApiCourses.Add(course);
                        return category;
                    },
                    splitOn: "Course_Id",
                    param: null,
                    commandType: CommandType.StoredProcedure
            );

            var finalResult = result.GroupBy(p => p.Category_Id).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.ApiCourses = g.Select(p =>
                p.ApiCourses.Single()).ToList();
                return groupedPost;

            });
            return finalResult.ToList();

        }

        public List<ApiCourse> GetAllCourse()
        {
            // call for storedProcedure 
           IEnumerable <ApiCourse> result = _dbContext.Connection.Query<ApiCourse>("COURSE_PACKAGE.GetAllCourses",
                
                commandType: CommandType.StoredProcedure);


            return result.ToList();


        }

        public ApiCourse GetCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id",id,dbType:DbType.Int32,direction:ParameterDirection.Input);
            IEnumerable<ApiCourse> result = _dbContext.Connection.Query<ApiCourse>("COURSE_PACKAGE.GetCourseById", p, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault();
           
        }

        public void UpdateCourse(ApiCourse apiCourse)
        {
            var p = new DynamicParameters();
            p.Add("id", apiCourse.Course_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("courseName", apiCourse.Course_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("price1", apiCourse.Price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("STARTDATE", apiCourse.StartDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("ENDDATE", apiCourse.EndDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("IMAGE_NAME", apiCourse.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CATEGORYID", apiCourse.Category_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("COURSE_PACKAGE.UPDATECOURSE", p, commandType: CommandType.StoredProcedure);
        }
    }
}
