using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LearningHub.infra.Repository
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly IDbContext dbContext;

        public StudentCourseRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreateStudentCourse(ApiStudentCourse apiStudentCourse)
        {
            var p = new DynamicParameters();
            p.Add("studentid", apiStudentCourse.Std_Id, dbType: DbType.Int32, direction:
            ParameterDirection.Input);
            p.Add("courseid", apiStudentCourse.Course_Id, dbType: DbType.Int32,
            direction: ParameterDirection.Input);
            p.Add("markstudent", apiStudentCourse.Mark_Student, dbType: DbType.Int32,
            direction: ParameterDirection.Input);
            p.Add("date_of_register", apiStudentCourse.Dateofregister, dbType:
            DbType.DateTime, direction: ParameterDirection.Input);
            var result =
            dbContext.Connection.Execute("STDCOURSE_PACKAGE.InsertStudentCourse", p,
            commandType: CommandType.StoredProcedure);

        }

        public void DeleteStudentCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("IDD", id, dbType: DbType.Int32, direction:
            ParameterDirection.Input);
            var result =
            dbContext.Connection.ExecuteAsync("STDCOURSE_PACKAGE.DeleteStudentCourse", p,
            commandType: CommandType.StoredProcedure);

        }

        public List<ApiStudentCourse> GetAllStudentCourse()
        {
            IEnumerable<ApiStudentCourse> result =
dbContext.Connection.Query<ApiStudentCourse>("STDCOURSE_PACKAGE.GetAllStudentCourse",
commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

        public ApiStudentCourse GetStudentCourseById(int id)
        {
            var p = new DynamicParameters();
            p.Add("IDD", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ApiStudentCourse> result =
            dbContext.Connection.Query<ApiStudentCourse>("STDCOURSE_PACKAGE.GetStudentCourseById", p,
            commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Search> SearcheStudenCourse(Search search)
        {
            var p = new DynamicParameters();

            p.Add("cName", search.Course_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("sName", search.First_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DateFrom", search.START_DATE, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DateTo", search.END_DATE, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            IEnumerable<Search> result = dbContext.Connection.Query<Search>("STDCOURSE_PACKAGE.SearchStudentAndCourse", p, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public List<TotalStudents> TotalStudentInEachCourse()
        {
            IEnumerable<TotalStudents> result = dbContext.Connection.Query<TotalStudents>("STDCOURSE_PACKAGE.TotalStudentInEachCourse", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdateStudentCourse(ApiStudentCourse apiStudentCourse)
        {
            var p = new DynamicParameters();
            p.Add("IDD", apiStudentCourse.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("studentid", apiStudentCourse.Std_Id, dbType: DbType.Int32, direction:
            ParameterDirection.Input);
            p.Add("courseid", apiStudentCourse.Course_Id, dbType: DbType.Int32,
            direction: ParameterDirection.Input);
            p.Add("markstudent", apiStudentCourse.Mark_Student, dbType: DbType.Int32,
            direction: ParameterDirection.Input);
            p.Add("date_of_register", apiStudentCourse.Dateofregister, dbType:
            DbType.DateTime, direction: ParameterDirection.Input);
            var result =
            dbContext.Connection.ExecuteAsync("STDCOURSE_PACKAGE.InsertStudentCourse", p,
            commandType: CommandType.StoredProcedure);
        }
    }
}
