using System;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    internal class PermissionModelBuilder
    {
        internal static void Build(ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>().ToTable("Roles");

            builder.Entity<ApplicationRole>().HasMany<ApplicationUserRole>().WithOne().IsRequired();

        }
    }
}
