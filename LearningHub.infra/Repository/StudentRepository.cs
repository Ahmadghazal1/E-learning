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
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContext _dbContext;
        public StudentRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void CreateStudent(ApiStudent apiStudent)
        {
            var P = new DynamicParameters();
            P.Add("FNAME", apiStudent.First_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("LNAME", apiStudent.Last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("DATE_OF_BIRTH", apiStudent.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            P.Add("IMAGEPATH", apiStudent.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Student_Package.InsertStudent", P, commandType: CommandType.StoredProcedure);

        }

        public void DeleteStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Student_Package.DELETE_STUDENT", p, commandType: CommandType.StoredProcedure);
        }

        public List<ApiStudent> GetAllStudent()
        {
           IEnumerable<ApiStudent> result = _dbContext.Connection.Query<ApiStudent>("Student_Package.GetAllStudent",commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ApiStudent> GetStudentByBirthDay(DateTime birth_date)
        {
            var p = new DynamicParameters();
            p.Add("DATE_OF_BIRTH",birth_date,direction:ParameterDirection.Input);

            IEnumerable<ApiStudent> result = _dbContext.Connection.Query<ApiStudent>("Student_Package.GET_STUDENT_BY_BIRTHDATE", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ApiStudent> GetStudentByFirstName(string firstName)
        {
            var p = new DynamicParameters();
            p.Add("FNAME", firstName, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<ApiStudent> result = _dbContext.Connection.Query<ApiStudent>("Student_Package.GET_STUDENT_BY_FNAME", p, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public ApiStudent GetStudentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<ApiStudent> result = _dbContext.Connection.Query<ApiStudent>("Student_Package.GetStudentById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<ApiStudent> GetStudentByInterval(DateTime start_date, DateTime end_date)
        {
            var p = new DynamicParameters();
            p.Add("START_BIRTH",start_date,dbType:DbType.Date,direction:ParameterDirection.Input);
            p.Add("END_BIRTH", start_date,dbType:DbType.Date,direction:ParameterDirection.Input);

            IEnumerable<ApiStudent> result = _dbContext.Connection.Query<ApiStudent>("Student_Package.GET_STUDENT_BY_INTERVAL", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
          
        }

        public List<ApiStudent> GetStudentWithFullName()
        {
       
            IEnumerable<ApiStudent> result = _dbContext.Connection.Query<ApiStudent>("Student_Package.GET_ALL_STUDENT_BY_NAME", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void UpdateStudent(ApiStudent apiStudent)
        {
            var p = new DynamicParameters();
            p.Add("ID", apiStudent.Student_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("FNAME", apiStudent.First_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("LNAME", apiStudent.Last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("DATE_OF_BIRTH", apiStudent.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("IMAGE_NAME", apiStudent.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Student_Package.UPDATE_STUDENT", p, commandType: CommandType.StoredProcedure);

        }
    }
}
