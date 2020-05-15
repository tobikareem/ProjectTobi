using System;
using System.Collections.Generic;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using ProjectTobi.Interface.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectTobi.Repository
{
    public class BlogRepository : ICrudRepository<Blog>
    {
        private readonly ProjectContext context;

        public BlogRepository(ProjectContext context)
        {
            this.context = context;
        }
        public void Add(Blog obj)
        {
            context.Blogs.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, Blog obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            GetById(id).ModifiedDate = DateTime.UtcNow;
            context.SaveChanges();
        }

        public Blog GetById(int id)
            => context.Blogs.Find(id);

        public IEnumerable<Blog> GetAll()
            => context.Blogs.ToList();

        public void Delete(int id)
        {
            var blog = GetById(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
        }
    }
}
