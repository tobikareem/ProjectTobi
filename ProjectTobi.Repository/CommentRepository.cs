using ProjectTobi.Interface.Repository;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using System.Linq;

namespace ProjectTobi.Repository
{
    public class CommentRepository : ICrudRepository<Comment>
    {
        private readonly ProjectContext context;

        public CommentRepository(ProjectContext context)
        {
            this.context = context;
        }
        public void Add(Comment obj)
        {
            context.Comments.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, Comment obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            GetById(id).ModifiedDate = DateTime.UtcNow;
            context.SaveChanges();
        }

        public Comment GetById(int id)
            => context.Comments.Find(id);

        public IEnumerable<Comment> GetAll()
            => context.Comments.ToList();

        public void Delete(int id)
        {
            var comment = GetById(id);
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
    }
}
