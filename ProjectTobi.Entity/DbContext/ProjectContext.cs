using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;
using ProjectTobi.Entity.ModelBuilders;

namespace ProjectTobi.Entity.DbContext
{
    public class ProjectContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options): base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("tobs");

            // Build all models
            UserModelBuilder.Build(builder);
            ImageModelBuilder.Build(builder);
            PermissionModelBuilder.Build(builder);
            CategoryModelBuilder.Build(builder);
            BlogModelBuilder.Build(builder);
            CommentModelBuilder.Build(builder);
            UserPermissionModelBuilder.Build(builder);
        }
    }
}
