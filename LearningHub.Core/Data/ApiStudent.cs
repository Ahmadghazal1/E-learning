using System;
using System.Collections.Generic;

#nullable disable

namespace LearningHub.Core.Data
{
    public partial class ApiStudent
    {
        public ApiStudent()
        {
            ApiLogins = new HashSet<ApiLogin>();
            ApiStudentCourses = new HashSet<ApiStudentCourse>();
        }

        public decimal Student_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<ApiLogin> ApiLogins { get; set; }
        public virtual ICollection<ApiStudentCourse> ApiStudentCourses { get; set; }
    }
}
