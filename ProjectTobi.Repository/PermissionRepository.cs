using ProjectTobi.Interface.Repository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using System.Linq;

namespace ProjectTobi.Repository
{
    public class PermissionRepository : ICrudRepository<ApplicationRole>
    {
        private readonly ProjectContext context;
        public PermissionRepository(ProjectContext context)
        {
            this.context = context;
        }
        public void Add(ApplicationRole obj)
        {
            context.ApplicationRoles.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, ApplicationRole obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            GetById(id).ModifiedDate = System.DateTime.UtcNow;
            context.SaveChanges();
        }

        public ApplicationRole GetById(int id)
            => context.ApplicationRoles.Find(id);
        

        public IEnumerable<ApplicationRole> GetAll()
            => context.ApplicationRoles.ToList();
        

        public void Delete(int id)
        {
            var permission = GetById(id);
            context.ApplicationRoles.Remove(permission);
            context.SaveChanges();
        }
    }
}
