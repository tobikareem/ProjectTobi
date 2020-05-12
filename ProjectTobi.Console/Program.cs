using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Interface.Repository;
using ProjectTobi.Interface.Service;
using ProjectTobi.Model;
using ProjectTobi.Repository;
using ProjectTobi.Service;
using System;

namespace ProjectTobi.ConsoleApp
{
    class Program
    {
        private static IServiceProvider serviceProvider;
        static void Main(string[] args)
        {
            RegisterService();
            AddUser u = new AddUser().MainUserAdd(serviceProvider);
        }

        private static void RegisterService()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IUserService, UserService>();
            collection.AddSingleton <ICrudRepository<User>, UserRepository>();

            serviceProvider = collection.BuildServiceProvider();

        }
    }
}
