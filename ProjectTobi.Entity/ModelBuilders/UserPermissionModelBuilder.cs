
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    public class UserPermissionModelBuilder
    {
        public static void Build(ModelBuilder builder)
        {

            builder.Entity<ApplicationUserRole>().HasOne<ApplicationUser>().WithMany().HasForeignKey(c => c.ApplicationUserId);
            builder.Entity<ApplicationUserRole>().HasOne<ApplicationRole>().WithMany().HasForeignKey(c => c.ApplicationRoleId);

        }
    }
}
