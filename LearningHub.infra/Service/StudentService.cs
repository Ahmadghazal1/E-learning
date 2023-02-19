using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.infra.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public void CreateStudent(ApiStudent apiStudent)
        {
            studentRepository.CreateStudent(apiStudent);
        }

        public void DeleteStudent(int id)
        {
            studentRepository.DeleteStudent(id);
        }

        public List<ApiStudent> GetAllStudent()
        {
            return studentRepository.GetAllStudent();
        }

        public List<ApiStudent> GetStudentByBirthDay(DateTime birth_date)
        {
            return studentRepository.GetStudentByBirthDay(birth_date);
        }

        public List<ApiStudent> GetStudentByFirstName(string firstName)
        {
            return studentRepository.GetStudentByFirstName(firstName);
        }

        public ApiStudent GetStudentById(int id)
        {
            return studentRepository.GetStudentById(id);
        }

        public List<ApiStudent> GetStudentWithFullName()
        {
            return studentRepository.GetStudentWithFullName();
        }

        public void UpdateStudent(ApiStudent apiStudent)
        {
            studentRepository.UpdateStudent(apiStudent);
        }


    }
}
