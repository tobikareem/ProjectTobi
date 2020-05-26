using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    internal class ImageModelBuilder
    {
        internal static void Build(ModelBuilder builder)
        {
            builder.Entity<Image>().ToTable("Images");
            builder.Entity<Image>().Property(c => c.Id)
             .HasColumnType("int");

            builder.Entity<Image>().Property(c => c.IsPrimary)
             .HasColumnType("bit");

            builder.Entity<Image>().Property(c => c.Picture);

            builder.Entity<Image>().Property(c => c.Name);

            // Shadow property UserId for Foreignkey
            builder.Entity<Image>().Property<int>("UserId");

            builder.Entity<Image>().Property(c => c.CreatedBy)
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

            builder.Entity<Image>().Property(c => c.CreatedDate)
             .HasColumnType("datetimeoffset")
             .HasDefaultValueSql("getutcdate()");

            builder.Entity<Image>().Property(c => c.ModifiedBy)
             .HasColumnType("varchar(200)")
             .HasMaxLength(200);

            builder.Entity<Image>().Property(c => c.ModifiedDate)
             .HasColumnType("datetimeoffset");

            builder.Entity<Image>().HasKey(c => c.Id);

           builder.Entity<Image>().HasOne<ApplicationUser>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade);

        }
    }
}
