using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;
using ProjectTobi.Entity.ModelBuilders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProjectTobi.Entity.DbContext
{
    public class ProjectContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ProjectContext(DbContextOptions<ProjectContext> context) : base(context)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("tobs");

            //builder.Entity<IdentityUser<int>>().ToTable("Users");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
            builder.Entity<IdentityUserToken<int>>().Property(c => c.LoginProvider).HasMaxLength(128);
            builder.Entity<IdentityUserToken<int>>().Property(c => c.Name).HasMaxLength(128);

            // Build all models
            ApplicationUserModelBuilder.Build(builder);
            ImageModelBuilder.Build(builder);
            PermissionModelBuilder.Build(builder);
            CategoryModelBuilder.Build(builder);
            BlogModelBuilder.Build(builder);
            CommentModelBuilder.Build(builder);
            UserPermissionModelBuilder.Build(builder);
            
        }
    }
}
