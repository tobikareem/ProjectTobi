using Microsoft.EntityFrameworkCore;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;
using ProjectTobi.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTobi.Repository
{
    public class ApplicationUserRepository : ICrudRepository<ApplicationUser>
    {
        private readonly ProjectContext context;

        public ApplicationUserRepository(ProjectContext context)
        {
            this.context = context;
        }
        public void Add(ApplicationUser obj)
        {
            context.ApplicationUsers.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, ApplicationUser obj)
        {          
                context.Entry(obj).State = EntityState.Modified;
                GetById(id).ModifiedDate = System.DateTime.UtcNow;
                context.SaveChanges();
        }

        public ApplicationUser GetById(int id)
            => context.ApplicationUsers.Find(id);

        public IEnumerable<ApplicationUser> GetAll()
            => context.ApplicationUsers.ToList();

        public void Delete(int id)
        {
            var user = GetById(id);
            context.ApplicationUsers.Remove(user);
            context.SaveChanges();
        }
    }
}
