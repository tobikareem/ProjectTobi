using Microsoft.Extensions.Options;
using ProjectTobi.Interface.Repository;
using ProjectTobi.Interface.Service;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using ProjectTobi.Model;
using ProjectTobi.Repository;
using ProjectTobi.Entity.DbContext;
using System.Runtime.CompilerServices;

namespace ProjectTobi.ConsoleApp
{
    class AddUser
    {
        private readonly ICrudRepository<User> crudRepository;

        public AddUser(ICrudRepository<User> crudRepository)
        {
            this.crudRepository = crudRepository;
        }
        public void MainUserAdd(IServiceProvider service)
        {
            var user = new User
            {
                LastName = "Ajayi",
                FirstName = "Dotun",
                Email = "dot@yahoo.com"
            };

            crudRepository.Add(user);
        }

    }
}
