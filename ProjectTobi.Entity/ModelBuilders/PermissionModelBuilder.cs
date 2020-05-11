using System;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    internal class PermissionModelBuilder
    {
        internal static void Build(ModelBuilder builder)
        {

            builder.Entity<Permission>().Property(c => c.Id)
             .HasColumnType("int");

            builder.Entity<Permission>().Property(c => c.PermissionName)
             .HasColumnType("varchar(300)")
             .HasMaxLength(300);

            builder.Entity<Permission>().Property(c => c.CreatedBy)
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

            builder.Entity<Permission>().Property(c => c.CreatedDate)
             .HasColumnType("datetimeoffset")
             .HasDefaultValueSql("getutcdate()");

            builder.Entity<Permission>().Property(c => c.ModifiedBy)
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

            builder.Entity<Permission>().Property(c => c.ModifiedDate)
             .HasColumnType("datetimeoffset");

            builder.Entity<Permission>().HasKey("Id");
            builder.Entity<Permission>().HasIndex("PermissionName")
             .HasName("IX_tobs_Permission_PermissionName")
             .IsUnique();

            builder.Entity<Permission>().HasMany(typeof(UserPermission), "UserPermissions").WithOne("Permission");

        }
    }
}
