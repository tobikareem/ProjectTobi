
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
            builder.Entity<UserPermission>().Property<string>("CreatedBy")
                 .HasColumnType("varchar(200)")
                 .HasMaxLength(200);
            builder.Entity<UserPermission>().Property(c => c.CreatedDate)
             .HasColumnType("datetimeoffset")
             .HasDefaultValueSql("getutcdate()");
            builder.Entity<UserPermission>().Property(c => c.ModifiedBy)
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);
            builder.Entity<UserPermission>().Property(c => c.ModifiedDate)
             .HasColumnType("datetimeoffset");

            builder.Entity<UserPermission>().HasKey("UserId", "PermissionId");

            builder.Entity<UserPermission>().HasOne<User>().WithMany().HasForeignKey(c => c.UserId);
            builder.Entity<UserPermission>().HasOne<Permission>().WithMany().HasForeignKey(c => c.PermissionId);

        }
    }
}
