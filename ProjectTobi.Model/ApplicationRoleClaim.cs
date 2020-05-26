using Microsoft.AspNetCore.Identity;
namespace ProjectTobi.Model
{
    public class ApplicationRoleClaim: IdentityRoleClaim<int>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
