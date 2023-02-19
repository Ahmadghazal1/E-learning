using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHub.Core.DTO
{
    public class Search
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public decimal? Mark_Student { get; set; }
        public string Course_Name { get; set; }
        public DateTime? START_DATE { get; set; }
        public DateTime? END_DATE
        {
            get; set;
        }
    }
}
