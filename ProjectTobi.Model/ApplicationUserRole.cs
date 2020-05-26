using Microsoft.AspNetCore.Identity;

namespace ProjectTobi.Model
{
    public class ApplicationUserRole: IdentityUserRole<int>
    {

        public int ApplicationUserId { get; set; }
        public int ApplicationRoleId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
