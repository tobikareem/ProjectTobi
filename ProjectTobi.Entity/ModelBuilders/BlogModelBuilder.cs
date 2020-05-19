using System;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    internal class BlogModelBuilder
    {
        internal static void Build(ModelBuilder builder)
        {
            builder.Entity<Blog>()
                   .Property(c => c.Id)
                   .HasColumnType("int");

            builder.Entity<Blog>()
                   .Property(c => c.Title)
                   .HasColumnType("varchar(200)")
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Entity<Blog>()
                   .Property(c => c.Content)
                   .IsRequired();

            builder.Entity<Blog>()
                   .Property(c => c.CreatedBy)
                   .HasColumnType("varchar(200)")
                    .HasMaxLength(200);

            builder.Entity<Blog>()
                   .Property(c => c.CreatedDate)
                   .HasColumnType("datetimeoffset")
                   .HasDefaultValueSql("getutcdate()");

            builder.Entity<Blog>()
                   .Property(c => c.ModifiedBy)
                   .HasColumnType("varchar(200)")
                   .HasMaxLength(200);

            builder.Entity<Blog>()
                   .Property(c => c.ModifiedDate)
                   .HasColumnType("datetimeoffset");

            builder.Entity<Blog>()
                   .HasKey("Id");

            builder.Entity<Blog>()
                   .HasIndex("Title")
                    .HasName("IX_tobs_Blog_Title");

           // builder.Entity<Blog>().HasOne(typeof(Category), "Category").WithMany("Blogs").HasForeignKey("CategoryId");
           // builder.Entity<Blog>().HasOne(typeof(User), "User").WithMany("Blogs").HasForeignKey("UserId");
            builder.Entity<Blog>().HasMany(typeof(Comment), "Comments").WithOne("Blog").HasForeignKey("BlogId").IsRequired();
        
        }
    }
}
