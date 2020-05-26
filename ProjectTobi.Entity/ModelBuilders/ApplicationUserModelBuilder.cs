using System;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;

namespace ProjectTobi.Entity.ModelBuilders
{
    internal class ApplicationUserModelBuilder
    {
        internal static void Build(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationUser>().HasMany<IdentityUserClaim<int>>().WithOne().IsRequired();
            builder.Entity<ApplicationUser>().HasMany<IdentityUserLogin<int>>().WithOne().IsRequired();
            builder.Entity<ApplicationUser>().HasMany<IdentityUserToken<int>>().WithOne().IsRequired();
            builder.Entity<ApplicationUser>().HasMany<ApplicationUserRole>().WithOne().IsRequired();


            builder.Entity<ApplicationUser>().HasMany<Image>().WithOne().IsRequired();
            builder.Entity<ApplicationUser>().HasMany<Blog>().WithOne().IsRequired();
            builder.Entity<ApplicationUser>().HasMany<Comment>().WithOne().IsRequired();
        }
    }
}
