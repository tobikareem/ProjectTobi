
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ProjectTobi.Model
{
    public class ApplicationUser : IdentityUser<int>
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }

        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }

    }
}
