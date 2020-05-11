using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    internal class ImageModelBuilder
    {
        internal static void Build(ModelBuilder builder)
        {

            builder.Entity<Image>().Property(c => c.Id)
             .HasColumnType("int");

            builder.Entity<Image>().Property(c => c.IsPrimary)
             .HasColumnType("bit");

            builder.Entity<Image>().Property(c => c.Picture);

            builder.Entity<Image>().Property(c => c.Name);

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

            builder.Entity<Image>().HasOne(typeof(User), "User").WithMany("Images").HasForeignKey("UserId");

        }
    }
}
