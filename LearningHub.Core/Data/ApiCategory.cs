using System;
using System.Collections.Generic;

#nullable disable

namespace LearningHub.Core.Data
{
    public partial class ApiCategory
    {
        public ApiCategory()
        {
            ApiCourses = new HashSet<ApiCourse>();
        }

        public decimal Category_Id { get; set; }
        public string Category_Name { get; set; }

        public virtual ICollection<ApiCourse> ApiCourses { get; set; }
    }
}
