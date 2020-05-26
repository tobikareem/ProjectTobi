using Microsoft.AspNetCore.Identity;
using System;

namespace ProjectTobi.Model
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
