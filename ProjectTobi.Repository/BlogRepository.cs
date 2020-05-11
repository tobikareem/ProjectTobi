

using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;

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
            throw new System.NotImplementedException();
        }

        public Blog GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Blog> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
