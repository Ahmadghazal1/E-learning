using System;
using System.Collections.Generic;

#nullable disable

namespace LearningHub.Core.Data
{
    public partial class ApiRole
    {
        public ApiRole()
        {
            ApiLogins = new HashSet<ApiLogin>();
        }

        public decimal RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<ApiLogin> ApiLogins { get; set; }
    }
}
