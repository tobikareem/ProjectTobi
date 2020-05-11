using ProjectTobi.Interface.Repository;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;

namespace ProjectTobi.Repository
{
    public class PermissionRepository : ICrudRepository<Permission>
    {
        private readonly IServiceProvider services;
        public PermissionRepository(IServiceProvider services)
        {
            this.services = services;
        }
        public void Add(Permission obj)
        {
            using var context = services.GetService<ProjectContext>();
            context.Permissions.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, Permission obj)
        {
            throw new NotImplementedException();
        }

        public Permission GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Permission> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
