using System;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    internal class CategoryModelBuilder
    {
        internal static void Build(ModelBuilder builder)
        {
            builder.Entity<Category>()
                   .Property(c => c.Id)
                   .HasColumnType("int");

            builder.Entity<Category>()
                   .Property(c => c.CategoryName)
                   .HasColumnType("varchar(200)")
                   .HasMaxLength(200);

            builder.Entity<Category>()
                   .Property(c => c.CreatedBy)
                   .HasColumnType("varchar(200)")
                   .HasMaxLength(200);

            builder.Entity<Category>()
                   .Property(c => c.CreatedDate)
                     .HasColumnType("datetimeoffset")
                     .HasDefaultValueSql("getutcdate()");

            builder.Entity<Category>()
                .Property(c => c.ModifiedBy)
                 .HasColumnType("varchar(200)")
                 .HasMaxLength(200);

            builder.Entity<Category>()
                   .Property(c => c.ModifiedDate)
                .HasColumnType("datetimeoffset");

            builder.Entity<Category>().HasKey("Id");

            builder.Entity<Category>().HasMany(typeof(Blog), "Blogs").WithOne("Category");
        }
    }
}
