
using Microsoft.AspNetCore.Identity;

namespace ProjectTobi.Model
{
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
