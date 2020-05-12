using ProjectTobi.Interface.Repository;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using System.Linq;

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
            using var context = services.GetService<ProjectContext>();
            var permission = GetById(id);
            permission.PermissionName = obj.PermissionName;
            context.SaveChanges();

        }

        public Permission GetById(int id)
        {
            using var context = services.GetService<ProjectContext>();
            return context.Permissions.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Permission> GetAll()
        {
            using var context = services.GetService<ProjectContext>();
            return context.Permissions.ToList();
        }

        public void Delete(int id)
        {
            using var context = services.GetService<ProjectContext>();
            var permission = GetById(id);
            context.Permissions.Remove(permission);
            context.SaveChanges();
        }
    }
}
