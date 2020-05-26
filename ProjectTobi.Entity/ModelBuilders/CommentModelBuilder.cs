using System;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    internal class CommentModelBuilder
    {
        internal static void Build(ModelBuilder builder)
        {
            builder.Entity<Comment>().ToTable("Comments");

           builder.Entity<Comment>()
                  .Property(c => c.Id)
             .HasColumnType("int");

           builder.Entity<Comment>().Property(c => c.UserName)
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

           builder.Entity<Comment>().Property(c => c.Content);

            //Shadow Properties for foreign keys
            builder.Entity<Comment>().Property<int>("UserId");
            builder.Entity<Comment>().Property<int>("BlogId");

            builder.Entity<Comment>().Property(c => c.CreatedBy)
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

           builder.Entity<Comment>().Property(c => c.CreatedDate)
             .HasColumnType("datetimeoffset")
             .HasDefaultValueSql("getutcdate()");

           builder.Entity<Comment>().Property(c => c.ModifiedBy)
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

           builder.Entity<Comment>().Property(c => c.ModifiedDate)
             .HasColumnType("datetimeoffset");

           builder.Entity<Comment>().HasKey(keyExpression: c => c.Id);

           builder.Entity<Comment>().HasOne<ApplicationUser>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade);
           builder.Entity<Comment>().HasOne<Blog>().WithMany().HasForeignKey("BlogId").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
