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

            // Shadow Properties for foreign keys
            builder.Entity<Blog>().Property<int>("UserId");
            builder.Entity<Blog>().Property<int>("CategoryId");

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

            builder.Entity<Blog>().HasOne<User>().WithMany().HasForeignKey("UserId").IsRequired();
            builder.Entity<Blog>().HasOne<Category>().WithMany().HasForeignKey("CategoryId").IsRequired();
            builder.Entity<Blog>().HasMany<Comment>().WithOne().IsRequired();
        
        }
    }
}
