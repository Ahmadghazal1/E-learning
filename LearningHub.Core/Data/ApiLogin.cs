using System;
using System.Collections.Generic;

#nullable disable

namespace LearningHub.Core.Data
{
    public partial class ApiLogin
    {
        public decimal Id { get; set; }
        public string User_Name { get; set; }
        public string Passwordd { get; set; }
        public decimal? Role_Id { get; set; }
        public decimal? Std_Id { get; set; }

        public virtual ApiRole Role { get; set; }
        public virtual ApiStudent Std { get; set; }
    }
}
