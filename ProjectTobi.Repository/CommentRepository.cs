using ProjectTobi.Interface.Repository;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;

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
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
