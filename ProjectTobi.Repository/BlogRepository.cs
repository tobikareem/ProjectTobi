

using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;
using System.Linq;

namespace ProjectTobi.Repository
{
    public class BlogRepository : ICrudRepository<Blog>
    {
        private readonly IServiceProvider services;

        public BlogRepository(IServiceProvider services)
        {
            this.services = services;
        }
        public void Add(Blog obj)
        {
            using var context = services.GetService<ProjectContext>();
            context.Blogs.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, Blog obj)
        {
            using var context = services.GetService<ProjectContext>();
            var blog = GetById(id);
            blog = obj;
            context.SaveChanges();
        }

        public Blog GetById(int id)
        {
            using var context = services.GetService<ProjectContext>();
            return context.Blogs.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Blog> GetAll()
        {
            using var context = services.GetService<ProjectContext>();
            return context.Blogs.ToList();
        }

        public void Delete(int id)
        {
            using var context = services.GetService<ProjectContext>();
            var blog = GetById(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
        }
    }
}
