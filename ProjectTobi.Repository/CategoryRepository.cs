using ProjectTobi.Interface.Repository;
using System;
using System.Collections.Generic;
using ProjectTobi.Model;
using ProjectTobi.Entity.DbContext;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectTobi.Repository
{
    public class CategoryRepository : ICrudRepository<Category>
    {
        private readonly ProjectContext context;

        public CategoryRepository(ProjectContext context)
        {
            this.context = context;
        }
        public void Add(Category obj)
        {
            context.Categories.Add(obj);
            context.SaveChanges();
        }

        public void Update(int id, Category obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            GetById(id).ModifiedDate = DateTime.UtcNow;
            context.SaveChanges();
        }

        public Category GetById(int id)
            => context.Categories.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Category> GetAll()
            => context.Categories.ToList();

        public void Delete(int id)
        {
            var cate = GetById(id);
            context.Categories.Remove(cate);
            context.SaveChanges();
        }
    }
}
