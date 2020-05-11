using System;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    internal class CommentModelBuilder
    {
        internal static void Build(ModelBuilder builder)
        {
           builder.Entity<Comment>()
                  .Property(c => c.Id)
             .HasColumnType("int");

           builder.Entity<Comment>().Property(c => c.UserName)
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

           builder.Entity<Comment>().Property(c => c.Content);

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

           builder.Entity<Comment>().HasOne(typeof(User), "User").WithMany("Comments");
           builder.Entity<Comment>().HasOne(typeof(Blog), "Blog").WithMany("Comments");
        }
    }
}
