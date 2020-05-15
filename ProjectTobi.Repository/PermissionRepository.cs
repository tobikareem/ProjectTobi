using ProjectTobi.Interface.Repository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using System.Linq;

namespace ProjectTobi.Repository
{
    public class PermissionRepository : ICrudRepository<Permission>
    {
        private readonly ProjectContext context;
        public PermissionRepository(ProjectContext context)
        {
            this.context = context;
        }
        public void Add(Permission obj)
        {
            context.Permissions.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, Permission obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            GetById(id).ModifiedDate = System.DateTime.UtcNow;
            context.SaveChanges();
        }

        public Permission GetById(int id)
            => context.Permissions.Find(id);
        

        public IEnumerable<Permission> GetAll()
            => context.Permissions.ToList();
        

        public void Delete(int id)
        {
            var permission = GetById(id);
            context.Permissions.Remove(permission);
            context.SaveChanges();
        }
    }
}
