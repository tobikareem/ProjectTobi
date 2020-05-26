
using Microsoft.AspNetCore.Identity;

namespace ProjectTobi.Model
{
    public class ApplicationUserToken : IdentityUserToken<int>
    {
        public virtual ApplicationUser User { get; set; }
    }
}
