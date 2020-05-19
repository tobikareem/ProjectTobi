using System;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    internal class UserModelBuilder
    {
        internal static void Build(ModelBuilder builder)
        {

            builder.Entity<User>().Property(c => c.Id)
             .HasColumnType("int");

            builder.Entity<User>().Property<string>("FirstName")
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

            builder.Entity<User>().Property<string>("LastName")
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

            builder.Entity<User>().Property<string>("DisplayName")
             .HasColumnType("varchar(200)")
             .HasMaxLength(200)
             .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

            builder.Entity<User>().Property<string>("Email")
             .HasColumnType("nvarchar(200)")
             .HasMaxLength(200);

            builder.Entity<User>().Property<string>("PhoneNumber")
             .HasColumnType("nvarchar(max)");

            builder.Entity<User>().Property<string>("CreatedBy")
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

            builder.Entity<User>().Property(c => c.CreatedDate)
             .HasColumnType("datetimeoffset")
             .HasDefaultValueSql("getutcdate()");

            builder.Entity<User>().Property<string>("ModifiedBy")
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

            builder.Entity<User>().Property(c => c.ModifiedDate)
             .HasColumnType("datetimeoffset");

            builder.Entity<User>().HasKey(c => c.Id);

            builder.Entity<User>().HasIndex("FirstName")
             .HasName("IX_tobs_User_FirstName")
             .IsUnique();
            builder.Entity<User>().HasMany(typeof(Image),"Images").WithOne("User").HasForeignKey("UserId").IsRequired();
            builder.Entity<User>().HasMany(typeof(UserPermission), "UserPermissions").WithOne("User").HasForeignKey("UserId").IsRequired();
            builder.Entity<User>().HasMany(typeof(Blog), "Blogs").WithOne("User").HasForeignKey("UserId").IsRequired();
            builder.Entity<User>().HasMany(typeof(Comment), "Comments").WithOne("User").HasForeignKey("UserId").IsRequired();
          
        }
    }
}
