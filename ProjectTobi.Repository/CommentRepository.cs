using ProjectTobi.Interface.Repository;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using System.Linq;

namespace ProjectTobi.Repository
{
    public class CommentRepository : ICrudRepository<Comment>
    {
        private readonly IServiceProvider services;

        public CommentRepository(IServiceProvider services)
        {
            this.services = services;
        }
        public void Add(Comment obj)
        {
            using var context = services.GetService<ProjectContext>();
            context.Comments.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, Comment obj)
        {
            using var context = services.GetService<ProjectContext>();
            var comment = GetById(id);
            comment = obj;
            context.SaveChanges();
        }

        public Comment GetById(int id)
        {
            using var context = services.GetService<ProjectContext>();
            return context.Comments.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Comment> GetAll()
        {
            using var context = services.GetService<ProjectContext>();
            return context.Comments.ToList();
        }

        public void Delete(int id)
        {
            using var context = services.GetService<ProjectContext>();
            var comment = GetById(id);
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
    }
}
