                                                   
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;
using ProjectTobi.Repository;
using ProjectTobi.Interface.Service;
using ProjectTobi.Service;
using Microsoft.AspNetCore.Identity;

namespace ProjectTobi.Base
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBlogService, BlogService>();


            // Add Repositories
            services.AddScoped<ICrudRepository<User>, UserRepository>();
            services.AddScoped<ICrudRepository<Blog>, BlogRepository>();
            services.AddScoped<ICrudRepository<Permission>, PermissionRepository>();
            services.AddScoped<ICrudRepository<Image>, ImageRepository>();
            services.AddScoped<ICrudRepository<Category>, CategoryRepository>();
            services.AddScoped<ICrudRepository<Comment>, CommentRepository>();

            // DB Context
            services.AddDbContext<ProjectContext>(options =>
            {
                var getConfig = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(getConfig, providerOption => providerOption.EnableRetryOnFailure(3));
            });


            // Identity Server
            services.Configure<IdentityOptions>((option) =>
            {
                // Password Settings
                option.Password.RequireDigit = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;

                //Lockout settings
                option.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(10);
                option.Lockout.MaxFailedAccessAttempts = 7;
                option.Lockout.AllowedForNewUsers = true;
            });



            return services;
        }
    }
}
