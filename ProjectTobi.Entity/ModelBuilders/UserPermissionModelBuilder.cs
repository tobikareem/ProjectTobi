
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    public class UserPermissionModelBuilder
    {
        public static void Build(ModelBuilder builder)
        {

           builder.Entity<UserPermission>().Property<int>("UserId");
           builder.Entity<UserPermission>().Property<int>("PermissionId");
           builder.Entity<UserPermission>().HasKey("UserId", "PermissionId");

           builder.Entity<UserPermission>().HasOne(typeof(User), "User").WithMany("UserPermissions").HasForeignKey("UserId");
           builder.Entity<UserPermission>().HasOne(typeof(Permission), "Permission").WithMany("UserPermissions").HasForeignKey("PermissionId");
          
        }
    }
}
