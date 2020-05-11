using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;

namespace ProjectTobi.Repository
{
    public class UserRepository: ICrudRepository<User>
    {
        private readonly IServiceProvider services;

        public UserRepository(IServiceProvider services)
        {
            this.services = services;
        }
        public void Add(User obj)
        {
            using var context = services.GetService<ProjectContext>();
            context.Users.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, User obj)
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
