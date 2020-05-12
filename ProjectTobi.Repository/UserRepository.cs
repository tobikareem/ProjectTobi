using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;
using ProjectTobi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ProjectTobi.Repository
{
    public class UserRepository : ICrudRepository<User>
    {
        private readonly ProjectContext context;

        public UserRepository(ProjectContext context)
        {
            this.context = context;
        }
        public void Add(User obj)
        {
            context.Users.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, User obj)
        {
            var user = GetById(id);
            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.Email = obj.Email;
            user.PhoneNumber = obj.PhoneNumber;
            user.ModifiedBy = obj.FirstName;

            context.SaveChanges();
        }

        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
