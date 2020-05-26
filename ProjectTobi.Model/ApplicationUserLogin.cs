
using Microsoft.AspNetCore.Identity;

namespace ProjectTobi.Model
{
    public class ApplicationUserLogin: IdentityUserLogin<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
