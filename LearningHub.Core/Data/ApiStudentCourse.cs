using System;
using System.Collections.Generic;

#nullable disable

namespace LearningHub.Core.Data
{
    public partial class ApiStudentCourse
    {
        public decimal Id { get; set; }
        public decimal? Course_Id { get; set; }
        public decimal? Std_Id { get; set; }
        public decimal? Mark_Student { get; set; }
        public DateTime? Dateofregister { get; set; }

        public virtual ApiCourse Course { get; set; }
        public virtual ApiStudent Std { get; set; }
    }
}
