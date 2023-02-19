using System;
using System.Collections.Generic;

#nullable disable

namespace LearningHub.Core.Data
{
    public partial class ApiCourse
    {
        public ApiCourse()
        {
            ApiStudentCourses = new HashSet<ApiStudentCourse>();
        }

        public decimal Course_Id { get; set; }
        public string Course_Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Category_Id { get; set; }
        public string Imagename { get; set; }

        public virtual ApiCategory Category { get; set; }
        public virtual ICollection<ApiStudentCourse> ApiStudentCourses { get; set; }
    }
}
