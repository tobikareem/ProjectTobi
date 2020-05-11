                                                   
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;
using ProjectTobi.Repository;

namespace ProjectTobi.Base
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Repositories
            services.AddSingleton<ICrudRepository<User>, UserRepository>();
            services.AddSingleton<ICrudRepository<Blog>, BlogRepository>();
            services.AddSingleton<ICrudRepository<Permission>, PermissionRepository>();
            services.AddSingleton<ICrudRepository<Image>, ImageRepository>();
            services.AddSingleton<ICrudRepository<Category>, CategoryRepository>();
            services.AddSingleton<ICrudRepository<Comment>, CommentRepository>();

            //DB Context
            services.AddDbContext<ProjectContext>(options =>
            {
                var getConfig = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(getConfig, providerOption => providerOption.EnableRetryOnFailure(3));
            });
            return services;
        }
    }
}
